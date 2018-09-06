using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class EstadoService : ServiceBase<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoService;

        public EstadoService(IEstadoRepository estadoService) 
            : base(estadoService)
        {
            _estadoService = estadoService;
        }
    }
}
