using System.ComponentModel.DataAnnotations;

namespace AmediaTestCrud.Web.Models;

public class UserViewModel
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Document { get; set; }
    public int RoleId { get; set; }
    public string Role { get; set; }
    public int Active { get; set; }
}
