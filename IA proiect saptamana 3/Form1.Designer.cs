namespace IA_proiect_saptamana_3
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxX = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.gen_button = new System.Windows.Forms.Button();
            this.sol_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_metoda = new System.Windows.Forms.ComboBox();
            this.reset_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_x_start = new System.Windows.Forms.TextBox();
            this.textBox_y_start = new System.Windows.Forms.TextBox();
            this.textBox_y_finish = new System.Windows.Forms.TextBox();
            this.textBox_x_finish = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_stare_init = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selectati marimea labirintului:";
            // 
            // comboBoxX
            // 
            this.comboBoxX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxX.FormattingEnabled = true;
            this.comboBoxX.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxX.Location = new System.Drawing.Point(251, 6);
            this.comboBoxX.Name = "comboBoxX";
            this.comboBoxX.Size = new System.Drawing.Size(45, 21);
            this.comboBoxX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // comboBoxY
            // 
            this.comboBoxY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxY.Location = new System.Drawing.Point(321, 6);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(45, 21);
            this.comboBoxY.TabIndex = 3;
            // 
            // gen_button
            // 
            this.gen_button.Location = new System.Drawing.Point(372, 4);
            this.gen_button.Name = "gen_button";
            this.gen_button.Size = new System.Drawing.Size(75, 23);
            this.gen_button.TabIndex = 4;
            this.gen_button.Text = "Generare";
            this.gen_button.UseVisualStyleBackColor = true;
            this.gen_button.Click += new System.EventHandler(this.gen_button_Click);
            // 
            // sol_button
            // 
            this.sol_button.Location = new System.Drawing.Point(475, 39);
            this.sol_button.Name = "sol_button";
            this.sol_button.Size = new System.Drawing.Size(75, 23);
            this.sol_button.TabIndex = 5;
            this.sol_button.Text = "Rezolva";
            this.sol_button.UseVisualStyleBackColor = true;
            this.sol_button.Click += new System.EventHandler(this.sol_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Labirintul se va rezolva prin metoda:";
            // 
            // comboBox_metoda
            // 
            this.comboBox_metoda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_metoda.FormattingEnabled = true;
            this.comboBox_metoda.Items.AddRange(new object[] {
            "BFS",
            "DFS",
            "DLS",
            "IDS",
            "GBFS",
            "A*",
            "IDA*"});
            this.comboBox_metoda.Location = new System.Drawing.Point(424, 39);
            this.comboBox_metoda.Name = "comboBox_metoda";
            this.comboBox_metoda.Size = new System.Drawing.Size(45, 21);
            this.comboBox_metoda.TabIndex = 7;
            // 
            // reset_button
            // 
            this.reset_button.Location = new System.Drawing.Point(453, 4);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(75, 23);
            this.reset_button.TabIndex = 8;
            this.reset_button.Text = "Resetare";
            this.reset_button.UseVisualStyleBackColor = true;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Finish:";
            // 
            // textBox_x_start
            // 
            this.textBox_x_start.Location = new System.Drawing.Point(50, 41);
            this.textBox_x_start.Name = "textBox_x_start";
            this.textBox_x_start.Size = new System.Drawing.Size(25, 20);
            this.textBox_x_start.TabIndex = 11;
            this.textBox_x_start.Text = "1";
            // 
            // textBox_y_start
            // 
            this.textBox_y_start.Location = new System.Drawing.Point(81, 41);
            this.textBox_y_start.Name = "textBox_y_start";
            this.textBox_y_start.Size = new System.Drawing.Size(25, 20);
            this.textBox_y_start.TabIndex = 12;
            this.textBox_y_start.Text = "1";
            // 
            // textBox_y_finish
            // 
            this.textBox_y_finish.Location = new System.Drawing.Point(199, 41);
            this.textBox_y_finish.Name = "textBox_y_finish";
            this.textBox_y_finish.Size = new System.Drawing.Size(25, 20);
            this.textBox_y_finish.TabIndex = 14;
            this.textBox_y_finish.Text = "3";
            // 
            // textBox_x_finish
            // 
            this.textBox_x_finish.Location = new System.Drawing.Point(168, 41);
            this.textBox_x_finish.Name = "textBox_x_finish";
            this.textBox_x_finish.Size = new System.Drawing.Size(25, 20);
            this.textBox_x_finish.TabIndex = 13;
            this.textBox_x_finish.Text = "3";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 600);
            this.panel1.TabIndex = 15;
            // 
            // button_stare_init
            // 
            this.button_stare_init.Location = new System.Drawing.Point(556, 39);
            this.button_stare_init.Name = "button_stare_init";
            this.button_stare_init.Size = new System.Drawing.Size(75, 23);
            this.button_stare_init.TabIndex = 16;
            this.button_stare_init.Text = "Stare Initiala";
            this.button_stare_init.UseVisualStyleBackColor = true;
            this.button_stare_init.Click += new System.EventHandler(this.stare_init_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 681);
            this.Controls.Add(this.button_stare_init);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_y_finish);
            this.Controls.Add(this.textBox_x_finish);
            this.Controls.Add(this.textBox_y_start);
            this.Controls.Add(this.textBox_x_start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.comboBox_metoda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sol_button);
            this.Controls.Add(this.gen_button);
            this.Controls.Add(this.comboBoxY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxX);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Proiect IA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.Button gen_button;
        private System.Windows.Forms.Button sol_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_metoda;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_x_start;
        private System.Windows.Forms.TextBox textBox_y_start;
        private System.Windows.Forms.TextBox textBox_y_finish;
        private System.Windows.Forms.TextBox textBox_x_finish;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_stare_init;
    }
}

