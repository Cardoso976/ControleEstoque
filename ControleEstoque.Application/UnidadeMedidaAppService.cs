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
    public class UnidadeMedidaAppService : AppServiceBase<UnidadeMedida>, IUnidadeMedidaAppService
    {
        private readonly IUnidadeMedidaService _unidadeMedidaService;

        public UnidadeMedidaAppService(IUnidadeMedidaService unidadeMedidaService) 
            : base(unidadeMedidaService)
        {
            _unidadeMedidaService = unidadeMedidaService;
        }
    }
}
