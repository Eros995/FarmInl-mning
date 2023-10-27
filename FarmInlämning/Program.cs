using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalManager animalManager = new AnimalManager();
            CropManager cropManager = new CropManager();
            Farm farm = new Farm(cropManager, animalManager);
            farm.Mainmenu();
        }
        

        
    }
}