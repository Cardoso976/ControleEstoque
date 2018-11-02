using System.Collections.Generic;
using System.Linq;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public string RecuperarImagemPeloId(int id)
        {
            return Db.Produtos.Where(p => p.ProdutoId == id).Select(x => x.Imagem).SingleOrDefault();
        }
    }
}
