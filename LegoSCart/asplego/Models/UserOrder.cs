using System;
namespace Asplego.Models
{
    public class UserOrder
    {
        public string Ordertime;
        public string Useraccount;
        public int LegoId;
        public int Quantity;
        public int Payaccount;

        public UserOrder(string ordertime, string useracc, int legoid, int quantity, int payacc)
        {

            Ordertime = ordertime;
            Useraccount = useracc;
            LegoId = legoid;
            Quantity = quantity;
            Payaccount = payacc;


        }

    }
}