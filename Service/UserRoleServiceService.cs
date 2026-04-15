using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DatabaseContext;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Service;

public class UserRoleServiceService : IUsersRolesService
{
    private readonly ContextDb _context;
    
    public UserRoleServiceService (ContextDb context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = await _context.Users
            .Include(u => u.Role)
            .Select(u => new
            {
                u.UserID,
                u.UserName,
                u.Mail,
                u.Password,
                Role = u.Role.RoleName
            })
            .ToListAsync();
        
        return new OkObjectResult(new
        {
            data = new
            {
                users = users
            },
            status = true
        });
    }
    
    public async Task<IActionResult> PostUserAsync(CreateNewUser newUser)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "User");
        var action = newUser.Action;

        if (action == null)
        {
            return new BadRequestObjectResult(new
            {
                status = false,
            });
        }
        if (action == "Register")
        {
            if (await _context.Users.AnyAsync(u => u.Mail == newUser.Mail))
            {
                return new BadRequestObjectResult(new
                {
                    status = false
                });
            }
            
            var user = new User()
            {
                UserName = newUser.UserName,
                Role_ID = role.RoleID,
                Mail = newUser.Mail,
                Password = newUser.Password
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return new OkObjectResult(new
            {
                status = true,
            });
        }
        if (action == "Login")
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Mail == newUser.Mail && u.Password == newUser.Password);
            string roleName = user.Role.RoleName;
            if (user != null)
            {
                return new OkObjectResult(new
                {
                    status = true,
                    role = roleName
                });
            }
        }

        return new BadRequestObjectResult(new
        {
            status = false
        });
    }

    public async Task<IActionResult> PatchUserAsync(UpdateUser updateUser)
    {
        if (updateUser != null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == updateUser.UserID);
            if (await _context.Users.AnyAsync(u => u.Mail == updateUser.Mail && u.UserID != updateUser.UserID))
            {
                return new BadRequestObjectResult(new
                {
                    status = false
                });
            }

            user.UserName = updateUser.UserName;
            user.Mail = updateUser.Mail;
            user.Password = updateUser.Password;
            
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                status = true,
            });
        }
        return new BadRequestObjectResult(new
        {
            status = false
        });
    }
        public async Task<IActionResult> DeleteUserAsync()
        {
        return new BadRequestObjectResult(new
        {
            status = false
        });
    }
}