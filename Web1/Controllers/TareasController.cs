using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Web1.Data;
using Web1.Models;
using Web1.Repositorios;

namespace Web1.Controllers
{
    public class TareasController : Controller
    {
        private readonly RepoTareas repoTare;
        public TareasController(RepoTareas rept) 
        {
            repoTare = rept;
        }

        public async Task<IActionResult> VerTareas()
        {
            List<TareaModel> lista = new List<TareaModel>();
            
            var listado  = repoTare.RegTareasAsy();

            lista.Add(listado);
            foreach (var a in listado)
            {

            }
            return View(listado);
        }

        public void mostrarMensaje(int res)
        {
            if (res == 0)
            {
                TempData["Message"] = "No se han podido cargar los datos";
            }
            else if (res == 1)
            {
                TempData["Message"] = "Los datos han sido cargados correctamente";
            }
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
                   resultado = await repoTare.AgregarTareasAsy(tma);
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
            var registro = await context.tareaModels.FindAsync(tma.Id);

            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTarea(TareaModel tma)
        {
            
            try
            {
                var res = new SqlParameter
                {
                    ParameterName = "@salida",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output

                };
                int id = tma.Id;
                string nam = tma.Name;
                string sta = tma.Status;
                string pri = tma.Priority;
                string des = tma.Description;
                DateTime start = tma.DateStart;
                DateTime end = tma.DateEnd;
                string usser = "E71C60E5-D581-4A2C-8764-A890F023FCBA";

                int respuesta = await context.Database.ExecuteSqlRawAsync(
                    "Exec pa_EditarTareas @id, @name, @description, @status, @priority, @start, @end, @userId, @salida output", new[]
                    {
                    new SqlParameter("@id", id),
                    new SqlParameter("@name", nam),
                    new SqlParameter("@description", des),
                    new SqlParameter("@status", sta),
                    new SqlParameter("@priority", pri),
                    new SqlParameter("@start", start),
                    new SqlParameter("@end", end),
                    new SqlParameter("@userId", usser),
                    res

                    }              
                );

                Console.WriteLine($"La respuesta es: {respuesta}");

            }
            catch (Exception ex)
            {
                 
                Console.WriteLine(ex.ToString());

                throw;
            }

            return RedirectToAction(nameof(VerTareas));
            
        }

        public async Task<IActionResult> EliminarTareas(TareaModel tma)
        {
            try
            {
                int id = tma.Id;
                string idUser = "E71C60E5-D581-4A2C-8764-A890F023FCBA";

                var res = new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@result",
                    Direction = ParameterDirection.Output
                };

                int respuesta = await context.Database.ExecuteSqlRawAsync(
                   "exec pa_EliminarTareas @id, @idUser, @result output", new[]
                   {
                       new SqlParameter("@id", id),
                       new SqlParameter("@idUser", idUser),
                       res
                   }
               );
                TempData["Message"] = "Se ha eliminado correctamente";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString()); 
            }

            return RedirectToAction(nameof(VerTareas));
            
        }
    }
}
