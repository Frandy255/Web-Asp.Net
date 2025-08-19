using Microsoft.AspNetCore.Mvc;
using Web1.Models;

namespace Web1.Interfaces
{
    public interface IUsuario
    {

          Task<UsuarioModels> AccesoAsy(UsuarioModels us);
    }
}
