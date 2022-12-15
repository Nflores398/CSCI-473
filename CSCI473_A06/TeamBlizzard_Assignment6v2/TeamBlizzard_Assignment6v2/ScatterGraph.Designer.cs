
namespace TeamBlizzard_Assignment6v2
{
    partial class ScatterGraph
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
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation3 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.TextAnnotation textAnnotation4 = new System.Windows.Forms.DataVisualization.Charting.TextAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.Linegraph1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Return_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Linegraph1)).BeginInit();
            this.SuspendLayout();
            // 
            // Linegraph1
            // 
            textAnnotation3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation3.Name = "TextAnnotation1";
            textAnnotation3.Text = "Hours";
            textAnnotation3.X = 0D;
            textAnnotation3.Y = 5D;
            textAnnotation4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textAnnotation4.Name = "TextAnnotation2";
            textAnnotation4.Text = "Month";
            textAnnotation4.X = 43D;
            textAnnotation4.Y = 94D;
            this.Linegraph1.Annotations.Add(textAnnotation3);
            this.Linegraph1.Annotations.Add(textAnnotation4);
            chartArea2.Name = "ChartArea1";
            this.Linegraph1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Linegraph1.Legends.Add(legend2);
            this.Linegraph1.Location = new System.Drawing.Point(1, 1);
            this.Linegraph1.Name = "Linegraph1";
            this.Linegraph1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series5.Legend = "Legend1";
            series5.Name = "Daniel";
            series5.YValuesPerPoint = 2;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series6.Legend = "Legend1";
            series6.Name = "Jon";
            series6.YValuesPerPoint = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series7.Legend = "Legend1";
            series7.Name = "John";
            series7.YValuesPerPoint = 2;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedArea;
            series8.Legend = "Legend1";
            series8.Name = "Geoffrey";
            series8.YValuesPerPoint = 2;
            this.Linegraph1.Series.Add(series5);
            this.Linegraph1.Series.Add(series6);
            this.Linegraph1.Series.Add(series7);
            this.Linegraph1.Series.Add(series8);
            this.Linegraph1.Size = new System.Drawing.Size(799, 449);
            this.Linegraph1.TabIndex = 1;
            this.Linegraph1.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Average Hours Slept By The Gamers in 2020";
            this.Linegraph1.Titles.Add(title2);
            // 
            // Return_Button
            // 
            this.Return_Button.Location = new System.Drawing.Point(713, 415);
            this.Return_Button.Name = "Return_Button";
            this.Return_Button.Size = new System.Drawing.Size(75, 23);
            this.Return_Button.TabIndex = 2;
            this.Return_Button.Text = "Return";
            this.Return_Button.UseVisualStyleBackColor = true;
            this.Return_Button.Click += new System.EventHandler(this.Return_Button_Click);
            // 
            // ScatterGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Return_Button);
            this.Controls.Add(this.Linegraph1);
            this.Name = "ScatterGraph";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScatterGraph_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Linegraph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Linegraph1;
        private System.Windows.Forms.Button Return_Button;
    }
}