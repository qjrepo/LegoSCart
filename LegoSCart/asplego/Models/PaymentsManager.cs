using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asplego.Models
{
    public class PaymentsManager
    {
        public static List<Payment> _payment = new List<Payment>();


        public void savepayindb(List<Payment> p)
        {
            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            MySqlConnection msql = new MySqlConnection(Conectstring);


            msql.Open();
            foreach (var i in p)
            {
                // check if the user info has already exist in database
                MySqlCommand cmdmysql = msql.CreateCommand();
                int iid = i.Cardnumber;
                int number = 0;
                string query = "SELECT count(*) AS Number FROM paymentinfo where Cardnumber = " + iid;
                var cmmd = new MySqlCommand(query, msql);

                using (var read = cmmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        number = Convert.ToInt32(read["Number"]);
                    }
                }
                if (number == 0)
                {
                    //insert user info into database


                        cmdmysql.CommandText = "INSERT INTO paymentinfo(Cardnumber,Bankname,Holdname,Expiredate,CVS) VALUES (@cardnumber,@bankname,@holdname,@expiredate,@cvs);";
                        cmdmysql.Parameters.Add("@cardnumber", MySqlDbType.Int16).Value = i.Cardnumber;
                        cmdmysql.Parameters.Add("@bankname", MySqlDbType.VarChar).Value = i.Bankname;
                        cmdmysql.Parameters.Add("@holdname", MySqlDbType.VarChar).Value = i.Holdname;
                        cmdmysql.Parameters.Add("@expiredate", MySqlDbType.VarChar).Value = i.Expiredate;
                        cmdmysql.Parameters.Add("@cvs", MySqlDbType.Int16).Value = i.CVS;
                        cmdmysql.ExecuteNonQuery();



                }
            }

        }

        public IEnumerable<Payment> readpayinmysql()
        {
            List<Payment> _pp = new List<Payment>();

            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            //MySqlConnection msql = new MySqlConnection(Conectstring);

            MySqlConnection msql = new MySqlConnection(Conectstring);
            msql.Open();
            MySqlCommand cmdmysql = msql.CreateCommand();
            string query = "SELECT * FROM paymentinfo";
            var cmmd = new MySqlCommand(query, msql);

            //read data from database and convert to lego type
            using (var read = cmmd.ExecuteReader())
            {
                while (read.Read())
                {
               
                    int cardnumber = Convert.ToInt32(read["Cardnumber"]);
                    string bankname = Convert.ToString(read["Bankname"]);
                    string holdname = Convert.ToString(read["Holdname"]);
                    string expiredate = Convert.ToString(read["Expiredate"]);
                    int cvs = Convert.ToInt32(read["CVS"]);
                    _pp.Add(new Payment(cardnumber, bankname, holdname, expiredate, cvs));
                }

            }

            return _pp;

        }


        public IEnumerable<Payment> GetAll
        {
            get
            {
                savepayindb(_payment);

                return readpayinmysql();
            }
        }

        public IEnumerable<Payment> GetPaymentsByCard(int cardnumber)
        {
            return readpayinmysql().Where(o => (o.Cardnumber).Equals(cardnumber)).ToList();
            //return _students.Where(...).ToList();
        }

        public void AddPayment(Payment p) { _payment.Add(p); }

        public bool EditPayment(Payment p)
        {
            var _p = _payment.FirstOrDefault(o => o.Cardnumber.Equals(p.Cardnumber));
            _p.Bankname = p.Bankname;
            _p.Cardnumber = p.Cardnumber;
            _p.Holdname = p.Holdname;
            _p.Expiredate = p.Expiredate;
            _p.CVS = p.CVS;

            return true;
        }



    }
}
