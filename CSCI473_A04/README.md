# CSCI473_A04
Assignment 4: r = 2a(1 – sin φ)
Whelp, since Activision Blizzard didn't take too kindly to our World of ConflictCraft project, issuing me a stern cease and desist, we're going to be moving on to different stolen borrrowed IP's. For this project, we're going to re-create graphing calculator functionality, in a .NET Form!

For those of you who somehow managed to avoid ever using graphing calculators in lower-level mathematics courses, or simply chose to erase those memories from your consciousness, graphing calculators functioned much like regular calculators, with the addition of being able to display rudimentary graphical representations of two-variable equations. Something like this. Hopefully, our implementation will look much nicer than this, given the ridiculously superior hardware we have to work with in comparsion.

One of the other distinct features of this assignment from our previous ones is that I won't be providing a look into what my solution ended up as, lending itself as a sort of template onto which you simply coded all the backend business for. Instead, you'll be tasked with working on the design of your graphing calculator Form as much as it's functionality! I will still provide specifications for what exactly you'll be expected to realize with this software, in addition to an organized and intuitive GUI.

Let's first address the looming dread you might already be feeling, if you've thought ahead to what challenges implementing this will include: parsing an equation to then begin plotting points onto your drawing field. To demonstrate what I mean: think about the code you would need to write in order to correctly graph this:

y = 14x2 - 7x + 42

And how that same code might also correctly graph this:

(x - 4)2 + (y + 2)2 = 36

In the first example, simply plugging in values of x generates values of y, whereas the second equation requires some basic algebra to finally determine the two values of y generated for each value of x. You could help resolve this by "solving for y":

(y + 2)2 = 36 - (x - 4)2
   y + 2 = ±√(36 - (x - 4)2)
       y = ±√(36 - (x - 4)2) - 2

But I much prefer the "human" version of the equation for circles, as opposed to what the computer needs. Especially because, as we've noted when discussing drawing graphics, there already exists tools by which we can draw circles and ellipses, as opposed to generated a series of data points ourselves. And as I learned from Professor Duffin's Graphics class, drawing curves and circles involves a non-trivial algorithm which I'm going to skip over entirely for this assignment. Instead, if you know where the center of the circle is (4, -2) and the radius of the circle (6), you can calculate the arguments you need to pass to DrawEllipse methods. Or even better, to include the function extensions we talked about, including DrawCircle.

Requirements
Let's start with the equation input. Your graphing calculator will be expected to simultaneously display up to four (4) different graphs at a time. To help the user differentiate them, you will need to let them select a color by which they can draw each equation's graph. You can easily achieve this functionality using a Color Dialog, which we haven't covered in lecture just yet, but also isn't terribly complicated to include in your project. Assuming you use a white background (although I personally recommend building a "dark-themed" drawing field), the four equations should be drawn with the following default colors: black, red, green, and blue. For the "dark-theme", you should only need to replace the first default color with white... obviously.

For the equation input itself, this is where you can exercise some ingenuity, at least when it comes to how exactly the user will define each of these equations. For example: the "hard-mode" route for this task is to include exactly one input field for each equation, wherein you expect (and will need to rigorously check) the correct formatting of each equation type (described below). Remember: the more freedom you give the user in their input decisions, the more likely they will break something. To help, you are recommended to initialize these input fields with a "format shadow", that is removed the moment this field gains focus but re-appears if this field loses focus and it is blank.

The easier and safer solution would be to limit the input the user provides to only coefficients and constants, leaving the rest of the structured format of the equation fixed in place. Something like:

y = ▢ x + ▢

This way, you only need to ensure the user entered numbers. If you go this route, I recommend not using NumericUpDowns, as we want to include real number inputs for these values.

The four equations types you will be expected to graph are:

Linear Equations (y = mx + b) where "m" is the slope and "b" is the y-intercept
Quadratic Equations (y = ax2 + bx + c), where a, b, and c are real number coefficients
Cubic Equations (y = ax3 + bx2 + cx + d), where a, b, c, and d are real number coefficients
Circle Equations ( (x - h)2 + (y - k)2 = r2 ), where (h, k) is the center of the circle, and r is the radius
For Linear and Circle Equations, you are encouraged to trivalize their graphical representation by using the already available DrawLine and DrawEllipse (or the extension method DrawCircle). You'll only need to do a little bit of math to figure out each value of the necessary arguments. For quadratic/cubic equations, you'll need to a little bit of legwork before utilizing the DrawCurve method, which has many overloaded implementations, all of which require an array of Points which you'll draw over. But even this shouldn't be too terrible a challenge. As opposed to...

The drawing field specifications. As with traditional graphing calculators, the drawing field should be adjustable, based on six (6) parameters, valid only with integer inputs:

xMin -- the lowest x-coordinate value
xMax -- the highest x-coordinate value
xInternval -- the distance between ticks on the x-axis
yMin
yMax
yInterval
Depending on the size of your drawing field (which should take up a fair amount of real estate), you can define appropriate default values. Something like [-100, 100] in both X and Y directions, and an interval set to 10 in both directions, for example. The tick marks should also have labels, although you may elect to not label each and every single one of them, in an effort to reduce the amount of "noise" in your drawing field. You can also freely choose between putting the tick labels above/below the x-axis and to the left/right of the y-axis as you prefer.

The various skews and stretches that can be applied to the drawing field is what really complicates this project, as a y = x equation would be represented as a diagonal line from the bottom-left corner of the screen to the top-right under the above default settings, but become slanted if I were to compress the x-coordinate range to [-50, 50]. So changing the equation obviously draws a different graph but changing the parameters of the drawing field can do it as well.

Don't forget! The top-left corner of our Forms is (0, 0) as far as .NET is concerned, so drawing a Cartesian Point at the origin is more like (DRAWING_FIELD_WIDTH / 2, DRAWING_FIELD_HEIGHT / 2), as long as the drawing field has square parameters to it.

Next, let's talk about the two axes and drawing tick marks. There are four (4) possible representations of the two axes and their associated tick marks.

Both axes are present: if both min values are <= 0, and the max values are > 0, then the axis is drawn from top-to-bottom (y-axis) or from left-to-right (x-axis). Tick marks should be very short, but visible above and below (or left and right) of each axis.

Only the Y-axis is present: if yMin > 0 or yMax < 0, then do not draw the X-axis itself but instead draw tick marks across the bottom (or top, respectively) edge of the drawing field. The y-axis and associated tick marks will be drawn as normal.

Only the X-axis is present: if xMin > 0 or xMax < 0, then do not draw the Y-axis itself but instead draw tick marks across the left (or right, respectively) edge of the drawing field. The x-axis and associated tick marks will be drawn as normal.

Neither axis is present: if (xMin > 0 && yMin > 0) || (xMax < 0 && yMin > 0) || (xMax < 0 && yMax < 0) || (xMin > 0 && yMax < 0), then both axes are to be omitted and only their tick marks drawn across the (left/bottom), (right/bottom), (right/top), (left, top), respectively.
Other Details
Make sure corresponding min/max values are never equal to each other, or that min > max or vise versa.

If any one of your equations do not have representations within a specific drawing field parameter set, produce a message somewhere alerting the user that "Equation X is out of scope" or something else along those lines. You can accomplish this by using DrawString to place the message on the same drawing field as everything else. Or reserve a sort of "Error Log" RichTextField, similar to the one in Assignment 2. Probably not as large an area, though, since we should only have — at most — four messages at a time.

When labeling your four equation input fields, you should have the equation format described along with the English term used. Be mindful that perhaps your user doesn't understand what the "h" and "k" values from the Circle Equation may represent, so provide a Tool that gives them a Tip (hint hint!) defining each non-x and non-y variables, for all four equations. This is done so that we don't overburden the Form's real estate with an explanation of symbols that are well-understood by competent mathematicians and regular users of our software.

Finally: I strongly recommend hammering down a system of symbolic constants and math expressions that will serve as the foundation of being able to:

Draw your axes and tick marks, adjusted by the parameters of the drawing field
Draw your tick mark labels — oh, and don't ever label the origin. If both axes are present and intersect, that "labels" the origin.
Drawing your linear equations using two calculated points. If the leftmost point is (-100, -50), how do you convert that into Form coordinates? How do you adjust those Form coordinates to fit the drawing field's parameters?
Drawing your quadratic/cubic equations using a series of points
Drawing your circles, which may not always look like circles if the drawing field's parameters are not square
More or less in that order.
