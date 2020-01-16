using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenSink.Core.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KitchenSinkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public List<Customer> Get(int? id = null)
        {

        }
    }
}