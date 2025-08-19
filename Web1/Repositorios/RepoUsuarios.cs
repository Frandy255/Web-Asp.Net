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
    public class RepoUsuarios :IUsuario
    {
        private readonly ApplicationDbContext context;
        public RepoUsuarios(ApplicationDbContext DbContext)
        {
            context = DbContext;
        }

        public async Task<UsuarioModels> AccesoAsy(UsuarioModels usuam)
        {
            UsuarioModels Usuario = await context.usuarioModels.FirstOrDefaultAsync(q => q.UserName == usuam.UserName);
            return Usuario;
        }
    }
}
