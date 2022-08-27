using System.ComponentModel.DataAnnotations;

namespace AmediaTestCrud.Web.Models;

public class UserViewModel
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "El usuario es requerido")]
    [Display(Name = "Usuario")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "La contraseña es requerida")]
    [Display(Name = "Constraseña")]
    public string Password { get; set; }
    [Required(ErrorMessage = "El nombre es requerido")]
    [Display(Name = "Nombre")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "El apellido es requerido")]
    [Display(Name = "Apellido")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "El documento es requerido")]
    [Display(Name = "Documento")]
    public string Document { get; set; }
    [Required(ErrorMessage = "El rol es requerido")]
    [Display(Name = "Rol")]
    public int RoleId { get; set; }
    [Display(Name = "Rol")]
    public string Role { get; set; }
    [Display(Name = "Activo")]
    public bool Active { get; set; }
}
