using Microsoft.EntityFrameworkCore;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Core.Repositories;
using TechSavvy.Data;

namespace TechSavvy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TechSavvyContext _dbContext;
        public UserRepository(TechSavvyContext dbContext) 
        { 
            _dbContext = dbContext;
        
        }

        public async Task<List<TechSavvyUser>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync(); 
        } 

        public async Task<TechSavvyUser?> GetUser(string id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
        public async Task<TechSavvyUser> UpdateUser(TechSavvyUser user)
        {
           _dbContext.Update(user);
           await _dbContext.SaveChangesAsync();
           return user;
        }
    }
}
