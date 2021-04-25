using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Api.Models
{

    [Table("PRODUTO")]
    public class Produto
    {
        //Foreing Key
        [Column("IDTIPO")]
        public int IdTipo { get; set; }

        //Navigation Property
        public TipoProduto Tipo { get; set; }

        [Key]
        [Column("IDPRODUTO")]
        public int IdProduto { get; set; }

        [Column("NOMEPRODUTO")]
        public string NomeProduto { get; set; }

        [Column("CARACTERISTICAS")]
        public string Caracteristicas { get; set; }

        [Column("PRECOMEDIO")]
        public double PrecoMedio { get; set; }

        [Column("LOGOTIPO")]
        public string Logotipo { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [NotMapped]
        public virtual TipoProduto TipoProduto { get; set; }
    }


}
