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
            Farm farm = new Farm(cropManager);
            farm.Mainmenu();
        }
        

        
    }
}