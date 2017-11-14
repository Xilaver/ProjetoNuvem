using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.DAL
{
    public class ProdutoDAO
    {

        private static Entities entities = Singleton.Instance.Entities;

        public static List<Produto> ListarProdutos()
        {
            return entities.Produtos.ToList();
        }

        public static bool CadastrarProduto(Produto Produto)
        {
            try
            {
                if (BuscarProdutoPorNome(Produto) == null)
                {

                    entities.Produtos.Add(Produto);
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



        public static Produto BuscarProdutoPorNome(Produto Produto)
        {
            return entities.Produtos.FirstOrDefault(x => x.Nome.Equals(Produto.Nome));
        }

        public static Produto BuscarProdutoPorId(int? id)
        {
            
            return entities.Produtos.Include("Ingredientes").FirstOrDefault(x => x.Id == id);
        }

        public static bool AlterarProduto(Produto Produto)
        {
            try
            {
                entities.Entry(Produto).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool ExcluirProduto(Produto Produto)
        {
            try
            {
                entities.Produtos.Remove(Produto);
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