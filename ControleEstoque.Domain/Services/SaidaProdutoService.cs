using System;
using System.Collections.Generic;
using ControleEstoque.Domain.Interfaces.Services;
using ControleEstoque.Domain.Interfaces.Repositories;

namespace ControleEstoque.Domain.Services
{
    public class SaidaProdutoService : ISaidaProdutoService
    {
        private readonly ISaidaProdutoRepository _saidaProdutoRepository;

        public SaidaProdutoService(ISaidaProdutoRepository saidaProdutoRepository)
        {
            _saidaProdutoRepository = saidaProdutoRepository;
        }

        public string Add(DateTime data, Dictionary<int,int> produtos)
        {
            return _saidaProdutoRepository.Add(data, produtos);
        }
    }
}
