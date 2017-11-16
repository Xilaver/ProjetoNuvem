using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.DAL
{
    public class EmpresaDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        public static List<Empresa> ListarEmpresas()
        {
            return entities.Empresas.ToList();
        }

        public static bool CadastrarEmpresa(Empresa Empresa)
        {
            try
            {
                if (BuscarempresaPorTitulo(Empresa) == null)
                {
                    entities.Empresas.Add(Empresa);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public static Empresa BuscarempresaPorTitulo(Empresa Empresa)
        {
            return entities.Empresas.FirstOrDefault(x => x.Nome.Equals(Empresa.Nome));
        }

        public static Empresa BuscarEmpresaPorId(int? id)
        {
            return entities.Empresas.Find(id);
        }

        public static Empresa BuscarEmpresaPorLogin()
        {
            string login = HttpContext.Current.Session["Login"].ToString();
            return entities.Empresas.FirstOrDefault(x => x.Login.Equals(login));
        }

        public static bool Alterarempresa(Empresa Empresa)
        {
            try
            {
                entities.Entry(Empresa).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool ExcluirEmpresa(Empresa Empresa)
        {
            try
            {
                entities.Empresas.Remove(Empresa);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Empresa BuscarEmpresaPorLoginESenha(Empresa Empresa)
        {
            return entities.Empresas.FirstOrDefault(x => x.Login.Equals(Empresa.Login) && x.Senha.Equals(Empresa.Senha));
        }
        public static bool Login(Empresa Empresa)
        {
            if (EmpresaDAO.BuscarEmpresaPorLoginESenha(Empresa) != null)
            {
                if (HttpContext.Current.Session["Login"] == null)
                {
                    HttpContext.Current.Session["Login"] = Empresa.Login;
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