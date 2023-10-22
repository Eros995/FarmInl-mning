using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Crop : Entity
    {

        public string CropType;
        private int Quantity;
        List <Crop> crop = new List<Crop>();

        public Crop(string aName, string, string aCropType, int aQuantity)
        {
            Crop crop1 = new Crop("vattenmelon", 20);
            CropType = aCropType;
            Quantity = aQuantity;


        }

        }
        public override void GetDescription()
        {
            string CropInfo ("The type of crop is: " + cropType + " and the Quantity of them are: " + quantity );
            Console.WriteLine(CropInfo);
        }
    }
}
