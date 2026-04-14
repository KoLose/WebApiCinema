using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Requests;

namespace WebAPI.Controllers;

public class UserRoleController : ControllerBase
{
    private readonly IUsersRoles _usersRoles;

    public UserRoleController(IUsersRoles usersRoles)
    {
        _usersRoles = usersRoles;
    }
    
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        return await _usersRoles.GetAllUsersAsync();
    }

    [HttpPost]
    [Route("PostUserRole")]
    public async Task<IActionResult> PostUserAsync([FromBody] CreateNewUser newUser)
    {
        return await _usersRoles.PostUserAsync(newUser);
    }
}
