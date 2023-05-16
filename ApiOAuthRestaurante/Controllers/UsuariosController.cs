using ApiOauthRestaurante.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuggetRestauranteXZX.Models;
using System.Security.Claims;

namespace ApiOAuthRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private RepositoryMenu repo;

        public UsuariosController(RepositoryMenu repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Usuario>> PerfilUsuario()
        {
            //DEBEMOS BUSCAR EL CLAIM DEL EMPLEADO
            Claim claim = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "USERDATA");
            string jsonUsuario =
                claim.Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>
                (jsonUsuario);
            return usuario;
        }

    }
}
