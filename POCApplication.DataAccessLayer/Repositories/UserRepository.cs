using POCApplication.DataAccessLayer.DataContext;
using POCApplication.DataAccessLayer.Entities;
using POCApplication.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCApplication.DataAccessLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _aspNetCoreNTierDbContext;
        public UserRepository(ApplicationDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
        {
            _aspNetCoreNTierDbContext = aspNetCoreNTierDbContext;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _ = _aspNetCoreNTierDbContext.Update(user);

            _aspNetCoreNTierDbContext.Entry(user).Property(x => x.Password).IsModified = false;

            await _aspNetCoreNTierDbContext.SaveChangesAsync();
            return user;
        }
    }
}
