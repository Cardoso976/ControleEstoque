using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class PaisAppService : AppServiceBase<Pais>, IPaisAppService
    {
        private readonly IPaisService _paisService;

        public PaisAppService(IPaisService paisService) 
            : base(paisService)
        {
            _paisService = paisService;
        }
    }
}
