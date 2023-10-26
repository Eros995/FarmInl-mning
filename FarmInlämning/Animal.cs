using Internal;
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

        public static string AnimalName { get; internal set; }

        public Animal(string aName, int aId, string aSpecies, string aAcceptableCropTypes)
            : base(aName, aId)
        {
            Species = species;
            AcceptableCropTypes = acceptableCropTypes;
            aName = Name;
            aId = Id;
            aSpecies = Species;
            aAcceptableCropTypes = AcceptableCropTypes;
        
        
        }

        public void Feed(Crop crop)
        {

        }


        public override void GetDescription()
        {
            string description = "Name: " + Name + "Id: "+ Id + "Type: " + Species + "Amount: " + AcceptableCropTypes;
            Console.WriteLine(description);
        }


        public string AnimalaName
        {
            get{ return; Animal.AnimalNameName}
            set{Name = value;}
        }


        

        

    }
}
