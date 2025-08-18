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


                if (inicio <= fin)
                {
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
                    ;

                }
                else
                {
                    result = 0;
                }
            }      
            catch (Exception ex)
            {
                result = 0;
                throw new Exception($"Ha ocurrido un error: {ex.ToString()}");
            }
            return result;
        }

        public async Task<List<TareaModel>> VerTareasAsy()
        {
            List<TareaModel> listTma = new List<TareaModel>();

            listTma = await context.tareaModels.ToListAsync();
            return listTma;
        }

        public async Task<int> ActualizarTareasAsy(TareaModel tma)
        {
            int respuesta = 0;
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

                respuesta = await context.Database.ExecuteSqlRawAsync(
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

            }
            catch (Exception ex)
            {
                respuesta = 0;
                throw new Exception($"Algo ha salido mal: {ex.ToString()}");
            }
            return respuesta;

        }

        public async Task<TareaModel> VerTareaAsy(TareaModel tma)
        {
            TareaModel tareaEditar = new TareaModel();

            tareaEditar = await context.tareaModels.FindAsync(tma.Id);

            return tareaEditar;

        }

        public async Task<int> EliminarTareasAsy(TareaModel tma)
        {
            int respuesta = 0;
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

                 respuesta = await context.Database.ExecuteSqlRawAsync(
                   "exec pa_EliminarTareas @id, @idUser, @result output", new[]
                   {
                           new SqlParameter("@id", id),
                           new SqlParameter("@idUser", idUser),
                           res
                   }
               );
            }
            catch (Exception ex)
            {
                respuesta = 0;
                throw new Exception(ex.ToString());
            }

            return respuesta;


        }

    }
}
