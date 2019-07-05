using System;
namespace Asplego.Models
{
    public class Ordercreate
    {
        public string userEmail { get; set; }
        public int pid { get; set; }
        public Ordercreate(string useremail,int pd)
        {
            userEmail = useremail;
            pid = pd;
        }
    }
}
