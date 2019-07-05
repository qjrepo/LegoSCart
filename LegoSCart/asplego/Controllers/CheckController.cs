using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asplego.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asplego.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CheckController : Controller
    {
        CheckoutManager cm = new CheckoutManager();
        private List<Checkout> checkoutlist = new List<Checkout>();
      
        private List<string> alist = new List<string>();
      
        [HttpGet]
        public string Get()
        {
            var checklists = cm.GetAll;

            return JsonConvert.SerializeObject(checklists);
        }




        string email;

        [HttpPost("{lego}")]
        [Route("[action]")]
        [ActionName("Remove2")]
        public async Task<StatusCodeResult> Remove2([FromBody]Checkout lego)
        {
            email = lego.userEmail;
            cm.DeletebyeEmail(email);
            return new StatusCodeResult(201);

        }



       



    }





}
