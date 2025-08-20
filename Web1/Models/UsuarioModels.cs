using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Web1.Models
{
    public class UsuarioModels : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public UsuarioModels()
        {

        }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(30, ErrorMessage = "{0} debe tener al menos {2} caracteres ")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage ="rellene este campo")]
        [StringLength(30,ErrorMessage = "{0} debe tener al menos {2} caracteres ")]
        public string Password { get; set; }

        [Display(Name ="Recordarme")]
        public bool Remember { get; set; }
    }
}
