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
    public class EstadoController : Controller
    {
        private readonly IEstadoAppService _estadoApp;

        public EstadoController(IEstadoAppService estadoApp)
        {
            _estadoApp = estadoApp;
        }

        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPaises()
        {
            var paisViewModel = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_estadoApp.GetAll());
            return Json(new { data = paisViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: Estados/Details/5
        public JsonResult Details(int id)
        {
            var estado = _estadoApp.GetById(id);
            var estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estado);

            return Json(new { data = estadoViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: Estados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(EstadoViewModel estado)
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
                    var estadoDomain = Mapper.Map<EstadoViewModel, Estado>(estado);
                    _estadoApp.Add(estadoDomain);
                    idSalvo = estadoDomain.EstadoId.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        // POST: Estados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(EstadoViewModel estado)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var estadoViewModel = estado;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var estadoDomain = Mapper.Map<EstadoViewModel, Estado>(estado);
                    _estadoApp.Update(estadoDomain);
                    estadoViewModel = Mapper.Map<Estado, EstadoViewModel>(estadoDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = estadoViewModel });
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var estado = _estadoApp.GetById(id);
                _estadoApp.Remove(estado);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}