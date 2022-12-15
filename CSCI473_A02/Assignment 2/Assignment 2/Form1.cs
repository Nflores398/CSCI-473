/************************************************************************
   Team Blizzard
   PROGRAM:    Form1.cs
   ASSIGNMENT: 2
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   2/11/21

   FUNCTION:  Windows Form App that lists all players and guilds in file in a listbox
   and allows creating new player and guilds, have players join or leave guilds, 
   print all users in a guild, and search either name or guild.

************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Management_System : Form
    {
        public uint newplayerID = 0;
        public uint newGuildID = 0;
        public Boolean hasMembers = false;
        public enum Race { Orc, Troll, Tauren, Forsaken };
        public enum Class { Warrior, Mage, Druid, Priest, Warlock, Rogue, Paladin, Hunter, Shaman };
        public enum Role { Unsigned, DPS, Tank, Healer };
        public enum GuildType { Unsigned, Causal, Questing, MythicPlus, Raiding, PVP };
        public enum Servers { Beta4Azeroth, TKWasASetback, ZappyBoi };
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
            public override string ToString()
            {
                return string.Format("Name: {0,-20}\t Race: {1,-7}\t Level: {2,-5}\t Guild: ", name, race, level);
            }
        }

        //Stores all guilds
        private static readonly string[,] guildsIDnames = new string[12, 3];
        //Stores players before being placed in an object
        public static string[,] playerInfo = new string[20, 7];
        //Stores Items before being stored as an object
        //Used to store a Players gear before being stored in the object
        //A helper array to hold temp  
        public static string[] temp = new string[80];
        //Path of guilds text
        public static string path = "../../../Input Files/guilds.txt";
        private static string fileInput;
        //Reads in all the text of path

        public Management_System()
        {
            InitializeComponent();
            //Reads input files
            ReadingFile();
            //Display players
            PlayerOutput();
            //Display Guilds
            GuildOutput();
        }
        public static void ReadingFile()
        {
            //Used as a temp  
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
                Player player = new Player((uint)Convert.ToInt32(playerInfo[i, 0]), Convert.ToString(playerInfo[i, 1]), (uint)Convert.ToInt32(playerInfo[i, 4]),
                    (Race)Convert.ToInt32(playerInfo[i, 2]), (Class)Convert.ToInt32(playerInfo[i, 3]), 0, (uint)Convert.ToInt32(playerInfo[i, 6]), Convert.ToUInt32(playerInfo[i, 5]));
                //Adds player object into sortedset peoplepool
                Playerspool.Add(player);
            }
            for (int i = 0; i < guildsIDnames.GetLength(0); i++)
            {

                // Beta4Azeroth, TKWasASetback, ZappyBoi
                if (guildsIDnames[i, 2].ToString().Trim() == ((Servers)0).ToString())
                {
                    tempServer = (Servers)0;
                }
                else if (guildsIDnames[i, 2].ToString().Trim() == ((Servers)1).ToString())
                {
                    tempServer = (Servers)1;
                }
                else if (guildsIDnames[i, 2].ToString().Trim() == ((Servers)2).ToString())
                {
                    tempServer = (Servers)2;
                }
                //string newName, uint newID, GuildType newType, Servers newServer
                Guild guild = new Guild(guildsIDnames[i, 1], (uint)Convert.ToInt32(guildsIDnames[i, 0]), 0, tempServer);
                Guildspool.Add(guild);
            }


        }
        private void GuildOutput()
        {
            //Clears out box before reprinting it
            Guild_List_Listbox.Items.Clear();
            //Add Guilds to the ListBox from Guildspool
            foreach (Guild guild in Guildspool)
            {
                Guild_List_Listbox.Items.Add(string.Format("{0, -29}\t\t{1,-15} {2}", guild.Name.Trim(), "[" + guild.Servers.ToString().Trim() + "]", Environment.NewLine));
            }

        }
        private void PlayerOutput()
        {
            //Player_List_Listbox.Clear();
            Player_List_Listbox.Items.Clear();
            //Add players to the ListBox from playerspool
            foreach (Player player in Playerspool)
            {
                StringBuilder result = new StringBuilder(string.Format("{0,-17}\t{1,-20}\t{2,-2} {3}", player.Name.Trim(), player.Pclass.ToString().Trim(), player.Level.ToString().Trim(), Environment.NewLine));
                Player_List_Listbox.Items.Add((result));
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
        //EasterEgg
        //Display if user double clicks title on form
        private void Title_Credit(object sender, EventArgs e)
        {
            //Loads soundfile
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../../Sound/World of Warcraft Login Music.wav");
            //Starts sound file and loops
            player.PlayLooping();
            //Display DialogResults with Credits
            DialogResult dialogResult = MessageBox.Show("Created by\n------------------------------------\n             Team Blizzard\n------------------------------------\n" +
                "Music By: Activision Blizzard", "Credits", MessageBoxButtons.OK);
            //User selects okay return and stop sound file
            if (dialogResult == DialogResult.OK)
            {
                player.Stop();
                return;
            }
        }
        //Prints Players in selected guild
        private void Print_Guild_Button_Click(object sender, EventArgs e)
        {
            //clears output
            Output_TextField.Clear();
            //Checks if user selected a guild 
            if (Guild_List_Listbox.SelectedIndex == -1)
            {
                Output_TextField.Text += "Please Selected a Guild!";
                return;
            }
            if (Guild_List_Listbox == null)
                return;
            //temp array
            _ = new string[30];
            try
            {
                //Stores selected guild name and splits its
                string[] help = Guild_List_Listbox.SelectedItem.ToString().Split('\t');
                //Loops through all the guilds
                foreach (Guild guild in Guildspool)
                {
                    //If the selected guild name matchs a name in the guildspool
                    if (help[0].ToString().Trim() == guild.Name)
                    {
                        //Print out
                        Output_TextField.Text += string.Format("Guild Listing for {0}" +
                            "---------------------------------------------------------------------------------\n",
                            Guild_List_Listbox.SelectedItem);
                        //loop through playerspool
                        foreach (Player player in Playerspool)
                        {
                            //Loops and checks if a player is in selected guild
                            if (guild.ID == player.GuildID)
                            {
                                //Print
                                Output_TextField.Text += player.ToString() + guild.Name + "\n";
                                hasMembers = true;
                            }
                        }
                        //If no one is in a guild
                        if (hasMembers == false)
                        {
                            Output_TextField.Text += "Guild Has No Members....";
                        }
                        hasMembers = false;
                        return;
                    }

                }
            }
            catch
            {
                Output_TextField.Text += "Error!";
            }
        }
        //Add Player
        private void Add_Button_Click(object sender, EventArgs e)
        {
            //Clear Output texbox
            Output_TextField.Clear();
            //Checks if player exist already
            foreach (Player player in Playerspool)
            {
                //If the name is already in use
                if (Player_Name_TextField.Text.Equals(player.Name))
                {
                    Output_TextField.Clear();
                    Output_TextField.Text += "Name Is Already In Use!\n";
                    return;
                }
            }
            //If name is out of range
            if (Player_Name_TextField.Text.Length < 2 || Player_Name_TextField.Text.Length > 12)
            {
                Output_TextField.Text += "Name Is Out Of Range!\n2-12 Characters";
                return;
            }
            //If name was left empty
            if (Player_Name_TextField.Text == string.Empty)
            {
                Output_TextField.Text += "Please Enter Player Name!\n";

            }
            //If user doesnt select role
            if (Role_Box.Text == string.Empty)
            {
                Output_TextField.Text += "Please Select Role!\n";

            }
            //If user doesnt select class
            if (Class_Box.Text == string.Empty)
            {
                Output_TextField.Text += "Please Select Class!\n";

            }
            //If user doesnt select Race
            if (Race_Box.Text == string.Empty)
            {
                Output_TextField.Text += "Please Select Race!\n";

            }
            //Checks if all boxes are filled
            if (Race_Box.Text != string.Empty && Class_Box.Text != string.Empty && Role_Box.Text != string.Empty && Player_Name_TextField.Text != string.Empty)
            {
                try
                {
                    //Increase ID number
                    newplayerID++;
                    //check if the guild ID is already in use
                    foreach (Player player1 in Playerspool)
                    {
                        if (newplayerID == player1.ID)
                        {
                            //Increase by 1 to avoid having matching id.
                            newplayerID++;
                        }
                    }
                    Output_TextField.Text += "Adding Player.....\n";
                    //uint newID, string newName, uint newLevel, Race newRace, Class newPclass, Role newRole, uint newGuildID, uint newExp
                    Player player = new Player(newplayerID, Player_Name_TextField.Text.ToString(), 1, (Race)Convert.ToInt32(Race_Box.SelectedItem),
                        (Class)Convert.ToInt32(Class_Box.SelectedItem), (Role)Convert.ToInt32(Role_Box.SelectedItem), 0, 0);
                    //Adds new player to pool
                    Playerspool.Add(player);
                    //Prints out new player list
                    PlayerOutput();
                    //Print out to output textbox
                    Output_TextField.Text += "Adding Successful!\n";
                    Output_TextField.Text += "\n----------------------------------------------------------------------------------\n";
                    Output_TextField.Text += string.Format("ID:{0}  Name: {1}   Race: {2}   Class: {3}   Role: {4}  LV: {5}", newplayerID, Player_Name_TextField.Text.ToString(),
                        (Race)Convert.ToInt32(Race_Box.SelectedItem), Class_Box.SelectedItem.ToString(), Role_Box.SelectedItem.ToString(), 1);
                    Output_TextField.Text += "\n----------------------------------------------------------------------------------\n";
                    //Clears player name text field after adding them, Will also clear role,class,race
                    Player_Name_TextField.Clear();
                }
                catch
                {
                    Output_TextField.Text += "Failed!\n";
                }
                return;
            }
        }

        private void Player_Name_TextField_TextChanged(object sender, EventArgs e)
        {
            if (Player_Name_TextField == null)
                return;
            //If the text field is empty clear comboboxes 
            if (Player_Name_TextField.Text == string.Empty)
            {
                Class_Box.Items.Clear();
                Race_Box.Items.Clear();
                Role_Box.Items.Clear();
                return;
            }
            //checks if name is in use
            foreach (Player player in Playerspool)
            {
                if (Player_Name_TextField.Text.Equals(player.Name))
                {
                    Output_TextField.Clear();
                    Output_TextField.Text += "Name Is Already In Use!\n";
                    return;
                }
            }
            //Checks if user enters anything into Textfield
            if (Class_Box.Items.Count == 0)
            {
                for (int i = 0; i <= 8; i++)
                    Class_Box.Items.Add(((Class)i));

                for (int i = 0; i <= 3; i++)
                    Race_Box.Items.Add(((Race)i));

                return;
            }

            return;
        }

        private void Class_Box_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //When user selects new class clear role text box
            Role_Box.SelectedIndex = -1;
            Role_Box.Items.Clear();
            //DPS 1, Tank 2, Healer 3
            //Fill Role box based off selected class
            if (Class_Box.SelectedItem.Equals(Class.Warrior))
            {
                Role_Box.Items.Add((Role)1);
                Role_Box.Items.Add((Role)2);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Mage))
            {
                Role_Box.Items.Add((Role)1);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Druid))
            {
                Role_Box.Items.Add((Role)1);
                Role_Box.Items.Add((Role)2);
                Role_Box.Items.Add((Role)3);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Priest))
            {
                Role_Box.Items.Add((Role)1);
                Role_Box.Items.Add((Role)3);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Warlock))
            {
                Role_Box.Items.Add((Role)1);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Rogue))
            {
                Role_Box.Items.Add((Role)1);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Paladin))
            {
                Role_Box.Items.Add((Role)1);
                Role_Box.Items.Add((Role)2);
                Role_Box.Items.Add((Role)3);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Hunter))
            {
                Role_Box.Items.Add((Role)1);
                return;
            }
            if (Class_Box.SelectedItem.Equals(Class.Shaman))
            {
                Role_Box.Items.Add((Role)1);
                Role_Box.Items.Add((Role)3);
                return;
            }
        }

        private void Disband_Guild_Button_Click(object sender, EventArgs e)
        {
            int count = 0;
            _ = new string[30];
            //clear output
            Output_TextField.Clear();
            //Check if user selected a guild
            if (Guild_List_Listbox.SelectedIndex == -1)
            {
                Output_TextField.Text += "Please Select a Guild!";
                return;
            }
            if (Guild_List_Listbox == null)
                return;
            //Checks if user wants to disband selected guild
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Disband Guild", MessageBoxButtons.YesNo);
            //If user selects yes
            if (dialogResult == DialogResult.Yes)
            {

                try
                {

                    string[] help = Guild_List_Listbox.SelectedItem.ToString().Split('\t');
                    //Loop through to find guild
                    foreach (Guild guild in Guildspool)
                    {
                        //Once the guild is found
                        if (help[0].ToString().Trim() == guild.Name)
                        {
                            //Loop through and find every player in the selected guild
                            foreach (Player player in Playerspool)
                            {
                                //Sets every member of the guild to 0
                                if (guild.ID == player.GuildID)
                                {
                                    count++;
                                    player.GuildID = 0;
                                }
                            }
                            //Print
                            Output_TextField.Text += string.Format(count + " players have been disbanded from " + "{0}!\n" +
                                "---------------------------------------------------------------------------------\n",
                                guild.Name);
                            //remove guild from set
                            Guildspool.Remove(guild);
                            GuildOutput();

                            return;
                        }

                    }
                }
                catch
                {
                    Output_TextField.Text += "Error!";
                }
            }
            //If user selects No
            else if (dialogResult == DialogResult.No)
            {
                Output_TextField.Text += string.Format("Aborted!");
                return;
            }
        }
        //Clears Comboboxs when new guild name box is empty
        private void Guild_Name_TextField_TextChanged(object sender, EventArgs e)
        {

            if (Guild_Name_TextField == null)
                return;
            //Textfield is empty
            if (Guild_Name_TextField.Text == string.Empty)
            {
                Type_Box.Items.Clear();
                Server_Box.Items.Clear();
            }
            //Fill Combo Boxes with servers and Guild types
            if (Type_Box.Items.Count == 0)
            {
                for (int i = 1; i <= 5; i++)
                    Type_Box.Items.Add(((GuildType)i));

                for (int i = 0; i <= 2; i++)
                    Server_Box.Items.Add(((Servers)i));

                return;
            }

            return;

        }
        //Adds new guilds
        private void Add_Guild_Button_Click(object sender, EventArgs e)
        {
            //Clear Output texbox
            Output_TextField.Clear();
            //Checks if guild exist already on selected server
            foreach (Guild guild in Guildspool)
            {
                if (Guild_Name_TextField.Text.Equals(guild.Name))
                {
                    if (Server_Box.SelectedItem.Equals(guild.Servers))
                    {
                        Output_TextField.Clear();
                        Output_TextField.Text += "Name Is Already In Use On" + guild.Servers + "!\n";
                        return;
                    }
                }
            }
            //checks range of name
            if (Guild_Name_TextField.Text.Length < 2 || Guild_Name_TextField.Text.Length > 24)
            {
                Output_TextField.Text += "Name Is Out Of Range!\n2-24 Characters";
                return;
            }
            //Checks if text field is not empty
            if (Guild_Name_TextField.Text == string.Empty)
            {
                Output_TextField.Text += "Please Enter Guild Name!\n";

            }
            //checks if type box is empty
            if (Type_Box.Text == string.Empty)
            {
                Output_TextField.Text += "Please Select Type!\n";

            }
            //checks if server box is empty
            if (Server_Box.Text == string.Empty)
            {
                Output_TextField.Text += "Please Select Server!\n";

            }
            //Checks if all boxes are filled
            if (Type_Box.Text != string.Empty && Server_Box.Text != string.Empty && Guild_Name_TextField.Text != string.Empty)
            {
                try
                {
                    //Increase ID number
                    newGuildID++;
                    //check if the guild ID is already in use
                    foreach (Guild guilds in Guildspool)
                    {
                        if (newGuildID == guilds.ID)
                        {
                            //Increase by 1 to avoid having matching id.
                            newGuildID++;
                        }
                    }
                    Output_TextField.Text += "Adding Guild.....\n";
                    //string newName, uint newID, GuildType newType, Servers newServer
                    Guild guild = new Guild(Guild_Name_TextField.Text, newGuildID, (GuildType)Convert.ToInt32(Type_Box.SelectedIndex),
                        (Servers)Convert.ToInt32(Server_Box.SelectedIndex));
                    //Adds new guild
                    Guildspool.Add(guild);
                    Output_TextField.Text += "Adding Successful!\n";
                    Output_TextField.Text += "\n------------------------------------------------------------------\n";
                    Output_TextField.Text += string.Format("ID:{0}  Name: {1}   Type: {2}   Server: {3}", newGuildID, Guild_Name_TextField.Text.ToString(),
                        Type_Box.SelectedItem.ToString(), Server_Box.SelectedItem.ToString());
                    Output_TextField.Text += "\n------------------------------------------------------------------";
                    //Clear Guild Name and will clear type/server because those boxes check if Guild name has anything in them
                    GuildOutput();
                    Guild_Name_TextField.Clear();
                }
                catch
                {
                    Output_TextField.Text += "Failed!\n";
                }
                return;
            }
        }
        //If Player clicks on Name on Player List
        private void Player_List_Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output_TextField.Clear();
            if (Player_List_Listbox.SelectedIndex == -1)
            {
                return;
            }
            if (Player_List_Listbox == null)
                return;
            _ = new string[30];
            try
            {

                string[] help = Player_List_Listbox.SelectedItem.ToString().Split('\t');
                //loops through playerspool
                foreach (Player player in Playerspool)
                {
                    //If player is found
                    if (help[0].Trim().ToString() == player.Name)
                    {
                        //loops through to see if they are in a guild
                        foreach (Guild guild in Guildspool)
                        {
                            //if in guild
                            if (player.GuildID == guild.ID)
                            {
                                //Print player info to output
                                Output_TextField.Text += string.Format(player.ToString() + guild.Name + "\n-------------------------------------------------------------------------------------------\n");
                                return;
                            }
                            //if not in guild
                            else if (player.GuildID == 0)
                            {
                                //Print player info to output
                                Output_TextField.Text += string.Format(player.ToString() + "None" + "\n-------------------------------------------------------------------------------------------\n"); ;
                                return;
                            }
                        }
                    }
                }
            }
            catch
            {
                Output_TextField.Text += "ERROR";
            }
        }
        private void Server_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check if the entered guild is already on a server
            foreach (Guild guild in Guildspool)
            {
                if (Guild_Name_TextField.Text.Equals(guild.Name))
                {
                    if (Server_Box.SelectedItem.Equals(guild.Servers))
                    {
                        Output_TextField.Clear();
                        Output_TextField.Text += "Name Is Already In Use On" + guild.Servers + "!\n";
                        return;
                    }
                }
            }
        }
        //have the selected person join the selected guild unless they are already in a guild
        private void Join_Guild_Button_Click(object sender, EventArgs e)
        {
            Output_TextField.Clear();
            if (Player_List_Listbox.SelectedIndex == -1)
            {
                Output_TextField.Text += string.Format("Select Player From List!");
                return;
            }
            if (Guild_List_Listbox.SelectedIndex == -1)
            {
                Output_TextField.Text += string.Format("Select Guild From List!");
                return;
            }
            if (Player_List_Listbox == null)
                return;
            _ = new string[30];//stores info from line in the player listbox
            _ = new string[30]; //stores info from line in the guild listbox
            try
            {

                string[] help = Player_List_Listbox.SelectedItem.ToString().Split('\t');
                string[] help2 = Guild_List_Listbox.SelectedItem.ToString().Split('\t');
                foreach (Player player in Playerspool)//loop through the sorted set to find
                {
                    if (help[0].Trim().ToString() == player.Name)
                    {
                        foreach (Guild guild in Guildspool)
                        {
                            if (help2[0].Trim().ToString() == guild.Name)
                            {
                                if (player.GuildID == 0)//check if player is not in a guild
                                {
                                    player.GuildID = guild.ID;
                                    Output_TextField.Text += string.Format(player.Name + " has joined " + "\"" + guild.Name + "\"");
                                    return;
                                }
                                else
                                {
                                    Output_TextField.Text += string.Format(player.Name + " is already in a guild!");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Output_TextField.Text += "ERROR";
            }
        }

        private void Leave_Guild_Button_Click(object sender, EventArgs e)
        {
            Output_TextField.Clear();
            if (Player_List_Listbox.SelectedIndex == -1)
            {
                Output_TextField.Text += string.Format("Select Player From List!");
                return;
            }
            if (Player_List_Listbox == null)
                return;
            _ = new string[30];//stores info from line in the player listbox
            try
            {
                string[] help = Player_List_Listbox.SelectedItem.ToString().Split('\t');
                foreach (Player player in Playerspool)//loop through the sorted set to find
                {
                    if (help[0].Trim().ToString() == player.Name)
                    {
                        if (player.GuildID != 0)//check if the player is in a guild
                        {
                            player.GuildID = 0;
                            Output_TextField.Text += string.Format(player.Name + " has left! ");
                            return;
                        }
                        else
                        {
                            Output_TextField.Text += string.Format(player.Name + " is not in a guild");
                            return;
                        }
                    }
                }
            }
            catch
            {
                Output_TextField.Text += "ERROR";
            }
        }

        //search for guild and players.
        private void Apply_Search_Criteria_Button_Click(object sender, EventArgs e)
        {
            //textfields empty? skip the search
            if (Search_Player_TextField.Text != string.Empty)
            {

                string str = Search_Player_TextField.Text;
                //Clear Output texbox
                Output_TextField.Clear();
                Player_List_Listbox.Items.Clear();
                //loop through pool and add players that meet the search criteria

                foreach (Player player in Playerspool)
                {
                    if (player.Name.Trim().StartsWith(str.Trim()))
                    {
                        StringBuilder result = new StringBuilder(string.Format("{0,-17}\t{1,-20}\t{2,-2} {3}", player.Name.Trim(), player.Pclass.ToString().Trim(), player.Level.ToString().Trim(), Environment.NewLine));
                        Player_List_Listbox.Items.Add((result));
                    }
                }
            }

            //textfields empty? skip the search
            if (Search_Guild_TextField.Text != string.Empty)
            {

                string str = Search_Guild_TextField.Text;
                //Clear Output texbox
                Output_TextField.Clear();
                Guild_List_Listbox.Items.Clear();
                //loop through guilds and look for the server

                foreach (Guild guild in Guildspool)
                {
                    if (guild.Servers.ToString().Trim().StartsWith(str.Trim()))
                    {
                        Guild_List_Listbox.Items.Add(string.Format("{0, -29}\t\t{1,-15} {2}", guild.Name.Trim(), "[" + guild.Servers.ToString().Trim() + "]", Environment.NewLine));
                    }
                }
            }
            //if player textbox is empty then print the entire list
            if (Search_Player_TextField.Text == string.Empty)
            {
                Output_TextField.Clear();
                Player_List_Listbox.Items.Clear();
                //loop through pool and add players that meet the search criteria

                foreach (Player player in Playerspool)
                {
                    StringBuilder result = new StringBuilder(string.Format("{0,-17}\t{1,-20}\t{2,-2} {3}", player.Name.Trim(), player.Pclass.ToString().Trim(), player.Level.ToString().Trim(), Environment.NewLine));
                    Player_List_Listbox.Items.Add((result));
                }
            }

            //if guild textbox is empty then print the entire list
            if (Search_Guild_TextField.Text == string.Empty)
            {
                //Clear Output texbox
                Output_TextField.Clear();
                Guild_List_Listbox.Items.Clear();
                //loop through pool and add guilds that meet the search criteriaa
                foreach (Guild guild in Guildspool)
                {
                    Guild_List_Listbox.Items.Add(string.Format("{0, -29}\t\t{1,-15} {2}", guild.Name.Trim(), "[" + guild.Servers.ToString().Trim() + "]", Environment.NewLine));
                }
            }

            //error message if the nothing was found for the search
            if (Player_List_Listbox.Items.Count == 0)
            {
                Output_TextField.Text += string.Format("Nothing was a match for your filtering criteria for players\n");
            }
            //error message if the nothing was found for the search
            if (Guild_List_Listbox.Items.Count == 0)
            {
                Output_TextField.Text += string.Format("Nothing was a match for your filtering criteria for guilds");
            }
            return;
        }
        //If user selects Guild for List
        private void Guild_List_Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Output_TextField.Clear();
            if (Guild_List_Listbox.SelectedIndex == -1)
            {
                return;
            }
            if (Guild_List_Listbox == null)
                return;
            _ = new string[30];
            try
            {

                string[] help = Guild_List_Listbox.SelectedItem.ToString().Split('\t');
                //loops through guildpool
                foreach (Guild guilds in Guildspool)
                {
                    //If guild is found
                    if (help[0].Trim().ToString() == guilds.Name)
                    {
                        //print
                        Output_TextField.Text += string.Format(guilds.ToString() + "\n-------------------------------------------------------------------------------------------\n");
                        return;

                    }
                }
            }
            catch
            {
                Output_TextField.Text += "ERROR";
            }
        }
    }
}
