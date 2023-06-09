﻿

using ApiOauthRestaurante.Repository;

using Microsoft.AspNetCore.Mvc;
using NuggetRestauranteXZX.Models;

namespace ApiOAuthRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMenuController : ControllerBase
    {
        private RepositoryMenu repo;

        public ItemMenuController(RepositoryMenu repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemMenu>>> GetItemMenu()
        {
            return await this.repo.GetItemMenuAsync();
        }


       

        [HttpGet("[action]/{categoria}")]
        public async Task<ActionResult<List<ItemMenu>>> GetItemMenuCategoria(string categoria)
        {
            return await this.repo.GetItemMenuCategoria(categoria);
        }


        [HttpGet("[action]/{idmenu}")]
        public async Task<ActionResult<ItemMenu>> FindItemMenu(int idmenu)
        {
            return await this.repo.FindItemMenu(idmenu);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult>
            CreateItemMenus(ItemMenu menu)
        {
            await this.repo.InsertItemMenuAsync
                (menu.IdMenu, menu.Nombre, menu.Categoria,
                menu.Imagen, menu.Precio);
            return Ok();
        }


        [HttpPut("{idmenu}")]
        public async Task<ActionResult> UpdateItemMenu(ItemMenu menu)
        {
            await this.repo.UpdateItemMenuAsync
               (menu.IdMenu, menu.Nombre, menu.Categoria,
                menu.Imagen, menu.Precio);
            return Ok();
        }

        [HttpDelete("{idmenu}")]
        public async Task<ActionResult> DeleteItemMenu(int idmenu)
        {
            await this.repo.DeleteItemMenuAsync(idmenu);
            return Ok();
        }


    }
}
