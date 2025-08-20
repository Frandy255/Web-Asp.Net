using Microsoft.AspNetCore.Mvc;
using Web1.Interfaces;
using Web1.Models;

namespace Web1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuario InUsua;

        public IActionResult Login()
        {
            return View();
        }
    }
}
