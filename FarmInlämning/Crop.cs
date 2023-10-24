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

        public string CropType{ get; set; }
        private int Quantity{ get; set; } = 0;

        List <Crop> crop = new List<Crop>();

        public Crop(string aName, int aId, string aCropType, int aQuantity)
            :base (aName, aId)
        {
            Crop crop1 = new Crop("Vattenmelon",1001 , "Frukt", 20);
            Crop crop2 = new Crop("Jordgubbe",1002 , "Bär", 15);
            Crop crop3 = new Crop("Äpple",1003 , "Frukt", 25);

            aName = Name;
            aId = Id;
            aCropType = CropType;
            aQuantity = Quantity;
        }

        public override void GetDescritpion()
        {
            string description = "Name: " + Name + "Id: "+ Id + "Type: " + CropType + "Amount: " + Quantity;
            Console.WriteLine(description);
        }
       
    }
        


}

