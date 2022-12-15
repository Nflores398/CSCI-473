
namespace Assignment_2
{
    partial class Management_System
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
            this.Print_Guild_Button = new System.Windows.Forms.Button();
            this.Disband_Guild_Button = new System.Windows.Forms.Button();
            this.Join_Guild_Button = new System.Windows.Forms.Button();
            this.Leave_Guild_Button = new System.Windows.Forms.Button();
            this.Apply_Search_Criteria_Button = new System.Windows.Forms.Button();
            this.Search_Player_TextField = new System.Windows.Forms.TextBox();
            this.Search_Guild_TextField = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Race_Box = new System.Windows.Forms.ComboBox();
            this.Role_Box = new System.Windows.Forms.ComboBox();
            this.Class_Box = new System.Windows.Forms.ComboBox();
            this.Player_Name_TextField = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Add_Guild_Button = new System.Windows.Forms.Button();
            this.Server_Box = new System.Windows.Forms.ComboBox();
            this.Type_Box = new System.Windows.Forms.ComboBox();
            this.Guild_Name_TextField = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Output_TextField = new System.Windows.Forms.RichTextBox();
            this.Player_List_Listbox = new System.Windows.Forms.ListBox();
            this.Guild_List_Listbox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(305, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(487, 40);
            this.Title.TabIndex = 0;
            this.Title.Text = "Player/Guild Management System";
            this.Title.DoubleClick += new System.EventHandler(this.Title_Credit);
            // 
            // Print_Guild_Button
            // 
            this.Print_Guild_Button.ForeColor = System.Drawing.Color.Black;
            this.Print_Guild_Button.Location = new System.Drawing.Point(9, 16);
            this.Print_Guild_Button.Name = "Print_Guild_Button";
            this.Print_Guild_Button.Size = new System.Drawing.Size(125, 23);
            this.Print_Guild_Button.TabIndex = 1;
            this.Print_Guild_Button.Text = "Print Guild Roster";
            this.Print_Guild_Button.UseVisualStyleBackColor = true;
            this.Print_Guild_Button.Click += new System.EventHandler(this.Print_Guild_Button_Click);
            // 
            // Disband_Guild_Button
            // 
            this.Disband_Guild_Button.ForeColor = System.Drawing.Color.Black;
            this.Disband_Guild_Button.Location = new System.Drawing.Point(9, 45);
            this.Disband_Guild_Button.Name = "Disband_Guild_Button";
            this.Disband_Guild_Button.Size = new System.Drawing.Size(125, 23);
            this.Disband_Guild_Button.TabIndex = 2;
            this.Disband_Guild_Button.Text = "Disband Guild";
            this.Disband_Guild_Button.UseVisualStyleBackColor = true;
            this.Disband_Guild_Button.Click += new System.EventHandler(this.Disband_Guild_Button_Click);
            // 
            // Join_Guild_Button
            // 
            this.Join_Guild_Button.ForeColor = System.Drawing.Color.Black;
            this.Join_Guild_Button.Location = new System.Drawing.Point(9, 74);
            this.Join_Guild_Button.Name = "Join_Guild_Button";
            this.Join_Guild_Button.Size = new System.Drawing.Size(125, 23);
            this.Join_Guild_Button.TabIndex = 3;
            this.Join_Guild_Button.Text = "Join Guild";
            this.Join_Guild_Button.UseVisualStyleBackColor = true;
            this.Join_Guild_Button.Click += new System.EventHandler(this.Join_Guild_Button_Click);
            // 
            // Leave_Guild_Button
            // 
            this.Leave_Guild_Button.ForeColor = System.Drawing.Color.Black;
            this.Leave_Guild_Button.Location = new System.Drawing.Point(9, 103);
            this.Leave_Guild_Button.Name = "Leave_Guild_Button";
            this.Leave_Guild_Button.Size = new System.Drawing.Size(125, 23);
            this.Leave_Guild_Button.TabIndex = 4;
            this.Leave_Guild_Button.Text = "Leave Guild";
            this.Leave_Guild_Button.UseVisualStyleBackColor = true;
            this.Leave_Guild_Button.Click += new System.EventHandler(this.Leave_Guild_Button_Click);
            // 
            // Apply_Search_Criteria_Button
            // 
            this.Apply_Search_Criteria_Button.ForeColor = System.Drawing.Color.Black;
            this.Apply_Search_Criteria_Button.Location = new System.Drawing.Point(9, 132);
            this.Apply_Search_Criteria_Button.Name = "Apply_Search_Criteria_Button";
            this.Apply_Search_Criteria_Button.Size = new System.Drawing.Size(125, 23);
            this.Apply_Search_Criteria_Button.TabIndex = 5;
            this.Apply_Search_Criteria_Button.Text = "Apply Search Criteria";
            this.Apply_Search_Criteria_Button.UseVisualStyleBackColor = true;
            this.Apply_Search_Criteria_Button.Click += new System.EventHandler(this.Apply_Search_Criteria_Button_Click);
            // 
            // Search_Player_TextField
            // 
            this.Search_Player_TextField.ForeColor = System.Drawing.Color.Black;
            this.Search_Player_TextField.Location = new System.Drawing.Point(140, 32);
            this.Search_Player_TextField.Name = "Search_Player_TextField";
            this.Search_Player_TextField.Size = new System.Drawing.Size(167, 23);
            this.Search_Player_TextField.TabIndex = 6;
            // 
            // Search_Guild_TextField
            // 
            this.Search_Guild_TextField.ForeColor = System.Drawing.Color.Black;
            this.Search_Guild_TextField.Location = new System.Drawing.Point(140, 74);
            this.Search_Guild_TextField.Name = "Search_Guild_TextField";
            this.Search_Guild_TextField.Size = new System.Drawing.Size(167, 23);
            this.Search_Guild_TextField.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Search_Guild_TextField);
            this.groupBox1.Controls.Add(this.Search_Player_TextField);
            this.groupBox1.Controls.Add(this.Apply_Search_Criteria_Button);
            this.groupBox1.Controls.Add(this.Leave_Guild_Button);
            this.groupBox1.Controls.Add(this.Join_Guild_Button);
            this.groupBox1.Controls.Add(this.Disband_Guild_Button);
            this.groupBox1.Controls.Add(this.Print_Guild_Button);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 177);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Management Functions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search Guild (by Server)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search Player (by Name)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Add_Button);
            this.groupBox2.Controls.Add(this.Race_Box);
            this.groupBox2.Controls.Add(this.Role_Box);
            this.groupBox2.Controls.Add(this.Class_Box);
            this.groupBox2.Controls.Add(this.Player_Name_TextField);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 138);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create New Player";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Role";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(150, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Race";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player Name";
            // 
            // Add_Button
            // 
            this.Add_Button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Add_Button.ForeColor = System.Drawing.Color.Black;
            this.Add_Button.Location = new System.Drawing.Point(311, 38);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(70, 23);
            this.Add_Button.TabIndex = 4;
            this.Add_Button.Text = "Add Player";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Race_Box
            // 
            this.Race_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Race_Box.FormattingEnabled = true;
            this.Race_Box.Location = new System.Drawing.Point(152, 38);
            this.Race_Box.Name = "Race_Box";
            this.Race_Box.Size = new System.Drawing.Size(140, 23);
            this.Race_Box.TabIndex = 3;
            // 
            // Role_Box
            // 
            this.Role_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Role_Box.FormattingEnabled = true;
            this.Role_Box.Location = new System.Drawing.Point(152, 80);
            this.Role_Box.Name = "Role_Box";
            this.Role_Box.Size = new System.Drawing.Size(140, 23);
            this.Role_Box.TabIndex = 2;
            // 
            // Class_Box
            // 
            this.Class_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Class_Box.FormattingEnabled = true;
            this.Class_Box.Location = new System.Drawing.Point(9, 81);
            this.Class_Box.Name = "Class_Box";
            this.Class_Box.Size = new System.Drawing.Size(125, 23);
            this.Class_Box.TabIndex = 1;
            this.Class_Box.SelectionChangeCommitted += new System.EventHandler(this.Class_Box_SelectionChangeCommitted);
            // 
            // Player_Name_TextField
            // 
            this.Player_Name_TextField.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Player_Name_TextField.Location = new System.Drawing.Point(9, 37);
            this.Player_Name_TextField.Name = "Player_Name_TextField";
            this.Player_Name_TextField.Size = new System.Drawing.Size(125, 21);
            this.Player_Name_TextField.TabIndex = 0;
            this.Player_Name_TextField.TextChanged += new System.EventHandler(this.Player_Name_TextField_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.Add_Guild_Button);
            this.groupBox3.Controls.Add(this.Server_Box);
            this.groupBox3.Controls.Add(this.Type_Box);
            this.groupBox3.Controls.Add(this.Guild_Name_TextField);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 460);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 127);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create New Guild";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(153, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Server";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Guild Name";
            // 
            // Add_Guild_Button
            // 
            this.Add_Guild_Button.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Add_Guild_Button.ForeColor = System.Drawing.Color.Black;
            this.Add_Guild_Button.Location = new System.Drawing.Point(314, 40);
            this.Add_Guild_Button.Name = "Add_Guild_Button";
            this.Add_Guild_Button.Size = new System.Drawing.Size(70, 23);
            this.Add_Guild_Button.TabIndex = 13;
            this.Add_Guild_Button.Text = "Add Guild";
            this.Add_Guild_Button.UseVisualStyleBackColor = true;
            this.Add_Guild_Button.Click += new System.EventHandler(this.Add_Guild_Button_Click);
            // 
            // Server_Box
            // 
            this.Server_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Server_Box.FormattingEnabled = true;
            this.Server_Box.Location = new System.Drawing.Point(155, 40);
            this.Server_Box.Name = "Server_Box";
            this.Server_Box.Size = new System.Drawing.Size(140, 23);
            this.Server_Box.TabIndex = 12;
            this.Server_Box.SelectedIndexChanged += new System.EventHandler(this.Server_Box_SelectedIndexChanged);
            // 
            // Type_Box
            // 
            this.Type_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Type_Box.FormattingEnabled = true;
            this.Type_Box.Location = new System.Drawing.Point(155, 82);
            this.Type_Box.Name = "Type_Box";
            this.Type_Box.Size = new System.Drawing.Size(140, 23);
            this.Type_Box.TabIndex = 11;
            // 
            // Guild_Name_TextField
            // 
            this.Guild_Name_TextField.Location = new System.Drawing.Point(12, 39);
            this.Guild_Name_TextField.Name = "Guild_Name_TextField";
            this.Guild_Name_TextField.Size = new System.Drawing.Size(125, 23);
            this.Guild_Name_TextField.TabIndex = 9;
            this.Guild_Name_TextField.TextChanged += new System.EventHandler(this.Guild_Name_TextField_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(21, 615);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 21);
            this.label9.TabIndex = 14;
            this.label9.Text = "Output";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(465, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 21);
            this.label11.TabIndex = 15;
            this.label11.Text = "Players";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(772, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 16;
            this.label12.Text = "Guilds";
            // 
            // Output_TextField
            // 
            this.Output_TextField.Location = new System.Drawing.Point(12, 639);
            this.Output_TextField.Name = "Output_TextField";
            this.Output_TextField.ReadOnly = true;
            this.Output_TextField.Size = new System.Drawing.Size(1115, 144);
            this.Output_TextField.TabIndex = 19;
            this.Output_TextField.Text = "";
            // 
            // Player_List_Listbox
            // 
            this.Player_List_Listbox.BackColor = System.Drawing.Color.Silver;
            this.Player_List_Listbox.FormattingEnabled = true;
            this.Player_List_Listbox.ItemHeight = 15;
            this.Player_List_Listbox.Location = new System.Drawing.Point(465, 98);
            this.Player_List_Listbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player_List_Listbox.Name = "Player_List_Listbox";
            this.Player_List_Listbox.Size = new System.Drawing.Size(247, 484);
            this.Player_List_Listbox.TabIndex = 20;
            this.Player_List_Listbox.SelectedIndexChanged += new System.EventHandler(this.Player_List_Listbox_SelectedIndexChanged);
            // 
            // Guild_List_Listbox
            // 
            this.Guild_List_Listbox.BackColor = System.Drawing.Color.Silver;
            this.Guild_List_Listbox.FormattingEnabled = true;
            this.Guild_List_Listbox.ItemHeight = 15;
            this.Guild_List_Listbox.Location = new System.Drawing.Point(772, 98);
            this.Guild_List_Listbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Guild_List_Listbox.Name = "Guild_List_Listbox";
            this.Guild_List_Listbox.Size = new System.Drawing.Size(356, 484);
            this.Guild_List_Listbox.TabIndex = 21;
            this.Guild_List_Listbox.SelectedIndexChanged += new System.EventHandler(this.Guild_List_Listbox_SelectedIndexChanged);
            // 
            // Management_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1138, 796);
            this.Controls.Add(this.Guild_List_Listbox);
            this.Controls.Add(this.Player_List_Listbox);
            this.Controls.Add(this.Output_TextField);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Title);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Name = "Management_System";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button Print_Guild_Button;
        private System.Windows.Forms.Button Disband_Guild_Button;
        private System.Windows.Forms.Button Join_Guild_Button;
        private System.Windows.Forms.Button Leave_Guild_Button;
        private System.Windows.Forms.Button Apply_Search_Criteria_Button;
        private System.Windows.Forms.TextBox Search_Player_TextField;
        private System.Windows.Forms.TextBox Search_Guild_TextField;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.ComboBox Race_Box;
        private System.Windows.Forms.ComboBox Role_Box;
        private System.Windows.Forms.ComboBox Class_Box;
        private System.Windows.Forms.TextBox Player_Name_TextField;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Add_Guild_Button;
        private System.Windows.Forms.ComboBox Server_Box;
        private System.Windows.Forms.ComboBox Type_Box;
        private System.Windows.Forms.TextBox Guild_Name_TextField;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox Output_TextField;
        private System.Windows.Forms.ListBox Player_List_Listbox;
        private System.Windows.Forms.ListBox Guild_List_Listbox;
    }
}

