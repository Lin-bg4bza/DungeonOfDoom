using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
        //This is all Cecilia!
        //properties
        public int AddDmg { get; set; }
        public string Name { get; set; }
        public int AddBonusHitChance { get; set; }
        public int AddBlock { get; set; }
        public string Rarity { get; set; }

        //ctors
        public Item(int addDmg, string name, int addbonusHitChance, int addBlock, string rarity)
        {
            AddDmg = addDmg;
            Name = name;
            AddBonusHitChance = addbonusHitChance;
            AddBlock = addBlock;
            Rarity = rarity;
        }
        //methods
        public override string ToString()
        {
            return string.Format("{0}\n" +
                "\t" + LibrarySkin.itemdamage +
                "\n\t" + LibrarySkin.itemhit +
                "\n\t" + LibrarySkin.itemblock +
                "\n\t" + LibrarySkin.itemrarity,
                Name, AddDmg, AddBonusHitChance, AddBlock, Rarity);
        }

    }
}
