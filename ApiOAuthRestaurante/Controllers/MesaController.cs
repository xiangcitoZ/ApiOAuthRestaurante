using ApiOauthRestaurante.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuggetRestauranteXZX.Models;

namespace ApiOAuthRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private RepositoryMenu repo;

        public MesaController(RepositoryMenu repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Mesa>>> GetMesa()
        {
           return await this.repo.GetMesasAsync();
           
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> CreateMesa(Mesa mesa)
        {
            await this.repo.InsertMesaAsync
                (mesa.Estado
                , mesa.Cantidad);
            return Ok();
        }
       
        [HttpPut("{idmesa}")]
        public async Task<ActionResult> UpdateMesa(Mesa mesa)
        {
            await this.repo.UpdateMesaAsync
                (mesa.IdMesa, mesa.Estado
                , mesa.Cantidad);
            return Ok();
        }
        [HttpDelete("{idmesa}")]
        public async Task<ActionResult> DeleteMesa(int idmesa)
        {
            await this.repo.DeleteMesaAsync(idmesa);
            return Ok();
        }

    }
}
