using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Application.Interface
{
    public interface IPaisAppService : IAppServiceBase<Pais>
    {
        IEnumerable<Pais> GetAtivos();
    }
}
