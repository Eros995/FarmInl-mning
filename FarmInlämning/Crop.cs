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

        public Crop(string aName, int aId, string aCropType, int aQuantity)
            :base (aName, aId)
        {
            Crop crop1 = new Crop("Vattenmelon",1001 , "Frukt", 20);
            Crop crop2 = new Crop("Jordgubbe",1002 , "Bär", 15);
            Crop crop3 = new Crop("Äpple",1003 , "Frukt", 25);
            
            CropType = aCropType;
            Quantity = aQuantity;
        }

        }
        public override void GetDescription()
        {
            string CropInfo("The type of crop is: " + aCropType + " and the Quantity of them are: " + aQuantity);
            Console.WriteLine(CropInfo);
        }


    }
}
