namespace FarmInlämning
{
    public class AnimalManager
    { 
       


    
        List<Animal> animals = new List<Animal>();
        public AnimalManager()
        {
            animals.Add(new Animal("Carl", 123, "Dog", "Dog food"));


        }

        public void AnimalManagerMenu()
        {
            bool animalrunning = true;
            while (animalrunning)
            {

            
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View animal");
                Console.WriteLine("2. Add animal");
                Console.WriteLine("3. Remove animal");
                Console.WriteLine("4. Feed animal");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAnimal();
                        break;

                    case "2":
                        AddAnimal();
                        break;

                    case "3":
                        RemoveAnimal();
                        break;

                    case "4":
                        FeedAnimal();
                        break;
                    
                    case "5":
                        animalrunning = false;
                        break;
                }




            }

        }

        private void AddAnimal()
        {
            Console.WriteLine("What is the name?");
            string name = Console.ReadLine();

            Console.WriteLine("What is the Id?");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the species?");
            string species = Console.ReadLine();

            Console.WriteLine("What is the acceptable crop type?");
            string acceptableCropType = Console.ReadLine();

            animals.Add(new Animal(name, id, species, acceptableCropType));
            Console.WriteLine(name + " was added!");


        }


        private void RemoveAnimal()
        {


        }

        private void FeedAnimal()
        {

        }
        private void ViewAnimal()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("No Animals Available ");
                Console.WriteLine("Animal name: ");
            }
            else
            {
                foreach (Animal animal in animals) ;
            }

        }


    }
}