using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class AnimalManager

    {
        List<Animal> animals = new List<Animal> ();
        public AnimalManager()
        {
            animals.Add(new Animal("Carl", 123, "Dog", "Dog food"));


        }

        public void AnimalManagerMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View animal");
            Console.WriteLine("2. Add animal");
            Console.WriteLine("3. Remove animal");
            Console.WriteLine("4. Feed animal");
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




            }

        }

        private void ViewAnimal()
        {


        }

        private void AddAnimal()
        {


        }


        private void RemoveAnimal()
        {


        }

        private void FeedAnimal()
        {

        }
        






    }
}
