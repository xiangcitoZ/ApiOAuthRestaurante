using ApiOauthRestaurante.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuggetRestauranteXZX.Models;

namespace ApiOAuthRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private RepositoryMenu repo;

        public PedidoController(RepositoryMenu repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> GetPedido()
        {
            return await this.repo.GetPedidos();  
        }



        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            await this.repo.InsertPedidoAsync
                (pedido.IdPedido, pedido.Precio, DateTime.Now,
                pedido.ItemsMenu, pedido.IdMesa, pedido.IdMenu, pedido.Cantidad);

            //await this.repo.MesaOcupado(pedido.IdMesa);

            return Ok();
            
        }



        [HttpPut("{idpedido}")]
        public async Task<ActionResult> UpdatePedido(Pedido pedido)
        {
            await this.repo.UpdatePedidoAsync
                (pedido.IdPedido, pedido.Precio, pedido.Fecha,
                pedido.ItemsMenu, pedido.IdMesa, pedido.IdMenu, pedido.Cantidad);
            return Ok();
        }

        [HttpDelete("{idpedido}")]
        public async Task<ActionResult> DeletePedido(int idpedido, Pedido pedido)
        {
            await this.repo.DeletePedidoAsync(idpedido);
            return Ok();
        }


    }
}
