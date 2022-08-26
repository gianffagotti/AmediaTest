namespace AmediaTestCrud.Web.Models.UserContext;

public class UserContext
{
    public UserContext(int userId, string userName, UserRoles rol)
    {
        UserId = userId;
        UserName = userName;
        Rol = rol;
    }

    public int UserId { get; set; }
    public string UserName { get; set; }
    public UserRoles Rol { get; set; }
}
