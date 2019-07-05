using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asplego.Models
{
    public class UsersManager
    {
        public static List<User> _user = new List<User>()
       {
           new User ("Bill", "Gates","bill@microsoft.com","mypassword"),
           new User( "Elon", "Musk", "elon@tesla.com","mypassword")

       };

        public void saveuserindb(List<User> u)
        {
            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            MySqlConnection msql = new MySqlConnection(Conectstring);

            
            msql.Open();
            foreach (var i in u)
            {
                // check if the user info has already exist in database
                MySqlCommand cmdmysql = msql.CreateCommand();
                string iemail = i.Email;
                int number = 0;
                string query = string.Format("{0} {1}{2}{3}", "SELECT count(*) AS Number FROM userinfo where Email = ", "'", iemail, "'");
               // string query = "SELECT count(*) AS Number FROM userinfo where Email = " + iemail;
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

                            
                                cmdmysql.CommandText = "INSERT INTO userinfo(Firstname,Lastname,Email,Accountpassword) VALUES (@firstname,@lastname,@email,@accountpassword);";
                                cmdmysql.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = i.Firstname;
                                cmdmysql.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = i.Lastname;
                                cmdmysql.Parameters.Add("@email", MySqlDbType.VarChar).Value = i.Email;
                                cmdmysql.Parameters.Add("@accountpassword", MySqlDbType.VarChar).Value = i.Password;
                                cmdmysql.ExecuteNonQuery();
                                
                            
                            
                        }
                    }
              
        }

        public IEnumerable<User> readuserinmysql()
        {
            List<User> _uu = new List<User>();

            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            //MySqlConnection msql = new MySqlConnection(Conectstring);

            MySqlConnection msql = new MySqlConnection(Conectstring);
            msql.Open();
            MySqlCommand cmdmysql = msql.CreateCommand();
            string query = "SELECT * FROM userinfo";
            var cmmd = new MySqlCommand(query, msql);

            //read data from database and convert to lego type
            using (var read = cmmd.ExecuteReader())
            {
                while (read.Read())
                {
                   
                    string firstname = Convert.ToString(read["Firstname"]);
                    string lastname = Convert.ToString(read["Lastname"]);
                    string email = Convert.ToString(read["Email"]); 
                    string password = Convert.ToString(read["Accountpassword"]);
                    _uu.Add(new User( firstname, lastname, email, password));
                }

            }

            return _uu;

        }


        public IEnumerable<User> GetAll
        {
            get
            {
                saveuserindb(_user);

                return readuserinmysql();
            }
        }

        public IEnumerable<User> GetUsersByEPassword(string ep)
        {
            return readuserinmysql().Where(o => (o.Email+o.Password).Equals(ep)).ToList();
            //return _students.Where(...).ToList();
        }

        public void AddUser(User u) { _user.Add(u); }

        public bool EditUser(User u)
        {
            var _u = _user.FirstOrDefault(o => o.Email.Equals(u.Email));
            _u.Firstname = u.Firstname;
            _u.Lastname = u.Lastname;
            _u.Password = u.Password;

            return true;
        }

    }



}
