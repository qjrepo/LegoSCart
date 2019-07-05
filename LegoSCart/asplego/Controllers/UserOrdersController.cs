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
    public class UserOrdersController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        UserOrderManager uom = new UserOrderManager();
        CheckoutManager cm = new CheckoutManager();
        DateTime now = new DateTime();

        // GET api/userorder
        [HttpGet]
        public string Get()
        {
            logger.Trace("get all orders");
            var userorders = uom.GetAll;
            return JsonConvert.SerializeObject(userorders);
        }

        //// GET api/userorder/userid
        [HttpGet("{id}")]
        public async Task<IEnumerable<UserOrder>> Get(string id)
        {
            logger.Trace("search order in db");
            return await GetAsync(id);
        }
        private Task<IEnumerable<UserOrder>> GetAsync(string id)
        {
            return Task.FromResult(uom.GetUserordersByuseremail(id));
        }

        [HttpPost]
        // POST: api/student
        public void PostUserOrder(UserOrder userorder)
        {
            uom.AddUserOrder(userorder);


        }

        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Post03")]
        public async Task<StatusCodeResult> Post03([FromBody] int pid)
        {

            if (uom == null)
            {

                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            logger.Trace("add new order in db");

            foreach(var a in cm.GetAll)
            {
                var  now2 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

                UserOrder neworder = new UserOrder(now2,a.userEmail,a.list.ID,1,pid);
                uom.AddUserOrder(neworder);
                return new StatusCodeResult(201); //created }

            }


            return new StatusCodeResult(201); //created }
            //if (await PostAsyncPartOne(uo))
            //{

            //    return await PostAsyncPartTwo(uo);
            //}
            //else
            //{



            //}
        }

        //private Task<bool> PostAsyncPartOne(UserOrder uo)
        //{
        //    return Task.FromResult(uom.GetAll.Any(o => o.UserId.Equals(uo.UserId)));
        //}
        //private Task<StatusCodeResult> PostAsyncPartTwo(UserOrder uo)
        //{
        //    if (uom.EditUserOrder(uo))
        //    {
        //        return Task.FromResult(new StatusCodeResult(200)); //success 
        //    }
        //    else
        //    {
        //        return Task.FromResult(new StatusCodeResult(404)); //not found 
        //    }

        //}

    }
}
