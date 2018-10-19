using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Application.Interface
{
    public interface ICidadeAppService : IAppServiceBase<Cidade>
    {
        IEnumerable<Cidade> GetCidadesByEstado(int estadoId);
    }
}
