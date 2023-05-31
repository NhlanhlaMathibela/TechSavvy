namespace TechSavvy.Areas.Identity.Data
{
    public class UserViewModel
    {
        public TechSavvyUser User { get; set; } = new TechSavvyUser();

        public IEnumerable<ApplicationRole>? Roles { get; set; }

    }
}
