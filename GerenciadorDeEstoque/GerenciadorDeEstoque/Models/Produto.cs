using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Quantidade de Produto")]
        public int Quantidade { get; set; }

        public int FornecedorID { get; set; }

        [ForeignKey("FornecedorID")]
        public virtual Fornecedor Fornecedor { get; set; }

        public int CategoriaID { get; set; }

        [ForeignKey("CategoriaID")]
        public virtual Categoria Categoria { get; set; }

        public Empresa Empresa { get; set; }

    }
}