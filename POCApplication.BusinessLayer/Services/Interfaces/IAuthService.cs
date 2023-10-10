using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Services.Interfaces;

public interface IAuthService
{
    Task<UserToReturnDTO> LoginAsync(UserToLoginDTO userToLoginDTO);
    Task<UserToReturnDTO> RegisterAsync(UserToRegisterDTO userToRegisterDTO);
}