/************************************************************************
   Team Blizzard
   PROGRAM:    Assign5.cs
   ASSIGNMENT: 5
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   4/1/21

   FUNCTION: Sudoku game that always the user to choose from different puzzles
            and difficulty levels.
   
************************************************************************/
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TeamBlizzard_Assignment5
{
    public partial class Assign5 : Form
    {
        //Used to store puzzle from input file
        public static string[] m1 = new string[200];
        public static string[] m2 = new string[200];
        public static string[] m3 = new string[200];
        public static string[] e1 = new string[200];
        public static string[] e2 = new string[200];
        public static string[] e3 = new string[200];
        public static string[] h1 = new string[200];
        public static string[] h2 = new string[200];
        public static string[] h3 = new string[200];
        //used to store saves of each puzzle from file
        public static string[] m1save = new string[200];
        public static string[] m2save = new string[200];
        public static string[] m3save = new string[200];
        public static string[] e1save = new string[200];
        public static string[] e2save = new string[200];
        public static string[] e3save = new string[200];
        public static string[] h1save = new string[200];
        public static string[] h2save = new string[200];
        public static string[] h3save = new string[200];

        public static int[] m1times = new int[200];
        public static int[] m2times = new int[200];
        public static int[] m3times = new int[200];
        public static int[] e1times = new int[200];
        public static int[] e2times = new int[200];
        public static int[] e3times = new int[200];
        public static int[] h1times = new int[200];
        public static int[] h2times = new int[200];
        public static int[] h3times = new int[200];

        bool cheater = false;



        public bool onstart = false;

        //paths for each file
        public static string path = "../../../Input Files/medium/m1.txt";
        public static string path1 = "../../../Input Files/medium/m2.txt";
        public static string path2 = "../../../Input Files/medium/m3.txt";
        public static string path3 = "../../../Input Files/hard/h1.txt";
        public static string path4 = "../../../Input Files/hard/h2.txt";
        public static string path5 = "../../../Input Files/hard/h3.txt";
        public static string path6 = "../../../Input Files/easy/e1.txt";
        public static string path7 = "../../../Input Files/easy/e2.txt";
        public static string path8 = "../../../Input Files/easy/e3.txt";

        public static string path9 = "../../../Saves/m1save.txt";
        public static string path10 = "../../../Saves/m2save.txt";
        public static string path11 = "../../../Saves/m3save.txt";
        public static string path12 = "../../../Saves/e1save.txt";
        public static string path13 = "../../../Saves/e2save.txt";
        public static string path14 = "../../../Saves/e3save.txt";
        public static string path15 = "../../../Saves/h1save.txt";
        public static string path16 = "../../../Saves/h2save.txt";
        public static string path17 = "../../../Saves/h3save.txt";



        private static string fileInput;

        public Assign5()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Assign5_Load(object sender, EventArgs e)
        {
            TimeSpan time = TimeSpan.FromSeconds(0);
            StartandPause_checkBox.Appearance = Appearance.Button;
            Record_textbox.Text = "00:00:00";
            Average_timebox.Text = "00:00:00";
            //Sets the default puzzle to m1
            Diff_combobox.SelectedIndex = 1;
            //reads input
            FileReader();
            //Fill the puzzle select menu
            PuzzleFill(sender, e);
            //Fill board with starting puzzle
            BoardFill(sender, e);
            //adjust board size
            BoardResize(sender, e);
            Timer_Textbox.ReadOnly = true;


        }
        //Used to fill board with selected puzzle
        public void BoardFill(object sender, EventArgs e)
        {
            string tempboard;
            //reset timer when puzzel is swithced
            i = 0;
            TimeSpan time = TimeSpan.FromSeconds(i);
            Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
            timer1.Stop();
            //changes start button
            StartandPause_checkBox.Checked = false;
            StartandPause_checkBox.Text = "Start";
            //timer1_Tick(sender, e);
            //easy
            if (Diff_combobox.SelectedIndex == 0)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //e1
                    tempboard = e1[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    tempboard = e1[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    tempboard = e1[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //e2
                    tempboard = e2[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();

                    tempboard = e2[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();

                    tempboard = e2[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();

                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //e3
                    tempboard = e3[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();

                    tempboard = e3[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();

                    tempboard = e3[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();

                }
            }
            //normal
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //m1
                    tempboard = m1[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    tempboard = m1[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    tempboard = m1[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    tempboard = m1[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    tempboard = m1[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //m2
                    tempboard = m2[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    tempboard = m2[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    tempboard = m2[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    tempboard = m2[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    tempboard = m2[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //m3
                    tempboard = m3[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    tempboard = m3[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    tempboard = m3[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    tempboard = m3[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    tempboard = m3[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                }
            }
            //hard
            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //h1
                    tempboard = h1[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    F1.Text = tempboard[5].ToString();
                    G1.Text = tempboard[6].ToString();

                    tempboard = h1[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    F2.Text = tempboard[5].ToString();
                    G2.Text = tempboard[6].ToString();

                    tempboard = h1[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    F3.Text = tempboard[5].ToString();
                    G3.Text = tempboard[6].ToString();

                    tempboard = h1[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    F4.Text = tempboard[5].ToString();
                    G4.Text = tempboard[6].ToString();

                    tempboard = h1[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    F5.Text = tempboard[5].ToString();
                    G5.Text = tempboard[6].ToString();

                    tempboard = h1[5];
                    A6.Text = tempboard[0].ToString();
                    B6.Text = tempboard[1].ToString();
                    C6.Text = tempboard[2].ToString();
                    D6.Text = tempboard[3].ToString();
                    E6.Text = tempboard[4].ToString();
                    F6.Text = tempboard[5].ToString();
                    G6.Text = tempboard[6].ToString();

                    tempboard = h1[6];
                    A7.Text = tempboard[0].ToString();
                    B7.Text = tempboard[1].ToString();
                    C7.Text = tempboard[2].ToString();
                    D7.Text = tempboard[3].ToString();
                    E7.Text = tempboard[4].ToString();
                    F7.Text = tempboard[5].ToString();
                    G7.Text = tempboard[6].ToString();

                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //h1
                    //h1
                    tempboard = h2[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    F1.Text = tempboard[5].ToString();
                    G1.Text = tempboard[6].ToString();

                    tempboard = h2[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    F2.Text = tempboard[5].ToString();
                    G2.Text = tempboard[6].ToString();

                    tempboard = h2[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    F3.Text = tempboard[5].ToString();
                    G3.Text = tempboard[6].ToString();

                    tempboard = h2[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    F4.Text = tempboard[5].ToString();
                    G4.Text = tempboard[6].ToString();

                    tempboard = h2[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    F5.Text = tempboard[5].ToString();
                    G5.Text = tempboard[6].ToString();

                    tempboard = h2[5];
                    A6.Text = tempboard[0].ToString();
                    B6.Text = tempboard[1].ToString();
                    C6.Text = tempboard[2].ToString();
                    D6.Text = tempboard[3].ToString();
                    E6.Text = tempboard[4].ToString();
                    F6.Text = tempboard[5].ToString();
                    G6.Text = tempboard[6].ToString();

                    tempboard = h2[6];
                    A7.Text = tempboard[0].ToString();
                    B7.Text = tempboard[1].ToString();
                    C7.Text = tempboard[2].ToString();
                    D7.Text = tempboard[3].ToString();
                    E7.Text = tempboard[4].ToString();
                    F7.Text = tempboard[5].ToString();
                    G7.Text = tempboard[6].ToString();
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //h1

                    tempboard = h3[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    F1.Text = tempboard[5].ToString();
                    G1.Text = tempboard[6].ToString();

                    tempboard = h3[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    F2.Text = tempboard[5].ToString();
                    G2.Text = tempboard[6].ToString();

                    tempboard = h3[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    F3.Text = tempboard[5].ToString();
                    G3.Text = tempboard[6].ToString();

                    tempboard = h3[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    F4.Text = tempboard[5].ToString();
                    G4.Text = tempboard[6].ToString();

                    tempboard = h3[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    F5.Text = tempboard[5].ToString();
                    G5.Text = tempboard[6].ToString();

                    tempboard = h3[5];
                    A6.Text = tempboard[0].ToString();
                    B6.Text = tempboard[1].ToString();
                    C6.Text = tempboard[2].ToString();
                    D6.Text = tempboard[3].ToString();
                    E6.Text = tempboard[4].ToString();
                    F6.Text = tempboard[5].ToString();
                    G6.Text = tempboard[6].ToString();

                    tempboard = h3[6];
                    A7.Text = tempboard[0].ToString();
                    B7.Text = tempboard[1].ToString();
                    C7.Text = tempboard[2].ToString();
                    D7.Text = tempboard[3].ToString();
                    E7.Text = tempboard[4].ToString();
                    F7.Text = tempboard[5].ToString();
                    G7.Text = tempboard[6].ToString();
                }
            }
        }
        //resizes board
        public void BoardResize(object sender, EventArgs e)
        {
            //easy
            if (Diff_combobox.SelectedIndex == 0)
            {

                A1.Visible = true;
                A2.Visible = true;
                A3.Visible = true;
                A4.Visible = false;
                A5.Visible = false;
                A6.Visible = false;
                A7.Visible = false;


                B1.Visible = true;
                B2.Visible = true;
                B3.Visible = true;
                B4.Visible = false;
                B5.Visible = false;
                B6.Visible = false;
                B7.Visible = false;


                C1.Visible = true;
                C2.Visible = true;
                C3.Visible = true;
                C4.Visible = false;
                C5.Visible = false;
                C6.Visible = false;
                C7.Visible = false;


                D1.Visible = false;
                D2.Visible = false;
                D3.Visible = false;
                D4.Visible = false;
                D5.Visible = false;
                D6.Visible = false;
                D7.Visible = false;


                E1.Visible = false;
                E2.Visible = false;
                E3.Visible = false;
                E4.Visible = false;
                E5.Visible = false;
                E6.Visible = false;
                E7.Visible = false;


                F1.Visible = false;
                F2.Visible = false;
                F3.Visible = false;
                F4.Visible = false;
                F5.Visible = false;
                F6.Visible = false;
                F7.Visible = false;


                G1.Visible = false;
                G2.Visible = false;
                G3.Visible = false;
                G4.Visible = false;
                G5.Visible = false;
                G6.Visible = false;
                G7.Visible = false;

                Row1_Checkbox.Visible = true;
                Row2_Checkbox.Visible = true;
                Row3_Checkbox.Visible = true;
                Row4_Checkbox.Visible = false;
                Row5_Checkbox.Visible = false;
                Row6_Checkbox.Visible = false;
                Row7_Checkbox.Visible = false;
                RowA_Checkbox.Visible = true;
                RowB_Checkbox.Visible = true;
                RowC_Checkbox.Visible = true;
                RowD_Checkbox.Visible = false;
                RowE_Checkbox.Visible = false;
                RowF_Checkbox.Visible = false;
                RowG_Checkbox.Visible = false;



            }
            //normal
            if (Diff_combobox.SelectedIndex == 1)
            {

                A1.Visible = true;
                A2.Visible = true;
                A3.Visible = true;
                A4.Visible = true;
                A5.Visible = true;
                A6.Visible = false;
                A7.Visible = false;


                B1.Visible = true;
                B2.Visible = true;
                B3.Visible = true;
                B4.Visible = true;
                B5.Visible = true;
                B6.Visible = false;
                B7.Visible = false;


                C1.Visible = true;
                C2.Visible = true;
                C3.Visible = true;
                C4.Visible = true;
                C5.Visible = true;
                C6.Visible = false;
                C7.Visible = false;


                D1.Visible = true;
                D2.Visible = true;
                D3.Visible = true;
                D4.Visible = true;
                D5.Visible = true;
                D6.Visible = false;
                D7.Visible = false;


                E1.Visible = true;
                E2.Visible = true;
                E3.Visible = true;
                E4.Visible = true;
                E5.Visible = true;
                E6.Visible = false;
                E7.Visible = false;


                F1.Visible = false;
                F2.Visible = false;
                F3.Visible = false;
                F4.Visible = false;
                F5.Visible = false;
                F6.Visible = false;
                F7.Visible = false;


                G1.Visible = false;
                G2.Visible = false;
                G3.Visible = false;
                G4.Visible = false;
                G5.Visible = false;
                G6.Visible = false;
                G7.Visible = false;


                Row1_Checkbox.Visible = true;
                Row2_Checkbox.Visible = true;
                Row3_Checkbox.Visible = true;
                Row4_Checkbox.Visible = true;
                Row5_Checkbox.Visible = true;
                Row6_Checkbox.Visible = false;
                Row7_Checkbox.Visible = false;
                RowA_Checkbox.Visible = true;
                RowB_Checkbox.Visible = true;
                RowC_Checkbox.Visible = true;
                RowD_Checkbox.Visible = true;
                RowE_Checkbox.Visible = true;
                RowF_Checkbox.Visible = false;
                RowG_Checkbox.Visible = false;


            }
            //hard
            if (Diff_combobox.SelectedIndex == 2)
            {
                A1.Visible = true;
                A2.Visible = true;
                A3.Visible = true;
                A4.Visible = true;
                A5.Visible = true;
                A6.Visible = true;
                A7.Visible = true;


                B1.Visible = true;
                B2.Visible = true;
                B3.Visible = true;
                B4.Visible = true;
                B5.Visible = true;
                B6.Visible = true;
                B7.Visible = true;


                C1.Visible = true;
                C2.Visible = true;
                C3.Visible = true;
                C4.Visible = true;
                C5.Visible = true;
                C6.Visible = true;
                C7.Visible = true;


                D1.Visible = true;
                D2.Visible = true;
                D3.Visible = true;
                D4.Visible = true;
                D5.Visible = true;
                D6.Visible = true;
                D7.Visible = true;


                E1.Visible = true;
                E2.Visible = true;
                E3.Visible = true;
                E4.Visible = true;
                E5.Visible = true;
                E6.Visible = true;
                E7.Visible = true;


                F1.Visible = true;
                F2.Visible = true;
                F3.Visible = true;
                F4.Visible = true;
                F5.Visible = true;
                F6.Visible = true;
                F7.Visible = true;


                G1.Visible = true;
                G2.Visible = true;
                G3.Visible = true;
                G4.Visible = true;
                G5.Visible = true;
                G6.Visible = true;
                G7.Visible = true;


                Row1_Checkbox.Visible = true;
                Row2_Checkbox.Visible = true;
                Row3_Checkbox.Visible = true;
                Row4_Checkbox.Visible = true;
                Row5_Checkbox.Visible = true;
                Row6_Checkbox.Visible = true;
                Row7_Checkbox.Visible = true;
                RowA_Checkbox.Visible = true;
                RowB_Checkbox.Visible = true;
                RowC_Checkbox.Visible = true;
                RowD_Checkbox.Visible = true;
                RowE_Checkbox.Visible = true;
                RowF_Checkbox.Visible = true;
                RowG_Checkbox.Visible = true;

            }
        }
        //Runs on start to fill puzzles selection
        public void PuzzleFill(object sender, EventArgs e)
        {
            if (Diff_combobox.SelectedIndex == 1)
            {
                Puzzle_Select_Combo.Items.Clear();
                Puzzle_Select_Combo.Items.Add("M1");
                Puzzle_Select_Combo.Items.Add("M2");
                Puzzle_Select_Combo.Items.Add("M3");
                Puzzle_Select_Combo.SelectedIndex = 0;
            }
        }
        //read files
        public static void FileReader()
        {

            fileInput = File.ReadAllText(path);
            m1 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path1);
            m2 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path2);
            m3 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path6);
            e1 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path7);
            e2 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path8);
            e3 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path3);
            h1 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path4);
            h2 = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path5);
            h3 = fileInput.Split('\t', '\n');

            fileInput = File.ReadAllText(path9);
            m1save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path10);
            m2save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path11);
            m3save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path12);
            e1save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path13);
            e2save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path14);
            e3save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path15);
            h1save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path16);
            h2save = fileInput.Split('\t', '\n');
            fileInput = File.ReadAllText(path17);
            h3save = fileInput.Split('\t', '\n');


        }

        //Used to help the user cheat
        private void Cheat_menuitem_Click(object sender, EventArgs e)
        {
            string tempboard;
            cheater = true; 
            if (Diff_combobox.SelectedIndex == 0)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //e1
                    tempboard = e1[4];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    tempboard = e1[5];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    tempboard = e1[6];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //e2
                    tempboard = e2[4];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    tempboard = e2[5];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    tempboard = e2[6];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }

                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //e3
                    tempboard = e3[4];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    tempboard = e3[5];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    tempboard = e3[6];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }

                }
            }
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //m1
                    tempboard = m1[6];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D1.Text != tempboard[3].ToString())
                    {
                        D1.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E1.Text != tempboard[4].ToString())
                    {
                        E1.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m1[7];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D2.Text != tempboard[3].ToString())
                    {
                        D2.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E2.Text != tempboard[4].ToString())
                    {
                        E2.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m1[8];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D3.Text != tempboard[3].ToString())
                    {
                        D3.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E3.Text != tempboard[4].ToString())
                    {
                        E3.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m1[9];
                    if (A4.Text != tempboard[0].ToString())
                    {
                        A4.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B4.Text != tempboard[1].ToString())
                    {
                        B4.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C4.Text != tempboard[2].ToString())
                    {
                        C4.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D4.Text != tempboard[3].ToString())
                    {
                        D4.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E4.Text != tempboard[4].ToString())
                    {
                        E4.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m1[10];
                    if (A5.Text != tempboard[0].ToString())
                    {
                        A5.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B5.Text != tempboard[1].ToString())
                    {
                        B5.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C5.Text != tempboard[2].ToString())
                    {
                        C5.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D5.Text != tempboard[3].ToString())
                    {
                        D5.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E5.Text != tempboard[4].ToString())
                    {
                        E5.Text = tempboard[4].ToString();
                        return;
                    }
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //m2
                    tempboard = m2[6];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D1.Text != tempboard[3].ToString())
                    {
                        D1.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E1.Text != tempboard[4].ToString())
                    {
                        E1.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m2[7];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D2.Text != tempboard[3].ToString())
                    {
                        D2.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E2.Text != tempboard[4].ToString())
                    {
                        E2.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m2[8];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D3.Text != tempboard[3].ToString())
                    {
                        D3.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E3.Text != tempboard[4].ToString())
                    {
                        E3.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m2[9];
                    if (A4.Text != tempboard[0].ToString())
                    {
                        A4.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B4.Text != tempboard[1].ToString())
                    {
                        B4.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C4.Text != tempboard[2].ToString())
                    {
                        C4.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D4.Text != tempboard[3].ToString())
                    {
                        D4.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E4.Text != tempboard[4].ToString())
                    {
                        E4.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m2[10];
                    if (A5.Text != tempboard[0].ToString())
                    {
                        A5.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B5.Text != tempboard[1].ToString())
                    {
                        B5.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C5.Text != tempboard[2].ToString())
                    {
                        C5.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D5.Text != tempboard[3].ToString())
                    {
                        D5.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E5.Text != tempboard[4].ToString())
                    {
                        E5.Text = tempboard[4].ToString();
                        return;
                    }
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //m3
                    tempboard = m3[6];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D1.Text != tempboard[3].ToString())
                    {
                        D1.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E1.Text != tempboard[4].ToString())
                    {
                        E1.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m3[7];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D2.Text != tempboard[3].ToString())
                    {
                        D2.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E2.Text != tempboard[4].ToString())
                    {
                        E2.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m3[8];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D3.Text != tempboard[3].ToString())
                    {
                        D3.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E3.Text != tempboard[4].ToString())
                    {
                        E3.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m3[9];
                    if (A4.Text != tempboard[0].ToString())
                    {
                        A4.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B4.Text != tempboard[1].ToString())
                    {
                        B4.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C4.Text != tempboard[2].ToString())
                    {
                        C4.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D4.Text != tempboard[3].ToString())
                    {
                        D4.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E4.Text != tempboard[4].ToString())
                    {
                        E4.Text = tempboard[4].ToString();
                        return;
                    }
                    tempboard = m3[10];
                    if (A5.Text != tempboard[0].ToString())
                    {
                        A5.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B5.Text != tempboard[1].ToString())
                    {
                        B5.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C5.Text != tempboard[2].ToString())
                    {
                        C5.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D5.Text != tempboard[3].ToString())
                    {
                        D5.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E5.Text != tempboard[4].ToString())
                    {
                        E5.Text = tempboard[4].ToString();
                        return;
                    }
                }
            }

            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //h1
                    tempboard = h1[8];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D1.Text != tempboard[3].ToString())
                    {
                        D1.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E1.Text != tempboard[4].ToString())
                    {
                        E1.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F1.Text != tempboard[5].ToString())
                    {
                        F1.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G1.Text != tempboard[6].ToString())
                    {
                        G1.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h1[9];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D2.Text != tempboard[3].ToString())
                    {
                        D2.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E2.Text != tempboard[4].ToString())
                    {
                        E2.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F2.Text != tempboard[5].ToString())
                    {
                        F2.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G2.Text != tempboard[6].ToString())
                    {
                        G2.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h1[10];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D3.Text != tempboard[3].ToString())
                    {
                        D3.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E3.Text != tempboard[4].ToString())
                    {
                        E3.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F3.Text != tempboard[5].ToString())
                    {
                        F3.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G3.Text != tempboard[6].ToString())
                    {
                        G3.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h1[11];
                    if (A4.Text != tempboard[0].ToString())
                    {
                        A4.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B4.Text != tempboard[1].ToString())
                    {
                        B4.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C4.Text != tempboard[2].ToString())
                    {
                        C4.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D4.Text != tempboard[3].ToString())
                    {
                        D4.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E4.Text != tempboard[4].ToString())
                    {
                        E4.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F4.Text != tempboard[5].ToString())
                    {
                        F4.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G4.Text != tempboard[6].ToString())
                    {
                        G4.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h1[12];
                    if (A5.Text != tempboard[0].ToString())
                    {
                        A5.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B5.Text != tempboard[1].ToString())
                    {
                        B5.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C5.Text != tempboard[2].ToString())
                    {
                        C5.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D5.Text != tempboard[3].ToString())
                    {
                        D5.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E5.Text != tempboard[4].ToString())
                    {
                        E5.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F5.Text != tempboard[5].ToString())
                    {
                        F5.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G5.Text != tempboard[6].ToString())
                    {
                        G5.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h1[13];
                    if (A6.Text != tempboard[0].ToString())
                    {
                        A6.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B6.Text != tempboard[1].ToString())
                    {
                        B6.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C6.Text != tempboard[2].ToString())
                    {
                        C6.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D6.Text != tempboard[3].ToString())
                    {
                        D6.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E6.Text != tempboard[4].ToString())
                    {
                        E6.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F6.Text != tempboard[5].ToString())
                    {
                        F6.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G6.Text != tempboard[6].ToString())
                    {
                        G6.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h1[14];
                    if (A7.Text != tempboard[0].ToString())
                    {
                        A7.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B7.Text != tempboard[1].ToString())
                    {
                        B7.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C7.Text != tempboard[2].ToString())
                    {
                        C7.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D7.Text != tempboard[3].ToString())
                    {
                        D7.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E7.Text != tempboard[4].ToString())
                    {
                        E7.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F7.Text != tempboard[5].ToString())
                    {
                        F7.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G7.Text != tempboard[6].ToString())
                    {
                        G7.Text = tempboard[6].ToString();
                        return;
                    }

                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //h2
                    tempboard = h2[8];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D1.Text != tempboard[3].ToString())
                    {
                        D1.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E1.Text != tempboard[4].ToString())
                    {
                        E1.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F1.Text != tempboard[5].ToString())
                    {
                        F1.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G1.Text != tempboard[6].ToString())
                    {
                        G1.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h2[9];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D2.Text != tempboard[3].ToString())
                    {
                        D2.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E2.Text != tempboard[4].ToString())
                    {
                        E2.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F2.Text != tempboard[5].ToString())
                    {
                        F2.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G2.Text != tempboard[6].ToString())
                    {
                        G2.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h2[10];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D3.Text != tempboard[3].ToString())
                    {
                        D3.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E3.Text != tempboard[4].ToString())
                    {
                        E3.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F3.Text != tempboard[5].ToString())
                    {
                        F3.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G3.Text != tempboard[6].ToString())
                    {
                        G3.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h2[11];
                    if (A4.Text != tempboard[0].ToString())
                    {
                        A4.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B4.Text != tempboard[1].ToString())
                    {
                        B4.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C4.Text != tempboard[2].ToString())
                    {
                        C4.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D4.Text != tempboard[3].ToString())
                    {
                        D4.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E4.Text != tempboard[4].ToString())
                    {
                        E4.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F4.Text != tempboard[5].ToString())
                    {
                        F4.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G4.Text != tempboard[6].ToString())
                    {
                        G4.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h2[12];
                    if (A5.Text != tempboard[0].ToString())
                    {
                        A5.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B5.Text != tempboard[1].ToString())
                    {
                        B5.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C5.Text != tempboard[2].ToString())
                    {
                        C5.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D5.Text != tempboard[3].ToString())
                    {
                        D5.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E5.Text != tempboard[4].ToString())
                    {
                        E5.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F5.Text != tempboard[5].ToString())
                    {
                        F5.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G5.Text != tempboard[6].ToString())
                    {
                        G5.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h2[13];
                    if (A6.Text != tempboard[0].ToString())
                    {
                        A6.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B6.Text != tempboard[1].ToString())
                    {
                        B6.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C6.Text != tempboard[2].ToString())
                    {
                        C6.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D6.Text != tempboard[3].ToString())
                    {
                        D6.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E6.Text != tempboard[4].ToString())
                    {
                        E6.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F6.Text != tempboard[5].ToString())
                    {
                        F6.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G6.Text != tempboard[6].ToString())
                    {
                        G6.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h2[14];
                    if (A7.Text != tempboard[0].ToString())
                    {
                        A7.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B7.Text != tempboard[1].ToString())
                    {
                        B7.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C7.Text != tempboard[2].ToString())
                    {
                        C7.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D7.Text != tempboard[3].ToString())
                    {
                        D7.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E7.Text != tempboard[4].ToString())
                    {
                        E7.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F7.Text != tempboard[5].ToString())
                    {
                        F7.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G7.Text != tempboard[6].ToString())
                    {
                        G7.Text = tempboard[6].ToString();
                        return;
                    }
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //h3
                    tempboard = h3[8];
                    if (A1.Text != tempboard[0].ToString())
                    {
                        A1.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B1.Text != tempboard[1].ToString())
                    {
                        B1.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C1.Text != tempboard[2].ToString())
                    {
                        C1.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D1.Text != tempboard[3].ToString())
                    {
                        D1.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E1.Text != tempboard[4].ToString())
                    {
                        E1.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F1.Text != tempboard[5].ToString())
                    {
                        F1.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G1.Text != tempboard[6].ToString())
                    {
                        G1.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h3[9];
                    if (A2.Text != tempboard[0].ToString())
                    {
                        A2.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B2.Text != tempboard[1].ToString())
                    {
                        B2.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C2.Text != tempboard[2].ToString())
                    {
                        C2.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D2.Text != tempboard[3].ToString())
                    {
                        D2.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E2.Text != tempboard[4].ToString())
                    {
                        E2.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F2.Text != tempboard[5].ToString())
                    {
                        F2.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G2.Text != tempboard[6].ToString())
                    {
                        G2.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h3[10];
                    if (A3.Text != tempboard[0].ToString())
                    {
                        A3.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B3.Text != tempboard[1].ToString())
                    {
                        B3.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C3.Text != tempboard[2].ToString())
                    {
                        C3.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D3.Text != tempboard[3].ToString())
                    {
                        D3.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E3.Text != tempboard[4].ToString())
                    {
                        E3.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F3.Text != tempboard[5].ToString())
                    {
                        F3.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G3.Text != tempboard[6].ToString())
                    {
                        G3.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h3[11];
                    if (A4.Text != tempboard[0].ToString())
                    {
                        A4.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B4.Text != tempboard[1].ToString())
                    {
                        B4.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C4.Text != tempboard[2].ToString())
                    {
                        C4.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D4.Text != tempboard[3].ToString())
                    {
                        D4.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E4.Text != tempboard[4].ToString())
                    {
                        E4.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F4.Text != tempboard[5].ToString())
                    {
                        F4.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G4.Text != tempboard[6].ToString())
                    {
                        G4.Text = tempboard[6].ToString();
                        return;
                    }





                    tempboard = h3[12];
                    if (A5.Text != tempboard[0].ToString())
                    {
                        A5.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B5.Text != tempboard[1].ToString())
                    {
                        B5.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C5.Text != tempboard[2].ToString())
                    {
                        C5.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D5.Text != tempboard[3].ToString())
                    {
                        D5.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E5.Text != tempboard[4].ToString())
                    {
                        E5.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F5.Text != tempboard[5].ToString())
                    {
                        F5.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G5.Text != tempboard[6].ToString())
                    {
                        G5.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h3[13];
                    if (A6.Text != tempboard[0].ToString())
                    {
                        A6.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B6.Text != tempboard[1].ToString())
                    {
                        B6.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C6.Text != tempboard[2].ToString())
                    {
                        C6.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D6.Text != tempboard[3].ToString())
                    {
                        D6.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E6.Text != tempboard[4].ToString())
                    {
                        E6.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F6.Text != tempboard[5].ToString())
                    {
                        F6.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G6.Text != tempboard[6].ToString())
                    {
                        G6.Text = tempboard[6].ToString();
                        return;
                    }

                    tempboard = h3[14];
                    if (A7.Text != tempboard[0].ToString())
                    {
                        A7.Text = tempboard[0].ToString();
                        return;
                    }
                    if (B7.Text != tempboard[1].ToString())
                    {
                        B7.Text = tempboard[1].ToString();
                        return;
                    }
                    if (C7.Text != tempboard[2].ToString())
                    {
                        C7.Text = tempboard[2].ToString();
                        return;
                    }
                    if (D7.Text != tempboard[3].ToString())
                    {
                        D7.Text = tempboard[3].ToString();
                        return;
                    }
                    if (E7.Text != tempboard[4].ToString())
                    {
                        E7.Text = tempboard[4].ToString();
                        return;
                    }
                    if (F7.Text != tempboard[5].ToString())
                    {
                        F7.Text = tempboard[5].ToString();
                        return;
                    }
                    if (G7.Text != tempboard[6].ToString())
                    {
                        G7.Text = tempboard[6].ToString();
                        return;
                    }

                }
            }
        }
        //Used to fill the puzzle select when the Diff is changed
        private void Diff_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Puzzle_Select_Combo.Items.Clear();
            if (Diff_combobox.SelectedIndex == 0)
            {
                Puzzle_Select_Combo.Items.Clear();
                Puzzle_Select_Combo.Items.Add("E1");
                Puzzle_Select_Combo.Items.Add("E2");
                Puzzle_Select_Combo.Items.Add("E3");
                Puzzle_Select_Combo.SelectedIndex = 0;
            }
            else if (Diff_combobox.SelectedIndex == 1)
            {
                Puzzle_Select_Combo.Items.Clear();
                Puzzle_Select_Combo.Items.Add("M1");
                Puzzle_Select_Combo.Items.Add("M2");
                Puzzle_Select_Combo.Items.Add("M3");
                Puzzle_Select_Combo.SelectedIndex = 0;
            }
            else if (Diff_combobox.SelectedIndex == 2)
            {
                Puzzle_Select_Combo.Items.Clear();
                Puzzle_Select_Combo.Items.Add("H1");
                Puzzle_Select_Combo.Items.Add("H2");
                Puzzle_Select_Combo.Items.Add("H3");
                Puzzle_Select_Combo.SelectedIndex = 0;
            }
        }
        //used to change board and resize when the diff is changed
        private void Puzzle_Select_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;


            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;

            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;

            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
            {
                //Keeps the program from crashing
                if (onstart == false)
                {
                
                    onstart = true;
                    return;
                }
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;

            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;
            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;
            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;
            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;
            }
            else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
            {
                BoardResize(sender, e);
                BoardFill(sender, e);
                timesetting();
                cheater = false;
            }

        }


        //Used check row sum
        private void A1_TextChanged(object sender, EventArgs e)
        {
            //used to help check correct sum
            string helper;
            int correct = 0;
            int checker;
            //easy
            if (Diff_combobox.SelectedIndex == 0)
            {
                try
                {

                    //row 1
                    //get sum of user inputs
                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(B1.Text) + Convert.ToInt32(C1.Text);
                    //if user is on easy puzzle one
                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        //then get the correct sum
                        helper = e1[4].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[4].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[4].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    //then check if the sums match
                    if (checker == correct)
                    {
                        //checks the checkbox for the row and changes it to green
                        Row1_Checkbox.Checked = true;
                        Row1_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        //else uncheck and set to red
                        Row1_Checkbox.Checked = false;
                        Row1_Checkbox.BackColor = Color.Red;
                    }
                    //repeat
                    //row 2
                    correct = 0;
                    checker = Convert.ToInt32(A2.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C2.Text);


                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[5].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[5].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[5].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row2_Checkbox.Checked = true;
                        Row2_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row2_Checkbox.Checked = false;
                        Row2_Checkbox.BackColor = Color.Red;
                    }
                    // Row 3
                    correct = 0;
                    checker = Convert.ToInt32(A3.Text) + Convert.ToInt32(B3.Text) + Convert.ToInt32(C3.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[6].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[6].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[6].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row3_Checkbox.Checked = true;
                        Row3_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row3_Checkbox.Checked = false;
                        Row3_Checkbox.BackColor = Color.Red;
                    }
                    //row A
                    correct = 0;
                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(A2.Text) + Convert.ToInt32(A3.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[4].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e1[5].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e1[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[4].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e2[5].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e2[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[4].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e3[5].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e3[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    //MessageBox.Show(correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowA_Checkbox.Checked = true;
                        RowA_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowA_Checkbox.Checked = false;
                        RowA_Checkbox.BackColor = Color.Red;
                    }
                    //row B
                    checker = Convert.ToInt32(B1.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(B3.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[4].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e1[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e1[6].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[4].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e2[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e2[6].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[4].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e3[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e3[6].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowB_Checkbox.Checked = true;
                        RowB_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowB_Checkbox.Checked = false;
                        RowB_Checkbox.BackColor = Color.Red;
                    }
                    // C
                    checker = Convert.ToInt32(C1.Text) + Convert.ToInt32(C2.Text) + Convert.ToInt32(C3.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[4].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e1[5].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e1[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[4].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e2[5].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e2[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[4].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e3[5].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e3[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowC_Checkbox.Checked = true;
                        RowC_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowC_Checkbox.Checked = false;
                        RowC_Checkbox.BackColor = Color.Red;
                    }

                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C3.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[4].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e1[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e1[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[4].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e2[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e2[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[4].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = e3[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e3[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Negative_Checkbox.Checked = true;
                        Negative_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Negative_Checkbox.Checked = false;
                        Negative_Checkbox.BackColor = Color.Red;
                    }

                    checker = Convert.ToInt32(A3.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C1.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
                    {
                        helper = e1[4].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e1[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e1[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
                    {
                        helper = e2[4].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e2[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e2[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
                    {
                        helper = e3[4].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = e3[5].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = e3[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Positive_Checkbox.Checked = true;
                        Positive_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Positive_Checkbox.Checked = false;
                        Positive_Checkbox.BackColor = Color.Red;
                    }
                }
                catch
                {
                    return;
                }
            }
            //normal
            if (Diff_combobox.SelectedIndex == 1)
            {
                try
                {

                    //row 1
                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(B1.Text) + Convert.ToInt32(C1.Text) + Convert.ToInt32(D1.Text) + Convert.ToInt32(E1.Text);
                    //MessageBox.Show(e1[4].ToString());
                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    //MessageBox.Show(checker.ToString() + " " + correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row1_Checkbox.Checked = true;
                        Row1_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row1_Checkbox.Checked = false;
                        Row1_Checkbox.BackColor = Color.Red;
                    }
                    //row 2
                    correct = 0;
                    checker = Convert.ToInt32(A2.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C2.Text) + Convert.ToInt32(D2.Text) + Convert.ToInt32(E2.Text);


                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[7].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[7].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[7].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    //MessageBox.Show(checker.ToString() + " " + correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row2_Checkbox.Checked = true;
                        Row2_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row2_Checkbox.Checked = false;
                        Row2_Checkbox.BackColor = Color.Red;
                    }
                    // Row 3
                    correct = 0;
                    checker = Convert.ToInt32(A3.Text) + Convert.ToInt32(B3.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(D3.Text) + Convert.ToInt32(E3.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[8].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[8].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[8].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row3_Checkbox.Checked = true;
                        Row3_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row3_Checkbox.Checked = false;
                        Row3_Checkbox.BackColor = Color.Red;
                    }
                    // Row 4
                    correct = 0;
                    checker = Convert.ToInt32(A4.Text) + Convert.ToInt32(B4.Text) + Convert.ToInt32(C4.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(E4.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[9].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[9].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[9].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row4_Checkbox.Checked = true;
                        Row4_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row4_Checkbox.Checked = false;
                        Row4_Checkbox.BackColor = Color.Red;
                    }
                    // Row 5
                    correct = 0;
                    checker = Convert.ToInt32(A5.Text) + Convert.ToInt32(B5.Text) + Convert.ToInt32(C5.Text) + Convert.ToInt32(D5.Text) + Convert.ToInt32(E5.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[10].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[10].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[10].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row5_Checkbox.Checked = true;
                        Row5_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row5_Checkbox.Checked = false;
                        Row5_Checkbox.BackColor = Color.Red;
                    }
                    //row A
                    correct = 0;
                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(A2.Text) + Convert.ToInt32(A3.Text) + Convert.ToInt32(A4.Text) + Convert.ToInt32(A5.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    //MessageBox.Show(correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowA_Checkbox.Checked = true;
                        RowA_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowA_Checkbox.Checked = false;
                        RowA_Checkbox.BackColor = Color.Red;
                    }
                    //row B
                    checker = Convert.ToInt32(B1.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(B3.Text) + Convert.ToInt32(B4.Text) + Convert.ToInt32(B5.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowB_Checkbox.Checked = true;
                        RowB_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowB_Checkbox.Checked = false;
                        RowB_Checkbox.BackColor = Color.Red;
                    }
                    // C
                    checker = Convert.ToInt32(C1.Text) + Convert.ToInt32(C2.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(C4.Text) + Convert.ToInt32(C5.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowC_Checkbox.Checked = true;
                        RowC_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowC_Checkbox.Checked = false;
                        RowC_Checkbox.BackColor = Color.Red;
                    }
                    //row D
                    checker = Convert.ToInt32(D1.Text) + Convert.ToInt32(D2.Text) + Convert.ToInt32(D3.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(D5.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowD_Checkbox.Checked = true;
                        RowD_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowD_Checkbox.Checked = false;
                        RowD_Checkbox.BackColor = Color.Red;
                    }
                    //row E
                    checker = Convert.ToInt32(E1.Text) + Convert.ToInt32(E2.Text) + Convert.ToInt32(E3.Text) + Convert.ToInt32(E4.Text) + Convert.ToInt32(E5.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowE_Checkbox.Checked = true;
                        RowE_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowE_Checkbox.Checked = false;
                        RowE_Checkbox.BackColor = Color.Red;
                    }

                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(E5.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Negative_Checkbox.Checked = true;
                        Negative_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Negative_Checkbox.Checked = false;
                        Negative_Checkbox.BackColor = Color.Red;
                    }

                    checker = Convert.ToInt32(A5.Text) + Convert.ToInt32(B4.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(D2.Text) + Convert.ToInt32(E1.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
                    {
                        helper = m1[6].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m1[7].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m1[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m1[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m1[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
                    {
                        helper = m2[6].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m2[7].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m2[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m2[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m2[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
                    {
                        helper = m3[6].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = m3[7].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = m3[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = m3[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = m3[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Positive_Checkbox.Checked = true;
                        Positive_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Positive_Checkbox.Checked = false;
                        Positive_Checkbox.BackColor = Color.Red;
                    }
                }
                catch
                {
                    return;
                }
            }
            //hard
            if (Diff_combobox.SelectedIndex == 2)
            {
                try
                {

                    //row 1
                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(B1.Text) + Convert.ToInt32(C1.Text) + Convert.ToInt32(D1.Text) + Convert.ToInt32(E1.Text) + Convert.ToInt32(F1.Text) + Convert.ToInt32(G1.Text);
                    //MessageBox.Show(e1[4].ToString());
                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    //MessageBox.Show(checker.ToString() + " " + correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row1_Checkbox.Checked = true;
                        Row1_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row1_Checkbox.Checked = false;
                        Row1_Checkbox.BackColor = Color.Red;
                    }
                    //row 2
                    correct = 0;
                    checker = Convert.ToInt32(A2.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C2.Text) + Convert.ToInt32(D2.Text) + Convert.ToInt32(E2.Text) + Convert.ToInt32(F2.Text) + Convert.ToInt32(G2.Text);


                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[9].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[9].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[9].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    //MessageBox.Show(checker.ToString() + " " + correct.ToString());

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row2_Checkbox.Checked = true;
                        Row2_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row2_Checkbox.Checked = false;
                        Row2_Checkbox.BackColor = Color.Red;
                    }
                    // Row 3
                    correct = 0;
                    checker = Convert.ToInt32(A3.Text) + Convert.ToInt32(B3.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(D3.Text) + Convert.ToInt32(E3.Text) + Convert.ToInt32(F3.Text) + Convert.ToInt32(G3.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[10].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[10].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[10].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row3_Checkbox.Checked = true;
                        Row3_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row3_Checkbox.Checked = false;
                        Row3_Checkbox.BackColor = Color.Red;
                    }
                    // Row 4
                    correct = 0;
                    checker = Convert.ToInt32(A4.Text) + Convert.ToInt32(B4.Text) + Convert.ToInt32(C4.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(E4.Text) + Convert.ToInt32(F4.Text) + Convert.ToInt32(G4.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[11].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[11].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[11].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row4_Checkbox.Checked = true;
                        Row4_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row4_Checkbox.Checked = false;
                        Row4_Checkbox.BackColor = Color.Red;
                    }
                    // Row 5
                    correct = 0;
                    checker = Convert.ToInt32(A5.Text) + Convert.ToInt32(B5.Text) + Convert.ToInt32(C5.Text) + Convert.ToInt32(D5.Text) + Convert.ToInt32(E5.Text) + Convert.ToInt32(F5.Text) + Convert.ToInt32(G5.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[12].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[12].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[12].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row5_Checkbox.Checked = true;
                        Row5_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row5_Checkbox.Checked = false;
                        Row5_Checkbox.BackColor = Color.Red;
                    }
                    // Row 6
                    correct = 0;
                    checker = Convert.ToInt32(A6.Text) + Convert.ToInt32(B6.Text) + Convert.ToInt32(C6.Text) + Convert.ToInt32(D6.Text) + Convert.ToInt32(E6.Text) + Convert.ToInt32(F6.Text) + Convert.ToInt32(G6.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[13].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[13].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[13].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row6_Checkbox.Checked = true;
                        Row6_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row6_Checkbox.Checked = false;
                        Row6_Checkbox.BackColor = Color.Red;
                    }
                    // Row 7
                    correct = 0;
                    checker = Convert.ToInt32(A7.Text) + Convert.ToInt32(B7.Text) + Convert.ToInt32(C7.Text) + Convert.ToInt32(D7.Text) + Convert.ToInt32(E7.Text) + Convert.ToInt32(F7.Text) + Convert.ToInt32(G7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[14].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[14].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[14].ToString();
                        correct = Convert.ToInt32(helper[0].ToString()) + Convert.ToInt32(helper[1].ToString()) + Convert.ToInt32(helper[2].ToString()) + Convert.ToInt32(helper[3].ToString()) + Convert.ToInt32(helper[4].ToString()) + Convert.ToInt32(helper[5].ToString()) + Convert.ToInt32(helper[6].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Row7_Checkbox.Checked = true;
                        Row7_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Row7_Checkbox.Checked = false;
                        Row7_Checkbox.BackColor = Color.Red;
                    }
                    //row A
                    correct = 0;
                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(A2.Text) + Convert.ToInt32(A3.Text) + Convert.ToInt32(A4.Text) + Convert.ToInt32(A5.Text) + Convert.ToInt32(A6.Text) + Convert.ToInt32(A7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    //MessageBox.Show(correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowA_Checkbox.Checked = true;
                        RowA_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowA_Checkbox.Checked = false;
                        RowA_Checkbox.BackColor = Color.Red;
                    }
                    //row B
                    correct = 0;
                    checker = Convert.ToInt32(B1.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(B3.Text) + Convert.ToInt32(B4.Text) + Convert.ToInt32(B5.Text) + Convert.ToInt32(B6.Text) + Convert.ToInt32(B7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                    }

                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowB_Checkbox.Checked = true;
                        RowB_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowB_Checkbox.Checked = false;
                        RowB_Checkbox.BackColor = Color.Red;
                    }
                    // C
                    correct = 0;
                    checker = Convert.ToInt32(C1.Text) + Convert.ToInt32(C2.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(C4.Text) + Convert.ToInt32(C5.Text) + Convert.ToInt32(C6.Text) + Convert.ToInt32(C7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowC_Checkbox.Checked = true;
                        RowC_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowC_Checkbox.Checked = false;
                        RowC_Checkbox.BackColor = Color.Red;
                    }
                    //row D
                    correct = 0;
                    checker = Convert.ToInt32(D1.Text) + Convert.ToInt32(D2.Text) + Convert.ToInt32(D3.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(D5.Text) + Convert.ToInt32(D6.Text) + Convert.ToInt32(D7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowD_Checkbox.Checked = true;
                        RowD_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowD_Checkbox.Checked = false;
                        RowD_Checkbox.BackColor = Color.Red;
                    }
                    //row E
                    correct = 0;
                    checker = Convert.ToInt32(E1.Text) + Convert.ToInt32(E2.Text) + Convert.ToInt32(E3.Text) + Convert.ToInt32(E4.Text) + Convert.ToInt32(E5.Text) + Convert.ToInt32(E6.Text) + Convert.ToInt32(E7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowE_Checkbox.Checked = true;
                        RowE_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowE_Checkbox.Checked = false;
                        RowE_Checkbox.BackColor = Color.Red;
                    }
                    //row F
                    correct = 0;
                    checker = Convert.ToInt32(F1.Text) + Convert.ToInt32(F2.Text) + Convert.ToInt32(F3.Text) + Convert.ToInt32(F4.Text) + Convert.ToInt32(F5.Text) + Convert.ToInt32(F6.Text) + Convert.ToInt32(F7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowF_Checkbox.Checked = true;
                        RowF_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowF_Checkbox.Checked = false;
                        RowF_Checkbox.BackColor = Color.Red;
                    }
                    //row G
                    correct = 0;
                    checker = Convert.ToInt32(G1.Text) + Convert.ToInt32(G2.Text) + Convert.ToInt32(G3.Text) + Convert.ToInt32(G4.Text) + Convert.ToInt32(G5.Text) + Convert.ToInt32(G6.Text) + Convert.ToInt32(G7.Text);

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                    }
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        RowG_Checkbox.Checked = true;
                        RowG_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        RowG_Checkbox.Checked = false;
                        RowG_Checkbox.BackColor = Color.Red;
                    }

                    checker = Convert.ToInt32(A1.Text) + Convert.ToInt32(B2.Text) + Convert.ToInt32(C3.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(E5.Text) + Convert.ToInt32(F6.Text) + Convert.ToInt32(G7.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());

                    }
                    //MessageBox.Show(checker.ToString() + " " + correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Negative_Checkbox.Checked = true;
                        Negative_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Negative_Checkbox.Checked = false;
                        Negative_Checkbox.BackColor = Color.Red;
                    }

                    checker = Convert.ToInt32(A7.Text) + Convert.ToInt32(B6.Text) + Convert.ToInt32(C5.Text) + Convert.ToInt32(D4.Text) + Convert.ToInt32(E3.Text) + Convert.ToInt32(F2.Text) + Convert.ToInt32(G1.Text);
                    correct = 0;

                    if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
                    {
                        helper = h1[8].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h1[9].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h1[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h1[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h1[12].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h1[13].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h1[14].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
                    {
                        helper = h2[8].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h2[9].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h2[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h2[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h2[12].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h2[13].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h2[14].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    else if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
                    {
                        helper = h3[8].ToString();
                        correct += Convert.ToInt32(helper[6].ToString());
                        helper = h3[9].ToString();
                        correct += Convert.ToInt32(helper[5].ToString());
                        helper = h3[10].ToString();
                        correct += Convert.ToInt32(helper[4].ToString());
                        helper = h3[11].ToString();
                        correct += Convert.ToInt32(helper[3].ToString());
                        helper = h3[12].ToString();
                        correct += Convert.ToInt32(helper[2].ToString());
                        helper = h3[13].ToString();
                        correct += Convert.ToInt32(helper[1].ToString());
                        helper = h3[14].ToString();
                        correct += Convert.ToInt32(helper[0].ToString());
                    }
                    // MessageBox.Show(checker.ToString() + " " + correct.ToString());
                    if (checker == correct)
                    {
                        //MessageBox.Show("Nice");
                        Positive_Checkbox.Checked = true;
                        Positive_Checkbox.BackColor = Color.Green;
                    }
                    else
                    {
                        Positive_Checkbox.Checked = false;
                        Positive_Checkbox.BackColor = Color.Red;
                    }
                }
                catch
                {
                    return;
                }
            }
            //Used to check when puzzle is completed
            int count = 0;
            //easy
            if (Diff_combobox.SelectedIndex == 0)
            {
                if (Row1_Checkbox.Checked == true)
                    count++;
                if (Row2_Checkbox.Checked == true)
                    count++;
                if (Row3_Checkbox.Checked == true)
                    count++;
                if (RowA_Checkbox.Checked == true)
                    count++;
                if (RowB_Checkbox.Checked == true)
                    count++;
                if (RowC_Checkbox.Checked == true)
                    count++;
                if (Negative_Checkbox.Checked == true)
                    count++;
                if (Positive_Checkbox.Checked == true)
                    count++;


                if (count == 8)
                {
                    MessageBox.Show("Puzzle Completed Good Job!");
                    timer1.Stop();
                    timesave();
                }


            }
            //normal
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Row1_Checkbox.Checked == true)
                    count++;
                if (Row2_Checkbox.Checked == true)
                    count++;
                if (Row3_Checkbox.Checked == true)
                    count++;
                if (Row4_Checkbox.Checked == true)
                    count++;
                if (Row5_Checkbox.Checked == true)
                    count++;

                if (RowA_Checkbox.Checked == true)
                    count++;
                if (RowB_Checkbox.Checked == true)
                    count++;
                if (RowC_Checkbox.Checked == true)
                    count++;
                if (RowD_Checkbox.Checked == true)
                    count++;
                if (RowE_Checkbox.Checked == true)
                    count++;

                if (Negative_Checkbox.Checked == true)
                    count++;
                if (Positive_Checkbox.Checked == true)
                    count++;


                if (count == 12)
                {
                    MessageBox.Show("Puzzle Completed Good Job!");
                    timer1.Stop();
                    timesave();
                }


            }
            //hard
            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Row1_Checkbox.Checked == true)
                    count++;
                if (Row2_Checkbox.Checked == true)
                    count++;
                if (Row3_Checkbox.Checked == true)
                    count++;
                if (Row4_Checkbox.Checked == true)
                    count++;
                if (Row5_Checkbox.Checked == true)
                    count++;
                if (Row6_Checkbox.Checked == true)
                    count++;
                if (Row7_Checkbox.Checked == true)
                    count++;

                if (RowA_Checkbox.Checked == true)
                    count++;
                if (RowB_Checkbox.Checked == true)
                    count++;
                if (RowC_Checkbox.Checked == true)
                    count++;
                if (RowD_Checkbox.Checked == true)
                    count++;
                if (RowE_Checkbox.Checked == true)
                    count++;
                if (RowF_Checkbox.Checked == true)
                    count++;
                if (RowG_Checkbox.Checked == true)
                    count++;

                if (Negative_Checkbox.Checked == true)
                    count++;
                if (Positive_Checkbox.Checked == true)
                    count++;

                if (count == 16)
                {
                    MessageBox.Show("Puzzle Completed Good Job!");
                    timer1.Stop();
                    timesave();

                }


            }


        }
        //Resets board and timer
        private void Reset_button_Click(object sender, EventArgs e)
        {
            //reset board
            BoardFill(sender, e);
            //reset timer to 0
            i = 0;
            TimeSpan time = TimeSpan.FromSeconds(i);
            Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
            cheater = false;

        }
        //Tells the user how many rows they have completed
        private void Progres_button_Click(object sender, EventArgs e)
        {
            int count = 0;
            //checks if timer has even started
            if (timer1.Enabled == false)
            {
                MessageBox.Show("Push Start to begin!");
                return;
            }
            //easy
            if (Diff_combobox.SelectedIndex == 0)
            {
                if (Row1_Checkbox.Checked == true)
                    count++;
                if (Row2_Checkbox.Checked == true)
                    count++;
                if (Row3_Checkbox.Checked == true)
                    count++;
                if (RowA_Checkbox.Checked == true)
                    count++;
                if (RowB_Checkbox.Checked == true)
                    count++;
                if (RowC_Checkbox.Checked == true)
                    count++;
                if (Negative_Checkbox.Checked == true)
                    count++;
                if (Positive_Checkbox.Checked == true)
                    count++;

                if (count == 0)
                {
                    MessageBox.Show("0 rows correct. Time is ticking!");
                }
                else if (count == 8)
                {
                    MessageBox.Show("Puzzle Completed Good Job!");
                }
                else
                {
                    MessageBox.Show(count.ToString() + " rows correct out of 8. Keep it up!");
                }

            }
            //normal
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Row1_Checkbox.Checked == true)
                    count++;
                if (Row2_Checkbox.Checked == true)
                    count++;
                if (Row3_Checkbox.Checked == true)
                    count++;
                if (Row4_Checkbox.Checked == true)
                    count++;
                if (Row5_Checkbox.Checked == true)
                    count++;

                if (RowA_Checkbox.Checked == true)
                    count++;
                if (RowB_Checkbox.Checked == true)
                    count++;
                if (RowC_Checkbox.Checked == true)
                    count++;
                if (RowD_Checkbox.Checked == true)
                    count++;
                if (RowE_Checkbox.Checked == true)
                    count++;

                if (Negative_Checkbox.Checked == true)
                    count++;
                if (Positive_Checkbox.Checked == true)
                    count++;

                if (count == 0)
                {
                    MessageBox.Show("0 rows correct. Time is ticking!");
                }
                else if (count == 12)
                {
                    MessageBox.Show("Puzzle Completed Good Job!");
                }
                else
                {
                    MessageBox.Show(count.ToString() + " rows correct out of 12. Keep it up!");
                }

            }
            //hard
            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Row1_Checkbox.Checked == true)
                    count++;
                if (Row2_Checkbox.Checked == true)
                    count++;
                if (Row3_Checkbox.Checked == true)
                    count++;
                if (Row4_Checkbox.Checked == true)
                    count++;
                if (Row5_Checkbox.Checked == true)
                    count++;
                if (Row6_Checkbox.Checked == true)
                    count++;
                if (Row7_Checkbox.Checked == true)
                    count++;

                if (RowA_Checkbox.Checked == true)
                    count++;
                if (RowB_Checkbox.Checked == true)
                    count++;
                if (RowC_Checkbox.Checked == true)
                    count++;
                if (RowD_Checkbox.Checked == true)
                    count++;
                if (RowE_Checkbox.Checked == true)
                    count++;
                if (RowF_Checkbox.Checked == true)
                    count++;
                if (RowG_Checkbox.Checked == true)
                    count++;

                if (Negative_Checkbox.Checked == true)
                    count++;
                if (Positive_Checkbox.Checked == true)
                    count++;

                if (count == 0)
                {
                    MessageBox.Show("0 rows correct. Time is ticking!");
                }
                else if (count == 16)
                {
                    MessageBox.Show("Puzzle Completed Good Job!");
                }
                else
                {
                    MessageBox.Show(count.ToString() + " rows correct out of 16. Keep it up!");
                }

            }

        }
        //timer tick
        int i = 0;
        //Timer
        private void Timer1_Tick(object sender, EventArgs e)
        {
            i++;
            TimeSpan time = TimeSpan.FromSeconds(i);
            Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
            //
        }
        //used to start and stop timer
        private void StartandPause_checkBox_Click(object sender, EventArgs e)
        {
            //Timer_Textbox.Focus();
            if (StartandPause_checkBox.Checked)
            {
                timer1.Start();
                StartandPause_checkBox.Text = "pause";
                //need to disable all text boxes
            }

            if (!StartandPause_checkBox.Checked)
            {
                timer1.Stop();
                StartandPause_checkBox.Text = "start";

            }
        }
        //Number only 
        //keeps user from enter non numbers
        private void BadKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                if (e.KeyChar != '0')
                {
                    e.Handled = true;
                }

            }

        }
        //used to save the puzzle and time
        private void Save_menuitem_Click(object sender, EventArgs e)
        {
            string puzzlesave;
            string path;
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "E1")
            {
                path = "../../../Saves/e1save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}\n{3}{4}{5}\n{6}{7}{8}\n{9}", A1.Text, B1.Text, C1.Text, A2.Text, B2.Text, C2.Text, A3.Text, B3.Text, C3.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "E2")
            {
                path = "../../../Saves/e2save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}\n{3}{4}{5}\n{6}{7}{8}\n{9}", A1.Text, B1.Text, C1.Text, A2.Text, B2.Text, C2.Text, A3.Text, B3.Text, C3.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "E3")
            {
                path = "../../../Saves/e3save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}\n{3}{4}{5}\n{6}{7}{8}\n{9}", A1.Text, B1.Text, C1.Text, A2.Text, B2.Text, C2.Text, A3.Text, B3.Text, C3.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }

            if (Puzzle_Select_Combo.SelectedItem.ToString() == "M1")
            {
                path = "../../../Saves/m1save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}{3}{4}\n{5}{6}{7}{8}{9}\n{10}{11}{12}{13}{14}\n{15}{16}{17}{18}{19}\n{20}{21}{22}{23}{24}\n{25}", A1.Text, B1.Text, C1.Text, D1.Text, E1.Text, A2.Text, B2.Text, C2.Text, D2.Text, E2.Text,
                    A3.Text, B3.Text, C3.Text, D3.Text, E3.Text, A4.Text, B4.Text, C4.Text, D4.Text, E4.Text, A5.Text, B5.Text, C5.Text, D5.Text, E5.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "M2")
            {
                path = "../../../Saves/m2save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}{3}{4}\n{5}{6}{7}{8}{9}\n{10}{11}{12}{13}{14}\n{15}{16}{17}{18}{19}\n{20}{21}{22}{23}{24}\n{25}", A1.Text, B1.Text, C1.Text, D1.Text, E1.Text, A2.Text, B2.Text, C2.Text, D2.Text, E2.Text,
                    A3.Text, B3.Text, C3.Text, D3.Text, E3.Text, A4.Text, B4.Text, C4.Text, D4.Text, E4.Text, A5.Text, B5.Text, C5.Text, D5.Text, E5.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "M3")
            {
                path = "../../../Saves/m3save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}{3}{4}\n{5}{6}{7}{8}{9}\n{10}{11}{12}{13}{14}\n{15}{16}{17}{18}{19}\n{20}{21}{22}{23}{24}\n{25}", A1.Text, B1.Text, C1.Text, D1.Text, E1.Text, A2.Text, B2.Text, C2.Text, D2.Text, E2.Text,
                    A3.Text, B3.Text, C3.Text, D3.Text, E3.Text, A4.Text, B4.Text, C4.Text, D4.Text, E4.Text, A5.Text, B5.Text, C5.Text, D5.Text, E5.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }

            if (Puzzle_Select_Combo.SelectedItem.ToString() == "H1")
            {
                path = "../../../Saves/h1save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}{3}{4}{5}{6}\n{7}{8}{9}{10}{11}{12}{13}\n{14}{15}{16}{17}{18}{19}{20}\n{21}{22}{23}{24}{25}{26}{27}\n{28}{29}{30}{31}{32}{33}{34}\n{35}{36}{37}{38}{39}{40}{41}\n{42}{43}{44}{45}{46}{47}{48}\n{49}",
                    A1.Text, B1.Text, C1.Text, D1.Text, E1.Text, F1.Text, G1.Text, A2.Text, B2.Text, C2.Text, D2.Text, E2.Text, F2.Text, G2.Text,
                    A3.Text, B3.Text, C3.Text, D3.Text, E3.Text, F3.Text, G3.Text, A4.Text, B4.Text, C4.Text, D4.Text, E4.Text, F4.Text, G4.Text,
                    A5.Text, B5.Text, C5.Text, D5.Text, E5.Text, F5.Text, G5.Text, A6.Text, B6.Text, C6.Text, D6.Text, E6.Text, F6.Text, G6.Text,
                    A7.Text, B7.Text, C7.Text, D7.Text, E7.Text, F7.Text, G7.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "H2")
            {
                path = "../../../Saves/h2save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}{3}{4}{5}{6}\n{7}{8}{9}{10}{11}{12}{13}\n{14}{15}{16}{17}{18}{19}{20}\n{21}{22}{23}{24}{25}{26}{27}\n{28}{29}{30}{31}{32}{33}{34}\n{35}{36}{37}{38}{39}{40}{41}\n{42}{43}{44}{45}{46}{47}{48}\n{49}",
                   A1.Text, B1.Text, C1.Text, D1.Text, E1.Text, F1.Text, G1.Text, A2.Text, B2.Text, C2.Text, D2.Text, E2.Text, F2.Text, G2.Text,
                   A3.Text, B3.Text, C3.Text, D3.Text, E3.Text, F3.Text, G3.Text, A4.Text, B4.Text, C4.Text, D4.Text, E4.Text, F4.Text, G4.Text,
                   A5.Text, B5.Text, C5.Text, D5.Text, E5.Text, F5.Text, G5.Text, A6.Text, B6.Text, C6.Text, D6.Text, E6.Text, F6.Text, G6.Text,
                   A7.Text, B7.Text, C7.Text, D7.Text, E7.Text, F7.Text, G7.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }
            if (Puzzle_Select_Combo.SelectedItem.ToString() == "H3")
            {
                path = "../../../Saves/h3save.txt";

                TimeSpan time = TimeSpan.FromSeconds(i);
                puzzlesave = string.Format("{0}{1}{2}{3}{4}{5}{6}\n{7}{8}{9}{10}{11}{12}{13}\n{14}{15}{16}{17}{18}{19}{20}\n{21}{22}{23}{24}{25}{26}{27}\n{28}{29}{30}{31}{32}{33}{34}\n{35}{36}{37}{38}{39}{40}{41}\n{42}{43}{44}{45}{46}{47}{48}\n{49}",
                    A1.Text, B1.Text, C1.Text, D1.Text, E1.Text, F1.Text, G1.Text, A2.Text, B2.Text, C2.Text, D2.Text, E2.Text, F2.Text, G2.Text,
                    A3.Text, B3.Text, C3.Text, D3.Text, E3.Text, F3.Text, G3.Text, A4.Text, B4.Text, C4.Text, D4.Text, E4.Text, F4.Text, G4.Text,
                    A5.Text, B5.Text, C5.Text, D5.Text, E5.Text, F5.Text, G5.Text, A6.Text, B6.Text, C6.Text, D6.Text, E6.Text, F6.Text, G6.Text,
                    A7.Text, B7.Text, C7.Text, D7.Text, E7.Text, F7.Text, G7.Text, time.TotalSeconds);
                File.WriteAllText(path, puzzlesave);
            }

        }
        //Used to load and fill puzzles with user saves
        private void Load_menuitem_Click(object sender, EventArgs e)
        {
            string tempboard;
            FileReader();

            if (Diff_combobox.SelectedIndex == 0)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //e1
                    tempboard = e1save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    tempboard = e1save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    tempboard = e1save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    i = Convert.ToInt32(e1save[3]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //e2
                    tempboard = e2save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();

                    tempboard = e2save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();

                    tempboard = e2save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    i = Convert.ToInt32(e2save[3]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");

                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //e3
                    tempboard = e3save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();

                    tempboard = e3save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();

                    tempboard = e3save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    i = Convert.ToInt32(e3save[3]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
            }
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //m1
                    tempboard = m1save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    tempboard = m1save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    tempboard = m1save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    tempboard = m1save[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    tempboard = m1save[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    i = Convert.ToInt32(m1save[5]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //m2
                    tempboard = m2save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    tempboard = m2save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    tempboard = m2save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    tempboard = m2save[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    tempboard = m2save[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    i = Convert.ToInt32(m2save[5]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //m3
                    tempboard = m3save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    tempboard = m3save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    tempboard = m3save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    tempboard = m3save[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    tempboard = m3save[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    i = Convert.ToInt32(m3save[5]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
            }
            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //h1
                    tempboard = h1save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    F1.Text = tempboard[5].ToString();
                    G1.Text = tempboard[6].ToString();

                    tempboard = h1save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    F2.Text = tempboard[5].ToString();
                    G2.Text = tempboard[6].ToString();

                    tempboard = h1save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    F3.Text = tempboard[5].ToString();
                    G3.Text = tempboard[6].ToString();

                    tempboard = h1save[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    F4.Text = tempboard[5].ToString();
                    G4.Text = tempboard[6].ToString();

                    tempboard = h1save[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    F5.Text = tempboard[5].ToString();
                    G5.Text = tempboard[6].ToString();

                    tempboard = h1save[5];
                    A6.Text = tempboard[0].ToString();
                    B6.Text = tempboard[1].ToString();
                    C6.Text = tempboard[2].ToString();
                    D6.Text = tempboard[3].ToString();
                    E6.Text = tempboard[4].ToString();
                    F6.Text = tempboard[5].ToString();
                    G6.Text = tempboard[6].ToString();

                    tempboard = h1save[6];
                    A7.Text = tempboard[0].ToString();
                    B7.Text = tempboard[1].ToString();
                    C7.Text = tempboard[2].ToString();
                    D7.Text = tempboard[3].ToString();
                    E7.Text = tempboard[4].ToString();
                    F7.Text = tempboard[5].ToString();
                    G7.Text = tempboard[6].ToString();

                    i = Convert.ToInt32(h1save[7]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");

                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    //h1
                    //h1
                    tempboard = h2save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    F1.Text = tempboard[5].ToString();
                    G1.Text = tempboard[6].ToString();

                    tempboard = h2save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    F2.Text = tempboard[5].ToString();
                    G2.Text = tempboard[6].ToString();

                    tempboard = h2save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    F3.Text = tempboard[5].ToString();
                    G3.Text = tempboard[6].ToString();

                    tempboard = h2save[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    F4.Text = tempboard[5].ToString();
                    G4.Text = tempboard[6].ToString();

                    tempboard = h2save[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    F5.Text = tempboard[5].ToString();
                    G5.Text = tempboard[6].ToString();

                    tempboard = h2save[5];
                    A6.Text = tempboard[0].ToString();
                    B6.Text = tempboard[1].ToString();
                    C6.Text = tempboard[2].ToString();
                    D6.Text = tempboard[3].ToString();
                    E6.Text = tempboard[4].ToString();
                    F6.Text = tempboard[5].ToString();
                    G6.Text = tempboard[6].ToString();

                    tempboard = h2save[6];
                    A7.Text = tempboard[0].ToString();
                    B7.Text = tempboard[1].ToString();
                    C7.Text = tempboard[2].ToString();
                    D7.Text = tempboard[3].ToString();
                    E7.Text = tempboard[4].ToString();
                    F7.Text = tempboard[5].ToString();
                    G7.Text = tempboard[6].ToString();

                    i = Convert.ToInt32(h2save[7]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    //h1

                    tempboard = h3save[0];
                    A1.Text = tempboard[0].ToString();
                    B1.Text = tempboard[1].ToString();
                    C1.Text = tempboard[2].ToString();
                    D1.Text = tempboard[3].ToString();
                    E1.Text = tempboard[4].ToString();
                    F1.Text = tempboard[5].ToString();
                    G1.Text = tempboard[6].ToString();

                    tempboard = h3save[1];
                    A2.Text = tempboard[0].ToString();
                    B2.Text = tempboard[1].ToString();
                    C2.Text = tempboard[2].ToString();
                    D2.Text = tempboard[3].ToString();
                    E2.Text = tempboard[4].ToString();
                    F2.Text = tempboard[5].ToString();
                    G2.Text = tempboard[6].ToString();

                    tempboard = h3save[2];
                    A3.Text = tempboard[0].ToString();
                    B3.Text = tempboard[1].ToString();
                    C3.Text = tempboard[2].ToString();
                    D3.Text = tempboard[3].ToString();
                    E3.Text = tempboard[4].ToString();
                    F3.Text = tempboard[5].ToString();
                    G3.Text = tempboard[6].ToString();

                    tempboard = h3save[3];
                    A4.Text = tempboard[0].ToString();
                    B4.Text = tempboard[1].ToString();
                    C4.Text = tempboard[2].ToString();
                    D4.Text = tempboard[3].ToString();
                    E4.Text = tempboard[4].ToString();
                    F4.Text = tempboard[5].ToString();
                    G4.Text = tempboard[6].ToString();

                    tempboard = h3save[4];
                    A5.Text = tempboard[0].ToString();
                    B5.Text = tempboard[1].ToString();
                    C5.Text = tempboard[2].ToString();
                    D5.Text = tempboard[3].ToString();
                    E5.Text = tempboard[4].ToString();
                    F5.Text = tempboard[5].ToString();
                    G5.Text = tempboard[6].ToString();

                    tempboard = h3save[5];
                    A6.Text = tempboard[0].ToString();
                    B6.Text = tempboard[1].ToString();
                    C6.Text = tempboard[2].ToString();
                    D6.Text = tempboard[3].ToString();
                    E6.Text = tempboard[4].ToString();
                    F6.Text = tempboard[5].ToString();
                    G6.Text = tempboard[6].ToString();

                    tempboard = h3save[6];
                    A7.Text = tempboard[0].ToString();
                    B7.Text = tempboard[1].ToString();
                    C7.Text = tempboard[2].ToString();
                    D7.Text = tempboard[3].ToString();
                    E7.Text = tempboard[4].ToString();
                    F7.Text = tempboard[5].ToString();
                    G7.Text = tempboard[6].ToString();

                    i = Convert.ToInt32(h3save[7]);
                    TimeSpan time = TimeSpan.FromSeconds(i);
                    Timer_Textbox.Text = time.ToString(@"hh\:mm\:ss");
                }
            }
        }


        private TextBox focusedControl;
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            focusedControl = (TextBox)sender;
        }

        private void A1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.Yellow;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;

            //function call to whenever a textbox is yellow be able to type into that without focus
        }

        private void A2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.Yellow;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void A3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.Yellow;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void A4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.Yellow;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void A5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.Yellow;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void A6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.Yellow;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void A7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.Yellow;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        //move to bottom
        private void Assign5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (A1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A1.Text = e.KeyChar.ToString();
            }
            if (A2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A2.Text = e.KeyChar.ToString();
            }
            if (A3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A3.Text = e.KeyChar.ToString();
            }
            if (A4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A4.Text = e.KeyChar.ToString();
            }
            if (A5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A5.Text = e.KeyChar.ToString();
            }
            if (A6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A6.Text = e.KeyChar.ToString();
            }
            if (A7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                A7.Text = e.KeyChar.ToString();
            }
            //B
            if (B1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B1.Text = e.KeyChar.ToString();
            }
            if (B2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B2.Text = e.KeyChar.ToString();
            }
            if (B3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B3.Text = e.KeyChar.ToString();
            }
            if (B4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B4.Text = e.KeyChar.ToString();
            }
            if (B5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B5.Text = e.KeyChar.ToString();
            }
            if (B6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B6.Text = e.KeyChar.ToString();
            }
            if (B7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                B7.Text = e.KeyChar.ToString();
            }
            //C
            if (C1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C1.Text = e.KeyChar.ToString();
            }
            if (C2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C2.Text = e.KeyChar.ToString();
            }
            if (C3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C3.Text = e.KeyChar.ToString();
            }
            if (C4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C4.Text = e.KeyChar.ToString();
            }
            if (C5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C5.Text = e.KeyChar.ToString();
            }
            if (C6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C6.Text = e.KeyChar.ToString();
            }
            if (C7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                C7.Text = e.KeyChar.ToString();
            }
            //D
            if (D1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D1.Text = e.KeyChar.ToString();
            }
            if (D2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D2.Text = e.KeyChar.ToString();
            }
            if (D3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D3.Text = e.KeyChar.ToString();
            }
            if (D4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D4.Text = e.KeyChar.ToString();
            }
            if (D5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D5.Text = e.KeyChar.ToString();
            }
            if (D6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D6.Text = e.KeyChar.ToString();
            }
            if (D7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                D7.Text = e.KeyChar.ToString();
            }
            //E
            if (E1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E1.Text = e.KeyChar.ToString();
            }
            if (E2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E2.Text = e.KeyChar.ToString();
            }
            if (E3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E3.Text = e.KeyChar.ToString();
            }
            if (E4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E4.Text = e.KeyChar.ToString();
            }
            if (E5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E5.Text = e.KeyChar.ToString();
            }
            if (E6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E6.Text = e.KeyChar.ToString();
            }
            if (E7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                E7.Text = e.KeyChar.ToString();
            }
            //F
            if (F1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F1.Text = e.KeyChar.ToString();
            }
            if (F2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F2.Text = e.KeyChar.ToString();
            }
            if (F3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F3.Text = e.KeyChar.ToString();
            }
            if (F4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F4.Text = e.KeyChar.ToString();
            }
            if (F5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F5.Text = e.KeyChar.ToString();
            }
            if (F6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F6.Text = e.KeyChar.ToString();
            }
            if (F7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                F7.Text = e.KeyChar.ToString();
            }
            //G
            if (G1.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G1.Text = e.KeyChar.ToString();
            }
            if (G2.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G2.Text = e.KeyChar.ToString();
            }
            if (G3.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G3.Text = e.KeyChar.ToString();
            }
            if (G4.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G4.Text = e.KeyChar.ToString();
            }
            if (G5.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G5.Text = e.KeyChar.ToString();
            }
            if (G6.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G6.Text = e.KeyChar.ToString();
            }
            if (G7.BackColor == Color.Yellow && !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                G7.Text = e.KeyChar.ToString();
            }
        }

        //B
        private void B1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.Yellow;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void B2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.Yellow;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void B3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.Yellow;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void B4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.Yellow;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void B5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.Yellow;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void B6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.Yellow;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void B7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.Yellow;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        //C
        private void C1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.Yellow;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void C2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.Yellow;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void C3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.Yellow;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void C4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.Yellow;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void C5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.Yellow;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void C6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.Yellow;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void C7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.Yellow;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        //D
        private void D1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.Yellow;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void D2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.Yellow;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void D3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.Yellow;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void D4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.Yellow;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void D5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.Yellow;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void D6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.Yellow;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void D7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.Yellow;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        //E
        private void E1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.Yellow;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void E2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.Yellow;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void E3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.Yellow;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void E4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.Yellow;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void E5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.Yellow;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void E6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.Yellow;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void E7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.Yellow;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        //F
        private void F1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.Yellow;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void F2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.Yellow;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void F3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.Yellow;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void F4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.Yellow;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void F5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.Yellow;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void F6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.Yellow;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void F7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.Yellow;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        //G
        private void G1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.Yellow;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void G2_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.Yellow;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void G3_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.Yellow;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void G4_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.Yellow;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void G5_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.Yellow;
            G6.BackColor = Color.White;
            G7.BackColor = Color.White;
        }

        private void G6_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.Yellow;
            G7.BackColor = Color.White;
        }

        private void G7_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Focus(); // 
            A1.BackColor = Color.White;
            A2.BackColor = Color.White;
            A3.BackColor = Color.White;
            A4.BackColor = Color.White;
            A5.BackColor = Color.White;
            A6.BackColor = Color.White;
            A7.BackColor = Color.White;

            B1.BackColor = Color.White;
            B2.BackColor = Color.White;
            B3.BackColor = Color.White;
            B4.BackColor = Color.White;
            B5.BackColor = Color.White;
            B6.BackColor = Color.White;
            B7.BackColor = Color.White;

            C1.BackColor = Color.White;
            C2.BackColor = Color.White;
            C3.BackColor = Color.White;
            C4.BackColor = Color.White;
            C5.BackColor = Color.White;
            C6.BackColor = Color.White;
            C7.BackColor = Color.White;

            D1.BackColor = Color.White;
            D2.BackColor = Color.White;
            D3.BackColor = Color.White;
            D4.BackColor = Color.White;
            D5.BackColor = Color.White;
            D6.BackColor = Color.White;
            D7.BackColor = Color.White;

            E1.BackColor = Color.White;
            E2.BackColor = Color.White;
            E3.BackColor = Color.White;
            E4.BackColor = Color.White;
            E5.BackColor = Color.White;
            E6.BackColor = Color.White;
            E7.BackColor = Color.White;

            F1.BackColor = Color.White;
            F2.BackColor = Color.White;
            F3.BackColor = Color.White;
            F4.BackColor = Color.White;
            F5.BackColor = Color.White;
            F6.BackColor = Color.White;
            F7.BackColor = Color.White;

            G1.BackColor = Color.White;
            G2.BackColor = Color.White;
            G3.BackColor = Color.White;
            G4.BackColor = Color.White;
            G5.BackColor = Color.White;
            G6.BackColor = Color.White;
            G7.BackColor = Color.Yellow;
        }
        int e1timeindex = 0;
        int e2timeindex = 0;
        int e3timeindex = 0;
        int m1timeindex = 0;
        int m2timeindex = 0;
        int m3timeindex = 0;
        int h1timeindex = 0;
        int h2timeindex = 0;
        int h3timeindex = 0;

        public string e1best = "00:00:00", e1avg = "00:00:00", e2best = "00:00:00", e2avg = "00:00:00", e3best = "00:00:00", e3avg = "00:00:00",
            m1best = "00:00:00", m1avg = "00:00:00", m2best = "00:00:00", m2avg = "00:00:00", m3best = "00:00:00", m3avg = "00:00:00",
            h1best = "00:00:00", h1avg = "00:00:00", h2best = "00:00:00", h2avg = "00:00:00", h3best = "00:00:00", h3avg = "00:00:00";

        //Used to store times while program runs
        public void timesave()
        {
            if(cheater == true)
            {
                MessageBox.Show("Your time cant be saved because you cheated!\n Please Restart!");
                return;
            }
            TimeSpan time = TimeSpan.FromSeconds(i);

            int sum;
            if (Diff_combobox.SelectedIndex == 0)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //sets next index of array to complete time
                    e1times[e1timeindex] = (int)time.TotalSeconds;
                    //move index
                    e1timeindex++;
                    //sort arrays
                    Array.Sort(e1times);
                    //changes to desc
                    Array.Reverse(e1times);
                    //Used to set record time to the first element of array which is the best time
                    TimeSpan besttime = TimeSpan.FromSeconds(e1times[0]);
                    //set textbox
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    //store best time
                    e1best = besttime.ToString(@"hh\:mm\:ss");
                    //calc sum of array
                    sum = e1times.Sum();
                    //get average array
                    sum = sum / e1timeindex;
                    //sets average time
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    //stores average time
                    e1avg = besttime.ToString(@"hh\:mm\:ss");
                }
                //repeat...
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    e2times[e2timeindex] = (int)time.TotalSeconds;
                    e2timeindex++;

                    Array.Sort(e2times);
                    Array.Reverse(e2times);

                    TimeSpan besttime = TimeSpan.FromSeconds(e2times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    e2best = besttime.ToString(@"hh\:mm\:ss");
                    sum = e2times.Sum();

                    sum = sum / e2timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    e2avg = besttime.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    e3times[e3timeindex] = (int)time.TotalSeconds;
                    e3timeindex++;

                    Array.Sort(e3times);
                    Array.Reverse(e3times);

                    TimeSpan besttime = TimeSpan.FromSeconds(e3times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    e3best = besttime.ToString(@"hh\:mm\:ss");

                    sum = e3times.Sum();

                    sum = sum / e3timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    e3avg = besttime.ToString(@"hh\:mm\:ss");
                }

            }
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    m1times[m1timeindex] = (int)time.TotalSeconds;
                    m1timeindex++;

                    Array.Sort(m1times);
                    Array.Reverse(m1times);

                    TimeSpan besttime = TimeSpan.FromSeconds(m1times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    m1best = besttime.ToString(@"hh\:mm\:ss");

                    sum = m1times.Sum();

                    sum = sum / m1timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    m1avg = besttime.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    m2times[m1timeindex] = (int)time.TotalSeconds;
                    m2timeindex++;

                    Array.Sort(m2times);
                    Array.Reverse(m2times);

                    TimeSpan besttime = TimeSpan.FromSeconds(m2times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    m2best = besttime.ToString(@"hh\:mm\:ss"); 
                    sum = m2times.Sum();

                    sum = sum / m2timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    m2avg = besttime.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    m3times[m3timeindex] = (int)time.TotalSeconds;
                    m3timeindex++;

                    Array.Sort(m3times);
                    Array.Reverse(m3times);

                    TimeSpan besttime = TimeSpan.FromSeconds(m3times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    m3best = besttime.ToString(@"hh\:mm\:ss");
                    sum = m3times.Sum();

                    sum = sum / m3timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    m3avg = besttime.ToString(@"hh\:mm\:ss");
                }

            }
            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    h1times[h1timeindex] = (int)time.TotalSeconds;
                    h1timeindex++;

                    Array.Sort(h1times);
                    Array.Reverse(h1times);

                    TimeSpan besttime = TimeSpan.FromSeconds(h1times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    h1best = besttime.ToString(@"hh\:mm\:ss");
                    sum = h1times.Sum();

                    sum = sum / h1timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    h1avg = besttime.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    h2times[h2timeindex] = (int)time.TotalSeconds;
                    h2timeindex++;

                    Array.Sort(h2times);
                    Array.Reverse(h2times);

                    TimeSpan besttime = TimeSpan.FromSeconds(h2times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    h2best = besttime.ToString(@"hh\:mm\:ss");

                    sum = h2times.Sum();

                    sum = sum / h2timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    h2avg = besttime.ToString(@"hh\:mm\:ss");
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    h3times[h3timeindex] = (int)time.TotalSeconds;
                    h3timeindex++;

                    Array.Sort(h3times);
                    Array.Reverse(h3times);

                    TimeSpan besttime = TimeSpan.FromSeconds(e3times[0]);
                    Record_textbox.Text = besttime.ToString(@"hh\:mm\:ss");
                    h3best = besttime.ToString(@"hh\:mm\:ss");

                    sum = h3times.Sum();

                    sum = sum / h3timeindex;
                    besttime = TimeSpan.FromSeconds(sum);
                    Average_timebox.Text = besttime.ToString(@"hh\:mm\:ss");
                    h3avg = besttime.ToString(@"hh\:mm\:ss");
                }

            }
        }
       //Used to set times when puzzle is selected
        public void timesetting()
        {
            if(Diff_combobox.SelectedIndex == 0)
            {
                if(Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    //sets best time
                    Record_textbox.Text = e1best;
                    //sets average time
                    Average_timebox.Text = e1avg;
                }
                //repeat...
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    Record_textbox.Text = e2best;
                    Average_timebox.Text = e2avg;
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    Record_textbox.Text = e3best;
                    Average_timebox.Text = e3avg;
                }
            }
            if (Diff_combobox.SelectedIndex == 1)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    Record_textbox.Text = m1best;
                    Average_timebox.Text = m1avg;
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    Record_textbox.Text = m2best;
                    Average_timebox.Text = m2avg;
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    Record_textbox.Text = m3best;
                    Average_timebox.Text = m3avg;
                }
            }
            if (Diff_combobox.SelectedIndex == 2)
            {
                if (Puzzle_Select_Combo.SelectedIndex == 0)
                {
                    Record_textbox.Text = h1best;
                    Average_timebox.Text = h1avg;
                }
                if (Puzzle_Select_Combo.SelectedIndex == 1)
                {
                    Record_textbox.Text = h2best;
                    Average_timebox.Text = h2avg;
                }
                if (Puzzle_Select_Combo.SelectedIndex == 2)
                {
                    Record_textbox.Text = h3best;
                    Average_timebox.Text = h3avg;
                }
            }
        }
        
    }

}
