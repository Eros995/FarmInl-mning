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
 

        public Crop(string aName, int aId, string aCropType, int aQuantity)
            :base (aName, aId)
        {
            aName = Name;
            aId = Id;
            aCropType = CropType;
            aQuantity = Quantity;
        }

        public override void GetDescription()
        {
            string description = "Name: " + Name + "Id: "+ Id + "Type: " + CropType + "Amount: " + Quantity;
            Console.WriteLine(description);
        }

        public string CropsName
        {
            get { return Name; }
            set { Name = value; }
        }

        public static string CropName { get; internal set; }
    }
        


}

