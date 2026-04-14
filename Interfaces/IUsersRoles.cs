using Microsoft.AspNetCore.Mvc;
using WebAPI.Requests;

namespace WebAPI.Interfaces;

public interface IUsersRoles
{
    Task<IActionResult> GetAllUsersAsync();
    Task<IActionResult> PostUserAsync(CreateNewUser newUser);
}