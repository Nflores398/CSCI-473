
namespace TeamBlizzard_Assignment6v2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Piechart_Button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.LineGraph_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BarGraph_Button = new System.Windows.Forms.Button();
            this.StackedGraph_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Piechart_Button
            // 
            this.Piechart_Button.Location = new System.Drawing.Point(91, 62);
            this.Piechart_Button.Name = "Piechart_Button";
            this.Piechart_Button.Size = new System.Drawing.Size(75, 23);
            this.Piechart_Button.TabIndex = 0;
            this.Piechart_Button.Text = "Pie Chart";
            this.Piechart_Button.UseVisualStyleBackColor = true;
            this.Piechart_Button.Click += new System.EventHandler(this.Barchart_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Location = new System.Drawing.Point(91, 259);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(75, 23);
            this.Exit_Button.TabIndex = 1;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // LineGraph_Button
            // 
            this.LineGraph_Button.Location = new System.Drawing.Point(91, 111);
            this.LineGraph_Button.Name = "LineGraph_Button";
            this.LineGraph_Button.Size = new System.Drawing.Size(75, 23);
            this.LineGraph_Button.TabIndex = 2;
            this.LineGraph_Button.Text = "Line Graph";
            this.LineGraph_Button.UseVisualStyleBackColor = true;
            this.LineGraph_Button.Click += new System.EventHandler(this.LineGraph_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Graph Demo";
            // 
            // BarGraph_Button
            // 
            this.BarGraph_Button.Location = new System.Drawing.Point(91, 158);
            this.BarGraph_Button.Name = "BarGraph_Button";
            this.BarGraph_Button.Size = new System.Drawing.Size(75, 23);
            this.BarGraph_Button.TabIndex = 4;
            this.BarGraph_Button.Text = "Bar Graph";
            this.BarGraph_Button.UseVisualStyleBackColor = true;
            this.BarGraph_Button.Click += new System.EventHandler(this.BarGraph_Button_Click);
            // 
            // StackedGraph_Button
            // 
            this.StackedGraph_Button.Location = new System.Drawing.Point(91, 205);
            this.StackedGraph_Button.Name = "StackedGraph_Button";
            this.StackedGraph_Button.Size = new System.Drawing.Size(75, 23);
            this.StackedGraph_Button.TabIndex = 5;
            this.StackedGraph_Button.Text = "Stacked";
            this.StackedGraph_Button.UseVisualStyleBackColor = true;
            this.StackedGraph_Button.Click += new System.EventHandler(this.StackedGraph_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(252, 294);
            this.Controls.Add(this.StackedGraph_Button);
            this.Controls.Add(this.BarGraph_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LineGraph_Button);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Piechart_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Piechart_Button;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button LineGraph_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BarGraph_Button;
        private System.Windows.Forms.Button StackedGraph_Button;
    }
}

