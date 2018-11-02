using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly IMarcaProdutoAppService _marcaProdutoApp;
        private readonly IFornecedorAppService _fornecedorApp;
        private readonly IGrupoProdutoAppService _grupoProdutoApp;
        private readonly ILocalArmazenamentoAppService _localArmazenamentoApp;
        private readonly IUnidadeMedidaAppService _unidadeMedidaApp;
        private readonly IProdutoAppService _produtoApp;
        private readonly IPaisAppService _paisApp;

        public ProdutoController(
            IProdutoAppService produtoApp, IPaisAppService paisApp, IUnidadeMedidaAppService unidadeMedidaApp,
            IMarcaProdutoAppService marcaProdutoApp, IFornecedorAppService fornecedorApp,
            IGrupoProdutoAppService grupoProdutoApp, ILocalArmazenamentoAppService localArmazenamentoApp)
        {
            _localArmazenamentoApp = localArmazenamentoApp;
            _grupoProdutoApp = grupoProdutoApp;
            _fornecedorApp = fornecedorApp;
            _unidadeMedidaApp = unidadeMedidaApp;
            _marcaProdutoApp = marcaProdutoApp;
            _produtoApp = produtoApp;
            _paisApp = paisApp;
        }

        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.GruposProduto = _grupoProdutoApp.GetAll();
            ViewBag.Marcas = _marcaProdutoApp.GetAll();
            ViewBag.Fornecedores = _fornecedorApp.GetAll();
            ViewBag.LocaisArmazenamento = _localArmazenamentoApp.GetAll();
            ViewBag.UnidadesMedida = _unidadeMedidaApp.GetAll();
            ViewBag.Paises = _paisApp.GetAll();
            return View();
        }

        public JsonResult GetProdutos()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());
            return Json(new { data = produtoViewModel }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetImagemPeloId(int id)
        {
            var nomeImagem = _produtoApp.RecuperarImagemPeloId(id);
            return Json(new { data = nomeImagem }, JsonRequestBehavior.AllowGet);
        }

        // GET: Produto/Details/5
        public JsonResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return Json(new { data = produtoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create()
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            var nomeArquivoImagem = "";
            HttpPostedFileBase arquivo = null;
            if (Request.Files.Count > 0)
            {
                arquivo = Request.Files[0];
                nomeArquivoImagem = Guid.NewGuid().ToString() + ".jpg";
            }

            var produto = new ProdutoViewModel()
            {
                ProdutoId = Int32.Parse(Request.Form["ProdutoId"]),
                Codigo = Request.Form["Codigo"],
                Descricao = Request.Form["Descricao"],
                PrecoCusto = Decimal.Parse(Request.Form["PrecoCusto"]),
                PrecoVenda = Decimal.Parse(Request.Form["PrecoVenda"]),
                QuantidadeEstoque = Int32.Parse(Request.Form["QuantidadeEstoque"]),
                UnidadeMedidaId = Int32.Parse(Request.Form["UnidadeMedidaId"]),
                GrupoProdutoId = Int32.Parse(Request.Form["GrupoProdutoId"]),
                MarcaId = Int32.Parse(Request.Form["MarcaId"]),
                FornecedorId = Int32.Parse(Request.Form["FornecedorId"]),
                LocalArmazenamentoId = Int32.Parse(Request.Form["LocalArmazenamentoId"]),
                Ativo = (Request.Form["Ativo"] == "true"),
                Imagem = nomeArquivoImagem
            };

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                    _produtoApp.Add(produtoDomain);
                    idSalvo = produtoDomain.ProdutoId.ToString();
                    if (!string.IsNullOrEmpty(nomeArquivoImagem) && arquivo != null)
                    {
                        SalvarImagem(arquivo, nomeArquivoImagem);
                    }
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(ProdutoViewModel produto)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var produtoViewModel = produto;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                    _produtoApp.Update(produtoDomain);
                    produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produtoDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = produtoViewModel });
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var produto = _produtoApp.GetById(id);
                _produtoApp.Remove(produto);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }

        private void SalvarImagem(HttpPostedFileBase arquivo, string nomeArquivoImagem)
        {
            var diretorio = Server.MapPath("~/Content/Imagens");

            var caminhoArquivo = Path.Combine(diretorio, nomeArquivoImagem);
            arquivo.SaveAs(caminhoArquivo);
        }
    }
}