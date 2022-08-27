using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmediaTestCrud.Web.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
        => _userService = userService;

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAll();
        var usersModel = users.Select(u => new UserViewModel()
        {
            UserId = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Role = u.Role.Description,
            Active = u.Active
        }).ToList(); // Habría que usar automapper
        
        return View(usersModel);
    }
}
