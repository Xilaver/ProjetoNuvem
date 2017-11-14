using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.DAL
{
    public class EmpresaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;


        public static Empresa BuscarEmpresaPorLoginESenha(Empresa empresa)
        {
            return entities.Empresas.FirstOrDefault(x => x.Login.Equals(empresa.Login) && x.Senha.Equals(empresa.Senha));
        }
        public static bool Login(Empresa empresa)
        {
            if (EmpresaDAO.BuscarEmpresaPorLoginESenha(empresa) != null)
            {
                if (HttpContext.Current.Session["Login"] == null)
                {
                    HttpContext.Current.Session["Login"] = empresa.Nome;
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        public static void Logout()
        {
            if (HttpContext.Current.Session["Login"] != null)
            {
                HttpContext.Current.Session["Login"] = null;
            }
        }
        public static bool EstaLogado()
        {
            if (HttpContext.Current.Session["Login"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}