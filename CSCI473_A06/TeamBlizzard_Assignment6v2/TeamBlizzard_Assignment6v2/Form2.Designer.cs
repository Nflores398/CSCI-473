
namespace TeamBlizzard_Assignment6v2
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation2 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.Return_Button = new System.Windows.Forms.Button();
            this.Piechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Piechart)).BeginInit();
            this.SuspendLayout();
            // 
            // Return_Button
            // 
            this.Return_Button.Location = new System.Drawing.Point(713, 415);
            this.Return_Button.Name = "Return_Button";
            this.Return_Button.Size = new System.Drawing.Size(75, 23);
            this.Return_Button.TabIndex = 0;
            this.Return_Button.Text = "Return";
            this.Return_Button.UseVisualStyleBackColor = true;
            this.Return_Button.Click += new System.EventHandler(this.Return_Button_Click);
            // 
            // Piechart
            // 
            textAnnotation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation1.Name = "Class Anno";
            textAnnotation1.Text = "Class";
            textAnnotation1.X = 75D;
            textAnnotation1.Y = 8D;
            textAnnotation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation2.Name = "DPS Anno";
            textAnnotation2.Text = "Total DPS %";
            textAnnotation2.X = 5D;
            textAnnotation2.Y = 15D;
            this.Piechart.Annotations.Add(textAnnotation1);
            this.Piechart.Annotations.Add(textAnnotation2);
            chartArea1.Name = "ChartArea1";
            this.Piechart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Piechart.Legends.Add(legend1);
            this.Piechart.Location = new System.Drawing.Point(12, 12);
            this.Piechart.Name = "Piechart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.Piechart.Series.Add(series1);
            this.Piechart.Size = new System.Drawing.Size(695, 426);
            this.Piechart.TabIndex = 1;
            title1.BackColor = System.Drawing.Color.Transparent;
            title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.OrangeRed;
            title1.Name = "Raid";
            title1.Text = "Castle Nathria Raid 2-6-2";
            this.Piechart.Titles.Add(title1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Piechart);
            this.Controls.Add(this.Return_Button);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Piechart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Return_Button;
        private System.Windows.Forms.DataVisualization.Charting.Chart Piechart;
    }
}