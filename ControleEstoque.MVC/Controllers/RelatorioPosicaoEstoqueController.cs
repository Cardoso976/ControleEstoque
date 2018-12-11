using ControleEstoque.Application.Interface;
using System.Web.Mvc;
using Rotativa;
using AutoMapper;
using System.Collections.Generic;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    public class RelatorioPosicaoEstoqueController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public RelatorioPosicaoEstoqueController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }
        
        // GET: RelatorioPosicaoEstoqueView
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoAppService.GetAll());
            return View("~/Views/Relatorio/RelatorioPosicaoEstoqueView.cshtml", produtoViewModel);
        }

        // GET: RelatorioPosicaoEstoque
        public ActionResult ImpressaoPDF()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoAppService.GetAll());
            return new ViewAsPdf("~/Views/Relatorio/RelatorioPosicaoEstoque.cshtml", produtoViewModel);
        }
    }
}