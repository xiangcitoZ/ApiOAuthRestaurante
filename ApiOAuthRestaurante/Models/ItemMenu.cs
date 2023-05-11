using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOauthRestaurante.Models
{
    [Table("ItemMenu")]
    public class ItemMenu
    {
        [Key]
        [Column("IdMenu")]
        public int IdMenu { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Categoria")]
        public string Categoria { get; set; }
        [Column("Imagen")]
        public string Imagen { get; set; }
        [Column("Precio")]
        public decimal Precio { get; set; }
       

    }
}
