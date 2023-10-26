using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Animal : Entity
    {
        public string Species { get; set; }
        private string AcceptableCropTypes { get; set; }

        public Animal(string aName, int aId, string species, string acceptableCropTypes)
            : base(aName, aId)
        {
            Species = species;
            AcceptableCropTypes = acceptableCropTypes;
        
        
        }

        public void Feed(Crop crop)
        {

        }

        public override void GetDescription()
        {
            string description "Name: " + Name + "Id: " + Id + "Species: " + Species + "AcceptableCropType" + AcceptableCropTypes;
            Console.WriteLine(description);

        }

        public string AnimalName
        {
            get { return; Name }
            set { Name = value; }
        }

        
    }
}
