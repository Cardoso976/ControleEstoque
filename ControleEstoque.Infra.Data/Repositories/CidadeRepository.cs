using System.Collections.Generic;
using System.Linq;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        public IEnumerable<Cidade> GetCidadesByEstado(int estadoId)
        {
            return Db.Set<Cidade>().Where(x => x.EstadoId == estadoId).ToList();
        }
    }
}
