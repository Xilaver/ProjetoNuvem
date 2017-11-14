using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string  Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }
    }
}