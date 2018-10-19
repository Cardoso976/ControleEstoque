using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Application.Interface
{
    public interface IEstadoAppService : IAppServiceBase<Estado>
    {
        IEnumerable<Estado> GetEstadosByPais(int paisId);
    }
}
