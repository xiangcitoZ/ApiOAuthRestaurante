using ApiOauthRestaurante.Data;
using Microsoft.EntityFrameworkCore;
using NuggetRestauranteXZX.Models;

namespace ApiOauthRestaurante.Repository
{
    public class RepositoryMenu
    {
        private RestauranteContext context;

        public RepositoryMenu(RestauranteContext context)
        {
            this.context = context;

        }

        //MENU

        public async Task<List<ItemMenu>> GetItemMenuAsync()
        {
            var consulta = from datos in this.context.ItemMenu
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<List<ItemMenu>> GetItemMenuCategoria(string categoria)
        {
            var consulta = from datos in this.context.ItemMenu
                           where datos.Categoria == categoria
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<ItemMenu> FindItemMenu(int idmenu)
        {
            var consulta = from datos in this.context.ItemMenu
                           where datos.IdMenu == idmenu
                           select datos;
            return await consulta.FirstAsync();
        }



        public async Task InsertItemMenuAsync
         (int idmenu, string nombre, string categoria, string imagen,
            decimal precio)
        {

            ItemMenu menu = new ItemMenu();

            menu.IdMenu = idmenu;
            menu.Nombre = nombre;
            menu.Categoria = categoria;
            menu.Imagen = imagen;
            menu.Precio = precio;


            this.context.ItemMenu.Add(menu);

            await this.context.SaveChangesAsync();
        }


        public async Task UpdateItemMenuAsync
             (int idmenu, string nombre, string categoria, string imagen,
                  decimal precio)
        {

            ItemMenu menu = await this.FindItemMenu(idmenu);

            menu.Nombre = nombre;
            menu.Categoria = categoria;
            menu.Imagen = imagen;
            menu.Precio = precio;


            await this.context.SaveChangesAsync();
        }


        public async Task DeleteItemMenuAsync(int idmenu)
        {
            ItemMenu menu = await this.FindItemMenu(idmenu);

            this.context.ItemMenu.Remove(menu);

            await this.context.SaveChangesAsync();
        }


        //PEDIDO

        public async Task<List<Pedido>> GetPedidos()
        {
            var consulta = from datos in this.context.Pedido
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<List<Pedido>> GetPedidosMesa(int idmesa)
        {
            var consulta = from datos in this.context.Pedido
                           where datos.IdMesa == idmesa
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Pedido> FindPedido(int idpedido)
        {
            var consulta = from datos in this.context.Pedido
                           where datos.IdPedido == idpedido
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        //public List<ItemMenu> GetItemMenuPedidos(int idmenu)
        //{
        //    var consulta = from datos in this.context.ItemMenu
        //                   where datos.IdMenu == idmenu
        //                   select datos;
        //    return consulta.ToList();
        //}


        public async Task InsertPedidoAsync
         (int idpedido, decimal precio, DateTime fecha, string itemsMenu,
            int idmesa, int idmenu, int cantidad)
        {

            Pedido pedido = new Pedido();

            pedido.IdPedido = idpedido;
            pedido.Precio = precio;
            pedido.Fecha = fecha;
            pedido.ItemsMenu = itemsMenu;
            pedido.IdMesa = idmesa;
            pedido.IdMenu = idmenu;
            pedido.Cantidad = cantidad;
            this.context.Pedido.Add(pedido);

            await this.context.SaveChangesAsync();
        }

        decimal total = 0;
        public decimal SumaPrecio(decimal precio)
        {
            total = +precio;
            return total;

        }

        public async Task UpdatePedidoAsync
              (int idpedido, decimal precio, DateTime fecha, string itemsMenu,
                 int idmesa, int idmenu, int cantidad)
        {

            Pedido pedido = await this.FindPedido(idpedido);

            pedido.Precio = precio;
            pedido.Fecha = fecha;
            pedido.ItemsMenu = itemsMenu;
            pedido.IdMesa = idmesa;
            pedido.IdMenu = idmenu;
            pedido.Cantidad = cantidad;

            await this.context.SaveChangesAsync();
        }



        public async Task DeletePedidoAsync(int idpedido)
        {
            Pedido pedido = await this.FindPedido(idpedido);

            this.context.Pedido.Remove(pedido);

            await this.context.SaveChangesAsync();
        }


        public async Task<List<Pedido>> BuscarPedidoPagar(int idmesa)
        {
            var consulta = from datos in this.context.Pedido
                           where datos.IdMesa == idmesa
                           select datos;
            return await consulta.ToListAsync();
        }



        public async Task PagarPedido(int idmesa)
        {
            List<Pedido> pedidos = await this.BuscarPedidoPagar(idmesa);

            foreach (var pedido in pedidos)
            {
                this.context.Pedido.Remove(pedido);
            }

            await this.context.SaveChangesAsync();
        }


        //MESA
        public async Task<List<Mesa>> GetMesasAsync()
        {
            var consulta = from datos in this.context.Mesa
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Mesa> FindMesaAsync(int idmesa)
        {
            var consulta = from datos in this.context.Mesa
                           where datos.IdMesa == idmesa
                           select datos;
            return await consulta.FirstAsync();
        }

    



        public async Task InsertMesaAsync
         (string estado, int cantidad)
        {
            //INSTANCIAR EL MODELO
            Mesa mesa = new Mesa();
            //ASIGNAMOS PROPIEDADES

            mesa.Estado = estado;

            mesa.Cantidad = cantidad;
            //AÑADIMOS EL MODEL A LA COLECCION CONTEXT
            this.context.Mesa.Add(mesa);
            //GUARDAMOS CAMBIOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }


        public async Task UpdateMesaAsync
             (int idmesa, string estado, int cantidad)
        {

            Mesa mesa = await this.FindMesaAsync(idmesa);

            mesa.Estado = estado;

            mesa.Cantidad = cantidad;

            await this.context.SaveChangesAsync();
        }



        public async Task DeleteMesaAsync(int idmesa)
        {

            Mesa mesa = await this.FindMesaAsync(idmesa);

            this.context.Mesa.Remove(mesa);

            await this.context.SaveChangesAsync();
        }



        public async Task MesaOcupado(int idmesa)
        {
            Mesa mesa = await this.FindMesaAsync(idmesa);

            mesa.Estado = "Ocupado";
 
            await this.context.SaveChangesAsync();
        }

        public async Task MesaLibre(int idmesa)
        {
            Mesa mesa = await this.FindMesaAsync(idmesa);

            mesa.Estado = "Libre";

            await this.context.SaveChangesAsync();
        }


    }

}
