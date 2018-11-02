using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _paisRepository;

        public ProdutoService(IProdutoRepository produtoRepository) 
            : base(produtoRepository)
        {
            _paisRepository = produtoRepository;
        }

        public string RecuperarImagemPeloId(int id)
        {
            return _paisRepository.RecuperarImagemPeloId(id);
        }
    }
}
