using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Crop : Entity
    {

        List <Crop> crop = new List<Crop>();

        public Crop()
        {
            Crop crop = new Crop("Häst",)
        }

        }
        public string cropType;
        private int quantity;

        public override void GetDescription()
        {
            string CropInfo ("The type of crop is: " + cropType + " and the Quantity of them are: " + quantity );
            Console.WriteLine(CropInfo);
        }
    }
}
