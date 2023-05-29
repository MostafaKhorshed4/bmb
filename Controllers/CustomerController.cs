using bmb.Entities;
using bmb.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bmb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        readonly ICustomer _Customer;
        public CustomerController(ICustomer Customer)
        {
            _Customer = Customer;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login( Customer customer)
        {
            var ret = await _Customer.Login (customer.name, customer.password);
            
            return Ok(ret);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(Customer customer )
        {
            var ret = await _Customer.Registration(customer);

            return Ok(ret);
        }

    }
}
