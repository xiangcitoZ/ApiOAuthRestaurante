namespace ApiOauthRestaurante.Models
{
    public class DatosMenuPedidos
    {
        public List<Pedido> Pedidos { get; set; }
        public List<ItemMenu> Items { get; set; }   

        public List<Mesa> Mesas { get; set; }

    }
}
