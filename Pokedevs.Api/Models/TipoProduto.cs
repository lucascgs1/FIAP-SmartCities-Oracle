using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedevs.Api.Models
{
    [Table("TIPOPRODUTO")]
    public class TipoProduto
    {
        [Key]
        [Column("IDTIPO")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(50, ErrorMessage = "A descrição deve ter no máximo 50 caracteres")]
        [Display(Name = "Descrição:")]
        [Column("DESCRICAOTIPO")]
        public string DescricaoTipo { get; set; }

        [Column("COMERCIALIZADO")]
        public char Comercializado { get; set; }

        //Navigation Property
        public IList<Produto> Produtos { get; set; }


    }
}
