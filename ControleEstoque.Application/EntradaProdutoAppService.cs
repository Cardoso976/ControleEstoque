using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Application
{
    public class EntradaProdutoAppService : IEntradaProdutoAppService
    {
        private readonly IEntradaProdutoService _entradaProdutoService;

        public EntradaProdutoAppService(IEntradaProdutoService entradaProdutoService)
        {
            _entradaProdutoService = entradaProdutoService;
        }

        public string Add(DateTime data, Dictionary<int, int> produtos)
        {
            return _entradaProdutoService.Add(data, produtos);
        }
    }
}
