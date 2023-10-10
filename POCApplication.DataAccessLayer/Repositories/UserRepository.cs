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
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepository(ApplicationDbContext aspNetCoreNTierDbContext) : base(aspNetCoreNTierDbContext)
        {
            _applicationDbContext = aspNetCoreNTierDbContext;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _ = _applicationDbContext.Update(user);

            _applicationDbContext.Entry(user).Property(x => x.Password).IsModified = false;

            await _applicationDbContext.SaveChangesAsync();
            return user;
        }
    }
}
