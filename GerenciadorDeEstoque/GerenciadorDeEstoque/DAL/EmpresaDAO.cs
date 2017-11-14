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


        public static Empresa BuscarEmpresaPorLoginESenha(Empresa Empresa)
        {
            return entities.Empresas.FirstOrDefault(x => x.Nome.Equals(Empresa.Nome) && x.Senha.Equals(Empresa.Senha));
        }
        public static bool Login(Empresa Empresa)
        {
            if (EmpresaDAO.BuscarEmpresaPorLoginESenha(Empresa) != null)
            {
                if (HttpContext.Current.Session["Login"] == null)
                {
                    HttpContext.Current.Session["Login"] = Empresa.Nome;
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