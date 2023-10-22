using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmInlämning
{
    internal class Entity
    {
        protected string name;
        public string id;

        public Entity(string aName, string aId)
        {
            name = aName;
            id = aId;
        }

        public abstract void GetDescritpion();
    }
}
