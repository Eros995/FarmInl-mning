using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace FarmInlämning
{
    public class AnimalManager
    {

        List<Crop> crops;
        List<Animal> animals = new List<Animal>();
        public AnimalManager()
        {
            crops = new List<Crop>();
            animals.Add(new Animal("Carl" , 123, "Goat", "Plant"));
            animals.Add(new Animal("Megan", 124, "Horse", "Vegetable"));
            animals.Add(new Animal("Bob", 125, "Cow", "Plant"));
            animals.Add(new Animal("Jake", 127, "Cow", "Plant"));
            animals.Add(new Animal("John", 128, "Chicken", "Plant"));
            animals.Add(new Animal("Trump", 129, "Pig", "Fruit"));
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
                    Console.WriteLine("");
                    index++;
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
                if (int.TryParse(Console.ReadLine(), out id)) 
                {
                    if (AnimalIdExists(id))
                    {
                        Console.WriteLine("An animal with the same ID already exists. Please choose a different ID.");
                    }
                    else
                    {
                        validId = true; 
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                }
            }

            Console.WriteLine("What is the species?");
            string species = Console.ReadLine();

            Console.WriteLine("What is the acceptable crop type?");
            string acceptableCropType = Console.ReadLine();

            Animal newAnimal = new Animal(name, id, species, acceptableCropType);
            animals.Add(newAnimal);
            Console.WriteLine(name + " was added!");
        }


        private void RemoveAnimal()
        {
            try
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

            catch (Exception ex)
            {
                Console.WriteLine("Write an ID that exists.");

            }

        }

        private void FeedAnimal()
        {

            Console.WriteLine("What animal would you like to feed?");
            ViewAnimal();

            int animalId = GetAnimalIdInput();
            if (animalId > 0)
            {
                Animal selectedAnimal = FindAnimalById(animalId);
                if (selectedAnimal != null)
                {
                    ViewCrop();
                    Console.WriteLine($"You chose: {selectedAnimal.AnimalsName}, And the crop it accepts is : {selectedAnimal.GetAcceptableCropType()}");
                    bool avaliableCrops = true;


                    while (avaliableCrops)
                    {
                        
                        int cropId = GetCropIdInput();
                        Crop selectedCrop = crops.FirstOrDefault(crop => crop.GetCropId() == cropId);

                        if (selectedCrop != null && selectedCrop.GetCropType() == selectedAnimal.GetAcceptableCropType() && selectedCrop.GetCropQuantity() > 0)
                        {
                            Console.WriteLine($"How much quantity of the crop would you like to use? There is {selectedCrop.GetCropQuantity()} left of {selectedCrop.cropsName} ");
                            string quantityInput = Console.ReadLine();
                            int quantity = int.Parse(quantityInput);
                            Console.WriteLine($"{selectedAnimal.AnimalsName} has been fed with {quantityInput}, of {selectedCrop.cropsName}.");
                            selectedCrop.SetCropQuantity(selectedCrop.GetCropQuantity() - quantity);
                            Console.WriteLine($"There is {selectedCrop.GetCropQuantity()} of {selectedCrop.cropsName} left. ");
                            break;
                        }
                        else if (selectedCrop.CropType != selectedAnimal.GetAcceptableCropType())
                        {
                            Console.WriteLine($"You tried to feed {selectedAnimal.AnimalsName} with {selectedCrop.CropType}");
                            Console.WriteLine($"{selectedAnimal.AnimalsName} does not eat that.");
                        }
                        else 
                        {
                            Console.WriteLine($"There is no more {selectedCrop.cropsName} left. ");
                        }

                        
                    }

                }
            }


        }

        private int GetCropIdInput()
        {
            int cropId;
            while (true)
            {
                Console.WriteLine("Please enter the ID of the crop you would like to use for feeding.");
                string input = Console.ReadLine();
                if(int.TryParse(input, out cropId)) 
                { 
                 return cropId;
                }
                else 
                {
                    Console.WriteLine("Invalid input. Please input a integer ID.");
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
                    Console.WriteLine(""); 
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







    






    
