using System.Runtime.Serialization.Json;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using System.Net.Http.Headers;
using System.Collections.Concurrent;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Data;
using Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class AnimalManager
    { 
        List<Animals> animal = new List<Animals> ();
        public void AnimalManagerMenu()
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("1. View Animals. ");
            Console.WriteLine("2. Add Animals. ");
            Console.WriteLine("3. Remove Animals. ");
            Console.WriteLine("4. Feed Aniamls. ");
            
            public string choice = Console.ReadLine();

            Switch (choice)
            {
                case "1":
                    System.Console.WriteLine();
            }


        }
        private void ViewAnimals()
        {
            if (animals.Count == 0)
            {
                Console.Writeline("No Animals Available ");
                Console.WriteLine("Animal name: " animal.AnimalName)
            }
            else
            {
                foreach(Animal animal in animals)
            }

        }
        private void AddAnimal()
        {

        }
        private void RemoveAnimal()
        {

        }
        private void FeedAnimals()
        {

        }

        


    }
}
