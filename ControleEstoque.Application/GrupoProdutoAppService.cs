using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class GrupoProdutoAppService : AppServiceBase<GrupoProduto>, IGrupoProdutoAppService
    {
        private readonly IGrupoProdutoService _grupoProdutoService;

        public GrupoProdutoAppService(IGrupoProdutoService grupoProdutoService) 
            : base(grupoProdutoService)
        {
            _grupoProdutoService = grupoProdutoService;
        }
    }
}
