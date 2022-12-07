using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Potion
    {
        //This is all Cecilia!
        //properties
        public int Heal { get; set; }
        public int Dmg { get; set; }
        public string Name { get; set; }

        //ctors
        public Potion(int heal, string name, int dmg)
        {
            Heal = heal;
            Dmg = dmg;
            Name = name;

        }


    }
}
