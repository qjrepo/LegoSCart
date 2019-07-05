using System;
namespace Asplego.Models
{
    public class Payment
    {
        public int Cardnumber;
        public string Bankname;
        public string Holdname;
        public string Expiredate;
        public int CVS;

        public Payment(int cardnumber, string bankname, string holdname, string exp, int cvs)
        {

            Cardnumber = cardnumber;
            Bankname = bankname;
            Holdname = holdname;
            Expiredate = exp;
            CVS = cvs;


        }

    }
}
