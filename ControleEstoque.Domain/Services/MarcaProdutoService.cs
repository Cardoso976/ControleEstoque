using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;

namespace ControleEstoque.Domain.Services
{
    public class MarcaProdutoService : ServiceBase<MarcaProduto>, IMarcaProdutoService
    {
        private readonly IMarcaProdutoRepository _marcaProdutoRepository;

        public MarcaProdutoService(IMarcaProdutoRepository marcaProdutoRepository) 
            : base(marcaProdutoRepository)
        {
            _marcaProdutoRepository = marcaProdutoRepository;
        }
    }
}
