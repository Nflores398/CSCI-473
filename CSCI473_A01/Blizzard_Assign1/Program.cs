/************************************************************************
   Team Blizzard
   PROGRAM:    Program.cs
   ASSIGNMENT: 1
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   1/28/21

   FUNCTION:  Console Application that represents a testing environment 
              for functionality for a game.

************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blizzard_Assign1
{
    class Program
    {
        public enum ItemType
        {
            Helmet = 0, Neck = 1, Shoulders = 2, Back = 3, Chest = 4,
            Wrist = 5, Gloves = 6, Belt = 7, Pants = 8, Boots = 9,
            Ring = 10, Trinket = 11
        };

        public enum Race { Orc, Troll, Tauren, Forsaken };

        private static readonly uint MAX_ILVL = 360;
        private static readonly uint MAX_PRIMARY = 200;
        private static readonly uint MAX_STAMINA = 275;
        private static readonly uint MAX_LEVEL = 60;
        private static readonly uint GEAR_SLOTS = 14;
        private static readonly uint MAX_INVENTORY_SIZE = 20;
        private static readonly uint MAX_EXP = 1830000;
        public class Item : IComparable<Item>
        {
            private readonly uint id;
            private string name;
            private ItemType type;
            private uint ilvl;
            private uint primary;
            private uint stamina;
            private uint requirement;
            private string flavor;

            //constructor
            public Item()
            {
                id = 0;
                name = "";
                type = 0;
                ilvl = 0;
                primary = 0;
                stamina = 0;
                requirement = 0;
                flavor = "";
            }
            public uint ID
            {
                get { return id; }
                set { }//no write-access
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public ItemType Type
            {
                get { return type; }
                set
                {
                    //if the value isnt in range than just return else set it to value
                    //if (value < 0 || value > 12)
                    //    return;
                    //else
                    type = value;
                }
            }
            public uint Ilvl
            {
                get { return ilvl; }
                set
                {
                    //if the value isnt in range than just return else set it to value
                    if (value < 0 || value > MAX_ILVL)
                        return;
                    //else
                    ilvl = value;
                }
            }
            public uint Primary
            {
                get { return primary; }
                set
                {
                    //if the value isnt in range than just return else set it to value
                    if (value < 0 || value > MAX_PRIMARY)
                        return;
                    //else
                    primary = value;
                }
            }
            public uint Stamina
            {
                get { return stamina; }
                set
                {
                    //if the value isnt in range than just return else set it to value
                    if (value < 0 || value > MAX_STAMINA)
                        return;
                    //else
                    stamina = value;
                }
            }
            public uint Requirement
            {
                get { return requirement; }
                set
                {
                    //if the value isnt in range than just return else set it to value
                    if (value < 0 || value > MAX_LEVEL)
                        return;
                    //else
                    requirement = value;
                }
            }
            public string Flavor
            {
                get { return flavor; }
                set { flavor = value; }
            }

            //alternate constructor
            public Item(uint newid, string newname, ItemType newitem, uint newilvl, uint newprimary, uint newstamina, uint newrequirement, string newflavor)
            {
                id = newid;
                Name = newname;
                Type = newitem;
                Ilvl = newilvl;
                Primary = newprimary;
                Stamina = newstamina;
                Requirement = newrequirement;
                Flavor = newflavor;
            }
            public int CompareTo(object obj)
            {
                try
                {
                    //checks if the obj is null
                    if (obj == null)
                        throw new ArgumentNullException();

                    //used to sort by names in the item sortedset
                    if (obj is Item rightOp)
                    {
                        return id.CompareTo(rightOp.id);
                    }
                    else
                        throw new ArgumentException();
                }
                //If an error has accord with sorting item
                catch
                {
                    Console.WriteLine("Error comparing Item names!");
                    return -1;

                }
            }
            //Formated output of Items
            public override string ToString()
            {
                return string.Format("({0}) {1} |{2}| --{3}--\n    \"{4}\"", type, name, ilvl, requirement, flavor.Trim());
            }
            int IComparable<Item>.CompareTo(Item other)
            {
                try
                {
                    //checks if the obj is null
                    if (other == null)
                        throw new ArgumentNullException();

                    //used to sort by names in the item sortedset
                    if (other is Item rightOp)
                    {
                        return name.CompareTo(rightOp.name);
                    }
                    else
                        throw new ArgumentException();
                }
                //If an error has accord with sorting item
                catch
                {
                    Console.WriteLine("Error comparing Item names!");
                    return -1;

                }

            }
        }
        //
        //end of item class
        //
        //sorted sets to store object player and Item
        private static readonly SortedSet<Player> peoplepool = new SortedSet<Player>();
        private static readonly List<Item> itemspool = new List<Item>();
        private static readonly List<Item> itemstemp = new List<Item>();

        public class Player : IComparable
        {
            private readonly uint id;
            private readonly string name;
            private readonly Race race;
            private uint level;
            private uint exp;
            private uint guildID;
            private uint[] gear;
            private readonly List<uint> inventory;
            //Default Constructor 
            public Player()
            {
                id = 0;
                name = System.String.Empty;
                level = 0;
                race = 0;
                exp = 0;
                guildID = 0;
                gear = new uint[14];
                inventory = new List<uint>(20);
            }
            //Consturctor
            public Player(uint newID, string newName, uint newLevel, Race newRace, uint newExp, uint newGuildiD, uint[] newGear, List<uint> newInventory)
            {
                id = newID;
                name = newName;
                level = newLevel;
                race = newRace;
                exp = newExp;
                guildID = newGuildiD;
                gear = new uint[GEAR_SLOTS];
                inventory = new List<uint>((int)Convert.ToUInt32(MAX_INVENTORY_SIZE));
                newGear.CopyTo(gear, 0);
                inventory = newInventory.ToList();
            }
            public uint ID
            {
                get { return id; }
                set { }
            }
            public string Name
            {
                get { return name; }
                set { }
            }
            public Race Race
            {
                get { return race; }
                set { }
            }
            public uint Level
            {
                get { return level; }
                set
                {
                    try
                    {
                        if (value < 0 || value > MAX_LEVEL)
                            throw new IndexOutOfRangeException();
                        else
                            level = value;
                    }
                    catch
                    {
                        Console.WriteLine("Level Out Of Range!");
                    }
                    //if the value isnt in range than just return else set it to value


                }
            }
            public uint Exp
            {
                get { return exp; }
                set { exp = value; }
            }

            public uint GuildID
            {
                get { return guildID; }
                set { guildID = value; }
            }
            public uint[] Gear
            {
                get { return gear; }
                set { gear = value; }
            }

            //this called when you unequip a item. this stores the the unequipped item in a inventory of size 20
            public void InventoryStore(uint newGearID)
            {
                foreach (Item item in itemspool)
                {
                    if (inventory.Count >= 20)
                    { //if the inventory is >= 20 spit out exception
                        throw new ArgumentException("the inventory is full");
                    }
                    if (newGearID.Equals(item.ID))
                    {
                        //check if item is trinket
                        if (item.Type == (ItemType)Convert.ToInt32(11))
                        {
                            //Checks if slot is filled
                            if (gear[13] != 0)
                            {
                                //gear[13]
                                inventory.Add(item.ID);
                                break;
                            }
                            //Checks if gear slot is filled
                            else if (gear[12] != 0)
                            {
                                //gear[12]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Ring
                        else if (item.Type == (ItemType)Convert.ToInt32(10))
                        {
                            //Checks if gear slot is filled
                            if (gear[11] != 0)
                            {
                                //gear[11]
                                inventory.Add(item.ID);
                                break;
                            }
                            //Checks if gear slot is filled
                            else if (gear[10] != 0)
                            {
                                //gear[10]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Boots
                        else if (item.Type == (ItemType)Convert.ToInt32(9))
                        {
                            //Checks if gear slot is filled
                            if (gear[9] != 0)
                            {
                                //gear[9]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Pants
                        else if (item.Type == (ItemType)Convert.ToInt32(8))
                        {
                            //Checks if gear slot is filled
                            if (gear[8] != 0)
                            {
                                //gear[8]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Belt
                        else if (item.Type == (ItemType)Convert.ToInt32(7))
                        {
                            //Checks if gear slot is filled
                            if (gear[7] != 0)
                            {
                                //gear[7]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }

                        }
                        //check if item is Gloves
                        else if (item.Type == (ItemType)Convert.ToInt32(6))
                        {
                            //Checks if gear slot is filled
                            if (gear[6] != 0)
                            {
                                //gear[6]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }

                        }
                        //check if item is Wrist
                        else if (item.Type == (ItemType)Convert.ToInt32(5))
                        {
                            //Checks if gear slot is filled
                            if (gear[5] != 0)
                            {
                                //gear[5]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Chest
                        else if (item.Type == (ItemType)Convert.ToInt32(4))
                        {
                            //Checks if gear slot is filled
                            if (gear[4] != 0)
                            {
                                //gear[4]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Back
                        else if (item.Type == (ItemType)Convert.ToInt32(3))
                        {
                            //Checks if gear slot is filled
                            if (gear[3] != 0)
                            {
                                //gear[3]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Shoulders
                        else if (item.Type == (ItemType)Convert.ToInt32(2))
                        {
                            //Checks if gear slot is filled
                            if (gear[2] != 0)
                            {
                                //gear[2]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Neck
                        else if (item.Type == (ItemType)Convert.ToInt32(1))
                        {
                            //Checks if gear slot is filled
                            if (gear[1] != 0)
                            {
                                //gear[1]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        //check if item is Helmet
                        else if (item.Type == (ItemType)Convert.ToInt32(0))
                        {
                            //Checks if gear slot is filled
                            if (gear[0] != 0)
                            {
                                //gear[0]
                                inventory.Add(item.ID);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No item in slot");
                                break;
                            }
                        }
                        else
                        {
                            //gear[Convert.ToInt32(item.Type)] = newGearID;
                            Console.WriteLine("Not a Item");
                        }
                        //if()//need a check. if the speciifed item is in the array
                        inventory.Add(item.ID);
                    }
                }
            }
            public void EquipGear(uint newGearID)
            {

                //loops to find id that matchs item
                foreach (Item item in itemspool)
                {
                    //After it finds item
                    if (newGearID.Equals(item.ID))
                    {
                        if (Level <= item.Requirement)//if players level doesnt match up with requirements
                        {
                            throw new ArgumentException("level is not high enough to equip");
                        }

                        //check if item is trinket
                        if (item.Type == (ItemType)Convert.ToInt32(11))
                        {
                            //Checks if gear[13] is empty
                            if (gear[13] == 0)
                            {
                                //gear[13]
                                gear[13] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else if (gear[12] == 0)
                            {
                                //gear[12]
                                gear[12] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Ring
                        else if (item.Type == (ItemType)Convert.ToInt32(10))
                        {
                            //Checks if spot is empty
                            if (gear[11] == 0)
                            {
                                //gear[11]
                                gear[11] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else if (gear[10] == 0)
                            {
                                //gear[10]
                                gear[10] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Boots
                        else if (item.Type == (ItemType)Convert.ToInt32(9))
                        {
                            if (gear[9] == 0)
                            {
                                //Checks if spot is empty
                                gear[9] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Pants
                        else if (item.Type == (ItemType)Convert.ToInt32(8))
                        {
                            //Checks if spot is empty
                            if (gear[8] == 0)
                            {
                                //gear[8]
                                gear[8] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Belt
                        else if (item.Type == (ItemType)Convert.ToInt32(7))
                        {
                            //Checks if spot is empty
                            if (gear[7] == 0)
                            {
                                //gear[7]
                                gear[7] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }

                        }
                        //check if item is Gloves
                        else if (item.Type == (ItemType)Convert.ToInt32(6))
                        {
                            //Checks if spot is empty
                            if (gear[6] == 0)
                            {
                                //gear[6]
                                gear[6] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }

                        }
                        //check if item is Wrist
                        else if (item.Type == (ItemType)Convert.ToInt32(5))
                        {
                            //Checks if spot is empty
                            if (gear[5] == 0)
                            {
                                //gear[5]
                                gear[5] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Chest
                        else if (item.Type == (ItemType)Convert.ToInt32(4))
                        {
                            //Checks if spot is empty
                            if (gear[4] == 0)
                            {
                                //gear[4]
                                gear[4] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Back
                        else if (item.Type == (ItemType)Convert.ToInt32(3))
                        {
                            //Checks if spot is empty
                            if (gear[3] == 0)
                            {
                                //gear[3]
                                gear[3] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Shoulders
                        else if (item.Type == (ItemType)Convert.ToInt32(2))
                        {
                            //Checks if spot is empty
                            if (gear[2] == 0)
                            {
                                //gear[2]
                                gear[2] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Neck
                        else if (item.Type == (ItemType)Convert.ToInt32(1))
                        {
                            //Checks if spot is empty
                            if (gear[1] == 0)
                            {
                                //gear[1]
                                gear[1] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        //check if item is Helmet
                        else if (item.Type == (ItemType)Convert.ToInt32(0))
                        {
                            //Checks if spot is empty
                            if (gear[0] == 0)
                            {
                                //gear[0]
                                gear[0] = newGearID;
                                Console.WriteLine("The Item was equipped");
                            }
                            else
                            {
                                Console.WriteLine("Item already equipped");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not a Item");
                        }
                    }
                }
            }
            public void UnequipGear(int gearSlot)
            {
                foreach (Item item in itemspool)
                {
                    //After it finds item
                    if (item.Type.Equals((ItemType)Convert.ToInt32(gearSlot)))
                    {
                        //check if item is trinket
                        if (item.Type == (ItemType)Convert.ToInt32(11))
                        {
                            //Checks if gear[13] is not empty
                            if (gear[13] != 0)
                            {
                                //Empty the gear slot
                                gear[13] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else if (gear[12] != 0)
                            {
                                //Empty the gear slot
                                gear[12] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Ring
                        else if (item.Type == (ItemType)Convert.ToInt32(10))
                        {
                            //Checks if spot is not empty
                            if (gear[11] != 0)
                            {
                                //Empty the gear slot
                                gear[11] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else if (gear[10] != 0)
                            {
                                //Empty the gear slot
                                gear[10] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Boots
                        else if (item.Type == (ItemType)Convert.ToInt32(9))
                        {
                            if (gear[9] != 0)
                            {
                                //Empty the gear slot
                                gear[9] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Pants
                        else if (item.Type == (ItemType)Convert.ToInt32(8))
                        {
                            if (gear[8] != 0)
                            {
                                //Empty the gear slot
                                gear[8] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                        }
                        //check if item is Belt
                        else if (item.Type == (ItemType)Convert.ToInt32(7))
                        {
                            if (gear[7] != 0)
                            {
                                //Empty the gear slot
                                gear[7] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }

                        }
                        //check if item is Gloves
                        else if (item.Type == (ItemType)Convert.ToInt32(6))
                        {
                            if (gear[6] != 0)
                            {
                                //Empty the gear slot
                                gear[6] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }

                        }
                        //check if item is Wrist
                        else if (item.Type == (ItemType)Convert.ToInt32(5))
                        {
                            if (gear[5] != 0)
                            {
                                //Empty the gear slot
                                gear[5] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                        }
                        //check if item is Chest
                        else if (item.Type == (ItemType)Convert.ToInt32(4))
                        {
                            if (gear[4] != 0)
                            {
                                //Empty the gear slot
                                gear[4] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Back
                        else if (item.Type == (ItemType)Convert.ToInt32(3))
                        {
                            if (gear[3] != 0)
                            {
                                //Empty the gear slot
                                gear[3] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Shoulders
                        else if (item.Type == (ItemType)Convert.ToInt32(2))
                        {
                            if (gear[2] != 0)
                            {
                                //Empty the gear slot
                                gear[2] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Neck
                        else if (item.Type == (ItemType)Convert.ToInt32(1))
                        {
                            if (gear[1] != 0)
                            {
                                //Empty the gear slot
                                gear[1] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        //check if item is Helmet
                        else if (item.Type == (ItemType)Convert.ToInt32(0))
                        {
                            if (gear[0] != 0)
                            {
                                //Empty the gear slot
                                gear[0] = 0;
                                Console.WriteLine("The Item was unequipped");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty");
                                break;
                            }
                        }
                        else
                        {
                            //gear[Convert.ToInt32(item.Type)] = newGearID;
                            Console.WriteLine("Not a Item");
                        }

                    }
                }
            }
            //Formated output of player info
            public override string ToString()
            {
                return string.Format("Name: {0,-10}\t Race: {1,-7}\t Level: {2,-5}\t Guild: ", Name, Race, Level);
            }
            //Used to sort players by name in the sortedset 
            public int CompareTo(object obj)
            {
                try
                {
                    //checks if the obj is null
                    if (obj == null)
                        throw new ArgumentNullException();

                    //used to sort by names in the Player sortedset
                    if (obj is Player rightOp)
                    {
                        return name.CompareTo(rightOp.name);
                    }
                    else
                        throw new ArgumentException();
                }
                //If an error has accord with sorting players
                catch
                {
                    Console.WriteLine("Error comparing player names!");
                    return -1;

                }
            }
        }

        static void Main()
        {
            //Stores all guilds
            string[,] guildsIDnames = new string[7, 2];
            //Stores players before being placed in an object
            string[,] playerInfo = new string[3, 20];
            //Stores Items before being stored as an object
            string[,] equipmentList = new string[21, 8];
            //Used to store a Players gear before being stored in the object
            uint[] playerGear = new uint[14];
            //A helper array to hold temp  
            _ = new string[60];
            //Path of guilds text
            string path = "../../../Input Files/guilds.txt";
            //Reads in all the text of path
            string fileInput = File.ReadAllText(path);
            //Temp list for invertory
            List<uint> inventory = new List<uint>(20);
            //Splits up file input text and stores in temp array
            string[] temp = fileInput.Split('\t', '\n');
            //Calls filereader to put array into 2d array
            FileReader(guildsIDnames, temp);
            path = "../../../Input Files/Players.txt";
            fileInput = File.ReadAllText(path);
            //testing reading file into array
            temp = fileInput.Split('\t', '\n');
            FileReader(playerInfo, temp);
            path = "../../../Input Files/equipment.txt";
            fileInput = File.ReadAllText(path);
            //testing reading file into array
            temp = fileInput.Split('\t', '\n');
            FileReader(equipmentList, temp);
            Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviroment!");
            //Creates objects for each player
            for (int i = 0; i < playerInfo.GetLength(0); i++)
            {
                //calls function that stores the gear of a player into an array of just gear
                SetPlayergear(playerGear, playerInfo, i);
                //Order of what part of the array is being stored
                //uint newID, string newName, uint newLevel, Race newRace, uint newExp, uint newGuildiD, uint[] newGear, List<uint> newInventory
                Player player = new Player((uint)Convert.ToInt32(playerInfo[i, 0]), Convert.ToString(playerInfo[i, 1]), (uint)Convert.ToInt32(playerInfo[i, 3]), (Race)Convert.ToInt32(playerInfo[i, 2]), (uint)Convert.ToInt32(playerInfo[i, 4]), (uint)Convert.ToInt32(playerInfo[i, 5]), playerGear, inventory);
                //Adds player object into sortedset peoplepool
                peoplepool.Add(player);
            }
            //Creates objects for each item and stores it into a sortedset
            for (int i = 0; i < equipmentList.GetLength(0); i++)
            {
                //Order of what part of the array is being stored
                //uint newid, string newname, ItemType newitem, uint newilvl, uint newprimary, uint newstamina, uint newrequirement, string newflavor
                Item item = new Item((uint)Convert.ToInt32(equipmentList[i, 0]), equipmentList[i, 1], (ItemType)Convert.ToInt32(equipmentList[i, 2]), (uint)Convert.ToInt32(equipmentList[i, 3]), (uint)Convert.ToInt32(equipmentList[i, 4]), (uint)Convert.ToInt32(equipmentList[i, 5]), (uint)Convert.ToInt32(equipmentList[i, 6]), equipmentList[i, 7]);
                //Adds item object into sortedset itemspool
                itemspool.Add(item);
            }
            //Stores items to be sorted by name later
            foreach (Item i in itemspool)
            {
                itemstemp.Add(i);
            }
            //repeats ontill user selects option 10 from menu
            while (true)
            {
                Console.WriteLine();
                //Passing in the array of guilds names
                Menu(guildsIDnames);
            }
        }
        //Used to get a players gear and store it into an array
        static void SetPlayergear(uint[] gear, string[,] player, int currentplayer)
        {
            int f = 0;
            //player[x,6-19] stores all the items a player has equipped 
            for (int i = 6; i < 20; i++)
            {
                //Adds each item that a player has into an array
                gear[f] = (uint)Convert.ToInt32(player[currentplayer, i]);
                f++;
            }
        }
        //Used to convert single array into 2d array
        static void FileReader(string[,] arr2d, string[] arr)
        {
            int k = 0;
            //Loops through and puts the each player and there info into the arr2d[] from the arr[]
            for (int i = 0; i < arr2d.GetLength(0); i++)
            {
                for (int j = 0; j < arr2d.GetLength(1); j++)
                {
                    arr2d[i, j] = arr[k];
                    k++;

                }
            }
        }


        static void Menu(string[,] guilds)
        {
            //helper variables
            bool Found = false;
            bool Found2 = false;
            string userName;
            string guildName;
            string gearName;
            string userInput;
            string itemRemove = System.String.Empty;
            string playersguild = System.String.Empty;
            uint expGiven;
            uint expPerLv;
            uint count;
            Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviroment. Please select an option from the list below:");
            //options of menu
            Console.WriteLine("\t 1.) Print All Players\n\t 2.) Print All Guilds\n\t 3.) List All Gear\n\t 4.) Print Gear List for Players\n\t 5.) Leave Guild\n\t 6.) Join Guild\n\t 7.) Equip Gear\n\t 8.) Unequip Gear\n\t 9.) Award Experience\n\t 10.) Quit");
            //Reads user input
            userInput = Console.ReadLine();

            //Checks for other words that triggers the program to exit
            if (userInput == "10" || userInput == "q" || userInput == "Q" || userInput == "quit" || userInput == "Quit" || userInput == "exit" || userInput == "Exit")
            {
                userInput = "10";
            }

            switch (userInput)
            {
                case "1":
                    //Print all players names,race,level,Guild
                    foreach (Player i in peoplepool)
                    {

                        //This checks if players in guild
                        if (i.GuildID != 0)
                        {
                            //If so then check if there id is valid
                            for (int f = 0; f < guilds.GetLength(0); f++)
                            {
                                //If guild is found in list
                                if (guilds[f, 0].Equals(Convert.ToString(i.GuildID)))
                                {
                                    playersguild = guilds[f, 1];
                                }

                            }
                        }
                        else
                        {
                            playersguild = "None";
                        }
                        //Format needs to be adjusted slightly
                        Console.WriteLine(i.ToString() + playersguild);
                    }
                    break;
                case "2":
                    //Print all the guilds
                    for (int i = 0; i < 7; i++)
                    {
                        Console.WriteLine(guilds[i, 1]);
                    }
                    break;
                case "3":
                    //List all gear
                    foreach (Item i in itemspool)
                    {
                        Console.WriteLine(i.ToString());
                    }
                    break;
                case "4":
                    //Players items
                    //loops untill player is found
                    while (!Found)
                    {
                        //user enters name
                        Console.Write("Enter the player name: ");
                        userName = Console.ReadLine();
                        //loops through all players
                        foreach (Player i in peoplepool)
                        {
                            //if the user input name is found
                            if (i.Name.Equals(userName))
                            {
                                //This checks if players in guild
                                if (i.GuildID != 0)
                                {
                                    //If so then check if there id is vaild
                                    for (int f = 0; f < guilds.GetLength(0); f++)
                                    {
                                        //If guild is found in list
                                        if (guilds[f, 0].Equals(Convert.ToString(i.GuildID)))
                                        {
                                            //sets players guild
                                            playersguild = guilds[f, 1];
                                        }
                                    }
                                }
                                //If the user is in no guild then sets guild to none
                                else
                                {
                                    playersguild = "None";
                                }
                                //Prints player info + guild they are in
                                Console.WriteLine(i.ToString() + playersguild);
                                //keeps track of which item slots have been checked
                                count = 0;

                                //Makes sure count isnt greater than array size to prevent crashing
                                while (count < i.Gear.GetLength(0))
                                {
                                    //Checks and prints if the gear slot is empty
                                    if ((i.Gear[count] == 0))
                                    {
                                        //If a trinket is empty for slot 1 and 2
                                        if (count == 12 || count == 13)
                                        {
                                            Console.WriteLine("({0,2}): Empty", ((ItemType)11));
                                        }
                                        //If a ring is empty for slot 1 and 2
                                        else if (count == 10 | count == 11)
                                        {
                                            Console.WriteLine("({0,2}) : Empty", ((ItemType)10));
                                        }
                                        //Any other slot that is empty
                                        else
                                        {
                                            Console.WriteLine("({0,2}) : Empty", ((ItemType)count));
                                        }
                                    }
                                    //Else matchs gear id to item and print item
                                    else
                                    {
                                        //Checks current gear[] through every item id
                                        foreach (Item f in itemspool)
                                        {
                                            //if item is found
                                            if (i.Gear[count].Equals(f.ID))
                                            {
                                                //print item
                                                Console.WriteLine(f.ToString());
                                            }
                                        }
                                    }
                                    //increase count to move to the next part of the player gear array
                                    count++;
                                }
                                //once every slot has been printed then escape loop
                                Found = true;
                            }
                        }
                        //If player is not found info user and let them enter a new player name
                        if (Found == false)
                        {
                            Console.WriteLine("Player not found!");
                        }
                    }

                    break;
                case "5":
                    //Leave Guild
                    //Loops until user enters vaild name
                    while (!Found)
                    {
                        //user enter name
                        Console.Write("Enter the player name: ");
                        userName = Console.ReadLine();
                        //checks for name by looping through all player in the sorted set
                        foreach (Player i in peoplepool)
                        {
                            //If enter name is found
                            if (i.Name.Equals(userName))
                            {
                                //then checks if the user is in a guild
                                if (i.GuildID != 0)
                                {
                                    //If player is in guild then its set to 0 
                                    i.GuildID = 0;
                                    Console.WriteLine(i.Name + " has left their guild!");
                                    //set to found to true to escape loop
                                    Found = true;
                                }
                                else
                                {
                                    //else tell user that the player is not in a guild
                                    Console.WriteLine(i.Name + " is not in a guild!");
                                    Found = true;
                                }
                            }
                        }

                    }

                    break;
                case "6":
                    //Join Guild
                    //Loop to check if player is found
                    while (!Found)
                    {
                        //user enters player
                        Console.Write("Enter the player name: ");
                        userName = Console.ReadLine();
                        //Loops through all players
                        foreach (Player i in peoplepool)
                        {
                            //If name is found
                            if (i.Name.Equals(userName))
                            {
                                //Check if player is already in guild
                                if (i.GuildID != (uint)Convert.ToInt32(0))
                                {
                                    Console.WriteLine(userName + "Is already in a Guild");
                                    //Sets true to escape loop
                                    Found = true;
                                }
                                //If user is not in a guild
                                else if (i.GuildID == Convert.ToInt32(0))
                                {
                                    //Loop untill user enters vaild guild
                                    while (!Found2)
                                    {
                                        //user enters guild
                                        Console.Write("Enter the Guild they will join: ");
                                        guildName = Console.ReadLine();
                                        //Loops though guild array to see if the guild exist
                                        for (int f = 0; f < guilds.GetLength(0); f++)
                                        {
                                            if (guilds[f, 1].Trim().Equals(guildName.Trim()))
                                            {
                                                i.GuildID = (uint)Convert.ToInt32(guilds[f, 0]);
                                                //Add join method here
                                                Console.WriteLine(userName + " has Joined " + guildName + "!");
                                                //Sets to true to escape loops
                                                Found2 = true;
                                                Found = true;
                                            }
                                        }
                                        //If guild does not exist tell user
                                        if (Found2 == false)
                                        {
                                            Console.WriteLine("Guild Not Found!");
                                        }
                                    }
                                }
                            }
                        }
                        //If player is not found
                        if (Found == false)
                        {
                            Console.WriteLine("Player not found!");
                        }
                    }

                    break;
                case "7":
                    //Equip Gear
                    //User enters player
                    Console.Write("Enter the player name: ");
                    userName = Console.ReadLine();
                    //User enters gear they want to equip to player
                    Console.Write("Enter the item name they will equip: ");
                    gearName = Console.ReadLine();
                    foreach (Player i in peoplepool)
                    {
                        if (i.Name.Equals(userName))
                        {
                            foreach (Item f in itemspool)
                            {

                                if (gearName.Equals(f.Name))
                                {
                                    try
                                    {
                                        i.EquipGear(f.ID);
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                        }
                    }

                    break;
                case "8":
                    //Unequip Gear
                    Console.Write("Enter the player name: ");
                    userName = Console.ReadLine();
                    Console.WriteLine("Enter the item slot number they will unequip: \n\t0 = Helmet\n\t1 = Neck\n\t2 = Shoulders\n\t3 = Back\n\t4 = Chest\n\t5 = Wrist\n\t6 = Gloves\n\t7 = Belt\n\t8 = Pants\n\t9 = Boots \n\t10 = Ring\n\t11 = Trinket\n");
                    itemRemove = Console.ReadLine(); // item to be removed

                    foreach (Player i in peoplepool)
                    {
                        if (i.Name.Equals(userName))
                        {
                            foreach (Item item in itemspool)
                            {
                                try
                                {
                                    if (item.Type.Equals((ItemType)Convert.ToInt32(itemRemove)))
                                    {
                                        try
                                        {
                                            i.InventoryStore(item.ID); // stores the item into inventory
                                            i.UnequipGear(Convert.ToInt32(itemRemove));
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }

                                        break;
                                    }

                                }
                                catch
                                {
                                    //If user enters not vaild choice
                                    Console.WriteLine("Invaild Input");
                                    break;
                                }
                            }
                        }
                    }


                    break;
                case "9":
                    //Award Experience
                    //Loops until user is found
                    while (Found == false)
                    {
                        //User enters Player nem
                        Console.Write("Enter the player name: ");
                        userName = Console.ReadLine();
                        //loops through all player
                        foreach (Player i in peoplepool)
                        {
                            //if player is found
                            if (i.Name.Equals(userName))
                            {
                                //Checks if player is at max level
                                if (i.Level != MAX_LEVEL)
                                {
                                    //User enters amount of exp to give player
                                    Console.Write("Enter the amount of experience to award: ");
                                    expGiven = (uint)Convert.ToInt32(Console.ReadLine());
                                    //checks to see if given exp is less then the max amount
                                    if (expGiven < MAX_EXP)
                                    {
                                        //adds any exp the player hads
                                        expGiven += i.Exp;
                                        //calc exp per lv
                                        expPerLv = i.Level * 1000;
                                        //Loops until exp given is less then exp to get level
                                        while (expGiven > expPerLv)
                                        {
                                            //Increase player's lv
                                            if (i.Level < MAX_LEVEL)
                                            {
                                                i.Level++;
                                                Console.WriteLine("DING!");
                                            }
                                            //subtract amount of exp to reach lv
                                            expGiven -= expPerLv;
                                            //calc new exp requirment for next lv
                                            expPerLv = i.Level * 1000;

                                        }
                                        //Once out of loop set any extra exp to i.exp if under lv 60
                                        if (i.Level < MAX_LEVEL)
                                        {
                                            i.Exp = expGiven;
                                            Found = true;
                                        }
                                        //If player is already 60 then set exp to 0;
                                        else
                                        {
                                            i.Exp = 0;
                                            Found = true;
                                        }
                                    }
                                    else
                                    {
                                        //If user enter exp amount too high
                                        Found = true;
                                    }

                                }
                                //inform user that player is already max lv
                                else
                                {
                                    Console.WriteLine(i.Name + " Is at max level!");
                                    Found = true;
                                }
                            }

                        }
                        //inform user that player is not found
                        if (Found == false)
                        {
                            Console.WriteLine("Player Not Found!");
                        }
                    }

                    break;
                case "10":
                    //Quit Program
                    Console.WriteLine("Closing");
                    Environment.Exit(0);
                    break;
                case "T":
                case "t":
                    //Select option: IComparable testing method.
                    Console.WriteLine("\tAll Players\n---------------------------");
                    foreach (Player i in peoplepool)
                    {
                        //This checks if players in guild
                        if (i.GuildID != 0)
                        {
                            //If so then check if there id is vaild
                            for (int f = 0; f < guilds.GetLength(0); f++)
                            {
                                //If guild is found in list
                                if (guilds[f, 0].Equals(Convert.ToString(i.GuildID)))
                                {
                                    playersguild = guilds[f, 1];
                                }

                            }
                        }
                        //if the user is not in a guild
                        else
                        {
                            playersguild = "None";
                        }
                        //Prints player info and guild they are in
                        Console.WriteLine(i.ToString() + playersguild);
                    }
                    Console.WriteLine("\n\tAll Items\n---------------------------");
                    //Sorts items by name
                    itemstemp.Sort();
                    //loops and prints all items that exist
                    foreach (Item i in itemstemp)
                    {

                        Console.WriteLine(i.ToString());
                    }
                    break;
            }
        }
    }

}