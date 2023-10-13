using Microsoft.AspNetCore.Mvc;
using POCApplication.BusinessLayer.Services.Interfaces;

namespace aspnetcore.ntier.API.Controllers.V2;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getusers")]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _userService.GetUsersAsync(cancellationToken));
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong");
        }
    }
}