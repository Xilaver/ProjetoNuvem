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
        public ActionResult Index([Bind(Include = "Login,Senha")] Empresa empresa)
        {
            Empresa usuario = new Empresa();

            

            if (EmpresaDAO.Login(usuario))
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