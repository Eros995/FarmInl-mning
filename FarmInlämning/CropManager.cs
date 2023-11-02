using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    public class CropManager

    {
        
        internal List<Crop> crops = new List<Crop>();
        public CropManager()
        {
            
            crops.Add(new Crop("Seeds", 1000,  "Plant", 500));
            crops.Add(new Crop("Carrot", 1001, "Vegetable", 200));
            crops.Add(new Crop("Wheat", 1002, "Plant", 150));
            crops.Add(new Crop("Hay", 1003, "Plant", 250));
            crops.Add(new Crop("Apple", 1004, "Fruit", 450));
            



        }
        public void CropManagerMenu()
        {
            bool croprunning = true;
            while (croprunning)
            {
                Console.WriteLine("Welcome to the Crop Manager! What would you like to do? ");
                Console.WriteLine("1. View Crops. ");
                Console.WriteLine("2. Add Crop. ");
                Console.WriteLine("3. Remove Crop. ");
                Console.WriteLine("5. Go back to the main menu.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewCrop();
                        break;
                    case "2":
                        AddCrop();
                        break;
                    case "3":
                        RemoveCrop();
                        break;
                    case "4":
                        
                    case "5":
                        croprunning = false;
                         break;
                }
            }
            
            
        }

        private void ViewCrop()
        {
            if (crops.Count == 0)
            {
                Console.WriteLine("No crops available!");
            }
            else
            {
                int index = 1;
                //Console.WriteLine("Here are the avaliable crops: ");
                foreach (Crop crop in crops)
                {
                    Console.WriteLine($"Crop: {index}, Name: {crop.cropsName}, Crop Type: {crop.GetCropType()} Qauntity: {crop.GetCropQuantity()}, CropID: {crop.GetCropId()}");
                    Console.WriteLine("");
                    index++;
                }
            }

        }

        private void AddCrop()
        {
            string name;
            do
            {
                Console.WriteLine("Enter the name of the new crop:");
                name = Console.ReadLine();
                if (!IsAlphabetic(name))
                {
                    Console.WriteLine("Write the name with letters not with numbers.");
                    Console.WriteLine("");
                }
            } while (!IsAlphabetic(name));

            string cropType;
            do
            {
                Console.WriteLine("Enter the crop type:");
                cropType = Console.ReadLine();
                if (!IsAlphabetic(cropType))
                {
                    Console.WriteLine("Crop type is not a number, write with letters.");
                    Console.WriteLine("");
                }
            } while (!IsAlphabetic(cropType));


            int quantity = 0;
            bool validQuantity = false;

            while (!validQuantity)
            {
                try
                {
                    Console.WriteLine("Enter the quantity:");
                    quantity = int.Parse(Console.ReadLine());
                    validQuantity = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                }
            }

            int cropId = crops.Max(crop =>crop.GetCropId());
            cropId++;

            try
            {
                Crop newCrop = new Crop(name, cropId, cropType, quantity);
                crops.Add(newCrop);
                Console.WriteLine("New crop added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the crop: " + ex.Message);
            }
        }



        private void RemoveCrop()
        {
            ViewCrop();
            while (true)
            {
                Console.WriteLine("What kind of crop do you want to remove: ");
                
                Console.WriteLine("Enter the CropID: ");

                if (int.TryParse(Console.ReadLine(), out int cropIdToRemove))
                {
                    int indexToRemove = -1;
                    for (int i = 0; i < crops.Count; i++)
                    {
                        if (crops[i].GetCropId() == cropIdToRemove)
                        {
                            indexToRemove = i;
                            break;
                        }
                    }

                    try
                    {
                        if (indexToRemove != -1)
                        {
                            crops.RemoveAt(indexToRemove);
                            Console.WriteLine("Crop with ID: " + cropIdToRemove + ", successfully removed!");
                        }
                        else
                        {
                            Console.WriteLine("Crop with ID: " + cropIdToRemove + " was not found!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("An error occurred while removing the crop.");
                    }

                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid CropID input. Please enter a valid integer CropID.");
                }
            }
        }

        public void FeedAnimal(int cropId, int quantity)
        {
            Crop selectedCrop = crops.FirstOrDefault(crop => crop.GetCropId() == cropId);
            if (selectedCrop != null)
            {
                selectedCrop.SetCropQuantity(selectedCrop.GetCropQuantity() - quantity);
            }
        }
        internal List<Crop> GetCrops()
        {
           
            return crops;
        }

        private bool IsAlphabetic(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
        }



    }
}
