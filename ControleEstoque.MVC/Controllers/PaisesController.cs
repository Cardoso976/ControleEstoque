using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ControleEstoque.Application;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    public class PaisesController : Controller
    {
        private readonly PaisAppService _paisApp;

        public PaisesController(PaisAppService paisApp)
        {
            _paisApp = paisApp;
        }

        // GET: Paises
        public ActionResult Index()
        {
            var paisViewModel = Mapper.Map<IEnumerable<Pais>, IEnumerable<PaisViewModel>>(_paisApp.GetAll());
            return View(paisViewModel);
        }

        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);

            return View(paisViewModel);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisViewModel pais)
        {
            if (ModelState.IsValid)
            {
                var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisApp.Add(paisDomain);

                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);

            return View(paisViewModel);
        }

        // POST: Paises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaisViewModel pais)
        {
            if (ModelState.IsValid)
            {
                var paisDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisApp.Update(paisDomain);

                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int id)
        {
            var pais = _paisApp.GetById(id);
            var paisViewModel = Mapper.Map<Pais, PaisViewModel>(pais);

            return View(paisViewModel);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var pais = _paisApp.GetById(id);
            _paisApp.Remove(pais);

            return RedirectToAction("Index");
        }
    }
}
