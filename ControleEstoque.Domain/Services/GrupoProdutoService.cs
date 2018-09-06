using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class GrupoProdutoService : ServiceBase<GrupoProduto>, IGrupoProdutoService
    {
        private readonly IGrupoProdutoRepository _grupoProdutoRepository;

        public GrupoProdutoService(IGrupoProdutoRepository grupoProdutoRepository) 
            : base(grupoProdutoRepository)
        {
            _grupoProdutoRepository = grupoProdutoRepository;
        }
    }
}
