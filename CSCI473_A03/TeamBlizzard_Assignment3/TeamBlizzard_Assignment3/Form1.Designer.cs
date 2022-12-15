
namespace TeamBlizzard_Assignment3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ServercomboBox1 = new System.Windows.Forms.ComboBox();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.Show_Results_button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ServercomboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Show_Results_button2 = new System.Windows.Forms.Button();
            this.Show_Results_button3 = new System.Windows.Forms.Button();
            this.RolecomboBox = new System.Windows.Forms.ComboBox();
            this.ServercomboBox3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MinNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.OutPut_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Show_Results_button4 = new System.Windows.Forms.Button();
            this.TypecomboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TankradioButton = new System.Windows.Forms.RadioButton();
            this.HealerradioButton = new System.Windows.Forms.RadioButton();
            this.DPSradioButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Show_Results_button5 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.Show_Results_button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MinNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Title.Location = new System.Drawing.Point(515, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(93, 37);
            this.Title.TabIndex = 1;
            this.Title.Text = "Query";
            this.Title.DoubleClick += new System.EventHandler(this.Title_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(39, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "All Class Type from a Single Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(39, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(193, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Server";
            // 
            // ServercomboBox1
            // 
            this.ServercomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServercomboBox1.FormattingEnabled = true;
            this.ServercomboBox1.Location = new System.Drawing.Point(193, 97);
            this.ServercomboBox1.Name = "ServercomboBox1";
            this.ServercomboBox1.Size = new System.Drawing.Size(141, 23);
            this.ServercomboBox1.TabIndex = 6;
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(44, 97);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(141, 23);
            this.ClassComboBox.TabIndex = 7;
            // 
            // Show_Results_button1
            // 
            this.Show_Results_button1.Location = new System.Drawing.Point(406, 96);
            this.Show_Results_button1.Name = "Show_Results_button1";
            this.Show_Results_button1.Size = new System.Drawing.Size(103, 22);
            this.Show_Results_button1.TabIndex = 8;
            this.Show_Results_button1.Text = "Show Results";
            this.Show_Results_button1.UseVisualStyleBackColor = true;
            this.Show_Results_button1.Click += new System.EventHandler(this.Show_Rsults_button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(39, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(416, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Percentage of Each Race From a Single Server";
            // 
            // ServercomboBox2
            // 
            this.ServercomboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServercomboBox2.FormattingEnabled = true;
            this.ServercomboBox2.Location = new System.Drawing.Point(193, 205);
            this.ServercomboBox2.Name = "ServercomboBox2";
            this.ServercomboBox2.Size = new System.Drawing.Size(141, 23);
            this.ServercomboBox2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(193, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Server";
            // 
            // Show_Results_button2
            // 
            this.Show_Results_button2.Location = new System.Drawing.Point(406, 204);
            this.Show_Results_button2.Name = "Show_Results_button2";
            this.Show_Results_button2.Size = new System.Drawing.Size(103, 22);
            this.Show_Results_button2.TabIndex = 12;
            this.Show_Results_button2.Text = "Show Results";
            this.Show_Results_button2.UseVisualStyleBackColor = true;
            this.Show_Results_button2.Click += new System.EventHandler(this.Show_Results_button2_Click);
            // 
            // Show_Results_button3
            // 
            this.Show_Results_button3.Location = new System.Drawing.Point(406, 304);
            this.Show_Results_button3.Name = "Show_Results_button3";
            this.Show_Results_button3.Size = new System.Drawing.Size(103, 22);
            this.Show_Results_button3.TabIndex = 19;
            this.Show_Results_button3.Text = "Show Results";
            this.Show_Results_button3.UseVisualStyleBackColor = true;
            this.Show_Results_button3.Click += new System.EventHandler(this.Show_Results_button3_Click);
            // 
            // RolecomboBox
            // 
            this.RolecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RolecomboBox.FormattingEnabled = true;
            this.RolecomboBox.Location = new System.Drawing.Point(44, 305);
            this.RolecomboBox.Name = "RolecomboBox";
            this.RolecomboBox.Size = new System.Drawing.Size(141, 23);
            this.RolecomboBox.TabIndex = 18;
            // 
            // ServercomboBox3
            // 
            this.ServercomboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServercomboBox3.FormattingEnabled = true;
            this.ServercomboBox3.Location = new System.Drawing.Point(193, 305);
            this.ServercomboBox3.Name = "ServercomboBox3";
            this.ServercomboBox3.Size = new System.Drawing.Size(141, 23);
            this.ServercomboBox3.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(193, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 21);
            this.label7.TabIndex = 16;
            this.label7.Text = "Server";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(39, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Role";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(44, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "All Role Types from a Single Server Within a Level Range";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "label10";
            // 
            // MinNumUpDown
            // 
            this.MinNumUpDown.Location = new System.Drawing.Point(44, 362);
            this.MinNumUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MinNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinNumUpDown.Name = "MinNumUpDown";
            this.MinNumUpDown.Size = new System.Drawing.Size(58, 23);
            this.MinNumUpDown.TabIndex = 20;
            this.MinNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinNumUpDown.ValueChanged += new System.EventHandler(this.MinNumUpDown_ValueChanged);
            // 
            // MaxNumUpDown
            // 
            this.MaxNumUpDown.Location = new System.Drawing.Point(127, 362);
            this.MaxNumUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MaxNumUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxNumUpDown.Name = "MaxNumUpDown";
            this.MaxNumUpDown.Size = new System.Drawing.Size(58, 23);
            this.MaxNumUpDown.TabIndex = 21;
            this.MaxNumUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxNumUpDown.ValueChanged += new System.EventHandler(this.MaxNumUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(44, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 21);
            this.label11.TabIndex = 22;
            this.label11.Text = "Min";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.SystemColors.Control;
            this.label12.Location = new System.Drawing.Point(127, 338);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 21);
            this.label12.TabIndex = 23;
            this.label12.Text = "Max";
            // 
            // OutPut_richTextBox1
            // 
            this.OutPut_richTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutPut_richTextBox1.Location = new System.Drawing.Point(515, 49);
            this.OutPut_richTextBox1.Name = "OutPut_richTextBox1";
            this.OutPut_richTextBox1.Size = new System.Drawing.Size(734, 603);
            this.OutPut_richTextBox1.TabIndex = 24;
            this.OutPut_richTextBox1.Text = "";
            // 
            // Show_Results_button4
            // 
            this.Show_Results_button4.Location = new System.Drawing.Point(406, 452);
            this.Show_Results_button4.Name = "Show_Results_button4";
            this.Show_Results_button4.Size = new System.Drawing.Size(103, 22);
            this.Show_Results_button4.TabIndex = 31;
            this.Show_Results_button4.Text = "Show Results";
            this.Show_Results_button4.UseVisualStyleBackColor = true;
            this.Show_Results_button4.Click += new System.EventHandler(this.Show_Results_button4_Click);
            // 
            // TypecomboBox
            // 
            this.TypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypecomboBox.FormattingEnabled = true;
            this.TypecomboBox.Location = new System.Drawing.Point(44, 453);
            this.TypecomboBox.Name = "TypecomboBox";
            this.TypecomboBox.Size = new System.Drawing.Size(141, 23);
            this.TypecomboBox.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.SystemColors.Control;
            this.label14.Location = new System.Drawing.Point(39, 426);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 21);
            this.label14.TabIndex = 27;
            this.label14.Text = "Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.SystemColors.Control;
            this.label15.Location = new System.Drawing.Point(39, 401);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(242, 25);
            this.label15.TabIndex = 26;
            this.label15.Text = "All Guilds of a Single Type";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(39, 401);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "label16";
            // 
            // TankradioButton
            // 
            this.TankradioButton.AutoSize = true;
            this.TankradioButton.ForeColor = System.Drawing.Color.White;
            this.TankradioButton.Location = new System.Drawing.Point(9, 16);
            this.TankradioButton.Name = "TankradioButton";
            this.TankradioButton.Size = new System.Drawing.Size(49, 19);
            this.TankradioButton.TabIndex = 32;
            this.TankradioButton.TabStop = true;
            this.TankradioButton.Text = "Tank";
            this.TankradioButton.UseVisualStyleBackColor = true;
            // 
            // HealerradioButton
            // 
            this.HealerradioButton.AutoSize = true;
            this.HealerradioButton.ForeColor = System.Drawing.Color.White;
            this.HealerradioButton.Location = new System.Drawing.Point(63, 16);
            this.HealerradioButton.Name = "HealerradioButton";
            this.HealerradioButton.Size = new System.Drawing.Size(59, 19);
            this.HealerradioButton.TabIndex = 33;
            this.HealerradioButton.TabStop = true;
            this.HealerradioButton.Text = "Healer";
            this.HealerradioButton.UseVisualStyleBackColor = true;
            // 
            // DPSradioButton
            // 
            this.DPSradioButton.AutoSize = true;
            this.DPSradioButton.ForeColor = System.Drawing.Color.White;
            this.DPSradioButton.Location = new System.Drawing.Point(128, 16);
            this.DPSradioButton.Name = "DPSradioButton";
            this.DPSradioButton.Size = new System.Drawing.Size(69, 19);
            this.DPSradioButton.TabIndex = 34;
            this.DPSradioButton.TabStop = true;
            this.DPSradioButton.Text = "Damage";
            this.DPSradioButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(39, 499);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(412, 21);
            this.label13.TabIndex = 35;
            this.label13.Text = "All Players Who Could Fill a Role But Presently Aren\'t";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DPSradioButton);
            this.groupBox1.Controls.Add(this.HealerradioButton);
            this.groupBox1.Controls.Add(this.TankradioButton);
            this.groupBox1.Location = new System.Drawing.Point(44, 527);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 41);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            // 
            // Show_Results_button5
            // 
            this.Show_Results_button5.Location = new System.Drawing.Point(406, 541);
            this.Show_Results_button5.Name = "Show_Results_button5";
            this.Show_Results_button5.Size = new System.Drawing.Size(103, 22);
            this.Show_Results_button5.TabIndex = 37;
            this.Show_Results_button5.Text = "Show Results";
            this.Show_Results_button5.UseVisualStyleBackColor = true;
            this.Show_Results_button5.Click += new System.EventHandler(this.Show_Results_button5_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.SystemColors.Control;
            this.label17.Location = new System.Drawing.Point(39, 597);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(408, 25);
            this.label17.TabIndex = 38;
            this.label17.Text = "Percentage of Max Level Players in All Guilds";
            // 
            // Show_Results_button6
            // 
            this.Show_Results_button6.Location = new System.Drawing.Point(406, 628);
            this.Show_Results_button6.Name = "Show_Results_button6";
            this.Show_Results_button6.Size = new System.Drawing.Size(103, 22);
            this.Show_Results_button6.TabIndex = 39;
            this.Show_Results_button6.Text = "Show Results";
            this.Show_Results_button6.UseVisualStyleBackColor = true;
            this.Show_Results_button6.Click += new System.EventHandler(this.Show_Results_button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1261, 664);
            this.Controls.Add(this.Show_Results_button6);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.Show_Results_button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.Show_Results_button4);
            this.Controls.Add(this.TypecomboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.OutPut_richTextBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.MaxNumUpDown);
            this.Controls.Add(this.MinNumUpDown);
            this.Controls.Add(this.Show_Results_button3);
            this.Controls.Add(this.RolecomboBox);
            this.Controls.Add(this.ServercomboBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Show_Results_button2);
            this.Controls.Add(this.ServercomboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Show_Results_button1);
            this.Controls.Add(this.ClassComboBox);
            this.Controls.Add(this.ServercomboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNumUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ServercomboBox1;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.Button Show_Rsults_button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ServercomboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox RolecomboBox;
        private System.Windows.Forms.ComboBox ServercomboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown MinUpDown;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown MaxUpDown;
        private System.Windows.Forms.NumericUpDown MinNumUpDown;
        private System.Windows.Forms.NumericUpDown MaxNumUpDown;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Show_Results_button4;
        private System.Windows.Forms.ComboBox TypecomboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton TankradioButton;
        private System.Windows.Forms.RadioButton HealerradioButton;
        private System.Windows.Forms.RadioButton DPSradioButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Show_Results_button5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button Show_Results_button6;
        private System.Windows.Forms.Button Show_Results_button1;
        private System.Windows.Forms.Button Show_Results_button2;
        private System.Windows.Forms.Button Show_Results_button3;
        private System.Windows.Forms.RichTextBox OutPut_richTextBox1;
    }
}

