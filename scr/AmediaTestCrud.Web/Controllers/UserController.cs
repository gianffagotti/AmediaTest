using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Domain.Entities;
using AmediaTestCrud.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmediaTestCrud.Web.Controllers;

public class UserController : Controller
{
    #region Atributos
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UserController(IUserService userService, IRoleService roleService)
        => (_userService, _roleService) = (userService, roleService);
    #endregion

    #region Buscador
    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetAll();
        var usersModel = users.Select(u => new UserViewModel()
        {
            UserId = u.Id,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Role = u.Role.Description,
            Active = u.IsActive()
        }).ToList(); // Habría que usar automapper

        return View(usersModel);
    }
    #endregion

    #region Consultar
    public async Task<IActionResult> Details(int? id)
    {
        var user = await _userService.GetById(id.Value);
        if (user is null)
            return NotFound();

        var model = new UserViewModel()
        {
            UserId = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Document = user.Document,
            RoleId = user.RoleId,
            Role = user.Role.Description,
            Active = user.IsActive(),
        };
        return View(model);
    }
    #endregion

    #region Nuevo
    public async Task<IActionResult> Create()
    {
        ViewData["Roles"] = new SelectList(await _roleService.GetForSelect(), "Id", "Description");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UserViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var user = new User(model.UserName, model.Password, model.FirstName, model.LastName, model.Document, model.RoleId, 1); //Automapper

                await _userService.Create(user);

                return RedirectToAction("Index");
            }
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        ViewData["Roles"] = new SelectList(await _roleService.GetForSelect(), "Id", "Description", model.RoleId);
        return View();
    }
    #endregion

    #region Modificar
    public async Task<IActionResult> Edit(int? id)
    {
        ViewData["Roles"] = new SelectList(await _roleService.GetForSelect(), "Id", "Description");
        var user = await _userService.GetById(id.Value);
        var model = new UserViewModel()
        {
            UserId = user.Id,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Document = user.Document,
            RoleId = user.RoleId,
            Active = user.IsActive(),
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UserViewModel model)
    {

        try
        {
            var user = await _userService.GetById(model.UserId);
            user.Update(model.UserName, model.FirstName, model.LastName, model.Document, model.RoleId, model.Active ? 1 : 0); //Automapper

            await _userService.Update(user);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        ViewData["Roles"] = new SelectList(await _roleService.GetForSelect(), "Id", "Description");
        return View(model);
    }
    #endregion

    #region Eliminar
    public async Task<IActionResult> Delete(int? id)
    {
        ViewData["Roles"] = new SelectList(await _roleService.GetForSelect(), "Id", "Description");
        var user = await _userService.GetById(id.Value);
        var model = new UserViewModel()
        {
            UserId = user.Id,
            UserName = user.UserName,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Document = user.Document,
            RoleId = user.RoleId,
            Active = user.IsActive(),
        };
        return View(model);
    }
    #endregion
}
