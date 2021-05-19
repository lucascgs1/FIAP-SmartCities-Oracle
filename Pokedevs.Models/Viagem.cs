using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Models
{
    [Table("VIAGEM")]
    public class Viagem
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("DATA_VIAGEM")]
        public DateTime DataViagem { get; set; }

        [Column("DESTINO")]
        public string Destino { get; set; }

        [Column("ORIGEM")]
        public string Origem { get; set; }

        [Column("VEICULO_ID")]
        [ForeignKey("VEICULO")]
        public int VeiculoId { get; set; }

        [Column("ROTA_ID")]
        [ForeignKey("ROTA")]
        public int RotaId { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual Rota Rota { get; set; }

        public virtual Veiculo Veiculo { get; set; }
    }
}