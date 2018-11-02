using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        string RecuperarImagemPeloId(int id);
    }
}
