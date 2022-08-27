using AmediaTestCrud.Web.Models;
using AmediaTestCrud.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AmediaTestCrud.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrentUserContextService _currentUserContextService;

        public HomeController(ICurrentUserContextService currentUserContextService) 
            => _currentUserContextService = currentUserContextService;

        public IActionResult Index()
        {
            var user = _currentUserContextService.GetUser();
            ViewBag.Usuario = user?.UserName ?? "";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("PageNotFound")]
        public IActionResult PageNotFound()
            => View();
    }
}