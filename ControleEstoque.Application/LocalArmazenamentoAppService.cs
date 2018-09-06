using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class LocalArmazenamentoAppService : AppServiceBase<LocalArmazenamento>, ILocalArmazenamentoAppService
    {
        private readonly ILocalArmazenamentoService _localArmazenamentoService;

        public LocalArmazenamentoAppService(ILocalArmazenamentoService localArmazenamentoService) 
            : base(localArmazenamentoService)
        {
            _localArmazenamentoService = localArmazenamentoService;
        }
    }
}
