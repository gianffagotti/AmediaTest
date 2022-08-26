using AmediaTestCrud.Web.Controllers;
using AmediaTestCrud.Web.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AmediaTestCrud.Web.Configurations.Filters;

public class VerifySessionFilter : ActionFilterAttribute
{
    private readonly ICurrentUserContextService _currentUserContextService;

    public VerifySessionFilter(ICurrentUserContextService currentUserContextService) 
        => _currentUserContextService = currentUserContextService;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var user = _currentUserContextService.GetUser();

        if (user is null)
            if (context.Controller is not LoginController)
                context.HttpContext.Response.Redirect("Login");

        base.OnActionExecuting(context);
    }
}
