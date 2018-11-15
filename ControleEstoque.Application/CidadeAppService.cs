using System.Collections.Generic;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class CidadeAppService : AppServiceBase<Cidade>, ICidadeAppService
    {
        private readonly ICidadeService _cidadeService;

        public CidadeAppService(ICidadeService cidadeService) 
            : base(cidadeService)
        {
            _cidadeService = cidadeService;
        }

        public IEnumerable<Cidade> GetCidadesByEstado(int estadoId)
        {
           return _cidadeService.GetCidadesByEstado(estadoId);
        }
    }
}
