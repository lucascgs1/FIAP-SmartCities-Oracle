using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Api.Models
{
    [Table("PASSAGEM")]
    public class Passagem
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("HORARIO_PARTIDA")]
        public DateTime HorarioPartida { get; set; }

        [Column("PRECO")]
        public float Preco { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("USUARIO_ID")]
        [ForeignKey("USUARIO")]
        public int UsuarioId { get; set; }

        [Column("VIAGEM_ID")]
        [ForeignKey("VIAGEM")]
        public int ViagemId { get; set; }

        [Column("ROTA_PARADA_ID")]
        [ForeignKey("ROTA_PARADA")]
        public int RotaParadaId { get; set; }

        public virtual Viagem Viagem { get; set; }

        public virtual RotaParada RotaParada { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}