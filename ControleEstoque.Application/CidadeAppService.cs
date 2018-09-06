using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class CidadeAppService : AppServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeService _cidadeService;

        public CidadeAppService(ICidadeService cidadeService) 
            : base(cidadeService)
        {
            _cidadeService = cidadeService;
        }
    }
}
