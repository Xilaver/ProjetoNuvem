using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GerenciadorDeEstoque.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "No maximo 50 caracteres")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 11 caracteres")]
        [MaxLength(50, ErrorMessage = "No maximo 15 caracteres")]
        [Display(Name = "Cnpj")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 8 caracteres")]
        [MaxLength(12, ErrorMessage = "No maximo 12 caracteres")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string telefone { get; set; }


        [Display(Name = "Email do Cliente")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "No maximo 20 caracteres")]
        [Display(Name = "Usuário")]
        public string usuario { get; set; }


        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(5, ErrorMessage = "No mínimo 5 caracteres")]
        [MaxLength(20, ErrorMessage = "No maximo 20 caracteres")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}