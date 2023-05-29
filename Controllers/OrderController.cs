using bmb.Entities;
using bmb.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        readonly IOrder _order;
        private readonly bmbContext _dbContext;
      //  private readonly HttpContext Context;


        public OrderController(bmbContext dbContext, IOrder order)
        {
            _order = order;
            _dbContext = dbContext;
           // Context = contextAccessor.HttpContext;

        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] Orders obj)
        {

            return Ok(await _order.CreateOrder(obj));
        }
        [HttpDelete("Delete/{CustomerCode}")]
        public async Task<IActionResult> Delete([FromRoute] int CustomerCode)
        {

            return Ok(await _order.Delete(CustomerCode));
        }

        [HttpGet("GetAllOrdersByCustomerId/{CustomerCode}")]
        public async Task<IActionResult> GetAllOrdersByCustomerId([FromRoute] int CustomerCode)
        {

            return Ok(await _order.GetAllOrdersByCustomerId(CustomerCode));
        }
        [HttpGet("GetAllOrdersByOrderId/{OrderCode}")]
        public async Task<IActionResult> GetAllOrdersByOrderId([FromRoute] int OrderCode)
        {

            return Ok(await _order.GetAllOrdersByOrderId(OrderCode));
        }
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {

            return Ok(await _order.GetAllOrders());
        }
    }
}
