using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciadorDeEstoque.Models;

namespace GerenciadorDeEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        private Entities db = new Entities();

        // GET: Produto
        public ActionResult Index()
        {
           
                return View(ProdutoDAO.ListarProdutos());
           
        }

        [HttpPost]
        public ActionResult Index(Produto p)
        {
            return View(p);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            Produto produto = new Produto();
            return View(produto);



        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Quantidade")] Produto produto)
        {

            if (ModelState.IsValid)
            {
                

                if(ProdutoDAO.CadastrarProduto(produto))
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Já existe um produto com o mesmo nome!");
                }
            }

            return View(produto);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);

           

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);


            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {

                Produto produtoAux = ProdutoDAO.BuscarProdutoPorId(produto.ProdutoId);
                produtoAux.Nome = produto.Nome;
                produtoAux.Quantidade = produto.Quantidade;

                if (ProdutoDAO.AlterarProduto(produtoAux))
                {
                    return RedirectToAction("Index");
                }

            }

            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            if (ProdutoDAO.ExcluirProduto(produto))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
