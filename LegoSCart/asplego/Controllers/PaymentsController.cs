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
    public class PaymentsController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        PaymentsManager pm = new PaymentsManager();
        // GET api/Payments
        [HttpGet]
        public string Get()
        {
            logger.Trace("get all Payments");
            var Payments = pm.GetAll;
            return JsonConvert.SerializeObject(Payments);
        }

        //// GET api/Payments/email,password
        [HttpGet("{ep}")]
        public async Task<IEnumerable<Payment>> Get(int cardnumber)
        {
            logger.Trace("search whether payment is in db");
            return await GetAsync(cardnumber);
        }
        private Task<IEnumerable<Payment>> GetAsync(int cardnumber)
        {
            return Task.FromResult(pm.GetPaymentsByCard(cardnumber));
        }

        [HttpPost]
        // POST: api/student
        public void PostPayment(Payment Payment)
        {
            pm.AddPayment(Payment);


        }




        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Post02")]
        public async Task<StatusCodeResult> Post02([FromBody] Payment p)
        {

            if (pm == null)
            {

                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            logger.Trace("add new payment");
            pm.AddPayment(p);

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

