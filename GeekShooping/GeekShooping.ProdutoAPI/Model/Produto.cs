using GeekShooping.ProdutoAPI.Model.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.ProdutoAPI.Model
{
    [Table("Produto")]
    public class Produto : BaseEntity
    {
        [Column("Nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("Preco")]
        [Required]
        public decimal Preco { get; set; }

        [Column("Descricao")]
        [StringLength(255)]
        public string Descricao { get; set; }

        [Column("Categoria")]
        [StringLength(50)]
        public string Categoria { get; set; }

        [Column("ImagemUrl")]
        [StringLength(150)]
        public string ImagemUrl { get; set; }
    }
}
