/************************************************************************
   Team Blizzard
   PROGRAM:    Assign4.cs
   ASSIGNMENT: 4
   COURSE:     CSCI 473-1
   AUTHOR:     Noah Flores z1861588
   AUTHOR:     Mit Patel   z1873417
   DUE DATE:   3/18/21

   FUNCTION:  Allows the User to enter values to set equations to be graphed.
   
************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TeamBlizzard_Assignment4
{
    public partial class Assign4 : Form
    {
        private static Point one;
        private static Point two;
        private static Point Xplus;
        private static Point Xminus;
        private static Point Yplus;
        private static Point Yminus;
        private readonly List<Point> points1 = new List<Point>();
        private readonly List<Point> points2 = new List<Point>();
        private static int W;
        private static int H;



        public Assign4()
        {
            InitializeComponent();

        }


        private void Assign4_Load(object sender, EventArgs e)
        {

        }


        private void MenuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Main Page")
            {
                this.Main_Graph.Visible = false;
                this.groupBox1.Visible = true;
            }
            if (e.ClickedItem.Text == "Graph")
            {
                this.Main_Graph.Visible = true;
                this.groupBox1.Visible = false;
            }
        }


        private void Main_Graph_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            //Main_Graph.Location = new Point(0, 0);
            W = Main_Graph.Width;
            H = Main_Graph.Height;
            Graphics g = e.Graphics;
            one.X = 0;
            one.Y = 0;
            two.Y = 0;
            two.X = 0;
            //System.Diagnostics.Debug.WriteLine("the width" + W);
            //System.Diagnostics.Debug.WriteLine("the height" + H);

            //variables saved for blackbox() funtion
            int yMin = (int)yMin_numericUpDown.Value;
            int yMax = (int)yMax_numericUpDown.Value;
            int xMin = (int)xMin_numericUpDown.Value;
            int xMax = (int)xMax_numericUpDown.Value;

            Rectangle quadrant1 = new Rectangle(250, 0, 250, 250);
            Rectangle quadrant2 = new Rectangle(0, 0, 250, 250);
            Rectangle quadrant3 = new Rectangle(0, 250, 250, 250);
            Rectangle quadrant4 = new Rectangle(250, 250, 250, 250);

            using (Pen myPen = new Pen(Color.Black))
            {
                Status_Box.Clear();

                //Makes sure graph stays at 500,500
                Main_Graph.Height = 500;
                Main_Graph.Width = 500;
                //Used to create the axis on the graph
                Xminus.X = W / 2;
                Xminus.Y = H;
                Xplus.X = W / 2;
                Xplus.Y = 0;
                g.DrawLine(myPen, Xminus, Xplus);
                Yminus.X = 0;
                Yminus.Y = H / 2;
                Yplus.X = W;
                Yplus.Y = H / 2;
                g.DrawLine(myPen, Yminus, Yplus);
                if (xMin_numericUpDown.Value >= 0)
                {
                    xMin_numericUpDown.Value = 1;
                }
                if (xMax_numericUpDown.Value <= 0)
                {
                    xMax_numericUpDown.Value = -1;
                }
                if (yMin_numericUpDown.Value >= 0)
                {
                    yMin_numericUpDown.Value = 1;
                }
                if (yMax_numericUpDown.Value <= 0)
                {
                    yMax_numericUpDown.Value = -1;
                }
                blackboxes();
                //Keep the program from dividing by zero
                if (xMin_numericUpDown.Value >= 0)
                    xMin_numericUpDown.Value = -xMax_numericUpDown.Value;

                if (yMin_numericUpDown.Value >= 0)
                    yMin_numericUpDown.Value = -yMax_numericUpDown.Value;

                if (xMax_numericUpDown.Value <= 0)
                    xMax_numericUpDown.Value = -xMin_numericUpDown.Value;

                if (yMax_numericUpDown.Value <= 0)
                    yMax_numericUpDown.Value = -yMin_numericUpDown.Value;

            }
            //mX+b
            if (checkBox1.Checked == true)
            {
                try
                {
                    one.X = (int)xMin_numericUpDown.Value;
                    two.X = (int)xMax_numericUpDown.Value;
                    _ = (int)((250 / yMin_numericUpDown.Value));
                    _ = (int)((250 / yMax_numericUpDown.Value));

                    //Checks if user entered M value
                    if (Convert.ToInt32(m_TextBox.Text) == 0 && Convert.ToInt32(b1_TextBox.Text) == 0)
                    {
                        Status_Box.Text += "ERROR: Box 1 B and M cant be both zero!\t";

                    }
                    else
                    {
                        //Scales the line to fit graph
                        one.Y = (Convert.ToInt32(m_TextBox.Text) * (one.X) + Convert.ToInt32(b1_TextBox.Text));
                        two.Y = (Convert.ToInt32(m_TextBox.Text) * (two.X) + Convert.ToInt32(b1_TextBox.Text));

                        one.X = (one.X) * -(int)((250 / xMin_numericUpDown.Value)) + 250;
                        one.Y = one.Y * (int)((250 / yMin_numericUpDown.Value)) + 250;
                        two.X = two.X * (int)((250 / xMax_numericUpDown.Value)) + 250;
                        two.Y = -two.Y * (int)((250 / yMax_numericUpDown.Value)) + 250;

                    }


                    using Pen myPen = new Pen(Color.Black);
                    //Draws
                    g.DrawLine(myPen, one, two);

                    blackboxes();
                }
                catch
                {
                    //If user enters a non number
                    Status_Box.Text += "ERROR: BOX 1 Check Enter Values!\t";
                }
            }
            //ax^2+bx+c
            if (checkBox2.Checked == true)
            {
                int y;
                _ = new Point[0];
                //keeps graph from regraphing 
                using Pen myPen = new Pen(Color.Red);
                try
                {
                    //checks if a is filled
                    if (Convert.ToInt32(a1_TextBox.Text).Equals(0))
                    {
                        Status_Box.Text += "ERROR: Box 2 A must be filled!\t";
                    }
                    else
                    {
                        //calc points to be plotted
                        for (int x = (int)xMin_numericUpDown.Value; x <= xMax_numericUpDown.Value; x++)
                        {

                            int temp = x;

                            y = (int)(Convert.ToInt32(a1_TextBox.Text) * Math.Pow((x), 2) + Convert.ToInt32(b2_TextBox.Text) * (x) + Convert.ToInt32(c1_TextBox.Text));
                            if (x >= 0)
                            {
                                temp = temp * (int)((250 / xMax_numericUpDown.Value)) + 250;
                                y = y * -(int)((250 / yMax_numericUpDown.Value)) + 250;
                            }
                            else
                            {
                                temp = -temp * (int)((250 / xMin_numericUpDown.Value)) + 250;
                                y = y * (int)((250 / yMin_numericUpDown.Value)) + 250;
                            }

                            points1.Add(new Point(temp, y));


                        }
                        //Stores points from list to array
                        Point[] points = points1.ToArray();
                        //Draw
                        g.DrawCurve(myPen, points);
                        blackboxes();
                        //clear points
                        points = new Point[0];
                        points1.Clear();
                    }
                }
                catch
                {
                    //If user enters a non number
                    Status_Box.Text += "ERROR: BOX 2 Check Enter Values!\t";
                }

            }
            //ax^3+bx^2+cx+d
            if (checkBox3.Checked == true)
            {
                int y;
                _ = new Point[0];
                //keeps graph from regraphing 

                try
                {
                    //checks if a is filled
                    if (Convert.ToInt32(a2_TextBox.Text).Equals(0))
                    {
                        Status_Box.Text += "ERROR: Box 3 A must be filled!\t";
                    }
                    else
                    {
                        using Pen myPen = new Pen(Color.LightGreen);
                        for (int x = (int)xMin_numericUpDown.Value; x <= xMax_numericUpDown.Value; x++)
                        {

                            int temp = x;
                            y = (int)(Convert.ToInt32(a2_TextBox.Text) * Math.Pow((x), 3) + (int)(Convert.ToInt32(b3_TextBox.Text) * Math.Pow(x, 2) + Convert.ToInt32(c2_TextBox.Text) * (x) + Convert.ToInt32(d_TextBox.Text)));
                            if (x >= 0)
                            {
                                temp = temp * (int)((250 / xMax_numericUpDown.Value)) + 250;
                                y = y * -(int)((250 / yMax_numericUpDown.Value)) + 250;
                            }
                            else
                            {
                                temp = -temp * (int)((250 / xMin_numericUpDown.Value)) + 250;
                                y = y * (int)((250 / yMin_numericUpDown.Value)) + 250;
                            }

                            points2.Add(new Point(temp, y));

                        }


                        Point[] arraypoints2 = points2.ToArray();
                        g.DrawCurve(myPen, arraypoints2);

                        arraypoints2 = new Point[0];
                        points2.Clear();
                        blackboxes();
                    }
                }
                catch
                {
                    //If user enters a non number
                    Status_Box.Text += "ERROR: BOX 3 Check Entered Values!\t";
                }
            }
            //Circle r=x+h
            if (checkBox4.Checked == true)
            {
                try
                {
                    //checks if user enter radius
                    if (Convert.ToInt32(r_textbox.Text).Equals(0))
                    {
                        Status_Box.Text += "ERROR: BOX 4 Enter radius!\t";
                    }
                    else
                    {
                        float h = Convert.ToInt32(h_TextBox.Text);
                        float k = Convert.ToInt32(k_TextBox.Text);
                        using Pen myPen = new Pen(Color.LightBlue);
                        float r = Convert.ToInt32(r_textbox.Text);
                        h = h * (int)((250 / xMin_numericUpDown.Value)) + 250;
                        k = k * (int)((250 / yMax_numericUpDown.Value)) + 250;
                        r *= (int)((250 / xMax_numericUpDown.Value));

                        //draw
                        g.DrawCircle(myPen, k, h, r);
                        blackboxes();
                    }
                }
                catch
                {
                    //If user enters a non number
                    Status_Box.Text += "ERROR: BOX 4 Check Entered Values!\t";
                }
            }

            //shows only the part of the graph that the user wants to see
            void blackboxes()
            {
                using (Pen myPen = new Pen(Color.Black))
                {
                    int xminspace = (int)((250 / xMin_numericUpDown.Value) * xInterval_numericUpDown.Value);
                    int xmaxspace = (int)((250 / xMax_numericUpDown.Value) * xInterval_numericUpDown.Value);
                    int yminspace = (int)((250 / yMin_numericUpDown.Value) * yInterval_numericUpDown.Value);
                    int ymaxspace = (int)((250 / yMax_numericUpDown.Value) * yInterval_numericUpDown.Value);
                    //ticks start
                    Font drawFont = new Font("Arial", 5);
                    StringFormat drawFormat = new StringFormat();
                    SolidBrush drawBrush = new SolidBrush(Color.Black);
                    int temp;
                    //draw black on bottom quadrants 3 and 4 of graph
                    if (yMin >= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant3);
                        e.Graphics.FillRectangle(blackBrush, quadrant4);

                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            //xmin   
                            g.DrawLine(myPen, ((i * xminspace) + (W / 2)), ((H / 2) + 3), ((i * xminspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xminspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                            temp = (int)(i * yInterval_numericUpDown.Value);
                            //xmax
                            g.DrawLine(myPen, ((i * xmaxspace) + (W / 2)), ((H / 2) + 3), ((i * xmaxspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xmaxspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) + 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * yminspace), drawFormat);
                            }
                            //ymax
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * ymaxspace), (W / 2) + 3, (H / 2) - (i * ymaxspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * ymaxspace), drawFormat);
                            }


                        }
                    }
                    //draw black on bottom quadrants 1 and 2 of graph
                    if (yMax <= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant1);
                        e.Graphics.FillRectangle(blackBrush, quadrant2);
                        for (int i = 0; i <= 250; i++)
                        {
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            //xmin   
                            g.DrawLine(myPen, ((i * xminspace) + (W / 2)), ((H / 2) + 3), ((i * xminspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xminspace) + (W / 2), ((H / 2) + 8), drawFormat);
                            }
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            //xmax
                            g.DrawLine(myPen, ((i * xmaxspace) + (W / 2)), ((H / 2) + 3), ((i * xmaxspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xmaxspace) + (W / 2), ((H / 2) + 8), drawFormat);
                            }

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) + 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * yminspace), drawFormat);
                            }
                           


                        }
                    }
                    //draw black on left quadrants 2 and 3 of graph
                    if (xMin >= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant2);
                        e.Graphics.FillRectangle(blackBrush, quadrant3);
                        for (int i = 0; i <= 250; i++)
                        {
                           
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            //xmax
                            g.DrawLine(myPen, ((i * xmaxspace) + (W / 2)), ((H / 2) + 3), ((i * xmaxspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xmaxspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) + 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * yminspace), drawFormat);
                            }
                            //ymax
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * ymaxspace), (W / 2) + 3, (H / 2) - (i * ymaxspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * ymaxspace), drawFormat);
                            }


                        }
                    }
                    //draw black on right quadrants 1 and 4 of graph
                    if (xMax <= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant1);
                        e.Graphics.FillRectangle(blackBrush, quadrant4);
                        for (int i = 0; i <= 250; i++)
                        {
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            //xmin   
                            g.DrawLine(myPen, ((i * xminspace) + (W / 2)), ((H / 2) + 3), ((i * xminspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xminspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                          

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) - 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) - 10, (H / 2) - (i * yminspace), drawFormat);
                            }
                            //ymax
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * ymaxspace), (W / 2) + 3, (H / 2) - (i * ymaxspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) - 10, (H / 2) - (i * ymaxspace), drawFormat);
                            }


                        }
                    }
                    //black out all qudrants except 1
                    if (xMin >= 0 && yMin >= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant2);
                        e.Graphics.FillRectangle(blackBrush, quadrant3);
                        e.Graphics.FillRectangle(blackBrush, quadrant4);
                        for (int i = 0; i <= 250; i++)
                        {

                            temp = (int)(i * yInterval_numericUpDown.Value);
                            //xmax
                            g.DrawLine(myPen, ((i * xmaxspace) + (W / 2)), ((H / 2) + 3), ((i * xmaxspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xmaxspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                        
                            //ymax
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * ymaxspace), (W / 2) + 3, (H / 2) - (i * ymaxspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * ymaxspace), drawFormat);
                            }


                        }
                    }
                    //black out all qudrants except 2
                    if (xMax <= 0 && yMin >= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant1);
                        e.Graphics.FillRectangle(blackBrush, quadrant3);
                        e.Graphics.FillRectangle(blackBrush, quadrant4);
                        for (int i = 0; i <= 250; i++)
                        {
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            //xmin   
                            g.DrawLine(myPen, ((i * xminspace) + (W / 2)), ((H / 2) + 3), ((i * xminspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xminspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }


                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                       
                            //ymax
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * ymaxspace), (W / 2) + 3, (H / 2) - (i * ymaxspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) - 10, (H / 2) - (i * ymaxspace), drawFormat);
                            }


                        }
                    }
                    //black out all qudrants except 3
                    if (xMax <= 0 && yMax <= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant1);
                        e.Graphics.FillRectangle(blackBrush, quadrant2);
                        e.Graphics.FillRectangle(blackBrush, quadrant4);
                        for (int i = 0; i <= 250; i++)
                        {
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            //xmin   
                            g.DrawLine(myPen, ((i * xminspace) + (W / 2)), ((H / 2) + 3), ((i * xminspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xminspace) + (W / 2), ((H / 2) + 8), drawFormat);
                            }

                            

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) + 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) - 10, (H / 2) - (i * ymaxspace), drawFormat);
                            }
                            //ymax
                           


                        }
                    }
                    //black out all qudrants except 4
                    if (xMin >= 0 && yMax <= 0)
                    {
                        e.Graphics.FillRectangle(blackBrush, quadrant1);
                        e.Graphics.FillRectangle(blackBrush, quadrant2);
                        e.Graphics.FillRectangle(blackBrush, quadrant3);
                        for (int i = 0; i <= 250; i++)
                        {
                           

                            temp = (int)(i * yInterval_numericUpDown.Value);
                            //xmax
                            g.DrawLine(myPen, ((i * xmaxspace) + (W / 2)), ((H / 2) + 3), ((i * xmaxspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xmaxspace) + (W / 2), ((H / 2) + 8), drawFormat);
                            }

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) + 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 10, (H / 2) - (i * ymaxspace), drawFormat);
                            }
                           
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= 250; i++)
                        {
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            //xmin   
                            g.DrawLine(myPen, ((i * xminspace) + (W / 2)), ((H / 2) + 3), ((i * xminspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xminspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                            temp = (int)(i * yInterval_numericUpDown.Value);
                            //xmax
                            g.DrawLine(myPen, ((i * xmaxspace) + (W / 2)), ((H / 2) + 3), ((i * xmaxspace) + (W / 2)), ((H / 2) - 3));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (i * xmaxspace) + (W / 2), ((H / 2) - 8), drawFormat);
                            }

                        }
                        //Uses to draw ticks
                        for (int i = 0; i <= 250; i++)
                        {
                            //ymin
                            temp = (int)(-i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * yminspace), (W / 2) + 3, (H / 2) - (i * yminspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * yminspace), drawFormat);
                            }
                            //ymax
                            temp = (int)(i * yInterval_numericUpDown.Value);
                            g.DrawLine(myPen, (W / 2) - 3, (H / 2) - (i * ymaxspace), (W / 2) + 3, (H / 2) - (i * ymaxspace));
                            //Used to label ticks
                            if (i != 0)
                            {
                                g.DrawString(temp.ToString(), drawFont, drawBrush, (W / 2) + 3, (H / 2) - (i * ymaxspace), drawFormat);
                            }


                        }
                    }
                }
            }
        }
        //Used make inputs nums only
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void MinNumUpDown_ValueChanged(object sender, EventArgs e)
        {


            //sets the max value to 1 more then min within the range 1 through 60
            if (xMax_numericUpDown.Value < xMin_numericUpDown.Value)
                xMax_numericUpDown.Value = xMin_numericUpDown.Value + 1;
            if (xMin_numericUpDown.Value == xMax_numericUpDown.Value)
                xMax_numericUpDown.Value++;

            if (yMax_numericUpDown.Value < yMin_numericUpDown.Value)
                yMax_numericUpDown.Value = yMin_numericUpDown.Value + 1;
            if (yMin_numericUpDown.Value == yMax_numericUpDown.Value)
                yMax_numericUpDown.Value++;
        }

        private void MaxNumUpDown_ValueChanged(object sender, EventArgs e)
        {

            //prevents the max from being lower then the min
            if (xMin_numericUpDown.Value == 2 && xMax_numericUpDown.Value == 1)
            {
                xMin_numericUpDown.Value = 1;
            }

            if (xMin_numericUpDown.Value > xMax_numericUpDown.Value)
            {
                if (xMax_numericUpDown.Value == 1)//if the max value is 1 then make sure min is also 1
                {
                    xMin_numericUpDown.Value = 1;
                    return;
                }
                xMin_numericUpDown.Value = xMax_numericUpDown.Value - 1;

            }
            if (xMin_numericUpDown.Value == xMax_numericUpDown.Value)
                xMin_numericUpDown.Value--;

            //for y max and min
            //prevents the max from being lower then the min
            if (yMin_numericUpDown.Value == 2 && yMax_numericUpDown.Value == 1)
            {
                yMin_numericUpDown.Value = 1;
            }


            if (yMin_numericUpDown.Value > yMax_numericUpDown.Value)
            {
                if (yMax_numericUpDown.Value == 1)//if the max value is 1 then make sure min is also 1
                {
                    yMin_numericUpDown.Value = 1;
                    return;
                }
                yMin_numericUpDown.Value = yMax_numericUpDown.Value - 1;

            }
            if (yMin_numericUpDown.Value == yMax_numericUpDown.Value)
                yMin_numericUpDown.Value--;
        }

        private void Main_Graph_Resize(object sender, EventArgs e)
        {


        }

    }
    //Use to draw circle
    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
