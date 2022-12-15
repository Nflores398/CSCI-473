# CSCI473_A05
Assignment 5: Let's Play a Game
Saw movie references are still hip, right? ... right? ... guys???

I got the idea for this puzzle game from Professor Hutchins, as it were, and thought it could make a great project premise for our next assignment. It's a sort of Sudoku puzzle game variant, where instead of the challenge being to arrange the numbers 1 through 9 in every row, column, and "box", we're going to make sure the sum of the numbers found in every row, column, and diagonal adds up to pre-determined values. And you know me: anytime I get to inject some maths into what we do in Computer Science, I'm going to leap at that chance!

Edit: I haven't explicitly stated it anywhere in this assignment handout, but this game should prohibit the entry of zero into any given cell. Zero will only be used in the input files to stand in for what should be displayed as blanks to the user/player.

I'm imagining the playing field to look very much like a conventional Sudoku puzzle (albeit with a variable number of rows and columns, as we're going to touch on later), with the addition of (1) the correct sum displayed for each row/column/diagonal and the (2) sum derived from the currently available input. This will serve as the mechanism by which the user/player can (1) solve the puzzle at all and (2) measure their progress by investigation. I'm also going to insist on colored displays to help highlight puzzle completion, such as the derived sums displayed in green when it matches the correct sum for this row/column/diagonal and red for when they have (1) overshot the correct sum or (2) completed any given row/column/diagonal and ended up with a sum that doesn't match the correct sum. "In-progress" sums should be displayed with a fairly neutral color — something that offsets the background, but doesn't stand out as mandating the user/player's attention. Which should have a wholly different color or style (e.g. bold) from the displayed correct sum values, to help distinguish between the two.

We're going to focus on the use of... Focus, drawing graphics, timers, fluid design, and "state" control in order for us to:

Pull up an unsolved puzzle...
From a selection of varying difficulities...
The ability for us to save our current progress, to be resumed later...
With a mechanism to track our progress with solving puzzles within a single difficulty...
A button to "cheat" or "help" with finding the solution...
Another button to verify the correctness (or lack thereof) of our current solution...
A "pause" button...
And of course, as with most things, a reset button.
Pulling up a new puzzle
While there are ways by which we can dynamically create new Sudoku puzzles, I wanted to focus on the front-end portion of this project instead. So we're going to have text files setup that will serve as our "database" of available puzzles, with two layers of organization: first by difficulty, then by completed followed by uncompleted puzzles within those difficulties.

Once the user has indicated they would like to select a new puzzle of a specific difficulty, your task will be to fetch either the first saved puzzle they have or an unsolved puzzle. If you arrange your puzzles as [Completed], [Completed], [Saved], [Saved], [Unsolved], you only need to iterate from 0 to (n - 1) until you find either or. This should have the effect of taking the contents of the (either saved or unsolved puzzle) and populating them into our Form. At which time, our timer should either resume from the saved time or begin from 0:00.

Here is a zip file of sample puzzles, including their solutions. You'll want to open the directory.txt file, which contains the names of the other files to be opened. Using ReadLine, you'll open each file, collect the input values, and if when the user action dictates it, save an in-progress puzzle, or record the time for that puzzle's solution.

Varying Difficulties
This introduces a problem you must solve when it comes to user input and more specifically, how many steps are necessary for them to complete before you can move forward with completing the desired functionality. In this case, those steps or choices are (1) deciding to pull up a new puzzle and (2) deciding which difficulty the puzzle will have. You can make this a two-step process: click this button, then select your difficulty, or choose your difficulty from a ComboBox before clicking the "New Puzzle" button. Or you can risk simplifying this into a single step (as done here on my favorite online Sukodu puzzle solver), by clicking the desired difficulty, to then create a new puzzle. You have to be careful when making these kinds of assumptions, as you risk confusing a user who's looking explicitly for a "New Puzzle" button, only to have to discover that functionality is baked into the difficulty options themselves. You can help bridge that gap most simply by placing a label around the available difficulties such as, "Click The Difficulty to Generate a New Puzzle", or more subtly by making it obvious that the difficulties can be interacted with by the user (such as with making them into Buttons.)

I would like to insist on the one-step process for this project, whereby choosing one of the difficulties pulls up a new puzzle.

In traditional Sudoku, difficulty is typically dictated by how many cells are initially populated, with easier puzzles having 30 or more cells already filled in. With this variant, difficulty will come instead from how large the dimensions the puzzle has, since there will be many more variables to keep track of. As we'll see, easy puzzles will be 3x3, medium puzzles will be 5x5, and hard puzzles will be 7x7 — using even numbers for the dimensions makes tracking diagonals a bit awkward.

As a result of this, you will need to make sure your playing field flexes to accommodate whichever size we're currently playing with. I see this as being possible to solve in two different ways (although there may be more):

Drawing the playing field with graphics and the numbers with DrawString, although this comes with some challenges regarding focus and recording user input
Dynamically allocating .NET components (as opposed to statically placing them using the Design View), although this comes with some challenges regarding the code and math necessary to elegantly layout these components to be correctly arranged into a grid that you might insist on filling the same playing field dimensions. Meaning you need to scale each cell accordingly.
For what it's worth: I decided on the first option, but mostly because I thoroughly enjoy using programming to create designs.

Saving Our Progress
This one comes with an extra logistical step, because we may want to ultimately clear this attempt at some point. As a result, you will find yourself with three (3) versions of each puzzle to be stored: the initial state of the puzzle, an (optionally defined) saved state, and the solution.

Tracking Our Success
The most significant measure of success when it comes to solving Sudoku puzzles is how much time elasped in order to solve them. So for each difficulty, I want a memory of (1) the fastest solve time and (2) the average solve time of all puzzles within this difficulty. My recommendation would be to record each time for each difficulty, then re-confirm and re-calculate the fastest/average time after each puzzle's completion.

After the player solves any given puzzle, make sure to display:

The completion time for this puzzle
The fastest completion time for this difficulty of puzzles
The average completion time for this difficulty of puzzles
You can do this simply enough with a dialog box.

Unlike traditional Sudoku puzzles, I'm not as familiar with what even constitutes a solvable puzzle in this game variant. Which is what is going to make this next bit so important.
Getting Help
Without getting into the philosophy or psychology related to the pros/cons of including a "cheat button" for any game you make, there can be some relief a "cheat button" can provide in particular with puzzle games. As opposed to other types of games that rely more on your skill, your reflexes, or your advanced preparation, puzzle games can often have a "I GIVE UP!!" moment, and in an effort to help hand-hold the player into continuing, allow them to tap into some built-in support.

Functionally, this option should choose (1) a random, un-filled cell and insert the correct number or (if the puzzle is completely filled but incorrect) (2) choose the first cell found in a sequential search (down each row, for each and every row) that isn't correct, and change it to the correct value.

This should also have the effect of not storing the time of this puzzle's solution, as "cheating" invalidates that attempt.

Progress Bar Button
Sudoku lends itself well to being checked over time to ensure whether we've make correct selections so far, since any given cell only has exactly one correct value. This function should examine the currently defined cells and compare them to the solution. If all of the currently defined cells match the solution, present some kind of, "You're doing well so far!" type of message. You might optionally inform the player of how many remaining cells need defining, which should be simple enough to figure out from a programmer's point of view.

If the player has made a mistake, though, you'll want to point out what exactly went wrong. The aforementioned WebSudoku website does this by darkening a row/column/box in red whenever two of the same numbers appear in any given row/column/box. Other Sudoku puzzle games I've played have drawn a circle around the offending cells, with a line connecting them, which I much preferred, as it made it more obvious where the mistake was.

Given this variant of the game, though, I am insisting on highlighting the row/column/diagonal where the mistake has occurred, but not highlighting the specific cell where the mistake is.

Pause
Functionally, this should stop our Timer from ticking on, until a second button is pressed to resume solving the puzzle. In nearly any game you make (especially one where a measure of success is the alloted time), including a pause button can be vitally important, to allow the player to stop/resume play as is convenient. As might be the case if you were working as the Undergraduate Advisor and the student for your 2:00pm appointment showed up 10 minutes early (not... not that this has ever actually happened... *cough*).

However, this pause functionality could be exploited to ignore the time spent deciding which next cell can be confirmed with any given number, so ideally, we should hide or otherwise mask the Sudoku puzzle grid while the pause functionality is active. You can achieve this anyway you like but if you're otherwise unsure, you can simply change the grid cells to all be equal to ? or X or just blank. Only to have their contents restored when the "Resume" button is pressed.

Oh, you'll want to make the "Pause" and "Resume" Buttons be the same component in your Form, too. You won't lose 50% of the available points for this assignment if you have two, fixed, buttons for each action, but you'll definitely lose some points. Instead, you should be able to change the text of the Button dynamically, depending on which state the game currently is in.

Reset
This function will likely be the easiest to realize, as you'll simply re-load the initial state of the currently selected Sudoku puzzle, and reset the timer. If the "cheated" flag had previously been set to true, go ahead and reset that as well to false.

Now Focus
Clearly, the most obvious Form component you might think of using to capture the user input would be an N number of TextBoxes, of an appropriate size. And you wouldn't be wrong, not that you must use TextBoxes for your input fields. What's most important, though, is that selecting one of these TextBoxes doesn't cause the blinking I-cursor to persist. Ideally, I would select one of the fields, and wait for it to detect which number I enter from the keyboard, without seeing the I-cursor appear. Only because I'm not really going to enter text and certainly not anymore than a single character.

To help accomplish this, you'll want to re-direct Focus of your input fields, so that the default I-cursor doens't appear -- although, if you find an alternate way to prevent this from happening, more power to you. Of course, you'll want to make sure only numberic characters are entered from the keyboard, and that any given cell only contains exactly one (1) numeric character. You might also want to disallow zero from being entered, as that's simply not a valid choice. You can control these input values by installing an EventHandler for keyboard input, and filtering our the KeyChar or KeyValue Property of the KeyPressEventArgs object. From there, you can check if whether the selected input value already has a value entered and if not, whether the pressed key was a numeric character.

Once you've solved the I-cursor problem, I want the selected cell to be highlighted (since there won't be a cursor to otherwise indicate where Focus currently is). You can do this quite simply by changing the background color of that input field.

While on the subject of colors and appearances: make sure the values from the initial state of the puzzle (1) are highlighted (I recommend putting them in bold) and (2) unable to be changed by the player.
