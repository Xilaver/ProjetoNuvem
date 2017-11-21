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
    public class ProdutosController : Controller
    {
        private Entities db = new Entities();

        // GET: Produtos
        public ActionResult Index()
        {
            if (EmpresaDAO.EstaLogado())
            {
                Empresa empresa = new Empresa();
                empresa = EmpresaDAO.BuscarEmpresaPorLogin();

                //var produtos = ProdutoDAO.ListarProdutosPorLogin(empresa);/*db.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor);*/
                //return View(produtos.ToList());
                return View(ProdutoDAO.ListarProdutosPorLogin(empresa));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        // GET: Produtos/Details/5
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

        // GET: Produtos/Create
        public ActionResult Create()
        {
            Empresa empresa = new Empresa();
            empresa = EmpresaDAO.BuscarEmpresaPorLogin();

            ViewBag.CategoriaID = new SelectList(CategoriaDAO.ListarCategoriasPorLogin(empresa), "Id", "Nome");
            ViewBag.FornecedorID = new SelectList(/*db.Fornecedores*/FornecedorDAO.ListarFornecedoresPorLogin(empresa), "Id", "Nome");

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Quantidade,FornecedorID,CategoriaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                Empresa empresa = new Empresa();
                var list = new List<Produto>();

                empresa = EmpresaDAO.BuscarEmpresaPorLogin();
                produto.Empresa = empresa;

                if (empresa.Produtos != null)
                {
                    list = empresa.Produtos;
                }

                list.Add(produto);
                empresa.Produtos = list;
                EmpresaDAO.Alterarempresa(empresa);
                return RedirectToAction("Index");
            }
            Empresa empre = new Empresa();
            empre = EmpresaDAO.BuscarEmpresaPorLogin();

            ViewBag.CategoriaID = new SelectList(CategoriaDAO.ListarCategoriasPorLogin(empre), "Id", "Nome", produto.CategoriaID);
            ViewBag.FornecedorID = new SelectList(FornecedorDAO.ListarFornecedoresPorLogin(empre), "Id", "Nome", produto.FornecedorID);
            return View(produto);
        }

        // GET: Produtos/Edit/5
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
            Empresa empresa = new Empresa();
            empresa = EmpresaDAO.BuscarEmpresaPorLogin();

            ViewBag.CategoriaID = new SelectList(CategoriaDAO.ListarCategoriasPorLogin(empresa), "Id", "Nome", produto.CategoriaID);
            ViewBag.FornecedorID = new SelectList(FornecedorDAO.ListarFornecedoresPorLogin(empresa), "Id", "Nome", produto.FornecedorID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Quantidade,FornecedorID,CategoriaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                Produto produtoAux = ProdutoDAO.BuscarProdutoPorId(produto.Id);
                produtoAux.Nome = produto.Nome;
                produtoAux.Quantidade = produto.Quantidade;
                produtoAux.FornecedorID = produto.FornecedorID;
                produtoAux.CategoriaID = produto.CategoriaID;
                if (ProdutoDAO.AlterarProduto(produtoAux))
                {
                    return RedirectToAction("Index");
                }
            }
            Empresa empresa = new Empresa();
            empresa = EmpresaDAO.BuscarEmpresaPorLogin();

            ViewBag.CategoriaID = new SelectList(CategoriaDAO.ListarCategoriasPorLogin(empresa), "Id", "Nome", produto.CategoriaID);
            ViewBag.FornecedorID = new SelectList(FornecedorDAO.ListarFornecedoresPorLogin(empresa), "Id", "Nome", produto.FornecedorID);
            return View(produto);
        }

        // GET: Produtos/Delete/5
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

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ProdutoDAO.ExcluirProduto(produto);
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
