using Microsoft.AspNetCore.Identity;

namespace Web1.Models
{
    public class UsuarioModels:IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public UsuarioModels()
        {

        }
    }
}
