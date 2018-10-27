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
    public class CidadeController : Controller
    {
        private readonly ICidadeAppService _cidadeApp;
        private readonly IEstadoAppService _estadoApp;

        public CidadeController(ICidadeAppService cidadeApp, IEstadoAppService estadoApp)
        {
            _cidadeApp = cidadeApp;
            _estadoApp = estadoApp;
        }

        // GET: Cidade
        public ActionResult Index()
        {
            ViewBag.Estados = _estadoApp.GetAll();
            return View();
        }

        public JsonResult GetCidades()
        {
            var cidadeViewModel = Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_cidadeApp.GetAll());
            return Json(new {data = cidadeViewModel}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetCidadesByEstado(int estadoId)
        {
            var cidadeViewModel =
                Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_cidadeApp.GetCidadesByEstado(estadoId));
            return Json(new { data = cidadeViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: Paises/Details/5
        public JsonResult Details(int id)
        {
            var cidade = _cidadeApp.GetById(id);
            var cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidade);

            return Json(new { data = cidadeViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(CidadeViewModel cidade)
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
                    var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidade);
                    _cidadeApp.Add(cidadeDomain);
                    idSalvo = cidadeDomain.CidadeId.ToString();
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
        public JsonResult Edit(CidadeViewModel cidade)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var cidadeViewModel = cidade;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var cidadeDomain = Mapper.Map<CidadeViewModel, Cidade>(cidade);
                    _cidadeApp.Update(cidadeDomain);
                    cidadeViewModel = Mapper.Map<Cidade, CidadeViewModel>(cidadeDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = cidadeViewModel });
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var cidade = _cidadeApp.GetById(id);
                _cidadeApp.Remove(cidade);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}