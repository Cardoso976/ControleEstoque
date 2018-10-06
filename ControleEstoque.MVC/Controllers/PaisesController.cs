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
    //[Authorize]
    public class PaisesController : Controller
    {
        private readonly IPaisAppService _paisApp;

        public PaisesController(IPaisAppService paisApp)
        {
            _paisApp = paisApp;
        }

        // GET: Paises
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPaises()
        {
            var paisViewModel = Mapper.Map<IEnumerable<Pais>, IEnumerable<PaisViewModel>>(_paisApp.GetAll());
            return Json(new { data = paisViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: Paises/Details/5
        public JsonResult Details(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);

            return Json(new {data = paisViewModel}, JsonRequestBehavior.AllowGet);
        }

        // POST: Paises/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(PaisViewModel pais)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;
            pais.PaisId = 0;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                    _paisApp.Add(paisDomain);
                    idSalvo = paisDomain.PaisId.ToString();
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
        public JsonResult Edit(PaisViewModel pais)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var paisViewModel = pais;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                    _paisApp.Update(paisDomain);
                    paisViewModel = Mapper.Map<Pais, PaisViewModel>(paisDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = paisViewModel });
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var pais = _paisApp.GetById(id);
                _paisApp.Remove(pais);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}
