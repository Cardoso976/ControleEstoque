using System;
using System.Collections.Generic;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class SaidaProdutoAppService : ISaidaProdutoAppService
    {
        private readonly ISaidaProdutoService _saidaProdutoService;
        private readonly IProdutoAppService _produtoAppService;

        public SaidaProdutoAppService(ISaidaProdutoService saidaProdutoService, IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
            _saidaProdutoService = saidaProdutoService;
        }

        public string Add(DateTime data, Dictionary<int, int> produtos)
        {
            foreach (var item in produtos)
            {
                var produto = _produtoAppService.GetById(item.Key);
                if (produto.QuantidadeEstoque < item.Value)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            return _saidaProdutoService.Add(data, produtos);            
        }
    }
}
