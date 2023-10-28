namespace FarmInlämning
{
    internal class Animal : Entity
    {
       private string Species { get; set; }
        private string AcceptableCropTypes { get; set; }

        public string AnimalName { get; set; }

        public Animal(string aName, int aId, string aSpecies, string aAcceptableCropTypes)
            : base(aName, aId)
        {
            Name = aName;
            Id = aId;
            Species = aSpecies;
            AcceptableCropTypes = aAcceptableCropTypes;
        
        
        }

        public void Feed(Crop crop)
        {
            if (crop.GetCropType().Equals(AcceptableCropTypes, StringComparison.OrdinalIgnoreCase))
            {
                int quantityToFeed = 1;

                if (crop.GetCropQuantity() >= quantityToFeed)
                {
                    crop.SetCropQuantity(crop.GetCropQuantity() - quantityToFeed);
                    Console.WriteLine($"The {AnimalsName}  is happy");
                }
                else
                {
                    Console.WriteLine($"Not enough {crop.CropsName} available to feed {AnimalsName}.");
                }
            }
            else
            {
                Console.WriteLine($"{AnimalsName} cannot eat {crop.CropsName}.");
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
