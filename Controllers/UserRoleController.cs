using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Requests;

namespace WebAPI.Controllers;

public class UserRoleController : ControllerBase
{
    private readonly IUsersRolesService _usersRolesService;

    public UserRoleController(IUsersRolesService usersRolesService)
    {
        _usersRolesService = usersRolesService;
    }
    
    [HttpGet]
    [Route("GetAllUsers")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        return await _usersRolesService.GetAllUsersAsync();
    }

    [HttpPost]
    [Route("PostUserRole")]
    public async Task<IActionResult> PostUserAsync([FromBody] CreateNewUser newUser)
    {
        return await _usersRolesService.PostUserAsync(newUser);
    }

    [HttpPatch]
    [Route("PatchUserRole")]
    public async Task<IActionResult> PatchUserAsync([FromBody] UpdateUser updateUser)
    {
        return await _usersRolesService.PatchUserAsync(updateUser);
    }
    
    [HttpDelete]
    [Route("DeleteUserRole")]
    public async Task<IActionResult> DeleteUserAsync()
    {
        return await _usersRolesService.DeleteUserAsync();
    }
}
