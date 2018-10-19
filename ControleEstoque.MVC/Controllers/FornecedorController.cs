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
    public class FornecedorController : Controller
    {
        private readonly IFornecedorAppService _fornecedorApp;
        private readonly IPaisAppService _paisApp;

        public FornecedorController(IFornecedorAppService fornecedorApp, IPaisAppService paisApp, IEstadoAppService estadoApp, ICidadeAppService cidadeApp)
        {
            _fornecedorApp = fornecedorApp;
            _paisApp = paisApp;
        }

        // GET: Fornecedor
        public ActionResult Index()
        {
            ViewBag.Paises = _paisApp.GetAll();
            return View();
        }

        public JsonResult GetFornecedores()
        {
            var fornecedorViewModel = Mapper.Map<IEnumerable<Fornecedor>, IEnumerable<FornecedorViewModel>>(_fornecedorApp.GetAll());
            return Json(new { data = fornecedorViewModel }, JsonRequestBehavior.AllowGet);
        }

        // GET: Fornecedor/Details/5
        public JsonResult Details(int id)
        {
            var fornecedor = _fornecedorApp.GetById(id);
            var fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedor);

            return Json(new { data = fornecedorViewModel }, JsonRequestBehavior.AllowGet);
        }

        // POST: Fornecedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(FornecedorViewModel fornecedor)
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
                    var fornecedorDomain = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                    _fornecedorApp.Add(fornecedorDomain);
                    idSalvo = fornecedorDomain.FornecedorId.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        // POST: Fornecedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(FornecedorViewModel fornecedor)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var fornecedorViewModel = fornecedor;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var fornecedorDomain = Mapper.Map<FornecedorViewModel, Fornecedor>(fornecedor);
                    _fornecedorApp.Update(fornecedorDomain);
                    fornecedorViewModel = Mapper.Map<Fornecedor, FornecedorViewModel>(fornecedorDomain);
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, data = fornecedorViewModel });
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var resultado = true;
            try
            {
                var fornecedor = _fornecedorApp.GetById(id);
                _fornecedorApp.Remove(fornecedor);
            }
            catch (Exception ex)
            {
                resultado = false;
            }

            return Json(resultado);
        }
    }
}