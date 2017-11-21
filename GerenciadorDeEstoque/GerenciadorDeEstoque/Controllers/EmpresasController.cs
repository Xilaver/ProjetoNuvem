using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorDeEstoque.Controllers
{
    public class EmpresasController : Controller
    {
        private Entities db = new Entities();

        // GET: Empresas
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cnpj,Telefone,Email,Login,Senha")] Empresa empresa)
        {
            db.Empresas.Add(empresa);
            db.SaveChanges();
            return RedirectToAction("Index","Login");
        }

    }
}