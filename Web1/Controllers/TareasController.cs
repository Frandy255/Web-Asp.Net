using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Web1.Data;
using Web1.Interfaces;
using Web1.Models;
using Web1.Repositorios;

namespace Web1.Controllers
{
    public class TareasController : Controller
    {
        private readonly ITareas inTareas;
        public TareasController(ITareas itr) 
        {
            inTareas = itr;
        }

        public void mostrarMensaje(int res)
        {
            if (res == 0)
            {
                TempData["Message"] = "No se han podido cargar los datos";
            }
            else if (res == 1)
            {
                TempData["Message"] = "Los datos han sido modificados/cargados correctamente";
            }
        }

        public async Task<IActionResult> VerTareas()
        {
            List<TareaModel> lista = new List<TareaModel>();
            
            var listado = await inTareas.VerTareasAsy();

            lista.AddRange(listado);
             
            return View(lista);
        }

        [HttpGet]
        public IActionResult CrearTareas()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CrearTarea(TareaModel tma)
        {
            int resultado = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    resultado = await inTareas.AgregarTareasAsy(tma);
                }
                else
                {
                    resultado = 0;
                    return View("CrearTareas", tma);
                }
            }
            catch (Exception ex)
            {
                resultado = 0;
                return View("CrearTareas", tma);
            }

            mostrarMensaje(resultado);
            return RedirectToAction(nameof(VerTareas));
        }
        

             


       
        public async Task<IActionResult> EditarTareas(TareaModel tma)
        {
            TareaModel registro = await inTareas.VerTareaAsy(tma);

            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarea(TareaModel tma)
        {
            int resp = await inTareas.ActualizarTareasAsy(tma);
            mostrarMensaje(resp);
            return RedirectToAction(nameof(VerTareas));
        }

        public async Task<IActionResult> EliminarTareas(TareaModel tma)
        {
            int resp = await inTareas.EliminarTareasAsy(tma);
            mostrarMensaje(resp);
            return RedirectToAction(nameof(VerTareas));

        }
    }
}
