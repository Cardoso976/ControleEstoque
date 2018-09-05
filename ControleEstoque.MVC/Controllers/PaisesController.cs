using System.Collections.Generic;
using ControleEstoque.Infra.Data.Repositories;
using System.Web.Mvc;
using AutoMapper;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.Controllers
{
    public class PaisesController : Controller
    {
        private readonly PaisRepository _paisRepository = new PaisRepository();

        // GET: Paises
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Pais>, IEnumerable<PaisViewModel>>(_paisRepository.GetAll());
            return View(clienteViewModel);
        }

        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                var clienteDomain = Mapper.Map<PaisViewModel, Pais>(pais);
                _paisRepository.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paises/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paises/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
