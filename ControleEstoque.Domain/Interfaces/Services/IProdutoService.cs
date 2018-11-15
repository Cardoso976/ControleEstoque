using ControleEstoque.Domain.Entities;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        string RecuperarImagemPeloId(int id);
        IEnumerable<Produto> RecuperarProdutosAtivos();
    }
}
