using System;
using System.Collections.Generic;
using System.Linq;

namespace Asplego.Models
{
    public class CheckoutManager
    {

            public static List<Checkout> checklists = new List<Checkout>();


        public IEnumerable<Checkout> GetAll { get { return checklists; } }

        public IEnumerable<Checkout> GetAllemail(string email) { return checklists.Where(o => o.userEmail.Equals(email)).ToList(); }

        public void AddLego(Checkout lego) { checklists.Add(lego); }

 

        public void DeleteLego() { checklists.Clear(); }

        public IEnumerable<Checkout> DeletebyeEmail(string email)
        {

            checklists.RemoveAll(o => o.userEmail.Equals(email));
            return checklists;


        }
    }
    }


