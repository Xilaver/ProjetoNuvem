using GerenciadorDeEstoque.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorDeEstoque.Controllers
{
    public class SairController : Controller
    {
        // GET: Sair
        public ActionResult Index()
        {
            if (EmpresaDAO.EstaLogado() == true)
            {
                EmpresaDAO.Logout();
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}