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
            crops.Add(new Crop( "egg", 12,  "food", 5));
            Crop crop1 = new Crop("Vattenmelon", 1001, "Frukt", 20);
            Crop crop2 = new Crop("Jordgubbe", 1002, "Bär", 15);
            Crop crop3 = new Crop("Äpple", 1003, "Frukt", 25);
            Crop crop4 = new Crop("Morot", 1007, "Grönsak", 45);
            

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

        }

        private void RemoveCrop()
        {

        }

      

    }
}
