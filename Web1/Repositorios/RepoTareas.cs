using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using Web1.Data;
using Web1.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Web1.Data;
using Web1.Models;

namespace Web1.Repositorios
{
    public class RepoTareas:ITareas
    {
        private readonly ApplicationDbContext context;

        public RepoTareas(ApplicationDbContext apDB)
        {
            context = apDB;
        }

        public async Task<int> AgregarTareasAsy(TareaModel tma)
        {
            int result = 0;
            try
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


                result = await context.Database.ExecuteSqlRawAsync(
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
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception($"Ha ocurrido un error: {ex.ToString()}");
            }
            return result;
        }

        public async Task<List<TareaModel>> RegTareasAsy()
        {
            List<TareaModel> listTma = new List<TareaModel>();

            listTma = await context.tareaModels.ToListAsync();
            return listTma;
        }
    }
}
