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
