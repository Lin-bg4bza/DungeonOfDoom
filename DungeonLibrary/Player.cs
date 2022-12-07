using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //fields
        //properties
        //Added items! Cecilia
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Item EquippedItem { get; set; }
        //ctors
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon, Item equippedItem)
        {
            MaxLife = maxLife;
            Name = name;
            Block = block;
            HitChance = hitChance;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            EquippedItem = equippedItem;
        } //end Player()
        //methods
        public override string ToString()
        {
            return string.Format("-=-= {0} -=-=" +
                "\n" + LibrarySkin.p2 +
                "\n" + LibrarySkin.p3 +
                "\n" + LibrarySkin.p4 +
                "\n" + LibrarySkin.p5 +
                "\n" + LibrarySkin.p6 + "\n",
                Name, Life, MaxLife, HitChance, EquippedWeapon, Block, CharacterRace, EquippedItem);
        }//end ToString()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int dmg = rand.Next(EquippedWeapon.MinDmg, EquippedWeapon.MaxDmg + 1 + EquippedItem.AddDmg);
            return dmg;
        } //end CalcDamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance + EquippedItem.AddBonusHitChance;
        } //end int CalcHitChance()

        public override int CalcBlock()
        {
            return base.CalcBlock() + EquippedItem.AddBlock;
        }


    } //end class
} //end namespace
