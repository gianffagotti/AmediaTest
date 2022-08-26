using AmediaTestCrud.Application.Intefaces.Services;
using AmediaTestCrud.Web.Models;
using AmediaTestCrud.Web.Models.UserContext;
using AmediaTestCrud.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmediaTestCrud.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserContextService _currentUserContextService;

        public LoginController(IUserService userService, ICurrentUserContextService currentUserContextService)
            => (_userService, _currentUserContextService) = (userService, currentUserContextService);

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ValidateUser(model.UserName, model.Password);

                if(user is not null)
                {
                    _currentUserContextService.SetUser(new(user.Id, user.UserName, (UserRoles)user.RoleId));

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}
