using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<UserDTO> GetUserAsync(int userId, CancellationToken cancellationToken = default);
        Task<UserDTO> AddUserAsync(UserToAddDTO userToAddDTO);
        Task<UserDTO> UpdateUserAsync(UserToUpdateDTO userToUpdateDTO);
        Task DeleteUserAsync(int userId);
    }
}
