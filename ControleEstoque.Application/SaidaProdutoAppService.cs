using System;
using System.Collections.Generic;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class SaidaProdutoAppService : ISaidaProdutoAppService
    {
        private readonly ISaidaProdutoService _saidaProdutoService;

        public SaidaProdutoAppService(ISaidaProdutoService saidaProdutoService)
        {
            _saidaProdutoService = saidaProdutoService;
        }

        public string Add(DateTime data, Dictionary<int,int> produtos)
        {
            return _saidaProdutoService.Add(data, produtos);
        }
    }
}
