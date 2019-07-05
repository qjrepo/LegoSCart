using System;
namespace Asplego.Models
{
    public class Checkout
    {

        public string userEmail { get; set; }
        public Lego list { get; set; }
        public int count { get; set; }


        public Checkout(string userEmail1, Lego list1,int count1)
        {

            userEmail = userEmail1;
            list = list1;
            count = count1;


        }
    }


}