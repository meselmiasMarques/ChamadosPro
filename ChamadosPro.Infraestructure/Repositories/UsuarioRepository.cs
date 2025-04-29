using ChamadosPro.Infraestructure.Data;
using ChamadosPro.Infraestructure.Repositories.Interfaces;
using ChamadosPro.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChamadosPro.Infraestructure.Repositories
{
    public class UsuarioRepository : Repository<Usuarios>, IUsuarioRepository
    {
        public UsuarioRepository(ChamadoProDbContext context) : base(context)
        {
        }

        public async Task<Usuarios?> GetByName(string name)
        {
          var usuario = await  _dbSet.FirstOrDefaultAsync(x => x.Nome.ToUpper().Contains(name));
          return usuario;
        }
    }
}
