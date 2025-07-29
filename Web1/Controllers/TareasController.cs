using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web1.Data;
using Web1.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Web1.Controllers
{
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext context;
        TareaModel tm = new TareaModel();
        public TareasController(ApplicationDbContext contxt) 
        {
            context = contxt;
        }

        public IActionResult VerTareas()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearTareas()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea(TareaModel tma)
        {
            if (ModelState.IsValid)
            {
             
                tma.UserId = "E71C60E5-D581-4A2C-8764-A890F023FCBA";
                context.Add(tma);

                Console.WriteLine("IF");
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(VerTareas));
            }
            else
            {
                Console.WriteLine("else");

                return View("CrearTareas", tma);
            }
        }

        
    }
}
