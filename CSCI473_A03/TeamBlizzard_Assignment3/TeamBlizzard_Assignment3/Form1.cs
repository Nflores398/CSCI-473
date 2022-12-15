/************************************************************************
   Team Blizzard
   PROGRAM:    Form1.cs
   ASSIGNMENT: 3
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   2/25/21

   FUNCTION:   Windows Form app that uses LINQ queries to filter large collections of data.
   
************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TeamBlizzard_Assignment3
{
    public partial class Form1 : Form
    {
        public enum Class { Warrior, Mage, Druid, Priest, Warlock, Rogue, Paladin, Hunter, Shaman };
        public enum Role { Tank, Healer, Damage };
        public enum GuildType { Causal, Questing, MythicPlus, Raiding, PVP };
        public enum Servers { Beta4Azeroth, TKWasASetback, ZappyBoi };
        public enum Race { Orc, Troll, Tauren, Forsaken };
        private static readonly SortedSet<Player> Playerspool = new SortedSet<Player>();
        private static readonly SortedSet<Guild> Guildspool = new SortedSet<Guild>();


        public class Guild : IComparable
        {
            private readonly string name;
            private readonly uint id;
            private readonly GuildType type;
            private readonly Servers server;

            public Guild()
            {
                name = string.Empty;
                id = 0;
                type = 0;
                server = 0;
            }
            public Guild(string newName, uint newID, GuildType newType, Servers newServer)
            {
                name = newName;
                id = newID;
                type = newType;
                server = newServer;
            }
            public string Name
            {
                get { return name; }
                set { }
            }
            public uint ID
            {
                get { return id; }
                set { }
            }
            public GuildType Type
            {
                get { return type; }
                set { }
            }
            public Servers Servers
            {
                get { return server; }
                set { }
            }

            public int CompareTo(object obj)
            {
                try
                {
                    //checks if the obj is null
                    if (obj == null)
                        throw new ArgumentNullException();

                    //used to sort by names in the Guild sortedset
                    if (obj is Guild rightOp)
                    {
                        //A Guild Has the same name then compare by server name
                        if (name.Equals(rightOp.name))
                        {
                            return Servers.CompareTo(rightOp.server);
                        }
                        return name.CompareTo(rightOp.name);
                    }
                    else
                        throw new ArgumentException();
                }
                //If an error has accord with sorting players
                catch
                {
                    Console.WriteLine("Error comparing Guild names!");
                    return -1;

                }
            }
            public override string ToString()
            {
                return string.Format("Name: {0,-25}\t Server: [{1,-7}]\t Type: {2,-5}", name, server, type);
            }
        }
        public class Player : IComparable
        {
            private readonly uint id;
            private readonly string name;
            private string guildName;
            private readonly Race race;
            private uint level;
            private uint exp;
            private Class pclass;
            private Role role;
            private uint guildID;
            //Default Constructor 
            public Player()
            {
                id = 0;
                name = System.String.Empty;
                level = 0;
                race = 0;
                role = 0;
                guildID = 0;
                exp = 0;
                guildName = "None";
            }
            public Player(uint newID, string newName, uint newLevel, Race newRace, Class newPclass, Role newRole, uint newGuildID, uint newExp)
            {
                id = newID;
                name = newName;
                level = newLevel;
                race = newRace;
                role = newRole;
                pclass = newPclass;
                guildID = newGuildID;
                exp = newExp;
            }
            public Class Pclass
            {
                get { return pclass; }
                set { pclass = value; }
            }
            public Role Role
            {
                get { return role; }
                set { role = value; }
            }
            public string GuildName
            {
                get { return guildName; }
                set { guildName = value; }
            }
            public uint Exp
            {
                get { return exp; }
                set { exp = value; }
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
                    level = value;
                }
            }

            public uint GuildID
            {
                get { return guildID; }
                set { guildID = value; }
            }

            public int CompareTo(object obj)
            {
                try
                {
                    //checks if the obj is null
                    if (obj == null)
                        throw new ArgumentNullException();

                    //used to sort by lv in the Player sortedset
                    if (obj is Player rightOp)
                    {
                        //if levels compare match then compare by name
                        if (level.Equals(rightOp.level))
                        {
                            return name.CompareTo(rightOp.name);
                        }
                        else
                        {
                            return level.CompareTo(rightOp.level);
                        }
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
            public override string ToString()
            {
                return string.Format("Name: {0,-20}\t ({1,-5} - {2,-15}\t " +
                    "Race: {3,-10}\t Level: {4,-5} <{5,-5}>\n", name, pclass, role + ")", race, level, guildName);
            }
        }
        //Stores all guilds
        private static readonly string[,] guildsIDnames = new string[12, 4];
        //Stores players before being placed in an object
        public static string[,] playerInfo = new string[34, 8];
        //Stores Items before being stored as an object
        //Used to store a Players gear before being stored in the object
        //A helper array to hold temp  
        public static string[] temp = new string[80];
        //Path of guilds text
        public static string path = "../../../Input Files/guilds.txt";
        private static string fileInput;
        //Reads in all the text of path
        public Form1()
        {
            InitializeComponent();
            //Reads input files and adds items to classes
            ReadingFile();
            //Adds guild names to each player
            GuildSetter();
        }
        //Used to store guild name into each player object
        public static void GuildSetter()
        {
            foreach (Player player in Playerspool)
            {
                foreach (Guild guild in Guildspool)
                {
                    if (player.GuildID == guild.ID)
                    {
                        player.GuildName = guild.Name;
                    }
                }
            }

        }
        public static void ReadingFile()
        {
            Servers tempServer = 0;
            fileInput = File.ReadAllText(path);
            //Temp list for invertory
            //Splits up file input text and stores in temp array
            temp = fileInput.Split('\t', '\n', '-');
            //Calls filereader to put array into 2d array
            FileReader(guildsIDnames, temp);
            path = "../../../Input Files/Players.txt";
            fileInput = File.ReadAllText(path);
            //testing reading file into array
            temp = fileInput.Split('\t', '\n');
            FileReader(playerInfo, temp);
            for (int i = 0; i < playerInfo.GetLength(0); i++)
            {
                //Order of what part of the array is being stored
                //uint newID, string newName, uint newLevel, Race newRace, Class newPclass, Role newRole, uint newGuildID, uint newExp
                Player player = new Player((uint)Convert.ToInt32(playerInfo[i, 0]), Convert.ToString(playerInfo[i, 1]), (uint)Convert.ToInt32(playerInfo[i, 5]),
                    (Race)Convert.ToInt32(playerInfo[i, 2]), (Class)Convert.ToInt32(playerInfo[i, 3]), (Role)Convert.ToInt32(playerInfo[i, 4]), (uint)Convert.ToInt32(playerInfo[i, 7]), Convert.ToUInt32(playerInfo[i, 6]));
                //Adds player object into sortedset peoplepool
                Playerspool.Add(player);
            }
            for (int i = 0; i < guildsIDnames.GetLength(0); i++)
            {
                // Beta4Azeroth, TKWasASetback, ZappyBoi
                if (guildsIDnames[i, 3].ToString().Trim() == ((Servers)0).ToString())
                {
                    tempServer = (Servers)0;
                }
                else if (guildsIDnames[i, 3].ToString().Trim() == ((Servers)1).ToString())
                {
                    tempServer = (Servers)1;
                }
                else if (guildsIDnames[i, 3].ToString().Trim() == ((Servers)2).ToString())
                {
                    tempServer = (Servers)2;
                }
                //string newName, uint newID, GuildType newType, Servers newServer
                Guild guild = new Guild(guildsIDnames[i, 2], (uint)Convert.ToInt32(guildsIDnames[i, 0]), (GuildType)Convert.ToInt32(guildsIDnames[i, 1]), tempServer);
                Guildspool.Add(guild);
            }

        }
        public static void FileReader(string[,] arr2d, string[] arr)
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
        //Double click on "Query" to see
        private void Title_Click(object sender, EventArgs e)
        {
            OutPut_richTextBox1.Clear();
            //EasterEgg must select "Tank" radiobutton and select "Raid" in the Type combobox
            if (TankradioButton.Checked && TypecomboBox.SelectedIndex == 3)
            {
                //Loads sound files
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../../Sound/DBM Run away.wav");
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("../../../Sound/Fall of the Lich King.wav");
                System.Media.SoundPlayer player3 = new System.Media.SoundPlayer("../../../Sound/Final Fantasy VII  Victory Fanfare.wav");
                player.Play();
                //Displays message box
                DialogResult dialogResult = MessageBox.Show("\nRAID WATCH OUT FOR SHADOW TRAP!!! \n-----------------------------------------------------\n" +
                    "\t     Do you move?", "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    //Stops player
                    player.Stop();
                    //Starts player3
                    player3.Play();
                    MessageBox.Show("You Didn't Wipe The Raid and Defeated The Lich King!!\nGood Job! :D", "You Did It!");
                    //Resets radiobutton and combobox
                    TypecomboBox.SelectedIndex = -1;
                    DPSradioButton.Checked = false;
                    OutPut_richTextBox1.Text += "Loot Drop\n--------------\n Absolutely Nothing!" +
                        "\n--------------\n Try 100 more times and maybe you will get Invincible's Reins! ;)";
                    return;
                }
                if (dialogResult == DialogResult.No)
                {
                    player.Stop();
                    player2.Play();
                    MessageBox.Show("You Wiped The Raid!\nGood Job...\n*Removed By Raid Leader*", "You Blew It!");
                    //Closes program
                    System.Environment.Exit(0);
                }
            }
            else
            {
                MessageBox.Show("Created by\n------------------------------------\n             Team Blizzard\n------------------------------------\n" +
                    "Music/Sounds By:\nActivision Blizzard,\nSquare Enix", "Credits");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Fill Comboboxes
            for (int i = 0; i < Enum.GetNames(typeof(Class)).Length; i++)
            {
                ClassComboBox.Items.Add((Class)i);
            }
            for (int i = 0; i < Enum.GetNames(typeof(Servers)).Length; i++)
            {
                ServercomboBox1.Items.Add((Servers)i);
                ServercomboBox2.Items.Add((Servers)i);
                ServercomboBox3.Items.Add((Servers)i);
            }
            for (int i = 0; i < Enum.GetNames(typeof(Role)).Length; i++)
            {
                RolecomboBox.Items.Add((Role)i);
            }
            for (int i = 0; i < Enum.GetNames(typeof(GuildType)).Length; i++)
            {
                TypecomboBox.Items.Add((GuildType)i);
            }
        }
        //Show class on selected server
        private void Show_Rsults_button1_Click(object sender, EventArgs e)
        {
            //clears output
            OutPut_richTextBox1.Clear();
            //Checks if both comboboxes are filled
            if (ClassComboBox.SelectedIndex.Equals(-1) || ServercomboBox1.SelectedIndex.Equals(-1))
            {
                OutPut_richTextBox1.Text += "Not All Items Selected!";
                return;
            }
            //Prints what class and what server are being used in the query
            OutPut_richTextBox1.Text += string.Format("All " + ClassComboBox.SelectedItem.ToString() + "s from " + ServercomboBox1.SelectedItem.ToString() +
                "\n---------------------------------------------------------------------------------------------\n");
            //Does query
            var Classtype =
                from N in Playerspool
                join T in Guildspool
                on N.GuildID equals T.ID
                where N.Pclass == (Class)Convert.ToInt32(ClassComboBox.SelectedItem)
                && T.Servers == (Servers)Convert.ToInt32(ServercomboBox1.SelectedIndex)
                select N;
            //If any results are found
            if (Classtype.Any())
            {
                //Print results
                foreach (var player in Classtype)
                {
                    OutPut_richTextBox1.Text += player;
                }

            }
            //If nothing is found
            else
            {
                OutPut_richTextBox1.Text += string.Format("\nNO RESULTS FOUND IN QUERY!\n");
            }
            OutPut_richTextBox1.Text += string.Format("\nEND RESULTS\n" +
                    "---------------------------------------------------------------------------------------------");
            return;
        }
        //Displays % of each Race from a single Server
        private void Show_Results_button2_Click(object sender, EventArgs e)
        {
            //clear output
            OutPut_richTextBox1.Clear();
            //Checks if user selected server
            if (ServercomboBox2.SelectedIndex.Equals(-1))
            {
                OutPut_richTextBox1.Text += "Please Select Server!";
                return;
            }
            //Print what server is being checked
            OutPut_richTextBox1.Text += string.Format("Percentage of Each Race from " + ServercomboBox2.SelectedItem.ToString() +
               "\n---------------------------------------------------------------------------------------------\n");
            //Used to store the percent
            double results = 0;
            //Gets count Orcs on server
            var OrcPercent =
                from N in Playerspool
                join T in Guildspool
                on N.GuildID equals T.ID
                where N.Race == 0 && T.Servers == (Servers)Convert.ToInt32(ServercomboBox2.SelectedIndex)
                select N;
            //Gets count Trolls on server
            var TrollPercent =
                from N in Playerspool
                join T in Guildspool
                on N.GuildID equals T.ID
                where N.Race == (Race)1 && T.Servers == (Servers)Convert.ToInt32(ServercomboBox2.SelectedIndex)
                select N;
            //Gets count Taurens on server
            var TaurenPercent =
                from N in Playerspool
                join T in Guildspool
                on N.GuildID equals T.ID
                where N.Race == (Race)2 && T.Servers == (Servers)Convert.ToInt32(ServercomboBox2.SelectedIndex)
                select N;
            //Gets count Foresakens on server
            var ForsakenkPercent =
                from N in Playerspool
                join T in Guildspool
                on N.GuildID equals T.ID
                where N.Race == (Race)3 && T.Servers == (Servers)Convert.ToInt32(ServercomboBox2.SelectedIndex)
                select N;
            //Gets total player count on server
            var TotalPlayerCount =
                 from N in Playerspool
                 join T in Guildspool
                 on N.GuildID equals T.ID
                 where T.Servers == (Servers)Convert.ToInt32(ServercomboBox2.SelectedIndex)
                 select N;
            //Calc percent of population of race and prints to outpute
            results = OrcPercent.Count() / (double)TotalPlayerCount.Count();
            OutPut_richTextBox1.Text += string.Format("{0}:\t\t{1,-30: 0.00%}\n", (Race)0, results);
            results = TrollPercent.Count() / (double)TotalPlayerCount.Count();
            OutPut_richTextBox1.Text += string.Format("{0}:\t\t{1,-30: 0.00%}\n", (Race)1, results);
            results = TaurenPercent.Count() / (double)TotalPlayerCount.Count();
            OutPut_richTextBox1.Text += string.Format("{0}:\t\t{1,-30: 0.00%}\n", (Race)2, results);
            results = ForsakenkPercent.Count() / (double)TotalPlayerCount.Count();
            OutPut_richTextBox1.Text += string.Format("{0}:\t{1,-25: 0.00%}\n", (Race)3, results);
            OutPut_richTextBox1.Text += string.Format("\nEND RESULTS\n" +
                   "---------------------------------------------------------------------------------------------");
            return;
        }
        //All Players of a single Role, from a single Server, within a Level range
        private void Show_Results_button3_Click(object sender, EventArgs e)
        {
            //Clears output
            OutPut_richTextBox1.Clear();
            //checks numupdown value
            if ((int)MinNumUpDown.Value == 0)
            {
                MinNumUpDown.Value = (Int32)1;
            }
            //checks if user selected a role and server
            if (RolecomboBox.SelectedIndex.Equals(-1))
            {
                OutPut_richTextBox1.Text += "Select a role!";
                return;
            }
            if (ServercomboBox3.SelectedIndex.Equals(-1))
            {
                OutPut_richTextBox1.Text += "Select a server!";
                return;
            }
            //prints out what role and server are being used in the query
            OutPut_richTextBox1.Text += string.Format("All " + RolecomboBox.SelectedItem.ToString() + " from " + ServercomboBox3.SelectedItem.ToString() + ", " + " Levels " + MinNumUpDown.Value + " to " + MaxNumUpDown.Value +
              "\n---------------------------------------------------------------------------------------------\n");
            //Runs query to find players that fit the query
            var Classtype =
            from N in Playerspool
            join T in Guildspool
            on N.GuildID equals T.ID
            where N.Role == (Role)Convert.ToInt32(RolecomboBox.SelectedItem)
            && T.Servers == (Servers)Convert.ToInt32(ServercomboBox3.SelectedIndex)
            where Convert.ToUInt32(N.Level) <= Convert.ToUInt32(MaxNumUpDown.Value)
            where Convert.ToUInt32(N.Level) >= Convert.ToUInt32(MinNumUpDown.Value)
            select N;

            //Prints out results
            foreach (var player in Classtype)
            {
                OutPut_richTextBox1.Text += player;
            }
            OutPut_richTextBox1.Text += string.Format("\nEND RESULTS\n" +
            "---------------------------------------------------------------------------------------------");
            return;
        }

        private void MinNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            //sets the max to 60 if min is 60
            if (MinNumUpDown.Value == 60)
            {
                MaxNumUpDown.Value = 60;
            }
            //sets the max value to 1 more then min within the range 1 through 60
            if (MaxNumUpDown.Value < MinNumUpDown.Value)
                MaxNumUpDown.Value = MinNumUpDown.Value + 1;
        }

        private void MaxNumUpDown_ValueChanged(object sender, EventArgs e)
        {

            //prevents the max from being lower then the min
            if (MinNumUpDown.Value == 2 && MaxNumUpDown.Value == 1)
            {
                MinNumUpDown.Value = 1;
            }

            //sets the min value to 1 less of max within the range 1 through 60
            if (MinNumUpDown.Value > MaxNumUpDown.Value)
            {
                if (MaxNumUpDown.Value == 1)//if the max value is 1 then make sure min is also 1
                {
                    MinNumUpDown.Value = 1;
                    return;
                }
                MinNumUpDown.Value = MaxNumUpDown.Value - 1;
            }
        }
        //All Guilds of a specific Guild Type
        private void Show_Results_button4_Click(object sender, EventArgs e)
        {
            //clear output
            OutPut_richTextBox1.Clear();
            //Checks if user selected a server type
            if (TypecomboBox.SelectedIndex.Equals(-1))
            {
                OutPut_richTextBox1.Text += string.Format("Please Select a Guild Type!");
                return;
            }
            //Print whhat server type is being searched for
            OutPut_richTextBox1.Text += string.Format("All " + TypecomboBox.SelectedItem.ToString() + "-Type of Guilds" +
              "\n---------------------------------------------------------------------------------------------\n");
            //Checks what servers have guilds that fit the selected type
            var Guildtypes =
                from G in Guildspool
                where G.Type == (GuildType)Convert.ToInt32(TypecomboBox.SelectedIndex)
                group G.Name by G.Servers into GuildsList
                orderby GuildsList.Key
                select GuildsList;
            foreach (var player in Guildtypes)
            {
                ////Prints out Server
                OutPut_richTextBox1.Text += string.Format(player.Key + Environment.NewLine);
                foreach (var G in player)
                {
                    //Prints out the guilds that fit the type
                    OutPut_richTextBox1.Text += string.Format("\t<{0}>\n", G);
                }
            }

            OutPut_richTextBox1.Text += string.Format("\nEND RESULTS\n" +
            "---------------------------------------------------------------------------------------------");
            return;
        }

        private void Show_Results_button5_Click(object sender, EventArgs e)
        {
            OutPut_richTextBox1.Clear();
            //if no role was selected
            if (!TankradioButton.Checked && !HealerradioButton.Checked && !DPSradioButton.Checked)
            {
                OutPut_richTextBox1.Text += "Please Select Role!";
                return;
            }

            //if the tank role was selected
            if (TankradioButton.Checked)
            {
                OutPut_richTextBox1.Text += string.Format("All Eligible Players Not Fulfilling the Tank Role " +
               "\n---------------------------------------------------------------------------------------------\n");
                var Tank =
                    from N in Playerspool
                    join T in Guildspool
                    on N.GuildID equals T.ID
                    where N.Role != Role.Tank
                    where N.Pclass == Class.Warrior || N.Pclass == Class.Druid || N.Pclass == Class.Paladin //warriors, druids and paladins players only
                    select N;

                foreach (var player in Tank)
                {
                    OutPut_richTextBox1.Text += player;
                }
            }

            //if the healer role was selected
            if (HealerradioButton.Checked)
            {
                OutPut_richTextBox1.Text += string.Format("All Eligible Players Not Fulfilling the Healer Role " +
               "\n---------------------------------------------------------------------------------------------\n");
                var Healer =
                    from N in Playerspool
                    join T in Guildspool
                    on N.GuildID equals T.ID
                    where N.Role != Role.Healer
                    where N.Pclass == Class.Druid || N.Pclass == Class.Priest || N.Pclass == Class.Shaman || N.Pclass == Class.Paladin  //Druid, priest, shaman, and paladin players only
                    select N;

                foreach (var player in Healer)
                {
                    OutPut_richTextBox1.Text += player;
                }
            }

            //if the damage role was selected
            if (DPSradioButton.Checked)
            {
                OutPut_richTextBox1.Text += string.Format("All Eligible Players Not Fulfilling the Damage Role " +
               "\n---------------------------------------------------------------------------------------------\n");
                var Damage =
                    from N in Playerspool
                    join T in Guildspool
                    on N.GuildID equals T.ID
                    where N.Role != Role.Healer
                    where N.Pclass == Class.Hunter || N.Pclass == Class.Mage || N.Pclass == Class.Rogue || N.Pclass == Class.Warlock  //hunter, Mmge, rogue, and warlock players only
                    select N;

                foreach (var player in Damage)
                {
                    OutPut_richTextBox1.Text += player;
                }
            }

            OutPut_richTextBox1.Text += string.Format("\nEND RESULTS\n" +
            "---------------------------------------------------------------------------------------------");
            return;
        }
        //Percentage of max Level Players in all Guilds
        private void Show_Results_button6_Click(object sender, EventArgs e)
        {
            //Clear output
            OutPut_richTextBox1.Clear();
            OutPut_richTextBox1.Text += string.Format("Percentage of Max Level Players in All Guilds " +
             "\n---------------------------------------------------------------------------------------------\n");
            //Loop through all the guilds
            foreach (Guild guild in Guildspool)
            {
                double results;
                //Check which players are max lv in a guild
                var MaxPlayers =
                    from N in Playerspool
                    where N.Level == 60 && N.GuildID == guild.ID
                    select N;
                //Gets the amount of people in the guild
                var TotalPlayers =
                    from N in Playerspool
                    where N.GuildID == guild.ID
                    select N;
                //Checks if the guild has any player
                if (TotalPlayers.Count() != 0)
                {
                    //Calcs the percent of max players in guild
                    results = MaxPlayers.Count() / (double)TotalPlayers.Count();
                    //Prints percents
                    OutPut_richTextBox1.Text += string.Format("<{0,-20}\t{1,35: 0.00%}\n\n", guild.Name + ">", results);
                }
            }
            OutPut_richTextBox1.Text += string.Format("\nEND RESULTS\n" +
           "---------------------------------------------------------------------------------------------");
            return;
        }
    }
}
