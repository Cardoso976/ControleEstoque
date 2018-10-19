using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Repositories
{
    public interface IEstadoRepository : IRepositoryBase<Estado>
    {
        IEnumerable<Estado> GetEstadosByPais(int paisId);
    }
}
