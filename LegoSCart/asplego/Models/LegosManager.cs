using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Asplego.Models
{
    public class LegosManager
    {
        public static List<Lego> _lego = new List<Lego>()
       {
           new Lego(1,"Big Ben","Architecture",249,4163,"16+","Get up close to Big Ben! The clock was first started on May 31st 1859, and Big Ben’s first chime rang from the 96-meter Elizabeth Tower on July 11th of the same year. This over 23” (60cm) high LEGO® interpretation of the iconic structure is a tribute to its engineering and architecture."),
           new Lego(2,"The Joker™ Manor","Film",269,3444,"14+","The Joker™ Manor is packed with iconic details from the movie and cool functions, including a rollercoaster encircling the whole building, a huge buildable The Joker head with trapdoor and slide, punching boxing gloves, a rocking ‘The Joker’ sign and rotating ‘big eye’ tower."),
           new Lego(3,"Assembly Square","Architecture",279,4002,"16+","Take a trip to the amazing Assembly Square, developed to celebrate ten years of LEGO® Modular Buildings, featuring a wealth of unsurpassed, intricate details and hidden surprises. "),
           new Lego(4,"Taj Mahal","Architecture",369,5923,"16+","Build and discover the Taj Mahal! The huge ivory-white marble mausoleum, renowned as one of the world’s architectural wonders, was commissioned in 1631 by the Emperor Shah Jahan in memory of his wife, the Empress Mumtaz Mahal.  "),
           new Lego(5,"Porsche 911 GT3 RS","Car",299,2704,"16+","Experience the iconic Porsche 911 GT3 RS with this authentic LEGO® Technic replica. Inside the box you’ll discover a special collector’s book chronicling the history of LEGO Technic and Porsche GT cars, together with 4 original-design rims bearing the RS emblem. "),
           new Lego(6,"The Disney Castle","Architecture",349,4080,"16+","Bring the magical world of Disney to your home with The Disney Castle. This highly detailed LEGO® model with over 4,000 pieces offers a rewarding build and play experience, and comes with an array of exciting Disney-themed features and functions. "),
           new Lego(7,"Bugatti Chiron","Car",349,3599,"16+","Explore engineering excellence with the LEGO® Technic™ 42083 Bugatti Chiron advanced building set. This exclusive model has been developed in partnership with Bugatti Automobiles S. "),
           new Lego(8,"Hogwarts™ Castle","Film",399,6020,"16+","Make the magic come alive at the LEGO® Harry Potter™ 71043 Hogwarts™ Castle! This highly detailed LEGO Harry Potter collectible has over 6,000 pieces and offers a rewarding build experience.  "),
           new Lego(9,"Millennium Falcon™","Film",799,7541,"16+","This amazing LEGO interpretation of Han Solo’s unforgettable Corellian freighter has all the details that Star Wars fans of any age could wish for, including intricate exterior detailing, upper and lower quad laser cannons, landing legs, lowering boarding ramp and a 4-minifigure cockpit with detachable canopy.  "),
           new Lego(10,"Death Star™","Architecture",499,4002,"16+","With over 4,000 pieces, this fantastic model has a galaxy of intricate and authentic environments, including a superlaser control room, Imperial conference chamber, hangar bay with moving launch rack and Lord Vader’s TIE Advanced with space for Vader inside, Emperor Palpatine’s throne room, Droid maintenance room, detention block, trash compactor, tractor beam, cargo area, turbo laser with spring-loaded shooters and seats for the 2 Death Star Gunners, and 2 movable turbo laser towers. "),

       };

        public void saveinmysql(List<Lego> l)
        {
             string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
            "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            MySqlConnection msql = new MySqlConnection(Conectstring);


            msql.Open();
            foreach (var i in l)
            {
                
                // check if the lego info has already exist in database
                MySqlCommand cmdmysql = msql.CreateCommand();
                int iid = i.ID;
                string query = "SELECT count(*) AS Number FROM legoinfo where Legoid = " + iid;
                
                var cmmd = new MySqlCommand(query, msql);
                int number = 0;
                using (var read = cmmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        number = Convert.ToInt32(read["Number"]);
                    }
                }

                        if ( number == 0)
                        {
                            //insert lego info into database
                          
                            cmdmysql.CommandText = "INSERT INTO legoinfo(Legoid,Legoname,Legotype,Price,Pieces, Age, Description) VALUES (@legoid,@legoname,@legotype,@price,@pieces,@age,@descrip);";
                            cmdmysql.Parameters.Add("@legoid", MySqlDbType.Int16).Value = i.ID;
                            cmdmysql.Parameters.Add("@legoname", MySqlDbType.VarChar).Value = i.Name;
                            cmdmysql.Parameters.Add("@legotype", MySqlDbType.VarChar).Value = i.Type;
                            cmdmysql.Parameters.Add("@price", MySqlDbType.Double).Value = i.Price;
                            cmdmysql.Parameters.Add("@pieces", MySqlDbType.Int16).Value = i.Pieces;
                            cmdmysql.Parameters.Add("@age", MySqlDbType.VarChar).Value = i.Age;
                            cmdmysql.Parameters.Add("@descrip", MySqlDbType.VarChar).Value = i.Description;
                            cmdmysql.ExecuteNonQuery();
                         

                        }
    
            }
            return;

        }

        public IEnumerable<Lego> readinmysql()
        {
            List<Lego> _ll = new List<Lego>();
            
            string Conectstring = "SERVER=shopdataapi.mysql.database.azure.com" + ";" + "DATABASE=shopdata;" +
           "UID=shopserver@shopdataapi;" + "PASSWORD=Password123;";
            //MySqlConnection msql = new MySqlConnection(Conectstring);
            
            MySqlConnection msql = new MySqlConnection(Conectstring);
            msql.Open();
            MySqlCommand cmdmysql = msql.CreateCommand();
            string query = "SELECT * FROM legoinfo";
            var cmmd = new MySqlCommand(query, msql);

            //read data from database and convert to lego type
            using(var read = cmmd.ExecuteReader())
            {
                while (read.Read())
                {
                    int legoid = Convert.ToInt32( read["Legoid"]);
                    string legoname =Convert.ToString( read["Legoname"]);
                    string legotype = Convert.ToString(read["Legotype"]);
                    int price = Convert.ToInt32(read["Price"]);
                    int pieces = Convert.ToInt32(read["Pieces"]);
                    string age = Convert.ToString(read["Age"]);
                    string describ = Convert.ToString(read["Description"]);
                    _ll.Add(new Lego(legoid,legoname,legotype,price,pieces,age,describ));
                }
                
            }

            return _ll;

        }


        public IEnumerable<Lego> GetAll { get 
        {
            saveinmysql(_lego);
            return readinmysql(); 
            } }

        public IEnumerable<Lego> GetLegoByType(string word)
        {
            return _lego.Where(o => o.Type.Equals(word)).ToList();
            //return _students.Where(...).ToList();
        }
    }
}


