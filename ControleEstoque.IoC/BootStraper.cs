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
