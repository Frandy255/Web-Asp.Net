using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web1.Data;
using Web1.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Microsoft.Data.SqlClient;

namespace Web1.Controllers
{
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext context;
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

            try
            {
                if (ModelState.IsValid)
                {
                    string nombre = tma.Name;
                    string descrip = tma.Description;
                    string estado = tma.Status;
                    string prior = tma.Priority;
                    DateTime inicio = DateTime.Now /*Convert.ToDateTime(tma.DateStart.ToString("yyyy-MM-dd HH:mm:ss"))*/;
                    DateTime fin = DateTime.Now /*Convert.ToDateTime(tma.DateEnd.ToString("yyyy-MM-dd HH:mm:ss"))*/;
                    string usuarioId = "E71C60E5-D581-4A2C-8764-A890F023FCBA";

                    var parametros = new[]
                    {
                        new SqlParameter("@nombre", nombre),
                        new SqlParameter("@descripcion", descrip),
                        new SqlParameter("@estado", estado),
                        new SqlParameter("@prioridad", prior),
                        new SqlParameter("@inicio", inicio),
                        new SqlParameter("@fin", fin),
                        new SqlParameter("@idUsuario", usuarioId),
                        new SqlParameter
                        {
                            ParameterName = "@result",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = System.Data.ParameterDirection.Output
                        }


                    };

                    //Console.WriteLine(inicio.ToString());
                    //Console.WriteLine(fin.ToString());

                    await context.Database.ExecuteSqlRawAsync($"Exec pa_AgregarTareas @nombre, @descripcion, @estado,  @prioridad, @inicio, @fin, @idUsuario, @result output", parametros);

                    int res = Convert.ToInt32(parametros[7].Value);

                    Console.WriteLine(res.ToString());
                  


                    //tma.UserId = "E71C60E5-D581-4A2C-8764-A890F023FCBA";
                    //context.Add(tma);

                    //Console.WriteLine("IF");

                  //  await context.SaveChangesAsync();
                    return RedirectToAction(nameof(VerTareas));

                }
                else
                {
                    Console.WriteLine("else");

                    return View("CrearTareas", tma);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View("CrearTareas", tma);

            }

        }

        
    }
}
