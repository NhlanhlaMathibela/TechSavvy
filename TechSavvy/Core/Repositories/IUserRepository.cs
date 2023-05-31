using TechSavvy.Areas.Identity.Data;

namespace TechSavvy.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<TechSavvyUser>> GetUsers();
        Task<TechSavvyUser> GetUser(string id);
        Task<TechSavvyUser> UpdateUser(TechSavvyUser User);

    }
}
