using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ControleEstoque.Application
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService) 
            : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public string RecuperarImagemPeloId(int id)
        {
            return _produtoService.RecuperarImagemPeloId(id);
        }

        public IEnumerable<Produto> RecuperarProdutosAtivos()
        {
            return _produtoService.RecuperarProdutosAtivos();
        }
    }
}
