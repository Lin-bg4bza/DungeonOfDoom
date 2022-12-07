using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Zombie : Monster
    {
        //fields

        //prop
        public bool IsFlood { get; set; }
        //ctor
        public Zombie(string name, int life, int maxLife, int hitChance, int block, int minDmg, int maxDmg, string description, bool isFlood) : base(name, life, maxLife, hitChance, block, minDmg, maxDmg, description)
        {
            IsFlood = isFlood;
        }

        public Zombie()
        {
            MaxLife = 5;
            MaxDamage = 4;
            Name = LibrarySkin.z2;
            Life = 5;
            HitChance = 20;
            Block = 8;
            MinDamage = 2;
            Description = LibrarySkin.z2description;
            IsFlood = false;
        }
        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFlood ? LibrarySkin.flood : LibrarySkin.notFlood);
        }

        public override int CalcBlock()
        {
            int floodBlock = Block;

            if (IsFlood)
            {
                floodBlock += floodBlock / 2;
            }
            return floodBlock;
        }
    }
}
