using System.Collections;
using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface IPaisService : IServiceBase<Pais>
    {
        IEnumerable<Pais> GetAtivos();
    }
}
