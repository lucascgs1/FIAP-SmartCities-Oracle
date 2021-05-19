using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Models
{
    [Table("PARADA")]
    public class Parada
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("LOCAL")]
        public string Local { get; set; }

        [Column("LATITUDE")]
        public float? Latitude { get; set; }

        [Column("LONGITUDE")]
        public float? Longitude { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
    }
}