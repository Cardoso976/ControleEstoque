using ControleEstoque.Application;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Domain.Interfaces.Services;
using ControleEstoque.Domain.Services;
using ControleEstoque.Identity.Configuration;
using ControleEstoque.Identity.Context;
using ControleEstoque.Identity.Model;
using ControleEstoque.Infra.Data.Contexto;
using ControleEstoque.Infra.Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace ControleEstoque.IoC
{

    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<ControleEstoqueContext>();

            container.RegisterPerWebRequest<IPaisAppService, PaisAppService>();
            container.RegisterPerWebRequest<IPaisService, PaisService>();
            container.RegisterPerWebRequest<IPaisRepository, PaisRepository>();

            container.RegisterPerWebRequest<IEstadoAppService, EstadoAppService>();
            container.RegisterPerWebRequest<IEstadoService, EstadoService>();
            container.RegisterPerWebRequest<IEstadoRepository, EstadoRepository>();

            container.RegisterPerWebRequest<ICidadeAppService, CidadeAppService>();
            container.RegisterPerWebRequest<ICidadeService, CidadeService>();
            container.RegisterPerWebRequest<ICidadeRepository, CidadeRepository>();

            container.RegisterPerWebRequest<IGrupoProdutoAppService, GrupoProdutoAppService>();
            container.RegisterPerWebRequest<IGrupoProdutoService, GrupoProdutoService>();
            container.RegisterPerWebRequest<IGrupoProdutoRepository, GrupoProdutoRepository>();

            container.RegisterPerWebRequest<IUnidadeMedidaAppService, UnidadeMedidaAppService>();
            container.RegisterPerWebRequest<IUnidadeMedidaService, UnidadeMedidaService>();
            container.RegisterPerWebRequest<IUnidadeMedidaRepository, UnidadeMedidaRepository>();

            container.RegisterPerWebRequest<IMarcaProdutoAppService, MarcaProdutoAppService>();
            container.RegisterPerWebRequest<IMarcaProdutoService, MarcaProdutoService>();
            container.RegisterPerWebRequest<IMarcaProdutoRepository, MarcaProdutoRepository>();

            container.RegisterPerWebRequest<ILocalArmazenamentoAppService, LocalArmazenamentoAppService>();
            container.RegisterPerWebRequest<ILocalArmazenamentoService, LocalArmazenamentoService>();
            container.RegisterPerWebRequest<ILocalArmazenamentoRepository, LocalArmazenamentoRepository>();

            container.RegisterPerWebRequest<IFornecedorAppService, FornecedorAppService>();
            container.RegisterPerWebRequest<IFornecedorService, FornecedorService>();
            container.RegisterPerWebRequest<IFornecedorRepository, FornecedorRepository>();

            container.RegisterPerWebRequest<IProdutoAppService, ProdutoAppService>();
            container.RegisterPerWebRequest<IProdutoService, ProdutoService>();
            container.RegisterPerWebRequest<IProdutoRepository, ProdutoRepository>();

            container.RegisterPerWebRequest<IEntradaProdutoAppService, EntradaProdutoAppService>();
            container.RegisterPerWebRequest<IEntradaProdutoService, EntradaProdutoService>();
            container.RegisterPerWebRequest<IEntradaProdutoRepository, EntradaProdutoRepository>();

            container.RegisterPerWebRequest<ISaidaProdutoAppService, SaidaProdutoAppService>();
            container.RegisterPerWebRequest<ISaidaProdutoService, SaidaProdutoService>();
            container.RegisterPerWebRequest<ISaidaProdutoRepository, SaidaProdutoRepository>();

            //Identity IoC
            container.RegisterPerWebRequest<ApplicationDbContext>();

            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

            container.RegisterPerWebRequest<IUsuarioRepository, UsuarioRepository>();
        }
    }

}
