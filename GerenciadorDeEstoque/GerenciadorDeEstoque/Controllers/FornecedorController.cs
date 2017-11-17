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
    public class FornecedorController : Controller
    {
        //private Entities db = new Entities();

        // GET: Fornecedor
        public ActionResult Index()
        {
            if (EmpresaDAO.EstaLogado())
            {
                Empresa empresa = new Empresa();
                empresa = EmpresaDAO.BuscarEmpresaPorLogin();

                return View(FornecedorDAO.ListarFornecedoresPorLogin(empresa));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        // GET: Fornecedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = FornecedorDAO.BuscarFornecedorPorId(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cnpj,Telefone,Email,Endereco,Cep,Cidade,Estado")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                Empresa empresa = new Empresa();
                var list = new List<Fornecedor>();

                empresa = EmpresaDAO.BuscarEmpresaPorLogin();
                fornecedor.Empresa = empresa;

                if (empresa.Fornecedores != null)
                {
                    list = empresa.Fornecedores;
                }

                list.Add(fornecedor);
                empresa.Fornecedores = list;
                EmpresaDAO.Alterarempresa(empresa);
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = FornecedorDAO.BuscarFornecedorPorId(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cnpj,Telefone,Email,Endereco,Cep,Cidade,Estado")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(fornecedor).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        // GET: Fornecedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fornecedor fornecedor = FornecedorDAO.BuscarFornecedorPorId(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Fornecedor fornecedor = db.Fornecedores.Find(id);
            //db.Fornecedores.Remove(fornecedor);
            //db.SaveChanges();
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
