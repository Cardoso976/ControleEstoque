using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    [Authorize]
    public class MarcaProdutoController : Controller
    {
        private readonly IMarcaProdutoAppService _marcaProdutoApp;

        public MarcaProdutoController(IMarcaProdutoAppService marcaProdutoApp)
        {
            _marcaProdutoApp = marcaProdutoApp;
        }

        // GET: Paises
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMarcas()
        {
            var marcaProdutoViewModels = Mapper.Map<IEnumerable<MarcaProduto>, IEnumerable<MarcaProdutoViewModel>>(_marcaProdutoApp.GetAll());
            return Json(new { data = marcaProdutoViewModels }, JsonRequestBehavior.AllowGet);
        }

        // GET: Paises/Details/5
        public JsonResult Details(int id)
        {
            var marcaProduto = _marcaProdutoApp.GetById(id);
            var marcaProdutoViewModel = Mapper.Map<MarcaProduto, MarcaProdutoViewModel>(marcaProduto);

            return Json(new { data = marcaProdutoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(MarcaProdutoViewModel marcaProduto)
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
                    var marcaProdutoDomain = Mapper.Map<MarcaProdutoViewModel, MarcaProduto>(marcaProduto);
                    _marcaProdutoApp.Add(marcaProdutoDomain);
                    idSalvo = marcaProdutoDomain.MarcaProdutoId.ToString();
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
        public JsonResult Edit(MarcaProdutoViewModel marcaProduto)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var marcaProdutoViewModel = marcaProduto;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var marcaProdutoDomain = Mapper.Map<MarcaProdutoViewModel, MarcaProduto>(marcaProduto);
                    _marcaProdutoApp.Update(marcaProdutoDomain);
                    marcaProdutoViewModel = Mapper.Map<MarcaProduto, MarcaProdutoViewModel>(marcaProdutoDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = marcaProdutoViewModel });
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var marcaProduto = _marcaProdutoApp.GetById(id);
                _marcaProdutoApp.Remove(marcaProduto);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}
