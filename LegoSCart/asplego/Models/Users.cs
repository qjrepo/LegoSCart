using System;
namespace Asplego.Models
{
    public class User
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string firstname, string lastname, string email, string password)
        {

           
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;


        }


    }
}
