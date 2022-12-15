/************************************************************************
   Team Blizzard
   PROGRAM:    Form2.cs
   ASSIGNMENT: 6
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   4/14/21

   FUNCTION:  Pie Chart
   
************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamBlizzard_Assignment6v2
{
    public partial class Form2 : Form
    {
        public static string path = "../../Input Files/Piein.txt";
        public static string[] temp = new string[80];
        private static readonly string[,] Input = new string[10, 2];
        private static string fileInput;
        readonly Form1 menu;
        public Form2(Form1 form)
        {
            InitializeComponent();
            menu = form;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //Set the MaximizeBox to false 
            this.MaximizeBox = false;
            //Set the MinimizeBox to false
            this.MinimizeBox = false;
            //Set the start position of the form to the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            //read input
            ReadingFile();
            Piechart.Series["s1"].IsValueShownAsLabel = true;
            //set the data points
            for (int i = 0; i < Input.GetLength(0); i++)
            {
               
               Piechart.Series["s1"].Points.AddXY(Input[i,0], Input[i,1]);
                
            }
        }
        public static void ReadingFile()
        {
            //reads file into srting
            fileInput = File.ReadAllText(path);
            //split string into array
            temp = fileInput.Split('\t', '\n', '-');
            //turns into 2d array
            FileReader(Input, temp);
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

        private void Return_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
    }
}
