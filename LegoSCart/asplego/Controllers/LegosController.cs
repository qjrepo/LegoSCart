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
    public class LegosController : Controller
    {
        UserOrderManager uom = new UserOrderManager();
        CheckoutManager cm = new CheckoutManager();
        LegosManager lm = new LegosManager();
        DateTime nowtime = new DateTime();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        // GET api/values
        [HttpGet]
        public string Get()

        {
            //           var legos = new Lego[] { new Lego{ID=1,Name="Big Ben",Type="Architecture",Price=249,Pieces=4163,Age="16+",Description="Get up close to Big Ben! The clock was first started on May 31st 1859, and Big Ben’s first chime rang from the 96-meter Elizabeth Tower on July 11th of the same year. This over 23” (60cm) high LEGO® interpretation of the iconic structure is a tribute to its engineering and architecture." },
            //          new Lego{ID=2,Name="The Joker™ Manor",Type="Film",Price=269,Pieces=3444,Age="14+",Description="The Joker™ Manor is packed with iconic details from the movie and cool functions, including a rollercoaster encircling the whole building, a huge buildable The Joker head with trapdoor and slide, punching boxing gloves, a rocking ‘The Joker’ sign and rotating ‘big eye’ tower." },
            //          new Lego{ID=3,Name="Assembly Square",Type="Architecture",Price=279,Pieces=4002,Age="16+",Description="Take a trip to the amazing Assembly Square, developed to celebrate ten years of LEGO® Modular Buildings, featuring a wealth of unsurpassed, intricate details and hidden surprises. " },
            //          new Lego{ID=4,Name= "Taj Mahal",Type= "Architecture",Price= 369,Pieces= 5923,Age= "16+",Description= "Build and discover the Taj Mahal! The huge ivory-white marble mausoleum, renowned as one of the world’s architectural wonders, was commissioned in 1631 by the Emperor Shah Jahan in memory of his wife, the Empress Mumtaz Mahal.  "},
            //          new Lego{ID=5,Name= "Porsche 911 GT3 RS",Type= "Car",Price= 299,Pieces= 2704,Age= "16+",Description= "Experience the iconic Porsche 911 GT3 RS with this authentic LEGO® Technic replica. Inside the box you’ll discover a special collector’s book chronicling the history of LEGO Technic and Porsche GT cars, together with 4 original-design rims bearing the RS emblem. "},
            //          new Lego{ID=6,Name= "The Disney Castle",Type= "Architecture",Price= 349,Pieces= 4080,Age= "16+",Description= "Bring the magical world of Disney to your home with The Disney Castle. This highly detailed LEGO® model with over 4,000 pieces offers a rewarding build and play experience, and comes with an array of exciting Disney-themed features and functions. "},
            //          new Lego{ID=7,Name= "Bugatti Chiron",Type="Car",Price= 349,Pieces= 3599,Age= "16+",Description= "Explore engineering excellence with the LEGO® Technic™ 42083 Bugatti Chiron advanced building set. This exclusive model has been developed in partnership with Bugatti Automobiles S. "},
            //          new Lego{ID=8,Name= "Hogwarts™ Castle",Type= "Film",Price= 399,Pieces= 6020,Age= "16+",Description= "Make the magic come alive at the LEGO® Harry Potter™ 71043 Hogwarts™ Castle! This highly detailed LEGO Harry Potter collectible has over 6,000 pieces and offers a rewarding build experience.  "},
            //          new Lego{ID=9,Name= "Millennium Falcon™",Type= "Film",Price= 799,Pieces= 7541,Age= "16+",Description= "This amazing LEGO interpretation of Han Solo’s unforgettable Corellian freighter has all the details that Star Wars fans of any age could wish for, including intricate exterior detailing, upper and lower quad laser cannons, landing legs, lowering boarding ramp and a 4-minifigure cockpit with detachable canopy.  "},
            //          new Lego{ID=10,Name= "Death Star™",Type= "Architecture",Price= 499,Pieces= 4002,Age= "16+",Description= "With over 4,000 pieces, this fantastic model has a galaxy of intricate and authentic environments, including a superlaser control room, Imperial conference chamber, hangar bay with moving launch rack and Lord Vader’s TIE Advanced with space for Vader inside, Emperor Palpatine’s throne room, Droid maintenance room, detention block, trash compactor, tractor beam, cargo area, turbo laser with spring-loaded shooters and seats for the 2 Death Star Gunners, and 2 movable turbo laser towers. "},

            //};       
            var legos = lm.GetAll;

            return JsonConvert.SerializeObject(legos);
        }


        [HttpPost]
        // [Route("api/[controller]/[action]")]
        [Route("[action]")]
        [ActionName("Post02")]
        public async Task<StatusCodeResult> Post02([FromBody] Ordercreate p)
        {

            if (uom == null)
            {

                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            logger.Trace("add new order in db");
            nowtime = System.DateTime.Now;

            foreach (var a in cm.GetAllemail(p.userEmail))
            {
                var now2 = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                UserOrder neworder = new UserOrder(now2, a.userEmail, a.list.ID, a.count, p.pid);
                uom.AddUserOrder(neworder);
                //return new StatusCodeResult(201); //created }

            }
            cm.DeletebyeEmail(p.userEmail);



            return new StatusCodeResult(201); //created }
        }


    }
}