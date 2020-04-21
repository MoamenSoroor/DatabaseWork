using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotNet.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }

        public Car()
        {

        }

        public Car(int carId, string color, string make, string petName)
        {
            CarId = carId;
            Color = color;
            Make = make;
            PetName = petName;
        }

        public override string ToString()
        {
            return $" Car[ ID={CarId}, Color={Color}, Make={Make}, PetName:{PetName} ]";
        }
    }
}
