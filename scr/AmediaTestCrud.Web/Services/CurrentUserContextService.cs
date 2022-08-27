using AmediaTestCrud.Web.Models.UserContext;
using System.Text.Json;

namespace AmediaTestCrud.Web.Services;

public interface ICurrentUserContextService
{
    UserContext GetUser();
    void SetUser(UserContext user);
    void RemoveUser();
}

public class CurrentUserContextService : ICurrentUserContextService
{
    private const string __UserKey__ = "user";

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserContextService(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    public void SetUser(UserContext user)
        => _httpContextAccessor.HttpContext.Session.SetString(__UserKey__, JsonSerializer.Serialize(user));


    public UserContext GetUser()
    {
        var userJson = _httpContextAccessor.HttpContext.Session.GetString(__UserKey__);
        if (userJson is null)
            return default;

        return JsonSerializer.Deserialize<UserContext>(userJson);
    }

    public void RemoveUser()
        => _httpContextAccessor.HttpContext.Session.Remove(__UserKey__);
}
