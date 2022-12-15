# CSCI473_A01
Assignment 1: Getting Comfortable
The objective with this assignment will be to get you acclimated to C# programming and using Visual Studio. This isn't meant to be a particularly difficult assignment, at least not the logic of it. If you disagree, I would encourage you to meet with me.

We're going to build a Console Application — ideally called "myGroupName_Assign1" — that will represent a testing environment for functionality associated with my MMORPGFPSMOBA game, World of War ConflictCraft. This initial prototype we're building for this assignment is purposefully clunky, as to highlight the value of the Forms we're going to work on later.
"Hear me know or hear me never! Glue your little eyes to the diagram." You will lose all of your work if you aren't careful with where you save your Visual Studios project (via citrix). When you are clicking through and picking "Console Application: .NET Framework", you need to change the default location for your project (some "repos" folder on C:) and click "Browse" and choose a folder under H: If you don't, your project will get saved onto a phantom drive, on an imaginary computer, in Neverland, next to all of the hecks that I give. And you won't get it back. And I'm not giving you an extension to compensate.

Also, back-up your work often. That's just a good practice to get into no matter what.
Before we get into the classes and their construction, we need to outline some symbolic constants and enumerations to be used.

public enum ItemType
{ Helmet, Neck, Shoulders, Back, Chest,
  Wrist, Gloves, Belt, Pants, Boots,
  Ring, Trinket };

public enum Race { Orc, Troll, Tauren, Forsaken };

private static uint MAX_ILVL = 360;
private static uint MAX_PRIMARY = 200;
private static uint MAX_STAMINA = 275;
private static uint MAX_LEVEL = 60;
private static uint GEAR_SLOTS = 14;
private static uint MAX_INVENTORY_SIZE = 20;

We will have two classes that need defining: Item and Player.

The Item Class
Attributes:

(readonly uint) id
(string) name
(ItemType) type
(uint) ilvl
(uint) primary
(uint) stamina
(uint) requirement
(string) flavor
Each of these private attributes should have a corresponding public Property, used to control read/write access for non-Items. They should be setup with these restrictions in mind:

id -- only R access
name -- free R/W access
type -- free R/W access, range is [0, 12].(Wikipedia page on interval set notation)
ilvl -- free R/W access, range is [0, MAX_ILVL].
primary -- free R/W access, range is [0, MAX_PRIMARY].
stamina -- free R/W access, range is [0, MAX_STAMINA].
requirement -- free R/W access, range is [0, MAX_LEVEL].
flavor -- free R/W access
It goes without saying, but you should always use Properties when assigning values to the corresponding private attributes — even from within class methods — as they have your R/W access and restrictions built in.

You will need at least two constructors: a default constructor that takes no arguments and sets all values to 0 or "" as appropriate; and an alternate constructor for when you want to provide initial values to all attributes.

I want the Item class to implement the IComparable interface, which means you must have the public int CompareTo(object alpha) method defined. Sort by Name.

And finally, as with most every class you'll build in C#, you want to provide an override to the ToString() method.

You may add as many other methods as you feel is necessary — what is described above is what you'll be graded on. You may notice this class isn't particularly exciting.

The Player Class
Attributes:

(readonly uint) id
(readonly string) name
(readonly Racial) race
(uint) level
(uint) exp
(uint) guildID
(uint[]) gear — NOTE: You don't have to define this as an array. You may use whatever Collection you feel is most appropriate/convenient.
(List<uint>) inventory
I personally found it useful to also define two Boolean attributes, which I'm going to talk about later.

The Player Properties are where things start to get weird:

id -- only R access
name -- only R access
race -- only R access
level -- free R/W access, range is [0, MAX_LEVEL].
exp -- normal R access, but the W access should instead increment the value of exp by... value. If this should make the exp value exceed the required experience for this player to increase their level (but not exceed MAX_LEVEL), it should do as such.
guildID -- free R/W access
gear -- instead of a Property, you should create an Indexer to allow access to gear.
inventory -- will not have a corresponding Property.
Additionally, you will need at least two Player constructors: a default constructor that takes no arguments and assigns 0, "", or null values to all attributes; and an alternate constructor, that takes as many arguments as necessary to give initial values to all attributes, including an array of unsigned integers to assign to the gear attribute. You should have the IComparable Interface implemented for Player, sorting them by their name.

Now for the interesting part of the project: defining the methods (or actions) a Player object can take. We'll start with the most basic: equiping and unequiping gear.

public void EquipGear(uint newGearID)
public void UnequipGear(int gearSlot)

The argument to EquipGear should only be the ID of the gear piece to be equipped, which we are not going to get directly from the user. From there, you'll first want to determine (1) if this is a valid piece of gear at all and (2) if the Player's Level matches or exceeds the Requirement for the piece of gear in question — if they don't meet the level requirement, throw a new Exception, with an appropriate error message as the argument. If we're clear to equip the gear, place that ID value into the correct element of your gear array.

The exception to this rule comes with the two rings and two trinket slots each Player has. When equipping rings and trinkets, you'll want to assign the new piece of gear:

Into the lower-numbered index if both slots are empty
Into the empty slot if only one index is occuiped
Alternating equipment to the lower/higher-numbered index if both slots are occuiped, starting with the lower.
This last rule is where I found the aforementioned Boolean attributes to be useful, as a way to keep track of which ring/trinket will be equipped next, assuming both slots are occuiped.

Unequipping gear should only need to examine whether the indicated index of the gear array is occupied. If it is, place the Item there into the Player's inventory. You might find it useful to have a method that does this. If the number of elements in the Player's inventory is equal to (or somehow greater than?) the symbolic constant that represents the inventory's maximum size, throw a new Exception, with an error message of your choosing as the argument.

There needs to be a fairly small method that handles leveling up the character. The experience threshold for gaining a level will be primitive: (Current Level * 1000). So getting to Level 2 takes 1000 experience points, while going from Level 59 to 60 takes 59,000. You should include a mechanism here that allows for a Player to LevelUp several times in a row.

Include a PrintGearList method that first prints the Player's information (name, level), followed by a list of all their equipped gear, or an "empty" message if that index value is equal to zero or null. You should be sure to begin each line with what type of gear slot is being represented, followed by the piece of gear or the empty/null message. ToString() becomes particularly useful here.

The ToString() method for Player should print their name, race, level, and their Guild name, but only if they are in a Guild at all. This output should be neatly formatted, too, as you'll see in the sample output below.

The Menu
Now that we have the classes well-defined, it's time to build the menu functionality. There should be ten (10) options available, as well as one hidden option that I'm tossing in just to test the IComparable Interface of each class, which doesn't have any meaningful use thus far.

Print All Players -- print a list of all Players.
Print All Guilds -- print the names of all Guilds.
Print All Gear -- print a list of all Items.
Print Gear List for Player -- get a Player name and print their gear list.
Leave Guild -- get a Player name and leave their Guild (only if they are in one).
Join Guild -- get a Player and Guild name, and have that Player "join".
Equip Gear -- get a Player and Item name, then have the Player attempt to equip.
Unequip Gear -- get a Player name and Item Slot (see sample output) and attempt to remove gear.
Award Experience -- get a Player name and experience amount to award.
Quit -- triggered by entering "10", "q", "Q", "quit", "Quit", "exit", or "Exit".
(Don't Show This In the Menu) Accessed by entering in "T" for the IComparable testing method.
For the "hidden" option, simply add all possible Items and Players into (separate) SortedSet collections, then print them using a foreach loop.

An important feature that you need to be mindful of when developing the user-Menu interactions: every single action the user takes needs to result in feedback. Some of these options are only functionally achieved by providing feedback, but others (such as "Leave Guild" or "Equip Gear") need to respond to the user with either a success or failure message, before re-printing the menu. This feedback is important to notify the user that their action has been carried out, to some conclusion — success or failure. Without it, you run the risk of the user repeating an action or performing a different one, in order to finally confirm the success/failure of the first.

A technical expectation for this assignment will be for your "global" storage of Items and Players to be placed specifically into Dictionary collections, where the Key is the Item/Player's ID. Guilds need to be defined in a Dictionary as well, but the Key/Value pair here can simply be uint and string. An organizational expectation is that the menu options' functionalities are realized by corresponding method calls. This way, main's only real job is simply reading the input files, then getting the ball rolling on the menu-loop. My main method was 63 lines of code long.
