namespace FarmInlämning
{
    public class AnimalManager
    {

        List<Crop> crops;
        public AnimalManager(List<Crop> crops)
        {
            this.crops = crops;
        }

        List<Animal> animals = new List<Animal>();
        public AnimalManager()
        {
            animals.Add(new Animal("Carl", 123, "Goat", "Hay"));
            animals.Add(new Animal("Megan", 124, "Horse", "Carrot"));
            animals.Add(new Animal("Bob", 125, "Cow", "Wheat"));
            animals.Add(new Animal("Jake", 127, "Cow", "Wheat"));
            animals.Add(new Animal("John", 128, "Chicken", "Seeds"));
            animals.Add(new Animal("Trump", 129, "Pig", "Apple"));



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
                Console.WriteLine("5. Quit");
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


        private void ViewAnimal()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("No crops available.");
            }
            else
            {
                int index = 1;
                foreach (Animal animal in animals)
                {
                    Console.WriteLine("Animal " + index + ":");
                    Console.WriteLine("Name: " + animal.AnimalsName);
                    Console.WriteLine("Animal Id: " + animal.GetAnimalId());
                    Console.WriteLine("Species: " + animal.GetSpecies());
                    Console.WriteLine("Croptype: " + animal.GetAcceptableCropType());
                    Console.WriteLine("");
                    index++;
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
            Console.WriteLine("What animal do you want to remove? ");
            Console.WriteLine("Type in the animal Id");

            if (!int.TryParse(Console.ReadLine(), out int animalIdToRemove))
            {
                Console.WriteLine("invalid ID input ");
                return;
            }

            int indexToRemove = -1;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].GetAnimalId() == animalIdToRemove)
                {
                    indexToRemove = i;
                    break;
                }
            }
            if (animalIdToRemove != -1)
            {
                animals.RemoveAt(indexToRemove);
                Console.WriteLine("Animal with ID: " + animalIdToRemove + ", successfully removed!");
            }
            else
            {
                Console.WriteLine("Animal with ID: " + animalIdToRemove + " was not found!");
            }

        }

        private void FeedAnimal()
        {
            Console.WriteLine("What animal do you want to feed?");
            Console.WriteLine("Please type in the species:");
            string input = Console.ReadLine();

            /*if (input != null)
             {
                 int maxFeed = 20;

             }*/

            try
            {
                int animalId = GetInput("Enter the ID of the animal you want to feed: ");
                Animal animal = FindAnimalById(animalId);

                int cropId = GetInput("Enter the ID of the crop to use for feeding: ");
                Crop crop = FindCropById(crops, cropId);

                int quantity = GetInput("Enter the quantity: ");

                if (quantity <= crop.GetCropQuantity())
                {
                    // Implement the feeding logic here
                    crop.SetCropQuantity(crop.GetCropQuantity() - quantity);
                    Console.WriteLine($"{animal.AnimalsName} was fed {quantity} units of {crop.CropsName}.");
                }
                else
                {
                    Console.WriteLine("Not enough of the selected crop to feed the animal.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private int GetInput(string prompt)
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out int value) || value <= 0)
            {
                throw new InvalidOperationException("Invalid input. Please enter a positive number.");
            }
            return value;
        }

        private Animal FindAnimalById(int id)
        {
            Animal animal = animals.FirstOrDefault(a => a.GetAnimalId() == id);
            if (animal == null)
            {
                throw new InvalidOperationException("Animal with the specified ID was not found.");
            }
            return animal;
        }

        private Crop FindCropById(List <Crop> crops, int id)
        {
            Crop crop = crops.FirstOrDefault(c => c.GetCropId() == id);
            if (crop == null)
            {
                throw new InvalidOperationException("Crop with the specified ID was not found.");
            }
            return crop;
        }

    }


}


    
