using System;
using AutoMapper;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ControleEstoque.MVC.Controllers
{
    [Authorize]
    public class GrupoProdutoController : Controller
    {
        private readonly IGrupoProdutoAppService _grupoProdutoApp;

        public GrupoProdutoController(IGrupoProdutoAppService grupoProdutoApp)
        {
            _grupoProdutoApp = grupoProdutoApp;
        }

        // GET: Paises
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetGrupoProdutos()
        {
            var grupoProdutoViewModel = Mapper.Map<IEnumerable<GrupoProduto>, IEnumerable<GrupoProdutoViewModel>>(_grupoProdutoApp.GetAll());
            return Json(new { data = grupoProdutoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: Paises/Details/5
        public JsonResult Details(int id)
        {
            var grupoProduto = _grupoProdutoApp.GetById(id);
            var grupoProdutoViewModel = Mapper.Map<GrupoProduto, GrupoProdutoViewModel>(grupoProduto);

            return Json(new { data = grupoProdutoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(GrupoProdutoViewModel grupoProduto)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var grupoProdutoDomain = Mapper.Map<GrupoProdutoViewModel, GrupoProduto>(grupoProduto);
                    _grupoProdutoApp.Add(grupoProdutoDomain);
                    idSalvo = grupoProdutoDomain.GrupoProdutoId.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        // POST: Paises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(GrupoProdutoViewModel grupoProduto)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var grupoProdutoViewModel = grupoProduto;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var grupoProdutoDomain = Mapper.Map<GrupoProdutoViewModel, GrupoProduto>(grupoProduto);
                    _grupoProdutoApp.Update(grupoProdutoDomain);
                    grupoProdutoViewModel = Mapper.Map<GrupoProduto, GrupoProdutoViewModel>(grupoProdutoDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = grupoProdutoViewModel });
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var grupoProduto = _grupoProdutoApp.GetById(id);
                _grupoProdutoApp.Remove(grupoProduto);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}
