using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace miliostore.Model
{
    public class Produto
    {
        [Key] //Primary Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY(1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Console { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateOnly DataLancamento { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string Foto { get; set; } = string.Empty;

        //Chave estrangeira
        public virtual Categoria? Categoria { get; set; }

        public virtual User? Usuario { get; set; }
    }
}
