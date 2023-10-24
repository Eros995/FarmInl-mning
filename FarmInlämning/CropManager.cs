using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class CropManager
    {
        public void CropManagerMenu()
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("1. View Crops. ");
            Console.WriteLine("2. Add Crop. ");
            Console.WriteLine("3. Remove Crop. ");
            Console.WriteLine("4. Get Crops. ");

            

            string choise = Console.ReadLine();

            switch(choise)
            {
                case "1":
                    Console.WriteLine("Which crop do you want to see?");
                    ViewCrop();
                    break;
                case "2":
                    Console.WriteLine("What crop do you want to add?");
                    AddCrop();
                    break;
                case "3":
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine();
                    break;
            }
            
            
            
        }

        private void ViewCrop()
        {


        }

        private void AddCrop()
        {

        }

        private void RemoveCrop()
        {

        }

        /*public GetCrop()
        {
            
             
        }*/
    }
}
