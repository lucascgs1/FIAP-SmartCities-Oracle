using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Models
{
    [Table("ROTA_PARADA")]
    public class RotaParada
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ROTA_ID")]
        [ForeignKey("ROTA")]
        public int RotaId { get; set; }

        [Column("PARADA_ID")]
        [ForeignKey("PARADA")]
        public int ParadaId { get; set; }

        public virtual Rota Rota { get; set; }

        public virtual Parada Parada { get; set; }
    }
}