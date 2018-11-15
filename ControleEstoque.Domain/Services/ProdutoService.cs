using System.Collections.Generic;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) 
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public string RecuperarImagemPeloId(int id)
        {
            return _produtoRepository.RecuperarImagemPeloId(id);
        }

        public IEnumerable<Produto> RecuperarProdutosAtivos()
        {
            return _produtoRepository.RecuperarProdutosAtivos();
        }
    }
}
