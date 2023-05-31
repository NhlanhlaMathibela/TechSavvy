using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Mail;
using System.Text;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Core.Repositories;
using TechSavvy.Data;
using TechSavvy.Models;
using TechSavvy.ViewModels;

namespace TechSavvy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<TechSavvyUser> _signInManager;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserStore<TechSavvyUser> _userStore;
        private readonly IUserEmailStore<TechSavvyUser> _emailStore;
        private readonly UserManager<TechSavvyUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly TechSavvyContext _dbContext;



        public UserController(IUnitOfWork unitOfWork, 
            SignInManager<TechSavvyUser> signInManager,
            IRoleRepository roleRepository, 
            IUserStore<TechSavvyUser> userStore,
            UserManager<TechSavvyUser> userManager,
            IUserRepository userRepository,
            IEmailSender emailSender,
            TechSavvyContext dbContext
            ) 
        { 
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _emailStore = GetEmailStore();
            _userStore = userStore;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await _userRepository.GetUsers());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userRepository.GetUser(id);
            var roles = await _roleRepository.GetRoles();
            if (user == null) return NotFound();

            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);
            var rolesItems = roles.Select(r => new SelectListItem(r.Name, r.Id, userRoles.Any(s => s.Contains(r.Name)))).ToList();

            var res = new EditUserViewModel
            {

                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                Surname = user.Surname,
                Roles = rolesItems,
            };
            return View(res);
        }

        [HttpGet]

        private async Task<EditUserViewModel> LoadView(string id)
        {
            var user = await _userRepository.GetUser(id);
            var roles = await _roleRepository.GetRoles();
            if (user == null) return new EditUserViewModel();

            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);
            var rolesItems = roles.Select(r => new SelectListItem(r.Name, r.Id, userRoles.Any(s => s.Contains(r.Name)))).ToList();

            return new EditUserViewModel
            {
                FirstName = user.FirstName,
                Surname = user.Surname,
                Email = user.Email,
                Id = user.Id,
                Roles = rolesItems,
            };

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            var rolesCount = model.Roles.Count(s => s.Selected);

            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.Surname) | string.IsNullOrEmpty(model.Email) || rolesCount < 1)
            {
                if (rolesCount < 1)
                {
                    ViewBag.Message = "Please select at least one role!";
                }
                return View(model);
            }
            var user = await _userRepository.GetUser(model.Id);
            if(user == null) return NotFound();


            user.FirstName = model.FirstName;
            user.Surname = model.Surname;
            user.Email = model.Email;

            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            foreach(var role in model.Roles)
            {
                var assignedRole = userRoles.FirstOrDefault(s => s == role.Text);
                if (role.Selected && assignedRole == null)
                    await _signInManager.UserManager.AddToRoleAsync(user, role.Text);
                else if (assignedRole != null && !role.Selected)
                    await _signInManager.UserManager.RemoveFromRoleAsync(user, role.Text);
            }

            var updateUser = await _userRepository.UpdateUser(user);

            return RedirectToAction("Index", "User", new { area = ""});
        }

       private async Task<EditUserViewModel> LoadView()
        {
            var roles = await _roleRepository.GetRoles();
            var roleItems = roles.Select(r => new SelectListItem(r.Name, r.Id, false)).ToList();

            return new EditUserViewModel 
            { 
                Roles = roleItems, 
            };
        }
        

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            
            return View(await LoadView());
        }
       
        [HttpPost]
        public async Task<IActionResult> AddUser(EditUserViewModel model)
        {
            var rolesCount = model.Roles.Count(s => s.Selected);

            if(string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.Surname) | string.IsNullOrEmpty(model.Email) || rolesCount < 1)
            {
                if(rolesCount < 1)
                {
                    ViewBag.Message = "Please select at least one role!";
                }
                return View(model);
            }
            var user = CreateUser();

            user.FirstName = model.FirstName;
            user.Surname = model.Surname;
            user.Email = model.Email;

           string returnUrl= Url.Content("~/");

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, model.Email,CancellationToken.None);
            var result = await _userManager.CreateAsync(user, "Password@01");
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/User/ConfirmEmail",
                pageHandler: null,
                values: new { /*area = "Identity", */UserId = userId, token = code, returnUrl = returnUrl },
                protocol: Request.Scheme);

          //  await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
          //$"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
            SendEmail(user.Email, callbackUrl);
            if (result.Succeeded)
            {
                foreach(var role in model.Roles)
                {
                    if (role.Selected)
                    {
                        await _signInManager.UserManager.AddToRoleAsync(user, role.Text);
                    }
                }
                return RedirectToAction("Index", "User", new {area = ""});
            }

            return View(model);
        }
        [AllowAnonymous]
        public void SendEmail(string To, string confirmationLink)
        {

            string Subject = "Email Confimation";
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Please Confirm your email</p1>" + "<hr/>" + "<a href=" + confirmationLink + ">Click here: Confirm</a>";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("eprescription@gmail.com.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("noreplay.eprescription@gmail.com.com", "rfqjhujrdlktdtka");
            smtp.SendMailAsync(Mail);

        }
  
        [AcceptVerbs("Get", "Post")]

        public async Task<IActionResult> ConfirmEmail(string UserId, string token)
        {
            if (UserId == null || token == null)
            {
                TempData["Error"] = "Something Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");

            }
            var Find_Use = await _userManager.FindByIdAsync(UserId);
            if (Find_Use == null)
            {
                TempData["Error"] = "Something Went Wrong Please Try Again";
                return RedirectToAction("Error", "User");
            }
            var Confirm_Email = await _userManager.ConfirmEmailAsync(Find_Use, token);
            if (Confirm_Email.Succeeded)
            {
                await _signInManager.SignInAsync(Find_Use, isPersistent: true);

                await _signInManager.SignOutAsync();
                TempData["Succeeded"] = "Your Email Was Confirm Succesfull";
                return RedirectToAction("Succeeded", "User");
            }
            else
            {
                TempData["Error"] = "Somthing Went Wrong Please Try Again";
                return RedirectToAction("Error", "Account");
            }

        }
        [HttpGet]
    
        public IActionResult Succeeded()
        {
            if (TempData["Succeeded"] != null)
            {
                ViewBag.success = TempData["Succeeded"];
                TempData.Clear();
            }
            return View();
        }
        [HttpGet]
       
        public IActionResult AccessDenied()
        {
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData.Clear();
            }
            return View();
        }

        [HttpGet]
     
        public IActionResult Error()
        {
            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
                TempData.Clear();
            }
            return View();
        }
        public void GeneratePassword(string To, string confirmationLink)
        {

            string Subject = "Email Confimation";
            MailMessage Mail = new MailMessage();
            Mail.To.Add(To);
            Mail.Subject = Subject;
            Mail.Body = "<p1>Please Confirm your email</p1>" + "<hr/>" + "<a href=" + confirmationLink + ">Click here: Confirm</a>";
            Mail.IsBodyHtml = true;
            Mail.From = new MailAddress("TechSavvyOnlineStore@gmail.com");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("noreplay.TechSavvyOnlineStore@gmail.com", "rfqjhujrdlktdtka");
            smtp.SendMailAsync(Mail);

        }
        private TechSavvyUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<TechSavvyUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(TechSavvyUser)}'. " +
                    $"Ensure that '{nameof(TechSavvyUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
        
        private IUserEmailStore<TechSavvyUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<TechSavvyUser>)_userStore;
        }
    }
}
