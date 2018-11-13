using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Repositories
{
    public interface IPaisRepository : IRepositoryBase<Pais>
    {
        IEnumerable<Pais> GetAtivos();
    }
}
