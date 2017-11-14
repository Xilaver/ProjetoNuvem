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
            Empresa empresa = new Empresa();

            empresa.Login = txtLogin;
            empresa.Senha = txtSenha;

            if (EmpresaDAO.Login(empresa))
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