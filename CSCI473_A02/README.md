# CSCI473_A02
I hope you're not too attached to console-window based programs, because we're never going to build another one in this class. From now on, we build Forms! Specifically, Windows Form Applications (.NET Framkework). The C# term used to describe programs that utilize graphic user interfaces, or GUI. That means we'll have windows or frames that contain text fields, labels, list boxes, combo boxes (aka drop-down menus), "rich text box", buttons, radio buttons, check boxes -- all manner of do-hickies (a very technical industry term) that are meant to allow for our software to mimic physical world interfaces. Control panels and that such.

To ease our transition into designing Forms for what might be the first time you're doing as much, we're going to simply upgrade our Assignment 1 work. That is, we're going to build a GUI for a Player/Guild Management system, for our #1 Best Seller: World of ConflictCraft. Most everything in that source code is going to be copied and function as the "back-end" part of our new project.

The input file containing players has been updated to (1) include more Players (2) disregard their equipment and (3) include their Class, which is a new Property to the Player... class, that we'll be introducing in this assignment. The input file containing guilds has been updated to include (1) more guilds and (2) server locations for each guild, which can be thought of as simply the address for these guilds. (In large-scale MMO games, it becomes technically necessary to partition the population of players onto multiple instances of the game, each of which operate in parallel. Otherwise, a single server would quickly buckle under the performance demand of hundreds of thousands or even millions of players, all performing actions and expecting feedback.) The server locations also add an extra layer of complexity to data handling during project execution, which is good, as we need to begin flexing our muscles now that we've gotten past the initial "shock" of working with C#.

Let's take a look at what I've put together to represent this new Player/Guild Management System.

The Main Menu

By no means are you expected to replicate this design, pound for pound. You can, if you'd like or if you'd rather not bother with re-inventing the wheel. After all, it has already been invented and comes in cheese form. You are only expected to replicate this functionality. You may add functionality to this for bonus Cool Person Points (which you can redeem at your nearest Dude Bro Ranch location), but you have to achieve everything described above, at a minimum. So let's now cover what that minimum functionality entails:

Print Guild Roster
Functionally identical to how this worked in Assignment 1, the output from this is now going to appear in the large message box provided.

Print Roster Output Example

I managed to neatly format my output by making all such containers use a monospaced font, such as Courier New, but you can achieve that goal in whatever way you think is best. You do have consider clean formatting, though.
Disband Guild
This will be one of the few new functions introduced with this project. Disband Guild should have two effects: (1) it should remove the guild from the ListBox containing your list of guilds and (2) iterate through your playerbase and set the GuildID Property of those Players, who were previously a part of that guild. You might find it useful to remove the guild from whatever Collection you're storing all guilds in as well, to prevent them from re-appearing again during a single project execution.
Join Guild
Again: functionally identical to how this worked in Assignment 1. Your success/failure message should now appear in the large message box provided. These functions will only work if the user has selected a Player and a Guild, from the two ListBox containers. If either condition has not been met, generate an error message of some kind in the RichTextBox to make sure the user understands why the function failed. Checking if a selection has been made is simple: the SelectedIndex Property of ListBox containers will be set to -1 if nothing has been selected.

NOTE: You are going to need to be careful with how you use the += operator of the Text property of RichTextBox objects. At regular intervals, you'll need to call Clear() in order to start fresh.

Leave Guild Same old, same old. Similar as with the Join Guild function, you need to ensure both a Player and Guild have been selected.
Apply Search Criteria
Anytime you have a large sample size of objects to choose from, you will most usually want to include a way to search or otherwise filter to a smaller, more human-manageable subset of the whole. This button will be tied to both input fields found to the right of this first group of buttons. Appropriately labeled "Search Player ( by Name )" and "Search Guild ( by Server )". This button will trigger the filter of one (or both) ListBoxes found in the rightmost part of this Form. Your code will need to examine the contents of both input fields, to determine which filter (if any) will be applied.

To make this interesting, we're going to filter in two different ways: when filtering Players by Name, you're going to list all Players who's Names StartsWith (hint hint) the Name value entered in that input field. So if I filter by "Z", nothing should change. Once I filter by "B", then only five Players (by default) should be shown in the list box. Filtering by Guild will simply look for identical matches. So filtering by "Death and Taxes" generates the "No results" event, whereas "ZappyBoi" produces the list of guilds on that server.

In my solution, I built this as a TextBox but in hindsight, a ComboBox would have been the superior implementation.

In the event that the filters would make either list box empty, instead populate them with all Players/Guilds from their respective pools and produce an error message in the large message box provided — something along the lines of, "Nothing was a match for your filtering criteria".

Add Player
Also new to this project, this functionality should allow us to add new Players, provided the four (4) corresponding input fields above the button are filled out. This includes the Player's Name, their Race, their Class, and their Role.

Class will be defined as a new enumerated type, containing nine values defined below, along with their corresponding Roles:

Warrior (Tank or DPS)
Mage (DPS only)
Druid (Tank, Healer, or DPS)
Priest (Healer or DPS)
Warlock (DPS only)
Rogue (DPS only)
Paladin (Tank, Healer, or DPS)
Hunter (DPS only)
Shaman (Healer or DPS)
There's a good chance many of these Properties will be used as part of what we'll work on in Assignment 3, so for consistency's sake, it would be ideal for you to define your Class enumerated type in this order.

Only once a Class has been chosen, should the final ComboBox be given any values, which should correspond to the Roles assigned above. For those classes that have only one Role available, you should populate the ComboBox with that singular value and automatically select it, since there is no choice to be made here.

Oh, and you'll need to make sure you have a unique ID value to attach to this new Player.

Add Guild
Functionally similar to adding a new Player, this button will allow us to add new guilds to the guild list. As long as there are well-defined values for all three inputs, the new guild can be created. For Type, use the following values:
Causal
Questing
Mythic+
Raiding
PVP
Same as with creating Players, you'll want to make sure you have a unique ID value to attach to new guilds, as one of the tests when it comes to grading will be to create a new Player and guild, then try and have the new Player join that guild.

Passive Reactions
Everything described up to this point, comes as a natural consequence of there being buttons you can click on. If you ever build a Form with a button that doesn't do anything, you have committed the most cardinal of sins. What I'm going to mandate also be realized will be "passive reactions" the program has to user actions. Something you'll program the software to do, to enhance the functionality and convenience of this project.

For example: when a Player is selected from the Player list, their ToString() method should be called and dumped into the output field.

Development Strategies
With our transition into developing Forms, our source code will morph from being a collection of methods that an object calls, to a collection of "event" methods that we'll attach to our Form objects. I had built nine (9) such methods in my solution to this assignment (along with the addition of some utility methods for re-occurring processes that wer shared among events), and they were all private void methods, with the same two arguments: object sender, EventArgs args. Inside these methods were the logic necessary to achieve the functional requirements specified in this assignment handout, which does lend itself to a "divide and conquer" strategy. Just make sure your pair/team agrees on error message conventions and other behavior.

My additional line count (including modifications to the original source code) end up nearing 500 lines. With generous white space and no documentation boxes. While I expect you'll write less code than with Assignment 1, the code you write will be a bit more complicated than with Assignment 1, including loads of methods calls we've not had a chance to use yet.
