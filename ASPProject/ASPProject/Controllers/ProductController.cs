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
    public class ProductController : ControllerBase
    {
        private readonly IProductManager manager;
        public ProductController(IProductManager productManager)
        {
            this.manager = productManager;
        }

        [HttpGet("id/{id}")]
        
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var prod = manager.GetById(id);

            return Ok(prod);
        }

        [HttpGet("read")]
        public async Task<IActionResult> GetProducts()
        {
            var prod = manager.GetProducts();
            return Ok(prod);
        }

        [HttpPost("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProductBlueprint prodBl)
        {
            manager.Create(prodBl);
            return Ok();
        }

        [HttpPut("update")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ProductBlueprint prodBl)
        {
            manager.Update(prodBl);
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
