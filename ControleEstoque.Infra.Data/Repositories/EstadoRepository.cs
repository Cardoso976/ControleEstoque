using System.Collections.Generic;
using System.Linq;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class EstadoRepository : RepositoryBase<Estado>, IEstadoRepository
    {
        public IEnumerable<Estado> GetEstadosByPais(int paisId)
        {
            return Db.Set<Estado>().Where(x => x.PaisId == paisId).ToList();
        }
    }
}
