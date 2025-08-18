using Microsoft.AspNetCore.Mvc;

namespace Web1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult IndexLogin()
        {
            return View();
        }
    }
}
