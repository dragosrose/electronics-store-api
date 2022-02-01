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
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager manager;
        public OrderController(IOrderManager productManager)
        {
            this.manager = productManager;
        }

        [HttpGet("id/{id}")]
        
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var ord = manager.GetById(id);

            return Ok(ord);
        }
                
        [HttpGet("read")]
        public async Task<IActionResult> GetOrders()
        {
            var ord = manager.GetOrders();
            return Ok(ord);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderBlueprint ordBl)
        {
            manager.Create(ordBl);
            return Ok();
        }

        [HttpPut("update")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] OrderBlueprint ordBl)
        {
            manager.Update(ordBl);
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
