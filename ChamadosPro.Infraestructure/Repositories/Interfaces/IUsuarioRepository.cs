using ChamadosPro.Core.Models;

namespace ChamadosPro.Infraestructure.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuarios>
    {
        Task<Usuarios?> GetByName(string name);
    }
}
