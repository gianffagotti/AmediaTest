using System.ComponentModel.DataAnnotations;

namespace AmediaTestCrud.Web.Models;

public class ChangePasswordViewModel
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "La contraseña anterior es requerida")]
    [Display(Name = "Constraseña Anterior")]
    public string OldPassword { get; set; }

    [Required(ErrorMessage = "La contraseña nueva es requerida")]
    [Display(Name = "Constraseña Nueva")]
    public string NewPassword { get; set; }
}
