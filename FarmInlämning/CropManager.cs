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
        List<Crop> crops = new List<Crop>();
        public CropManager()
        {
            crops.Add(new Crop("egg", 12,  "food", 5));
            crops.Add(new Crop("Vattenmelon", 1001, "Frukt", 20));
            crops.Add(new Crop("Jordgubbe", 1002, "Bär", 15));
            crops.Add(new Crop("Äpple", 1003, "Frukt", 25));
            crops.Add(new Crop("Morot", 1007, "Grönsak", 45));
            

        }
        public void CropManagerMenu()
        {
            bool croprunning = true;
            while (croprunning)
            {
                Console.WriteLine("What would you like to do? ");
                Console.WriteLine("1. View Crops. ");
                Console.WriteLine("2. Add Crop. ");
                Console.WriteLine("3. Remove Crop. ");
                Console.WriteLine("4. Get Crops. ");
                Console.WriteLine("5. Quit ");

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
                Console.WriteLine("No crops available.");
            }
            else
            {
                int index = 1;
                foreach (Crop crop in crops)
                {
                    Console.WriteLine("Crop " + index + ":");
                    Console.WriteLine("Name: " + crop.CropsName);
                    Console.WriteLine("Crop type: " + crop.GetCropType());
                    Console.WriteLine("Quantity: " + crop.GetCropQuantity());
                    Console.WriteLine("");
                    index++;
                }
            }

        }

        private void AddCrop()
        {
            Console.WriteLine("Enter the name of the new crop:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the crop type:");
            string cropType = Console.ReadLine();

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

            try
            {
                int maxId = crops.Max(crop => crop.GetCropId());
                Crop newCrop = new Crop(name, maxId, cropType, quantity);
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
            System.Console.WriteLine("What kind of crop do you want to remove: ");
            int cropIdToRemove;
            cropIdToRemove=int.Parse(Console.ReadLine());
            if (!int.TryParse(Console.ReadLine(), out int cropIdToRemove))
            {
                Console.WriteLine("invalid ID input ");
                return;
            }

            int indexToRemove = -1;
            for(int i = 0; i < crops.Count; i++)
            {
                if(crops[i].GetCropId() == cropIdToRemove)
                {
                    indexToRemove = i;
                    break;
                }
            }
            if(cropIdToRemove != -1)
            {
                crops.RemoveAt(indexToRemove);
                Console.WriteLine("Crop with ID: " + cropIdToRemove + ", successfully removed!");
            }
            else
            {
                Console.WriteLine("Crop with ID: " + cropIdToRemove + " was not found!");
            }
        }

      

    }
}
