# -CSCI473_A06
Assignment 6: Uncharted
For this final project, we're going to explore the Charts functionality within C#, as the means of creating "template" charts quickly, and easily, as might be particularly useful for any kind of data visualization we're attempting with our work. You're also going to have the freedom to choose which charts you would like to use (although they must be unique), as well as the data points you want to represent (although there must be a minimum number of data points). I expect the latter will be the most difficult part of the assignment.

Make sure to include this using statement:

using System.Windows.Forms.DataVisualization.Charting;

As it will give you access to data types such as Chart, and Series.

The specific parameters of this assignment are as follows:

There will be a "portal" Form, which will only contain the buttons that transition to one of the other Forms you'll create (or Hide/Show), which will contain the designated chart. The buttons should have labels indicating the type of chart you're demo'ing, such "Bar Chart" or "Powerlifting Totals Over Time: A Line Chart". There must be a button on each of these chart Forms that allows you to return to this "portal", also triggered by closing the chart Form by clicking the X in the top right corner.

Include an "Exit" button on the "portal" Form as well.

At any given point during the program's execution, there should only be one Form visible.

Each chart Form must contain:
A Title

A label for both the X and Y axes (as applicable)

Labels for the tick marks of each axes (as applicable)

Percentage values of the whole (as applicable -- think Pie Chart)

A legend defining groups of data or sections of the chart (as applicable)

There must be at least four (4) unique charts you demonstrate. If possible, they may share the same data. NOTE: You may not use both Bar and Column charts, and they're effectively the same graph, just tilted 90 degrees.

At least one of the charts must contain representations for at least three similarly groups of data. For example, my "Powerlifting Totals Over Time" chart may contain totals for myself, my non-existent best friend, and non-existent significant other. Ideally, this would be achieved by coloring those groups of data points differently from each other. Her's a great visual example of what I mean.

All charts must represent no less than ten (10) data points. Some denser chart types such as Box Plot contain multiple data points within each "box", meaning you only need 3-4 of them to cover the minimum requirement.

There will be no requirement that the data you use be factual. You're encouraged to use real data if possible, but you're welcome to simply invent data points to be used. In either case, though, you should be storing the data points into data files that are read and processed when the program starts up. Hard-coding your data points within the program is discouraged, as goes for most any instance of hard-coding. The one exception, though, is if you use a mathematical function to plot an arbitrary number of points!

And that's it! Bonus Cool Person Points if you integrate a joke into your chart, such as how much enjoyment is derived from naps over the course of your life (with the graph tending towards positive infinity as you get older), or how many living creature existed in the universe leading up to and shortly after The Snap.
