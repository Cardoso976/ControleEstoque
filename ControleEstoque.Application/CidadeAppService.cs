using System.Collections.Generic;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class CidadeAppService : AppServiceBase<Cidade>, ICidadeAppService
    {
        private readonly ICidadeService _cidadeAppService;

        public CidadeAppService(ICidadeService cidadeService) 
            : base(cidadeService)
        {
            _cidadeAppService = cidadeService;
        }

        public IEnumerable<Cidade> GetCidadesByEstado(int estadoId)
        {
           return _cidadeAppService.GetCidadesByEstado(estadoId);
        }
    }
}
