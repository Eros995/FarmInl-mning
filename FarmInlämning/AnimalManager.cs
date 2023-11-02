using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace FarmInlämning
{
    public class AnimalManager
    {

        CropManager cropManager = new CropManager();
        List<Crop> availableCrops;

        List<Animal> animals = new List<Animal>();
        public AnimalManager(CropManager cropManager)
        {
            animals.Add(new Animal("Carl" , 123, "Goat", "Plant"));
            animals.Add(new Animal("Megan", 124, "Horse", "Vegetable"));
            animals.Add(new Animal("Bob", 125, "Cow", "Plant"));
            animals.Add(new Animal("Jake", 127, "Cow", "Plant"));
            animals.Add(new Animal("John", 128, "Chicken", "Plant"));
            animals.Add(new Animal("Trump", 129, "Pig", "Fruit"));

            availableCrops = cropManager.GetCrops();
        }


        public void AnimalManagerMenu()
        {
            bool animalrunning = true;
            while (animalrunning)
            {


                Console.WriteLine("Welcome to the Animal Manager! What would you like to do? ");
                Console.WriteLine("1. View animal");
                Console.WriteLine("2. Add animal");
                Console.WriteLine("3. Remove animal");
                Console.WriteLine("4. Feed animal");
                Console.WriteLine("5. Go back to the main menu.");
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
                Console.WriteLine("Here are the avaliable animals: ");
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
            //Ta bort rad
            int id = 0;
            bool validId = false;

            while (!validId)
            {
                Console.WriteLine("Type the ID for the animal, enter three digit number.");
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

                    Console.WriteLine($"You chose: {selectedAnimal.AnimalsName}, And the crop it accepts is : {selectedAnimal.GetAcceptableCropType()}");
                    Console.WriteLine("");
                    ViewCropList();
                    bool avaliableCrops = true;
                    while (avaliableCrops)
                    {

                        int cropId = GetCropIdInput();
                        Crop selectedCrop = availableCrops.FirstOrDefault(crop => crop.GetCropId() == cropId);
                        if (selectedCrop != null)
                        {
                            if (selectedCrop.GetCropType() == selectedAnimal.GetAcceptableCropType() && selectedCrop.GetCropQuantity() > 0)
                            {
                                Console.WriteLine($"How much quantity of the crop would you like to use? There is {selectedCrop.GetCropQuantity()} left of {selectedCrop.cropsName} ");
                                string quantityInput = Console.ReadLine();

                                if (int.TryParse(quantityInput, out int quantity) && quantity > 0)
                                {
                                    if (quantity <= selectedCrop.GetCropQuantity())
                                    {
                                        selectedCrop.SetCropQuantity(selectedCrop.GetCropQuantity() - quantity);

                                        Console.WriteLine($"{selectedAnimal.AnimalsName} has been fed with {quantity}, of {selectedCrop.cropsName}.");
                                        Console.WriteLine($"There is {selectedCrop.GetCropQuantity()} of {selectedCrop.cropsName} left. ");
                                        // Additional code for the updated list or any other features you need
                                    }
                                    else
                                    {
                                        Console.WriteLine($"There is not enough quantity of {selectedCrop.cropsName} left. ");
                                        Console.WriteLine($"There is only {selectedCrop.GetCropQuantity()}, of {selectedCrop.cropsName} left.");
                                    }
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid positive integer quantity.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("That CropID does not exsist in the list.");
                        }
                    }
                }
            }
        }

                              
         
        private void ViewCropList()
        {
            
            if (availableCrops.Count == 0)
            {
                Console.WriteLine("No crops available.");
            }
            else
            {
                Console.WriteLine("Here are the avaliable crops: ");
                int index = 1;
                foreach (Crop crop in availableCrops)
                {
                    Console.WriteLine($"Crop: {index}, Name: {crop.cropsName}, Crop Type: {crop.GetCropType()} Qauntity: {crop.GetCropQuantity()}, CropID: {crop.GetCropId()}");
                    Console.WriteLine("");
                    index++;
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
                if (int.TryParse(input, out cropId))
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
        
        private Animal FindAnimalById(int id)
        {
            return animals.FirstOrDefault(animal => animal.GetAnimalId() == id);
        }
    }
}







    






    
