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
            
            Species = aSpecies;
            AcceptableCropTypes = aAcceptableCropTypes;
        
        
        }

        public void Feed(Crop crop)
        {

        }


        public override void GetDescription()
        {
            string description = "Name: " + Name + "Id: "+ Id + "Type: " + Species + "Amount: " + AcceptableCropTypes;
            Console.WriteLine(description);
        }


       


        

        

    }
}
