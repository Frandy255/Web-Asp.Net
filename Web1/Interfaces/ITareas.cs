using Web1.Models;

namespace Web1.Interfaces
{
    public interface ITareas
    {
        Task<List<TareaModel>> VerTareasAsy();
        Task<TareaModel> VerTareaAsy(TareaModel tma);
        Task<int> AgregarTareasAsy(TareaModel tma);
        Task<int> EliminarTareasAsy(TareaModel tma);
        Task<int> ActualizarTareasAsy(TareaModel tma);
    }
}
