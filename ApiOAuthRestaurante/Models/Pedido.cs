using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiOauthRestaurante.Models
{
    [Table("Pedido")]
    public class Pedido
    {

            [Key]
            [Column("IdPedido")]
            public int IdPedido { get; set; }
          
            [Column("Precio")]
            public decimal Precio { get; set; }
            [Column("Fecha")]
            public DateTime Fecha { get; set; }
            [Column("ItemsMenu")]
            public string ItemsMenu { get; set; }
            [Column("IdMesa")]
            public int IdMesa { get; set; }
            [Column("IdMenu")]
            public int IdMenu { get; set; }
            [Column("Cantidad")]
            public int Cantidad { get; set; }


    }
}
