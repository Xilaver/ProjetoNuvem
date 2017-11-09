using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(40, ErrorMessage = "No maximo 40 caracteres")]
        [Display(Name = "Nome da Categoria")]
        public string nome { get; set; }

    }
}