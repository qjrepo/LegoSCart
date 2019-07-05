using System;
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
    public class RemoveOneController : Controller
    {
        CheckoutManager cm = new CheckoutManager();
        private List<Checkout> checkoutlist = new List<Checkout>();
        private string a;
        private List<string> alist = new List<string>();
        private string b;

        [HttpGet]
        public string Get()
        {
            var checklists = cm.GetAll;

            return JsonConvert.SerializeObject(checklists);
        }





        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Remove1")]
        public async Task<StatusCodeResult> Remove1([FromBody] Checkout lego)
        {
            b = lego.userEmail + lego.list.Name;
            checkoutlist = (System.Collections.Generic.List<Asplego.Models.Checkout>)cm.GetAll;
            foreach (var element in checkoutlist)
            {
                a = element.userEmail + element.list.Name;
                alist.Add(a);
            }

            if (!checkoutlist.Count.Equals(0))
            {
                if (alist.Contains(b))
                {
                    foreach (var i in cm.GetAll)
                    {
                        if (lego.list.Name.Equals(i.list.Name) && lego.userEmail.Equals(i.userEmail))
                        { i.count -= 1; }

                    }

                     checkoutlist.RemoveAll(o => o.count.Equals(0));
                }
            }
           
            return new StatusCodeResult(201); //created }

        }



    }
}
