using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface ICidadeService : IServiceBase<Cidade>
    {
        IEnumerable<Cidade> GetCidadesByEstado(int estadoId);
    }
}
