using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Entity
    {
        protected string Name{get; set;}
        public int Id{get; set;}

        public Entity(string aName, int aId)
        {
            Name = aName;
            Id = aId;
        }

        public abstract void GetDescription();
    }
}
