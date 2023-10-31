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
            CropManager cropManager = new CropManager();
            AnimalManager animalManager = new AnimalManager(cropManager);
            Farm farm = new Farm(cropManager, animalManager);
            farm.Mainmenu();
        }
        

        
    }
}