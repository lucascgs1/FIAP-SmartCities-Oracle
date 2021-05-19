using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("SOBRENOME")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Sobrenome { get; set; }

        [Column("EMAIL")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [EmailAddress]
        [Display(Name = "E-mail", Prompt = "Digite o {0}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "E-mail", Prompt = "Digite o {0}")]
        [Column("SENHA")]
        public string Senha { get; set; }

        [Column("ENDERECO")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Endereço", Prompt = "Digite o {0}")]
        public string Endereco { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Telefone", Prompt = "Digite o {0}")]
        public string CPF { get; set; }

        [Column("TELEFONE")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Phone]
        [Display(Name = "Telefone", Prompt = "Digite o {0}")]
        public string Telefone { get; set; }

        [Column("CODIGO_SEGURANCA")]
        [Display(Name = "Codigo de segurança", Prompt = "Digite o {0}")]
        public string CodigoSeguranca { get; set; }

        [Column("DATA_CADASTRO")]
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data", Prompt = "Digite o {0}")]
        public DateTime DataCadastro { get; set; }
    }
}