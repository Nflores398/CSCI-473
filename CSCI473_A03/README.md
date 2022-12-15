# CSCI473_A03
I have incredible news everyone: our World of Conflict game has well-exceeded sales projections! Our Player base is growing and with it, our access to data. For this assignment, we're going to run experiments on how to translate that Player data into meaningful information, through the power of queries! No, we're not going to construct a relational database and use MySQL, PHP, etc. to pull down results — that's an assignment from a different class. Instead, we're going to use .NET's Language Integrated Query (LINQ) to perform some particularly elegant manipulation and filtering of a large collection of related objects. We'll be implementing this through a Form again, where the user can provide input on how to filter the initial datasets.

Our input files (Players and Guilds) have once again been updated, to include additional records, as well as more attributes. Specifically, Guild Types are finally being stored, as the second value in each record. Player Roles have also been stored, as the fourth value in each record. As well, the boys and girls in marketing have insisted that anytime a Guild Name is presented, that it be within <Guild Name> symbols.

Important Update: the Class and Role enumerated types must be defined in this same order:

public enum Classes
{
Warrior, Mage, Druid, Priest, Warlock,
Rogue, Paladin, Hunter, Shaman
};

public enum Role { Tank, Healer, Damage };

for the input files to be read correctly. Which will dictate whether your query outputs will match the defined output below.

As you'll see in the sample output screenshots at the bottom of this page, the output from the Player's ToString() method was modified. In part to allow for more information to be displayed without stretching the output field too far horizontally. I also formally introduced a Guild to save myself some headache, now that we have proper attributes of Guilds. I made GuildTypes and Roles into new enumerated types, but you aren't required to do the same. (Although you should.)

Some of these queries are being tested for implementation within the game itself, with others only being accessible by our admins. They are described below:

All Players of a single Class, from a single Server
% of each Race from a single Server
All Players of a single Role, from a single Server, within a Level range
All Guilds of a specific Guild Type
All Players who could fill a specific Role but presently aren't
Percentage of max Level Players in all Guilds

While there are ways to implement this functionality without using LINQ, it will be a functional requirement for full credit on this assignment that you heavily rely on LINQ to filter your datasets, before ultimately producing the results to a large text box area. For some of these results, there may also be an empty set of results, in which case you would only print a "n/a" or "No Results" type of message.

Generally speaking, your button EventHandler methods will follow this structure:

Verify input values (when applicable)
Perform one or more LINQ's
Dump results or print "No results" message

Here's what my Form ended up looking like:



This can help provide some directions on how to implement this, as well as point out features of this that are new from the Form we created in Assignment 2.

Besides the text fields, ComboBoxes, and buttons that we've utilized in Assignment 2, there's the addition of RadioButtons, which are typically input fields where only one in any given group may be selected (if any are selected at all). We're also introducing the NumericUpDown, which has a Value Property that we'll be manipulating from within our code, as well as a ValueChanged Event that is triggered anytime the, well, value being represented changes.

Each of the ComboBoxes need to be populated from your source code, with many of their values derived from the input files or our previously defined enumerations. The NumericUpDown components should both be initially set to 1, with a few additional restrictions:

Neither value should become less than 1, or greater than MAX_LEVEL
If I increment the value of "min" and if it would otherwise become greater than "max", automatically increment max as well, or otherwise set it to be no less than equal to the new value of "min".
Similarly, if I were to decrement or lower the value of "max" to what might otherwise by less than the value of "min", automatically set the value of "min" to be no greater than equal to the new value of "max".

Now, while I have no intention of walking you through the code necessary to achieve each of these objectives, some of them are reached through... potentially less than obvious means. So here are some "Development Strategies".

All Players of a single Class, from a single Server: This is listed as the first query, primarily because it is the simplest to implement. A requirement for this query (and many others involving the listing of Players) is that the output be sorted in order by their Level. The LINQ statement here provides an excellent launching pad for the rest of the objectives to be reached below.

% of each Race from a single Server: The primary challenge with this query is recognizing that you need multiple pieces of data before you can present: you need a Count() (hint hint) of each of the four defined Races from a specific Server, which you can infer from the Server their Guild is on. You then need a Count() of how many Players are on that specific Server in total. I ended up using five separate queries to accomplish this task.

All Players of a single Role, from a single Server, within a Level range: The most difficult part of this query is configuring the NumericUpDowns correctly. Once you accomplish this, the actually LINQ itself is only slightly more complicated than with the first one.

All Guilds of a specific Guild Type: The primary challenge with this query is the requirement for the output to be group by (hint hint) Servers. Manipulating a list of lists with the data type of var personally felt strange.

All Players who could fill a specific Role but presently aren't: This will require multiple queries, each tailored to the three Roles available.

Percentage of max Level Players in all Guilds: This was the only one where I performed a LINQ query inside of a loop! One thing to be aware of: accidentally, some of the Guilds ended up with zero Player members, which can make your division produce a NaN (not a number) result when dividing by zero. Omit those records altogether.
