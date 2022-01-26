using ASPProject.Models.Blueprints;
using ASPProject.Services.OtherServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager manager;
        public CategoryController (ICategoryManager categManager)
        {
            this.manager = categManager;
        }

        [HttpGet("id/{id}")]
        
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var categ = manager.GetById(id);

            return Ok(categ);
        }

        [HttpGet("read")]
        public async Task<IActionResult> GetCategories()
        {
            var categs = manager.GetCategories();
            return Ok(categs);
        }

        [HttpPost("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] CategoryBlueprint catBl)
        {
            manager.Create(catBl);
            return Ok();
        }

        [HttpPut("update")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] CategoryBlueprint catBl)
        {
            manager.Update(catBl);
            return Ok();
        }


        [HttpDelete("delete/{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            manager.Delete(id);

            return Ok();
        }



    }
}
