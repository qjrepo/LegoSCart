using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Asplego.Models
{
    public class UserOrderManager
    {
        public static List<UserOrder> _userorders = new List<UserOrder>() { };

        public void saveuoindb(List<UserOrder> uo)
        {
            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            MySqlConnection msql = new MySqlConnection(Conectstring);


            msql.Open();
            foreach (var i in uo)
            {

                //check if the order info has already exist in database
                MySqlCommand cmdmysql = msql.CreateCommand();
                string iordertime = i.Ordertime;
                string iacc = i.Useraccount;
                int ilegoid = i.LegoId;
                int ipay = i.Payaccount;

                int number = 0;
                string query = string.Format("{0} {1}{2}{3} {4} {5}{6}{7} {8} {9} {10} {11}",
                    "SELECT count(*) AS Number FROM userorderinfo where Ordertime = ", "'", iordertime, "'", "and Useraccount =", "'", iacc, "'", "and Legoid = ",ilegoid, "and Payment =",ipay);
                var cmmd = new MySqlCommand(query, msql);
                using(var read = cmmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        number = Convert.ToInt32(read["Number"]);
                    }
                }
                if(number == 0)
                {
                    //insert orderinfo to db
                    cmdmysql.CommandText = "INSERT INTO userorderinfo(Ordertime,Useraccount,Legoid,Quantity,Payment) VALUES (@ordertime,@useracc,@legoid,@quantity,@payment);";
                    cmdmysql.Parameters.Add("@ordertime", MySqlDbType.VarChar).Value = i.Ordertime;
                    cmdmysql.Parameters.Add("@useracc", MySqlDbType.VarChar).Value = i.Useraccount;
                    cmdmysql.Parameters.Add("@legoid", MySqlDbType.Int16).Value = i.LegoId;
                    cmdmysql.Parameters.Add("@quantity", MySqlDbType.Int16).Value = i.Quantity;
                    cmdmysql.Parameters.Add("@payment", MySqlDbType.Int16).Value = i.Payaccount;
                    cmdmysql.ExecuteNonQuery();
                }


            }
        }

        public IEnumerable<UserOrder> Readuserorderinmysql()
        {
            List<UserOrder> _uo = new List<UserOrder>();

            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            //MySqlConnection msql = new MySqlConnection(Conectstring);

            MySqlConnection msql = new MySqlConnection(Conectstring);
            msql.Open();
            MySqlCommand cmdmysql = msql.CreateCommand();
            string query = "SELECT * FROM userorderinfo";
            var cmmd = new MySqlCommand(query, msql);

            //read data from database and convert to lego type
            using (var read = cmmd.ExecuteReader())
            {
                while (read.Read())
                {
                    string ordertime = Convert.ToString(read["Ordertime"]);
                    string useracc = Convert.ToString(read["Useraccount"]);
                    int legoid = Convert.ToInt16(read["Legoid"]);
                    int quantity = Convert.ToInt16(read["Quantity"]);
                    int payment = Convert.ToInt16(read["Payment"]);
                    _uo.Add(new UserOrder(ordertime, useracc, legoid, quantity,payment));

                }

            }

            return _uo;

        }

        public IEnumerable<UserOrder> Readspeialuserinmysql(string username)
        {
            List<UserOrder> _uo = new List<UserOrder>();

            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            //MySqlConnection msql = new MySqlConnection(Conectstring);

            MySqlConnection msql = new MySqlConnection(Conectstring);
            msql.Open();
            MySqlCommand cmdmysql = msql.CreateCommand();
            string query = string.Format("{0} {1}{2}{3} ",
                    "SELECT * FROM userorderinfo where Useraccount = ", "'", username, "'");
           
            var cmmd = new MySqlCommand(query, msql);

            //read data from database and convert to lego type
            using (var read = cmmd.ExecuteReader())
            {
                while (read.Read())
                {
                    string ordertime = Convert.ToString(read["Ordertime"]);
                    string useracc = Convert.ToString(read["Useraccount"]);
                    int legoid = Convert.ToInt16(read["Legoid"]);
                    int quantity = Convert.ToInt16(read["Quantity"]);
                    int payment = Convert.ToInt16(read["Payment"]);
                    _uo.Add(new UserOrder(ordertime, useracc, legoid, quantity, payment));

                }

            }

            return _uo;

        }


        public IEnumerable<UserOrder> GetAll
        {
            get
            {
                saveuoindb(_userorders);


                return Readuserorderinmysql();
            }
        }

        public void AddUserOrder(UserOrder u) { _userorders.Add(u); }

        public IEnumerable<UserOrder> GetUserordersByuseremail(string email)
        {
            return Readspeialuserinmysql(email);
            //return Readuserorderinmysql().Where(o => o.Useraccount.Equals(email)).ToList();
            //return _students.Where(...).ToList();
        }

        public bool EditUserOrder(UserOrder uo)
        {
            var _uo = _userorders.FirstOrDefault(o => o.Useraccount.Equals(uo.Useraccount));
       

            return true;
        }


    }

}

