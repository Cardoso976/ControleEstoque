using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Repositories
{
    public interface ICidadeRepository : IRepositoryBase<Cidade>
    {
        IEnumerable<Cidade> GetCidadesByEstado(int estadoId);
    }
}
