﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Crop : Entity
    {

        public string CropType{ get; set; }
        private int Quantity{ get; set; } 
 

        public Crop(string aName, int aId, string aCropType, int aQuantity)
            :base (aName, aId)
        {
            Name = aName;
            Id = aId;
            CropType = aCropType;
            Quantity = aQuantity;
        }

        public override string GetDescription()
        {
            string description = "Name: " + Name + "Id: "+ Id + "Type: " + CropType + "Amount: " + Quantity;
            Console.WriteLine(description);
            return description;
        }

        public string cropsName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int GetCropQuantity()
        { return Quantity; }

        public void SetCropQuantity(int value)
        { Quantity = value; }

        public string GetCropType()
        { return CropType; }
        
        public int GetCropId() { return Id; }
    }
        


}

