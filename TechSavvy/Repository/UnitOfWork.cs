using Microsoft.AspNetCore.Identity;
using TechSavvy.Core.Repositories;

namespace TechSavvy.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; set; }
        public IRoleRepository Role { get; set; }
        public UnitOfWork(IUserRepository user, IRoleRepository role) 
        {

            User = user;
            Role = role;
        
        
        }

    }
}
