namespace WeConnect
{
    partial class Form4
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_travel = new System.Windows.Forms.CheckBox();
            this.checkBox_sports = new System.Windows.Forms.CheckBox();
            this.checkBox_entertainment = new System.Windows.Forms.CheckBox();
            this.checkBox_food = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(237, 180);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 94);
            this.button1.TabIndex = 3;
            this.button1.Text = "PROCEED";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.checkBox_travel);
            this.panel1.Controls.Add(this.checkBox_sports);
            this.panel1.Controls.Add(this.checkBox_entertainment);
            this.panel1.Controls.Add(this.checkBox_food);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(83, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 488);
            this.panel1.TabIndex = 4;
            // 
            // checkBox_travel
            // 
            this.checkBox_travel.AutoSize = true;
            this.checkBox_travel.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_travel.ForeColor = System.Drawing.Color.White;
            this.checkBox_travel.Location = new System.Drawing.Point(434, 435);
            this.checkBox_travel.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_travel.Name = "checkBox_travel";
            this.checkBox_travel.Size = new System.Drawing.Size(123, 32);
            this.checkBox_travel.TabIndex = 15;
            this.checkBox_travel.Text = "TRAVEL";
            this.checkBox_travel.UseVisualStyleBackColor = true;
            // 
            // checkBox_sports
            // 
            this.checkBox_sports.AutoSize = true;
            this.checkBox_sports.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_sports.ForeColor = System.Drawing.Color.White;
            this.checkBox_sports.Location = new System.Drawing.Point(46, 435);
            this.checkBox_sports.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_sports.Name = "checkBox_sports";
            this.checkBox_sports.Size = new System.Drawing.Size(124, 32);
            this.checkBox_sports.TabIndex = 14;
            this.checkBox_sports.Text = "SPORTS";
            this.checkBox_sports.UseVisualStyleBackColor = true;
            // 
            // checkBox_entertainment
            // 
            this.checkBox_entertainment.AutoSize = true;
            this.checkBox_entertainment.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_entertainment.ForeColor = System.Drawing.Color.White;
            this.checkBox_entertainment.Location = new System.Drawing.Point(425, 158);
            this.checkBox_entertainment.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_entertainment.Name = "checkBox_entertainment";
            this.checkBox_entertainment.Size = new System.Drawing.Size(232, 32);
            this.checkBox_entertainment.TabIndex = 13;
            this.checkBox_entertainment.Text = "ENTERTAINMENT";
            this.checkBox_entertainment.UseVisualStyleBackColor = true;
            // 
            // checkBox_food
            // 
            this.checkBox_food.AutoSize = true;
            this.checkBox_food.Font = new System.Drawing.Font("Palatino Linotype", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_food.ForeColor = System.Drawing.Color.White;
            this.checkBox_food.Location = new System.Drawing.Point(46, 158);
            this.checkBox_food.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_food.Name = "checkBox_food";
            this.checkBox_food.Size = new System.Drawing.Size(103, 32);
            this.checkBox_food.TabIndex = 12;
            this.checkBox_food.Text = "FOOD";
            this.checkBox_food.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::WeConnect.Properties.Resources.Food;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(46, 25);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 128);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::WeConnect.Properties.Resources.Dance;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Location = new System.Drawing.Point(425, 25);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(184, 128);
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::WeConnect.Properties.Resources.OIP1;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(434, 299);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 131);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::WeConnect.Properties.Resources.OIP__2_;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(46, 299);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 131);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(76, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 45);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select your Interests";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::WeConnect.Properties.Resources.abstract_minimalism_hd_4k_15393708202;
            this.ClientSize = new System.Drawing.Size(848, 641);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(870, 697);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(870, 697);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interests";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_travel;
        private System.Windows.Forms.CheckBox checkBox_sports;
        private System.Windows.Forms.CheckBox checkBox_entertainment;
        private System.Windows.Forms.CheckBox checkBox_food;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}