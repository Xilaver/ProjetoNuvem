using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.DAL
{
    public class CategoriaDAO
    {

        private static Entities entities = Singleton.Instance.Entities;

        public static List<Categoria> ListarCategoriasPorLogin(/*Empresa empresa*/)
        {
            return entities.Categorias.ToList();
        }

        public static bool CadastrarCategoria(Categoria Categoria)
        {
            try
            {
                if (BuscarCategoriaPorTitulo(Categoria) == null)
                {
                    entities.Categorias.Add(Categoria);
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

        public static Categoria BuscarCategoriaPorTitulo(Categoria Categoria)
        {
            return entities.Categorias.FirstOrDefault(x => x.Nome.Equals(Categoria.Nome));
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return entities.Categorias.Find(id);
        }

        public static bool AlterarCategoria(Categoria Categoria)
        {
            try
            {
                entities.Entry(Categoria).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool ExcluirCategoria(Categoria Categoria)
        {
            try
            {
                entities.Categorias.Remove(Categoria);
                entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}