using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Models
{
    [Table("ROTA")]
    public class Rota
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("EMBARQUE")]
        public string Embarque { get; set; }

        [Column("DESTINO")]
        public string Destino { get; set; }

        [Column("PRECO")]
        public float Preco { get; set; }

        [Column("TEMPO_VIAGEM")]
        public DateTime TempoViagen { get; set; }

        [Column("HORA_EMBARQUE")]
        public DateTime HoraEmbarque { get; set; }

        [Column("HORA_CHEGADA")]
        public DateTime HoraChegada { get; set; }

        [Column("NUMERO_PARADA")]
        public int NumeroParada { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}