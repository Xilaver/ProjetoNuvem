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
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Quantidade de Produto")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Produto")]
        public Fornecedor Fornecedor { get; set; }

        public Categoria Categoria { get; set; }

    }
}