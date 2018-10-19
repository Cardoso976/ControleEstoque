using System.Collections.Generic;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(ICidadeRepository cidadeRepository) 
            : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public IEnumerable<Cidade> GetCidadesByEstado(int estadoId)
        {
            return _cidadeRepository.GetCidadesByEstado(estadoId);
        }
    }
}
