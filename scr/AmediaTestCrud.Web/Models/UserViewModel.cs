using System.ComponentModel.DataAnnotations;

namespace AmediaTestCrud.Web.Models;

public class UserViewModel
{
    [Required]
    [Display(Name = "Usuario")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Constraseña")]
    public string Password { get; set; }
}
