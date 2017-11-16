using GerenciadorDeEstoque.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.DAL
{
    public class FornecedorDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        public static List<Fornecedor> ListarFornecedores()
        {
            return entities.Fornecedores.ToList();
        }

        public static bool CadastrarFornecedores(Fornecedor Fornecedor)
        {
            try
            {
                if (BuscarFornecedorPorNome(Fornecedor) == null)
                {

                    entities.Fornecedores.Add(Fornecedor);
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



        public static Fornecedor BuscarFornecedorPorNome(Fornecedor Fornecedor)
        {
            return entities.Fornecedores.FirstOrDefault(x => x.Nome.Equals(Fornecedor.Nome));
        }

        public static Fornecedor BuscarFornecedorPorId(int? id)
        {

            return entities.Fornecedores.Include("Fornecedor").FirstOrDefault(x => x.Id == id);
        }

        public static bool AlterarFornecedor(Fornecedor Fornecedor)
        {
            try
            {
                entities.Entry(Fornecedor).State = EntityState.Modified;
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ExcluirFornecedor(Fornecedor Fornecedor)
        {
            try
            {
                entities.Fornecedores.Remove(Fornecedor);
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