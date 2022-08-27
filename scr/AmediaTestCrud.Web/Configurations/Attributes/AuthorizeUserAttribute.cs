using AmediaTestCrud.Web.Models.UserContext;
using AmediaTestCrud.Web.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AmediaTestCrud.Web.Configurations.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeUserAttribute :  Attribute, IAuthorizationFilter
{
    private readonly UserRoles _rol;
    public AuthorizeUserAttribute(UserRoles rol) 
        => _rol = rol;

    public  void OnAuthorization(AuthorizationFilterContext context)
    {
        var currentUserService = context.HttpContext.RequestServices.GetService<ICurrentUserContextService>();
        var currentUser = currentUserService.GetUser();
        if(currentUser is null || currentUser.Rol != _rol)
            context.HttpContext.Response.Redirect("PageNotFound");
    }
}
