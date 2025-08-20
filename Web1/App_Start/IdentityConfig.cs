using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Web1.Data;
using Web1.Models;

namespace Web1.App_Start
{
    public class ApplicationUserManager : UserManager<AplicationUser>
    {
        public ApplicationUserManager(IUserStore<AplicationUser> store) 
            : base(store)
        {

        }
      
    }
}
