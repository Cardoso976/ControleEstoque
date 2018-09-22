using System;
using AutoMapper;
using ControleEstoque.Application.Interface;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ControleEstoque.MVC.Controllers
{
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
            throw new Exception();
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
            if (ModelState.IsValid)
            {
                var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisApp.Add(paisDomain);

                return Json("OK");
            }

            return Json("Erro");
        }

        // POST: Paises/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(PaisViewModel pais)
        {
            if (ModelState.IsValid)
            {
                var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisApp.Update(paisDomain);

                return Json("Ok");
            }

            return Json("Erro");
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var pais = _paisApp.GetById(id);
            _paisApp.Remove(pais);

            return Json("Ok");
        }
    }
}
