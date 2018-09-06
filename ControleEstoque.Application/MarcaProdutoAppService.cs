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
    public class MarcaProdutoAppService : AppServiceBase<MarcaProduto>, IMarcaProdutoAppService
    {
        private readonly IMarcaProdutoService _marcaProdutoService;

        public MarcaProdutoAppService(IMarcaProdutoService marcaProdutoService) 
            : base(marcaProdutoService)
        {
            _marcaProdutoService = marcaProdutoService;
        }
    }
}
