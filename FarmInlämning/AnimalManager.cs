using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace FarmInlämning
{
    public class AnimalManager
    {

        List<Crop> crops;
        AnimalManager(List<Crop> crops)
        {
            this.crops = crops ?? new List<Crop>();
        }

        List<Animal> animals = new List<Animal>();
        public AnimalManager()
        {
            crops = new List<Crop>();
            animals.Add(new Animal("Carl", 123, "Goat", "Hay"));
            animals.Add(new Animal("Megan", 124, "Horse", "Carrot"));
            animals.Add(new Animal("Bob", 125, "Cow", "Wheat"));
            animals.Add(new Animal("Jake", 127, "Cow", "Wheat"));
            animals.Add(new Animal("John", 128, "Chicken", "Seeds"));
            animals.Add(new Animal("Trump", 129, "Pig", "Apple"));

            crops.Add(new Crop("Seeds", 1000, "Plant", 500));
            crops.Add(new Crop("Carrot", 1001, "Vegetable", 200));
            crops.Add(new Crop("Wheat", 1002, "Plant", 150));
            crops.Add(new Crop("Hay", 1003, "Plant", 250));
            crops.Add(new Crop("Apple", 1004, "Fruit", 450));
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
                Console.WriteLine("No animals available.");
            }
            else
            {
                int index = 1;
                foreach (Animal animal in animals)
                {
                    Console.WriteLine($"Animal: {index}, Name: {animal.AnimalsName}, Animal ID: {animal.GetAnimalId()}, Species: {animal.GetSpecies()}, CropType: {animal.GetAcceptableCropType()}");
                }
            }
        }


        private bool AnimalIdExists(int id)
        {
            return animals.Any(animal => animal.GetAnimalId() == id);
        }

        private void AddAnimal()
        {
            Console.WriteLine("What is the name?");
            string name = Console.ReadLine();

            int id = 0;
            bool validId = false;

            while (!validId)
            {
                Console.WriteLine("What is the Id?");
                if (int.TryParse(Console.ReadLine(), out id)) // Get the ID from the user's input
                {
                    if (AnimalIdExists(id))
                    {
                        Console.WriteLine("An animal with the same ID already exists. Please choose a different ID.");
                    }
                    else
                    {
                        validId = true; // The ID is unique.
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                }
            }

            // Collect the remaining animal details outside of the loop.
            Console.WriteLine("What is the species?");
            string species = Console.ReadLine();

            Console.WriteLine("What is the acceptable crop type?");
            string acceptableCropType = Console.ReadLine();

            // Create a new Animal using the collected details.
            Animal newAnimal = new Animal(name, id, species, acceptableCropType);
            animals.Add(newAnimal);
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
            
            Console.WriteLine("What animal would you like to feed?");
            int index = 1;
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Animal: {index}, Name: {animal.AnimalsName}, Animal ID: {animal.GetAnimalId()}, Species: {animal.GetSpecies()}, CropType: {animal.GetAcceptableCropType()}");
                index++;
            }

            GetAnimalIdInput();
            ViewCrop();
            int animalId = GetAnimalIdInput();
            if ( animalId > 0) 
            {
                Animal selectedAnimal = FindAnimalById(animalId);
                if ( selectedAnimal != null ) 
                { 
                 ViewCrop();
                }
                else 
                {
                    Console.WriteLine("There is no animal with this ID.");
                }
            }
        }

        private int GetAnimalIdInput()
        {
            int animalId;
            while (true)
            {
                Console.WriteLine("Please enter the id of the animal you would like to feed.");
                string input = Console.ReadLine();

                if (int.TryParse(input, out animalId))
                {
                    if (AnimalIdExists(animalId))
                    {
                        return animalId;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. There is no animal with this ID.");
                    }
                }

                else 
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer ID.");      
                }
            }


        }
        private void ViewCrop()
        {
            if (crops.Count == 0)
            {
                Console.WriteLine("No crops available.");
            }
            else
            {
                Console.WriteLine("Here are the avaliable crops: ");
                int index = 1;
                foreach (Crop crop in crops)
                {
                    Console.WriteLine($"Crop: {index}, Name: {crop.cropsName}, Crop Type: {crop.GetCropType()} Qauntity: {crop.GetCropQuantity()}, CropID: {crop.GetCropId()}");
                    index++;
                }
            } 

        }
        private Animal FindAnimalById(int id)
        {
            return animals.FirstOrDefault(animal => animal.GetAnimalId() == id);
        }

    }
}







    






    
