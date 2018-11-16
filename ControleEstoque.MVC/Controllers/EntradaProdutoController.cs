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
    public class EntradaProdutoController : Controller
    {
        private readonly IEntradaProdutoAppService _entradaProdutoAppService;
        private readonly IProdutoAppService _produtoAppService;

        public EntradaProdutoController(IProdutoAppService produtoAppService, IEntradaProdutoAppService entradaProdutoAppService)
        {
            _entradaProdutoAppService = entradaProdutoAppService;
            _produtoAppService = produtoAppService;
        }

        // GET: EntradaProduto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProdutos()
        {
            var produtosDomain = _produtoAppService.RecuperarProdutosAtivos();
            var produtos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(produtosDomain);

            return Json(new { data = produtos }, JsonRequestBehavior.AllowGet);
        }

        // POST: EntradaProduto/Salvar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Salvar([ModelBinder(typeof(EntradaSaidaProdutoViewModelModelBinder))]EntradaSaidaProdutoViewModel dados)
        {
            try
            {
                var numPedido = _entradaProdutoAppService.Add(dados.Data, dados.Produtos);

                return Json(new RetornoViewModel { Sucesso = numPedido });
            }
            catch (Exception ex)
            {
                return Json(new RetornoViewModel { Erro = "Não foi possível concluir a operação, tente novamente mais tarde" });
            }

        }
    }
}
