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
    public class UsersController : Controller
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
       
        UsersManager um = new UsersManager();
        // GET api/users
        [HttpGet]
        public string Get()
        {
            logger.Trace("get all users");
            var users = um.GetAll;
            return JsonConvert.SerializeObject(users);
        }

        //// GET api/users/email,password
        [HttpGet("{ep}")]
        public async Task<IEnumerable<User>> Get(string ep)
        {
            logger.Trace("search whether users is in db");
            return await GetAsync(ep);
        }
        private Task<IEnumerable<User>> GetAsync(string ep)
        {
            return Task.FromResult(um.GetUsersByEPassword(ep));
        }

        [HttpPost]
        // POST: api/student
        public void PostUser(User user)
        {
            um.AddUser(user);
            

        }




        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Post01")]
        public async Task<StatusCodeResult> Post01([FromBody] User u)
        {

            if (um == null)
            {

                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            logger.Trace("add new user");
            um.AddUser(u);
            return new StatusCodeResult(201);

            //if (um.GetUsersByEPassword(u.Email + u.Password).Equals(null))
            //{

            //    return new StatusCodeResult(201);
            //}else {
            //    return new StatusCodeResult(401);
            //}
            //if (await PostAsyncPartOne(u))
            //{

            //    return await PostAsyncPartTwo(u);
            //}
            //else
            //{

            //    um.AddUser(u);

            //    return new StatusCodeResult(201); //created }

            //}
        }

        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Post03")]
        public async Task<StatusCodeResult> Post03([FromBody] int pid)
        {

            //if (uom == null)
            //{

            //    return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            //}
            //logger.Trace("add new order in db");

            //foreach (var a in cm.GetAll)
            //{

            //    UserOrder neworder = new UserOrder(System.DateTime.Now, a.userEmail, a.list.ID, 1, pid);
            //    uom.AddUserOrder(neworder);
            //    return new StatusCodeResult(201); //created }

            //}


            return new StatusCodeResult(201); //created }
            //if (await PostAsyncPartOne(uo))
            //{

            //    return await PostAsyncPartTwo(uo);
            //}
            //else
            //{



            //}
        }

        //private Task<bool> PostAsyncPartOne(User u)
        //{
        //    return Task.FromResult(um.GetAll.Any(o => o.Email.Equals(u.Email)));
        //}
        //private Task<StatusCodeResult> PostAsyncPartTwo(User u)
        //{
        //    if (um.EditUser(u))
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
        //public async Task<StatusCodeResult> Put01([FromBody] User u)
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

        //        um.AddUser(u);
        //        //dbContext.Companies.Add(company);
        //        //await dbContext.SaveChangesAsync();
        //        return new StatusCodeResult(201); //created 
        //    }
        //}

    }
}

   

