using POCApplication.DataAccessLayer.Entities;

namespace POCApplication.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UpdateUserAsync(User user);
    }
}
