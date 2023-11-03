namespace FarmInlämning
{
    internal class Animal : Entity
    {
        private string Species { get; set; }
        private string AcceptableCropTypes { get; set; }

        public Animal(string aName, int aId, string aSpecies, string aAcceptableCropTypes)
            : base(aName, aId)
        {
            Name = aName;
            Id = aId;
            Species = aSpecies;
            AcceptableCropTypes = aAcceptableCropTypes;
        
        
        }

        public void Feed(Crop crop, int quantity)
        {
            if (AcceptableCropTypes == crop.GetCropType() && crop.GetCropQuantity() >= quantity)
            {
                
                crop.SetCropQuantity(crop.GetCropQuantity() - quantity);
                Console.WriteLine($"{Name} has been fed with {quantity} of {crop.cropsName}.");
            }
            else
            {
                Console.WriteLine($"Not enough quantity of crops for hungry {Name}.");
            }
        }


        public override void GetDescription()
        {
            string description = "Name: " + Name + "Id: "+ Id + "Type: " + Species + "Food: " + AcceptableCropTypes;
            Console.WriteLine(description);
        }

        public int GetAnimalId()
        {
            return Id;
        }
       

        public string GetSpecies()
        { return Species; }

        public string GetAcceptableCropType()
        { return AcceptableCropTypes; }

        public string AnimalsName
        {
            get { return Name; }
            set { Name = value; }
        }
        

    }
}
