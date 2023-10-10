using Microsoft.AspNetCore.Mvc;
using POCApplication.BusinessLayer.Services.Interfaces;
using POCApplication.BusinessLayer.Utilities.CustomExceptions;
using POCApplication.DTO.DTOs;

namespace POCApplication.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserToLoginDTO userToLoginDTO)
    {
        try
        {
            var user = await _authService.LoginAsync(userToLoginDTO);

            return Ok(user);
        }
        catch (UserNotFoundException)
        {
            return Unauthorized();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
    {
        try
        {
            return Ok(await _authService.RegisterAsync(userToRegisterDTO));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}