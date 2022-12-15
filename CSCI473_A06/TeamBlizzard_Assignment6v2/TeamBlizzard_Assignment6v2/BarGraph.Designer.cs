
namespace TeamBlizzard_Assignment6v2
{
    partial class BarGraph
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.Return_Button = new System.Windows.Forms.Button();
            this.Linegraph1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Linegraph1)).BeginInit();
            this.SuspendLayout();
            // 
            // Return_Button
            // 
            this.Return_Button.Location = new System.Drawing.Point(713, 406);
            this.Return_Button.Name = "Return_Button";
            this.Return_Button.Size = new System.Drawing.Size(75, 23);
            this.Return_Button.TabIndex = 2;
            this.Return_Button.Text = "Return";
            this.Return_Button.UseVisualStyleBackColor = true;
            this.Return_Button.Click += new System.EventHandler(this.Return_Button_Click);
            // 
            // Linegraph1
            // 
            textAnnotation1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation1.Name = "TextAnnotation1";
            textAnnotation1.Text = "Hours";
            textAnnotation1.X = 0D;
            textAnnotation1.Y = 5D;
            textAnnotation2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation2.Name = "TextAnnotation2";
            textAnnotation2.Text = "Month";
            textAnnotation2.X = 43D;
            textAnnotation2.Y = 94D;
            this.Linegraph1.Annotations.Add(textAnnotation1);
            this.Linegraph1.Annotations.Add(textAnnotation2);
            chartArea1.Name = "ChartArea1";
            this.Linegraph1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Linegraph1.Legends.Add(legend1);
            this.Linegraph1.Location = new System.Drawing.Point(0, -4);
            this.Linegraph1.Name = "Linegraph1";
            this.Linegraph1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Daniel";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Jon";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "John";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Geoffrey";
            this.Linegraph1.Series.Add(series1);
            this.Linegraph1.Series.Add(series2);
            this.Linegraph1.Series.Add(series3);
            this.Linegraph1.Series.Add(series4);
            this.Linegraph1.Size = new System.Drawing.Size(707, 433);
            this.Linegraph1.TabIndex = 3;
            this.Linegraph1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Average Hours Slept By The Gamers in 2020";
            this.Linegraph1.Titles.Add(title1);
            // 
            // BarGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Linegraph1);
            this.Controls.Add(this.Return_Button);
            this.Name = "BarGraph";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarGraph_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Linegraph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Return_Button;
        private System.Windows.Forms.DataVisualization.Charting.Chart Linegraph1;
    }
}