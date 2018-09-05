using System.Collections.Generic;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDescricao(string descricao);
    }
}
