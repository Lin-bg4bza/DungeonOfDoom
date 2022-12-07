﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
   public class Monster : Character
    {
        //fields
        private int _minDamage;
        //props
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                } //end if
                else
                {
                    _minDamage = 1;
                } //end else
            } // end set
        } // end int MinDamge
        //ctors
        public Monster()
        {

        }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }

        //methods
        public override string ToString()
        {
            return string.Format("\n" + LibrarySkin.scarymonster + "\n" +
                "{0}\n" +
                LibrarySkin.ow2 + "\n" +
                LibrarySkin.ow3 + "\n" +
                LibrarySkin.ow4 + "\n" +
                LibrarySkin.ow5 + "\n" ,
                Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }
    }
}
