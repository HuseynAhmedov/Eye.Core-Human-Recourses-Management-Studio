using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }

        public car( int id , string model , string brand , string color )
        {
            this.Id = id;
            this.Model = model;
            this.Brand = brand;
            this.Color = color;
        }
    }
}
