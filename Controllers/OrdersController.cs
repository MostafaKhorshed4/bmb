using bmb.Entities;
using bmb.Interfaces;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
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
    [ODataRoutePrefix("orders")]
    public class OrdersController : ODataController
    {

        private readonly bmbContext _dbContext;


        public OrdersController(bmbContext dbContext )
        {
            _dbContext = dbContext;

        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return (IActionResult)Ok(_dbContext.orders);
        }
        
    }
}
