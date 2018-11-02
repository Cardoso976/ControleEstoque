using System.Web;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        string RecuperarImagemPeloId(int id);
    }
}
