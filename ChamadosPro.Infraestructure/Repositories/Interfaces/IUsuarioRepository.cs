using ChamadosPro.Model.Entities;

namespace ChamadosPro.Infraestructure.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuarios>
    {
        Task<Usuarios?> GetByName(string name);
    }
}
