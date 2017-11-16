using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciadorDeEstoque.Models;
using GerenciadorDeEstoque.DAL;

namespace GerenciadorDeEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        //private Entities db = new Entities();

        // GET: Categoria
        public ActionResult Index()
        {
            if (EmpresaDAO.EstaLogado())
            {
                Empresa empresa = new Empresa();
                empresa = EmpresaDAO.BuscarEmpresaPorLogin();

                return View(CategoriaDAO.ListarCategoriasPorLogin(empresa));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                Empresa empresa = new Empresa();
                var list = new List<Categoria>();

                empresa = EmpresaDAO.BuscarEmpresaPorLogin();
                categoria.Empresa = empresa;

                if (empresa.Categorias != null)
                {
                    list = empresa.Categorias;
                }

                list.Add(categoria);
                empresa.Categorias = list;
                EmpresaDAO.Alterarempresa(empresa);
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                Categoria categoriaAux = CategoriaDAO.BuscarCategoriaPorId(categoria.Id);
                categoriaAux.Nome = categoria.Nome;
                if (CategoriaDAO.AlterarCategoria(categoriaAux))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = CategoriaDAO.BuscarCategoriaPorId(id);
            CategoriaDAO.ExcluirCategoria(categoria);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
