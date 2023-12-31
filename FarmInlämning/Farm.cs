﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    public class Farm
    {
        public AnimalManager animalmanager;
        public CropManager cropmanager;
        public Farm(CropManager cropmanager, AnimalManager animalmanager)

        {
            this.animalmanager = animalmanager;
            this.cropmanager = cropmanager;
        }

        public void Mainmenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome to the farm main menu! What would you like to do?");
                Console.WriteLine("1. Access the Animal Manager.");
                Console.WriteLine("2. Access the Crop Manager");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Make your choice: ");

                string choice = Console.ReadLine();

                switch (choice) 
                {
                    case "1":
                        animalmanager.AnimalManagerMenu();
                        break;

                    case "2":
                        cropmanager.CropManagerMenu();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Not an option, please try again.");
                        break;
                }

            }
        }

       
    }
}   


    

