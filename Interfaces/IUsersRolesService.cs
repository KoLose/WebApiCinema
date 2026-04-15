using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Requests;

namespace WebAPI.Interfaces;

public interface IUsersRolesService
{
    Task<IActionResult> GetAllUsersAsync();
    Task<IActionResult> PostUserAsync(CreateNewUser newUser);
    Task<IActionResult> PatchUserAsync(UpdateUser updateUser);
    Task<IActionResult> DeleteUserAsync();
}