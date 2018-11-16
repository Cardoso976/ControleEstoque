using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Entities.Binders;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    [Authorize]
    public class SaidaProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly ISaidaProdutoAppService _saidaProdutoAppService;

        public SaidaProdutoController(ISaidaProdutoAppService saidaProdutoAppService, IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
            _saidaProdutoAppService = saidaProdutoAppService;
        }

        // GET: SaidaProduto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProdutos()
        {
            try
            {
                var domain = _produtoAppService.RecuperarProdutosAtivos();
                var produtos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(domain);

                return Json(new RetornoViewModel { Entidade = produtos, Sucesso = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new RetornoViewModel { Erro = ex.Message });
            }

        }

        // POST: SaidaProduto/Salvar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Salvar([ModelBinder(typeof(EntradaSaidaProdutoViewModelModelBinder))]EntradaSaidaProdutoViewModel dados)
        {
            try
            {
                var numPedido = _saidaProdutoAppService.Add(dados.Data, dados.Produtos);

                return Json(new RetornoViewModel { Sucesso = numPedido });
            }
            catch (Exception ex)
            {
                return Json(new RetornoViewModel { Erro = "Não foi possível executar a operação, tente novamente mais tarde." });
            }
        }

    }
}
