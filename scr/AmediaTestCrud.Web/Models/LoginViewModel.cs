using System.ComponentModel.DataAnnotations;

namespace AmediaTestCrud.Web.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "El usuario es requerido")]
    [Display(Name = "Usuario")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida")]
    [Display(Name = "Constraseña")]
    public string Password { get; set; }
}
