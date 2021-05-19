using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Models
{
    [Table("VEICULO")]
    public class Veiculo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("PLACA")]
        public string Placa { get; set; }

        [Column("QTD_ASSENTOS")]
        public int Qtd_assentos { get; set; }

        [Column("ANO")]
        public int Ano { get; set; }

        [Column("TIPO_VEICULO")]
        public string TipoVeiculo { get; set; }

        [Column("WIFI")]
        public bool Wifi { get; set; }

        [Column("BANHEIRO")]
        public bool Banheiro { get; set; }

        [Column("LANCHES")]
        public bool Lanches { get; set; }

        [Column("AR_CONDICIONADO")]
        public bool ArCondicionado { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}