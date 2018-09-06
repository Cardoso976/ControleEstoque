using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
