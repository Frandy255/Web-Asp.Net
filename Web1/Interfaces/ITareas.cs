using Web1.Models;

namespace Web1.Interfaces
{
    public interface ITareas
    {
        Task<List<TareaModel>> RegTareasAsy();
        Task<TareaModel> RegTareasEditAsy(int idTarea);
        Task<int> AgregarTareasAsy(TareaModel tma);
        Task<int> EliminarTareasAsy(int id, string id2);
        Task<int> ActualizarTareasAsy(TareaModel tma);
    }
}
