using Microsoft.AspNetCore.Mvc;
using Web1.Interfaces;
using Web1.Models;

namespace Web1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuario InUsua;
        public IActionResult IndexLogin()
        {
            return View();
        }

        public Task<RedirectToActionResult> Acceso(UsuarioModels usum)
        {
            var usario = InUsua.AccesoAsy(usum);

            if (usario != null)
            {
                RedirectToAction(nameof(IndexLogin));

            }
            else
            {
                TempData["Error"] = "El usuario no ha sido encontrado";
                RedirectToAction(nameof(IndexLogin));
            }
            RedirectToAction();
        }
    }
}
