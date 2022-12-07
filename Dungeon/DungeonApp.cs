using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dungeon;
using DungeonLibrary;

namespace DungeonApp
{
    class DungeonApp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            Console.Title = (skin.title);
            string ISO = langPicker();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n" + skin.welcome);
            Console.ResetColor();

            //TODO 1. Create a variable that will keep track of player score
            int score = 0;

            //TODO 2. Create the Weapon
            Weapon w1 = new Weapon(1, 15,skin.w1, 5, false);
            Weapon w2 = new Weapon(1, 6, skin.w2, 3, false);
            Weapon w3 = new Weapon(1, 12, skin.w3, 7, true);
            Weapon w4 = new Weapon(1, 10, skin.w4, 10, false);
            Weapon w5 = new Weapon(1, 15, skin.w5, 7, false);
            Weapon w6 = new Weapon(1, 30, skin.w6, 20, false);
            Weapon w7 = new Weapon(1, 20, skin.w7, 5, true);

            //Put created weapons into an array
            Weapon[] weaponList = { w1, w2, w3, w4, w5 };
            //randomly select weapon
            Random randWeapon = new Random();
            int weapon = randWeapon.Next(weaponList.Length);
            Weapon mainWeapon = weaponList[weapon];

            //!!!!! Cecilia
            //potions
            Potion p1 = new Potion(5, skin.p1, 0);
            Potion p2 = new Potion(15, skin.p2, 0);
            Potion p3 = new Potion(0, skin.p3, 5);
            Potion p4 = new Potion(2, skin.p4, 0);
            Potion p5 = new Potion(0, skin.p5, 20);
            //items
            Item i1 = new Item(2, skin.i1, 3, 0, skin.standard);
            Item i2 = new Item(0, skin.i2, 4, 1, skin.standard);
            Item i3 = new Item(3, skin.i3, 2, 0, skin.standard);
            Item i4 = new Item(8, skin.i4, 3, 2, skin.rare);
            Item i5 = new Item(3, skin.i5, 2, 8, skin.rare);
            Item i6 = new Item(0, skin.i6, 0, 0, skin.none);
            Item i7 = new Item(2, skin.i7, 8, 3, skin.rare);

            Potion[] potionLoot = { p1, p2, p3, p4 };
            Item[] regularItem = { i1, i2, i3 };
            Item[] rareItem = { i4, i5, i7 };
            //!!!!! Cecilia

            //TODO 3. Create players

            Player viking = new Player(skin.viking, 70, 10, 100, 100, Race.Viking, mainWeapon, i6);
            Player chief = new Player(skin.chief, 90, 20, 120, 120, Race.Fallen, w5, i6);
            Player deathWing = new Player(skin.deathwing, 95, 50, 200, 200, Race.Dragon, w6 ,i6);
            Player elf = new Player(skin.elf, 60, 10, 100, 100, Race.Elf, mainWeapon, i2);
            Player caveMan = new Player(skin.caveman, 40, 50, 300, 300, Race.Caveman, w2, i6);
            Player orc = new Player(skin.orc, 80, 20, 150, 150, Race.Orc, w3, i6);
            Player gnome = new Player(skin.gnome, 100, 10, 50, 50, Race.Gnome, mainWeapon, i6);
            Player native = new Player(skin.native, 70, 20, 130, 130, Race.Native, w5, i6);
            Player goblin = new Player(skin.goblin, 75, 15, 80, 80, Race.Goblin, w1, i6);
            Player localization = new Player(skin.localization, 90, 30, 100, 100, Race.Localization, w7, i6);



            //TODO 4. Create the outer dowhile loop that manages game
            /*Console.WriteLine("\nSelect your player\n" +
                        "A) Viking\n" +
                        "B) Chief\n" +
                        "C) Deathwing\n" +
                        "D) Elf\n" +
                        "E) Caveman\n" +
                        "F) Orc\n" +
                        "G) Gnome\n" +
                        "H) Native\n" +
                        "I) Goblin\n" +
                        "J) Localization Professional")
                ;*/

            Console.WriteLine("\n" + skin.selectPlayer);


            ConsoleKey userPlayer = Console.ReadKey(true).Key;
            Console.Clear();
            Player selectedPlayer = goblin;
            switch (userPlayer)
            {
                case ConsoleKey.A:
                    selectedPlayer = viking;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.B:
                    selectedPlayer = chief;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.C:
                    selectedPlayer = deathWing;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.D:
                    selectedPlayer = elf;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.E:
                    selectedPlayer = caveMan;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.F:
                    selectedPlayer = orc;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.G:
                    selectedPlayer = gnome;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.H:
                    selectedPlayer = native;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.I:
                    selectedPlayer = goblin;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;
                case ConsoleKey.J:
                    selectedPlayer = localization;
                    Console.WriteLine(skin.selected, selectedPlayer);
                    break;


                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(skin.validOption + "\n");
                    Console.ResetColor();
                    break;
            }

            //counter
            bool exit = false;

            do
            {
                //TODO 5. Write a method for getting room description
                Console.WriteLine(GetRoom());
                //TODO 6. Create monsters for the player to compete against
                //create monsters here
                Rabbit r1 = new Rabbit(skin.r1, 12, 12, 80, 20, 2, 6, skin.r1description, true);
                Rabbit r2 = new Rabbit();
                Vampire v1 = new Vampire(skin.v1, 25, 25, 40, 40, 2, 12, skin.v1description);
                Gorilla g1 = new Gorilla();
                Gorilla g2 = new Gorilla(skin.g2, 60, 60, 55, 15, 4, 13, skin.g2description, true);

                //Cecilia
                Zombie z1 = new Zombie(skin.z1, 20, 20, 70, 10, 5, 10, skin.z1description, true);
                Zombie z2 = new Zombie();
                //Cecilia


                //store monsters in collection
                Monster[] monsters = { r1, r2, v1, g1, g2, z1, z2 };
                //randomly generate the monster to compete against
                Random rand = new Random();
                int randNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randNbr];
                //show the monster in the room
                Console.WriteLine("\n" + skin.inThisRoom, monster.Name);
                //TODO 7. Create a loop for the game menu

                bool reload = false;
                do
                {


                    //TODO 8. Create the menu for interaction with the monster and write it to the screen
                    #region Menu
                    /*Console.WriteLine("\nChoose an action:\n" +
                        "1) Attack\n" +
                        "2) Run\n" +
                        "3) Player Information\n" +
                        "4) Monster Information\n" +
                        "5) Exit Application");*/
                    Console.WriteLine("\n"+skin.chooseAction);
                    #endregion
                    //TODO 8a. Wait and Capture the user input for their selection in the menu
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    //TODO 8b. Create a switch that houses the functionality based on user choice
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine(skin.attack);
                            Combat.DoBattle(selectedPlayer, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n" + skin.d1 + "\n", monster.Name);
                                Console.ResetColor();
                                //Loot System!! Cecilia
                                Random rnd = new Random();
                                int perCent = rnd.Next(0, 100);

                                if (perCent < 60)
                                {
                                    Console.WriteLine("\n" + skin.cheap + "\n");
                                }
                                else if (perCent < 60 + 20)
                                {
                                    Random randLoot = new Random();
                                    int randNum = rand.Next(potionLoot.Length);
                                    Potion Potion = potionLoot[randNum];
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("\n" + skin.loot, Potion.Name);
                                    
                                    Console.ResetColor();
                                    if (Potion.Name.Contains(skin.poison))
                                    {
                                        Console.WriteLine(skin.potion + "\n", Potion.Dmg, selectedPlayer.Life, selectedPlayer.MaxLife);

                                    } else
                                    {
                                        Console.WriteLine(skin.potion2, Potion.Heal, selectedPlayer.Life, selectedPlayer.MaxLife);
                                    }
                                    selectedPlayer.Life = selectedPlayer.Life + Potion.Heal - Potion.Dmg;

                                }
                                else if (perCent < 60 + 20 + 15)                                
                                {
                                    Random randLoot = new Random();
                                    int randNum = rand.Next(regularItem.Length);
                                    Item item = regularItem[randNum];
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine("\n" + skin.corpse, item.Name);
                                    Console.ResetColor();
                                    if (selectedPlayer.EquippedItem.Rarity.Contains(skin.rare)) {
                                        Console.WriteLine(skin.item+"\n");
                                    } else
                                    {
                                        Console.WriteLine("\n" + skin.equip + "\n", item.Name);
                                        selectedPlayer.EquippedItem = item;
                                    }
                                    



                                }
                                else if (perCent <60 + 20 +15+5)
                                {
                                    Random randLoot = new Random();
                                    int randNum = rand.Next(rareItem.Length);
                                    Item item = rareItem[randNum];
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    if (item.Name.Contains(skin.i18n))
                                    {
                                        Console.WriteLine("\n" + skin.i18n2, item.Name);
                                    } else
                                    {
                                        Console.WriteLine("\n" + skin.i18n3, item.Name);
                                    }
                                    Console.ResetColor();
                                    Console.WriteLine("\n" + skin.equip + "\n", item.Name);
                                    selectedPlayer.EquippedItem = item;
                                }
                                //Loot system ends!
                                reload = true;
                                score++;
                            } //end if
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine(skin.run);
                            Console.WriteLine(skin.monsterattack, monster.Name);
                            Combat.DoAtk(monster, selectedPlayer);
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine(skin.playerinfo);
                            Console.WriteLine(selectedPlayer);
                            Console.WriteLine(skin.defeat + score);
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine(skin.monsterinfo);
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.D5:
                            Console.WriteLine(skin.disgrace+"\n");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine(skin.actionNO);
                            break;
                    }
                    if (selectedPlayer.Life <= 0)
                    {
                        Console.WriteLine("\n" + skin.death, monster.Name);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n" + skin.dead + "\n");
                        Console.ResetColor();
                        exit = true;
                    }

                } while (!exit && !reload);
            } while (!exit);
            Console.WriteLine(skin.gameover +
                        skin.defeatmonsters, score);
            Console.ReadLine();
            //TODO 9. If the player has died, we are going to give them a message here about how many monsters they have defeated

        } //end main
        //TODO 10. Create the GetRoom() and plug it in here. Make sure to call the GetRoom() in TODO 4

        private static string GetRoom()
        {
            string[] rooms = {skin.room,
            skin.room2,
            skin.room3,
            skin.room4,
            skin.room5,
            skin.room6,
            skin.room7,
            skin.room8,
            skin.room9,
            skin.room10};
            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];

            return room;


        } //end GetRoom()

        //localization!
        static string langPicker()
        {
            string answer = null;
            Console.WriteLine("This game is available in the following languages!");
            var locale = new List<string> { "en-US", "zh-CN", "ja-JP", "fr-FR" };
            Console.WriteLine(string.Join("\t", locale));

            Console.WriteLine("Please enter the ISO code of the langauge you would like to utilize");
            answer = Console.ReadLine();
            Console.WriteLine("You have chosen {0}.", answer);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(answer);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(answer);

            return answer;
        }
    } // end class

} //end namespace
