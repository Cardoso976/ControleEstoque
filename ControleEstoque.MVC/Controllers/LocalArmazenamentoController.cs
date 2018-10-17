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
    public class LocalArmazenamentoController : Controller
    {
        private readonly ILocalArmazenamentoAppService _localArmazenamentoApp;

        public LocalArmazenamentoController(ILocalArmazenamentoAppService localArmazenamentoApp)
        {
            _localArmazenamentoApp = localArmazenamentoApp;
        }

        // GET: LocalArmazenamento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLocalArmazenamento()
        {
            var localArmazenamentoViewModel = Mapper.Map<IEnumerable<LocalArmazenamento>, IEnumerable<LocalArmazenamentoViewModel>>(_localArmazenamentoApp.GetAll());
            return Json(new { data = localArmazenamentoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: LocalArmazenamento/Details/5
        public JsonResult Details(int id)
        {
            var localArmazenamento = _localArmazenamentoApp.GetById(id);
            var localArmazenamentoViewModel = Mapper.Map<LocalArmazenamento, LocalArmazenamentoViewModel>(localArmazenamento);

            return Json(new { data = localArmazenamentoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: LocalArmazenamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(LocalArmazenamentoViewModel localArmazenamento)
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
                    var localArmazenamentoDomain = Mapper.Map<LocalArmazenamentoViewModel, LocalArmazenamento>(localArmazenamento);
                    _localArmazenamentoApp.Add(localArmazenamentoDomain);
                    idSalvo = localArmazenamentoDomain.LocalArmazenamentoId.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        // POST: LocalArmazenamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(LocalArmazenamentoViewModel localArmazenamento)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var localArmazenamentoViewModel = localArmazenamento;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var localArmazenamentoDomain = Mapper.Map<LocalArmazenamentoViewModel, LocalArmazenamento>(localArmazenamento);
                    _localArmazenamentoApp.Update(localArmazenamentoDomain);
                    localArmazenamentoViewModel = Mapper.Map<LocalArmazenamento, LocalArmazenamentoViewModel>(localArmazenamentoDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = localArmazenamentoViewModel });
        }

        // POST: LocalArmazenamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var localArmazenamento = _localArmazenamentoApp.GetById(id);
                _localArmazenamentoApp.Remove(localArmazenamento);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}
