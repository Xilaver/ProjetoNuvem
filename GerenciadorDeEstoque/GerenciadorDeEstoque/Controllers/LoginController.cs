using GerenciadorDeEstoque.DAL;
using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciadorDeEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtLogin, string txtSenha)
        {
            Empresa Empresa = new Empresa();

            Empresa.Login = txtLogin;
            Empresa.Senha = txtSenha;

            if (EmpresaDAO.Login(Empresa))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login ou senha invalidos!");
                //return RedirectToAction("Index", "Login");
            }
            return View();
        }


    }
}