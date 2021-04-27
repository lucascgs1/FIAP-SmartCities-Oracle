using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Api.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("ENDERECO")]
        public string Endereco { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("TELEFONE")]
        public string Telefone { get; set; }
    }
}