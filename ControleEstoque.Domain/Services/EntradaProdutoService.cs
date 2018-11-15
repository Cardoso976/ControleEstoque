using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Services
{
    public class EntradaProdutoService : IEntradaProdutoService
    {
        private readonly IEntradaProdutoRepository _entradaProdutoRepository;

        public EntradaProdutoService(IEntradaProdutoRepository entradaProdutoRepository)
        {
            _entradaProdutoRepository = entradaProdutoRepository;
        }

        public string Add(DateTime data, Dictionary<int, int> produtos)
        {
            return _entradaProdutoRepository.Add(data, produtos);
        }
    }
}
