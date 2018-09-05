using System.Collections.Generic;
using System.Linq;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorDescricao(string descricao)
        {
            return Db.Produtos.Where(p => p.Descricao == descricao);
        }
    }
}
