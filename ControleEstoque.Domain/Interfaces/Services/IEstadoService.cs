using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface IEstadoService : IServiceBase<Estado>
    {
        IEnumerable<Estado> GetEstadosByPais(int paisId);
    }
}
