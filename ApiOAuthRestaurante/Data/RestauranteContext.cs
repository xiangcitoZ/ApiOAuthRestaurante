using Microsoft.EntityFrameworkCore;
using NuggetRestauranteXZX.Models;
using System.Collections.Generic;


namespace ApiOauthRestaurante.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }


        public DbSet<ItemMenu> ItemMenu { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Mesa> Mesa { get; set; }

        public DbSet<Usuario> Usuario { get; set; }


    }
}
