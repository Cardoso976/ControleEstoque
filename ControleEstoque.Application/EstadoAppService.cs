using System.Collections.Generic;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Application
{
    public class EstadoAppService : AppServiceBase<Estado>, IEstadoAppService
    {
        private readonly IEstadoService _estadoAppService;

        public EstadoAppService(IEstadoService estadoService) 
            : base(estadoService)
        {
            _estadoAppService = estadoService;
        }

        public IEnumerable<Estado> GetEstadosByPais(int paisId)
        {
            return _estadoAppService.GetEstadosByPais(paisId);
        }
    }
}
