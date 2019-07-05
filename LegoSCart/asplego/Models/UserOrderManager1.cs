using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asplego.Models
{
    public class UserOrderManager
    {
        public static List<UserOrder> _userorder = new List<UserOrder>();

       

        public void saveuserorderindb(List<UserOrder> uo)
        {
            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            MySqlConnection msql = new MySqlConnection(Conectstring);


            msql.Open();
            foreach (var i in uo)
            {

                MySqlCommand cmdmysql = msql.CreateCommand();

                cmdmysql.CommandText = "INSERT INTO userorderinfo(Ordertime,Userid,Legoid,Quantity) VALUES (@ordertime,@userid,@legoid,@quantity);";
                cmdmysql.Parameters.Add("@ordertime", MySqlDbType.DateTime).Value = i.Ordertime;
                cmdmysql.Parameters.Add("@userid", MySqlDbType.Int16).Value = i.UserId;
                cmdmysql.Parameters.Add("@legoid", MySqlDbType.Int16).Value = i.LegoId;
                cmdmysql.Parameters.Add("@quantity", MySqlDbType.Int16).Value = i.Quantity;
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
                    DateTime ordertime = Convert.ToDateTime(read["Ordertime"]);
                    int userid = Convert.ToInt16(read["Userid"]);
                    int legoid = Convert.ToInt16(read["Legoid"]);
                    int quantity = Convert.ToInt16(read["Quantity"]);
                _uo.Add(new UserOrder(ordertime, userid, legoid, quantity));

                }

            }

            return _uo;

        }


        public IEnumerable<UserOrder> GetAll
        {
            get
            {    saveuserorderindb(_userorder);
                

                return Readuserorderinmysql();
            }
        }

        //public IEnumerable<UserOrder> GetUserOrdersByEPassword(string ep)
        //{
        //    return readuserinmysql().Where(o => (o.Email + o.Password).Equals(ep)).ToList();
        //    //return _students.Where(...).ToList();
        //}

        public void AddUserOrder(UserOrder u) { _userorder.Add(u); }

        //public bool EditUserOrder(UserOrder u)
        //{
        //    var _u = _user.FirstOrDefault(o => o.Email.Equals(u.Email));
        //    _u.Firstname = u.Firstname;
        //    _u.Lastname = u.Lastname;
        //    _u.Password = u.Password;

        //    return true;
        //}

    }



}
