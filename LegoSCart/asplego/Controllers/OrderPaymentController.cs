using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asplego.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Asplego.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class OrderPaymentsController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var orderpayments = new OrderPayment[] { new OrderPayment { } };
            return JsonConvert.SerializeObject(orderpayments);
        }
    }
}
