/************************************************************************
   Team Blizzard
   PROGRAM:    Form1.cs
   ASSIGNMENT: 6
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   4/14/21

   FUNCTION:  Menu for Selecting which graph to show
   
************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TeamBlizzard_Assignment6v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            //closes program
            System.Environment.Exit(0);
        }

        private void Barchart_Button_Click(object sender, EventArgs e)
        {
            //hides menu and creates barchart
            this.Hide();
            //creates form
            var piechart = new Form2(this);
            //shows new form
            piechart.Show();
        }
        //opens linegraph
        private void LineGraph_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            LineGraph linechart = new LineGraph(this);
            linechart.Show();
        }
        //opens bar graph
        private void BarGraph_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            BarGraph bargraph = new BarGraph(this);
            bargraph.Show();
        }
        //opens stackedgraph
        private void StackedGraph_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ScatterGraph stackedgraph = new ScatterGraph(this);
            stackedgraph.Show();
        }
    }
}
