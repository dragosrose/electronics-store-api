using ASPProject.Repositories.InterRepository;
using ASPProject.Services.GeneralServices;
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
    public class GeneralController : ControllerBase
    {
        private IGeneralManager manager;

        public GeneralController(IGeneralManager manager)
        {
            this.manager = manager;
        }

        [HttpGet("full_orders")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetOrdersWithProducts()
        {
            var ord = manager.GetOrdersWithProduct();
            return Ok(ord);
        }
    }
}
