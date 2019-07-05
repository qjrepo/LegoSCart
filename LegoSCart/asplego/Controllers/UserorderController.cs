using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asplego.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asplego.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UserorderController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        UserOrderManager uom = new UserOrderManager();
        // GET api/Userorder
        [HttpGet]
        public string Get()
        {
            logger.Trace("get all Payments");
            var Orders = uom.GetAll;
            return JsonConvert.SerializeObject(Orders);
        }

        //// GET api/userorder/username
        [HttpGet("{useremail}")]
        public async Task<IEnumerable<UserOrder>> Get(string useremail)


        {
            logger.Trace("search whether payment is in db");
            return await GetAsync(useremail);
        }
        private Task<IEnumerable<UserOrder>> GetAsync(string useremail)
        {
            return Task.FromResult(uom.GetUserordersByuseremail(useremail));
        }







        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Post03")]
        public async Task<StatusCodeResult> Post03([FromBody] int p)
        {

            if (uom == null)
            {

                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            logger.Trace("add new order");
            //.AddPayment(p);

            return new StatusCodeResult(201); //created }

            //if (await PostAsyncPartOne(p))
            //{

            //    return await PostAsyncPartTwo(p);
            //}
            //else
            //{


            //}
        }




        //private Task<bool> PostAsyncPartOne(Payment p)
        //{
        //    return Task.FromResult(pm.GetAll.Any(o => o.Paymentid.Equals(p.Paymentid)));
        //}
        //private Task<StatusCodeResult> PostAsyncPartTwo(Payment p)
        //{
        //    if (pm.EditPayment(p))
        //    {
        //        return Task.FromResult(new StatusCodeResult(200)); //success 
        //    }
        //    else
        //    {
        //        return Task.FromResult(new StatusCodeResult(404)); //not found 
        //    }

        //}



        //// add new or edit
        //[HttpPut]
        //[Route("api/[controller]/[action]")]
        //[ActionName("Put01")]
        //public async Task<StatusCodeResult> Put01([FromBody] Payment u)
        //{

        //    if (u == null)
        //    {

        //        return new Microsoft.AspNetCore.Mvc.BadRequestResult();
        //    }
        //    if (await PostAsyncPartOne(u))
        //    {

        //        return await PostAsyncPartTwo(u);
        //    }
        //    else
        //    {

        //        pm.AddPayment(u);
        //        //dbContext.Companies.Add(company);
        //        //await dbContext.SaveChangesAsync();
        //        return new StatusCodeResult(201); //created 
        //    }
        //}


    }
}
