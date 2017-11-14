using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.Models
{
    public class Entities : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<GerenciadorDeEstoque.Models.Fornecedor> Fornecedors { get; set; }

        public System.Data.Entity.DbSet<GerenciadorDeEstoque.Models.Produto> Produtoes { get; set; }
    }
}