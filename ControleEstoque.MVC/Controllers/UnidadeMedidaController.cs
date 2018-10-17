using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    public class UnidadeMedidaController : Controller
    {
        private readonly IUnidadeMedidaAppService _unidadeMedidaApp;

        public UnidadeMedidaController(IUnidadeMedidaAppService unidadeMedidaApp)
        {
            _unidadeMedidaApp = unidadeMedidaApp;
        }

        // GET: UnidadeMedida
        public ActionResult Index()
        {
            return View();
        }

        // GET: UnidadeMedida/GetUnidadesMedida
        public JsonResult GetUnidadesMedidas()
        {
            var unidadeMedidaViewModel = Mapper.Map<IEnumerable<UnidadeMedida>, IEnumerable<UnidadeMedidaViewModel>>(_unidadeMedidaApp.GetAll());
            return Json(new { data = unidadeMedidaViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: UnidadeMedida/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Details(int id)
        {
            var unidadeMedida = _unidadeMedidaApp.GetById(id);
            var unidadeMedidaViewModel = Mapper.Map<UnidadeMedida, UnidadeMedidaViewModel>(unidadeMedida);

            return Json(new { data = unidadeMedidaViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: UnidadeMedida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(UnidadeMedidaViewModel unidadeMedida)
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
                    var unidadeMedidaDomain = Mapper.Map<UnidadeMedidaViewModel, UnidadeMedida>(unidadeMedida);
                    _unidadeMedidaApp.Add(unidadeMedidaDomain);
                    idSalvo = unidadeMedidaDomain.UnidadeMedidaId.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        // POST: UnidadeMedida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(UnidadeMedidaViewModel unidadeMedida)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var unidadeMedidaViewModel = unidadeMedida;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var unidadeMedidaDomain = Mapper.Map<UnidadeMedidaViewModel, UnidadeMedida>(unidadeMedida);
                    _unidadeMedidaApp.Update(unidadeMedidaDomain);
                    unidadeMedidaViewModel = Mapper.Map<UnidadeMedida, UnidadeMedidaViewModel>(unidadeMedidaDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = unidadeMedidaViewModel });
        }

        // POST: UnidadeMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var pais = _unidadeMedidaApp.GetById(id);
                _unidadeMedidaApp.Remove(pais);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}
