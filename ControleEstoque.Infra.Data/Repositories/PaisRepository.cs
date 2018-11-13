using System.Collections.Generic;
using System.Linq;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class PaisRepository : RepositoryBase<Pais>, IPaisRepository
    {
        public IEnumerable<Pais> GetAtivos()
        {
            return Db.Set<Pais>().Where(x => x.Ativo).ToList();
        }
    }
}
