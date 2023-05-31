using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Data;

namespace TechSavvy.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<List<IdentityRole>> GetRoles();

    }
    public class RoleRepository : IRoleRepository
    {
        public TechSavvyContext _dbContext;
        public RoleRepository(TechSavvyContext dbContext)
        {
            _dbContext = dbContext;
        }


        Task<List<IdentityRole>> IRoleRepository.GetRoles()
        {
            return _dbContext.Roles.Where(s => s.Name != "Customer" && s.Name != "Admin").ToListAsync();
        }
    }
    
}
