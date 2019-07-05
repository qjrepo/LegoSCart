using System;
namespace Asplego.Models
{
   
        public class Lego
        {
            public int ID { get; set; }
            public string Name{ get; set; }
            public string Type{ get; set; }
            public double Price{ get; set; }
            public int Pieces{ get; set; }
            public string Age{ get; set; }
            public string Description { get; set; }

        public Lego(int id, string name, string type, int price, int pieces, string age, string description)
        {
            ID = id;
            Name = name;
            Type = type;
            Price = price;
            Pieces = pieces;
            Age = age;
            Description = description;

        }
    }



}
