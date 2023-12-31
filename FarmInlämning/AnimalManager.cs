﻿using FarmInlämning;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace FarmInlämning
{
    public class AnimalManager
    {

        
        internal List<Crop> availableCrops;

        List<Animal> animals = new List<Animal>();
        public AnimalManager(CropManager cropManager)
        {
            animals.Add(new Animal("Carl" , 1, "Goat", "Plant"));
            animals.Add(new Animal("Megan", 2, "Horse", "Vegetable"));
            animals.Add(new Animal("Bob", 3, "Cow", "Plant"));
            animals.Add(new Animal("Jake", 4, "Cow", "Plant"));
            animals.Add(new Animal("John", 5, "Chicken", "Plant"));
            animals.Add(new Animal("Trump", 6, "Pig", "Fruit"));
          
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
            string name;
            do
            {
                Console.WriteLine("What is the name?");
                name = Console.ReadLine();
                if (!IsAlphabetic(name))
                {
                    Console.WriteLine("Write the name with letters not with numbers.");
                    Console.WriteLine("");
                }
            } while (!IsAlphabetic(name));
            
            int animalId = animals.Max(animal => animal.GetAnimalId());
            animalId++;

            string species;
            do
            {
                Console.WriteLine("What is the species?");
                species = Console.ReadLine();
                if (!IsAlphabetic(species))
                {
                    Console.WriteLine("Write the species with letters not with numbers.");
                    Console.WriteLine("");
                }
            } while (!IsAlphabetic(species));

            string acceptableCropType;
            do
            {
                Console.WriteLine("What is the acceptable crop type?");
                acceptableCropType = Console.ReadLine();
                if (!IsAlphabetic(acceptableCropType))
                {
                    Console.WriteLine("Write the acceptable crop type with letters not with numbers.");
                    Console.WriteLine("");
                }
            } while (!IsAlphabetic(acceptableCropType));

            Animal newAnimal = new Animal(name, animalId, species, acceptableCropType);
            animals.Add(newAnimal);
            Console.WriteLine(name + " was added!");
        }


        private void RemoveAnimal()
        {
            ViewAnimal();

            int animalIdToRemove;

            while (true)
            {
                Console.WriteLine("Type in the ID of the animal you would like to remove. ");
                if (int.TryParse(Console.ReadLine(), out animalIdToRemove))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid ID input. Please enter a valid integer ID.");
                }
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

            try
            {
                if (indexToRemove != -1)
                {
                    animals.RemoveAt(indexToRemove);
                    Console.WriteLine("Animal with ID: " + animalIdToRemove + ", successfully removed!");
                }
                else
                {
                    Console.WriteLine("Animal with ID: " + animalIdToRemove + " was not found!");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Write a valid ID");
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
                                   selectedAnimal.Feed(selectedCrop, quantity);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid positive integer quantity.");
                                }
                            }
                            else if ((selectedCrop.GetCropType() != selectedAnimal.GetAcceptableCropType() && selectedCrop.GetCropQuantity() > 0))
                            {
                                Console.WriteLine($"{selectedAnimal.AnimalsName} does not eat {selectedCrop.cropsName}.");
                            }
                            else 
                            {
                                Console.WriteLine($"There is no more {selectedCrop.cropsName} left.");
                                break;
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

        private bool IsAlphabetic(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
        }
    }
}







    






    
