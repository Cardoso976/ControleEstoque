using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class LocalArmazenamentoService : ServiceBase<LocalArmazenamento>, ILocalArmazenamentoService
    {
        private readonly ILocalArmazenamentoRepository _localArmazenamentoRepository;

        public LocalArmazenamentoService(ILocalArmazenamentoRepository localArmazenamentoRepository) 
            : base(localArmazenamentoRepository)
        {
            _localArmazenamentoRepository = localArmazenamentoRepository;
        }
    }
}
