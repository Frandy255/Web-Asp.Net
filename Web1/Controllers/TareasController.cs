using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Mono.TextTemplating;
using System.Data;
using System.Security.Claims;
using Web1.Data;
using Web1.Models;

namespace Web1.Controllers
{
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext context;
        public TareasController(ApplicationDbContext contxt) 
        {
            context = contxt;
        }

        public async Task<IActionResult> VerTareas()
        {
            var tareas = await context.tareaModels.ToListAsync();
            return View(tareas);
        }

        [HttpGet]
        public IActionResult CrearTareas()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CrearTarea(TareaModel tma)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    string nombre = tma.Name;
                    string descrip = tma.Description;
                    string estado = tma.Status;
                    string prior = tma.Priority;
                    DateTime inicio = Convert.ToDateTime(tma.DateStart.ToString("dd-MM-yyyy HH:mm:ss")); /*Convert.ToDateTime(tma.DateStart.ToString("yyyy-MM-dd HH:mm:ss"))*/;
                    DateTime fin = Convert.ToDateTime(tma.DateEnd.ToString("dd-MM-yyyy HH:mm:ss"));
                    string usuarioId = "E71C60E5-D581-4A2C-8764-A890F023FCBA";

                    var resul = new SqlParameter
                    {

                        ParameterName = "@result",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output

                    };


                    await context.Database.ExecuteSqlRawAsync(
                        "EXEC pa_AgregarTareas @nombre, @descripcion, @estado, @prioridad, @inicio, @fin, @idUsuario, @result OUTPUT", new[]
                        {
                            new SqlParameter("@nombre", nombre ?? (object)DBNull.Value),
                            new SqlParameter("@descripcion", descrip ?? (object)DBNull.Value),
                            new SqlParameter("@estado", estado ?? (object)DBNull.Value),            // e.g. "Por hacer"
                            new SqlParameter("@prioridad", prior ?? (object)DBNull.Value),      // e.g. "Baja"
                            new SqlParameter("@inicio", inicio), // DateTime directamente
                            new SqlParameter("@fin", fin),       // DateTime directamente
                            new SqlParameter("@idUsuario", usuarioId ?? (object)DBNull.Value),
                            resul
                        }
                        
                    );

                    ViewBag.Correcto = "El registro fue cargado";
                    return RedirectToAction(nameof(VerTareas));

                }
                else
                {
                    Console.WriteLine("else");

                    ViewBag.Error = "No se han podido cargar los datos";
                    return View("CrearTareas", tma);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                ViewBag.Error = "No se han podido cargar los datos";
                return View("CrearTareas", tma);

            }

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
            var registroViejo = await context.tareaModels.FindAsync(tma.Id);

            if (registroViejo == null)
            {
                return NotFound();
            }
            else
            {
                string nam = tma.Name;
                string sta = tma.Status;
                string pri = tma.Priority;
                string des = tma.Description;
                DateTime start = tma.DateStart;
                DateTime end = tma.DateEnd;

                int respuesta = await context.Database.ExecuteSqlRawAsync(

                    );
                
                return View();
            }
        }
    }
}
