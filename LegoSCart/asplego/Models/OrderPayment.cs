using System;
namespace Asplego.Models
{
    public class OrderPayment
    {
        public DateTime Ordertime;
        public int Userid;
        public int Paymentid;

        public OrderPayment(DateTime ordertime, int userid, int paymentid)
        {

            Ordertime = ordertime;
            Userid = userid;
            Paymentid = paymentid;
         


        }
    }
}
