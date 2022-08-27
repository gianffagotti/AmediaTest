using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Domain.Entities;
using AmediaTestCrud.Web.Models;
using AmediaTestCrud.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AmediaTestCrud.Web.Controllers;

public class UserController : Controller
{
    #region Atributos
    private readonly ICurrentUserContextService _currentUserContextService;
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    public UserController(ICurrentUserContextService currentUserContextService,
                          IUserService userService,
                          IRoleService roleService)
    {
        _currentUserContextService = currentUserContextService;
        _userService = userService;
        _roleService = roleService;
    }
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

        var model = CreateUserViewModel(user);
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
        if (user is null)
            return NotFound();

        var model = CreateUserViewModel(user);
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

    public async Task<IActionResult> EditPassword(int? id)
    {
        var user = await _userService.GetById(id.Value);
        if (user is null)
            return NotFound();

        var model = new ChangePasswordViewModel() { UserId = user.Id };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPassword(ChangePasswordViewModel model)
    {

        try
        {
            await _userService.UpdatePassword(model.UserId, model.OldPassword, model.NewPassword);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View(model);
    }
    #endregion

    #region Eliminar
    public async Task<IActionResult> Delete(int? id)
    {
        var user = await _userService.GetById(id.Value);
        if (user is null)
            return NotFound();

        var model = CreateUserViewModel(user);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(UserViewModel model)
    {

        try
        {
            var currentUser = _currentUserContextService.GetUser();
            if (currentUser.UserId == model.UserId)
                throw new Exception("No puede eliminarte a ti mismo");

            var user = await _userService.GetById(model.UserId);
            if (user is null)
                return NotFound();

            await _userService.Delete(model.UserId);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = ex.Message;
        }

        return View(model);
    }
    #endregion

    #region Automapper
    private UserViewModel CreateUserViewModel(User user)
        => new UserViewModel()
        {
            UserId = user.Id,
            UserName = user.UserName,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Document = user.Document,
            RoleId = user.RoleId,
            Role = user.Role.Description,
            Active = user.IsActive(),
        };
    #endregion
}
