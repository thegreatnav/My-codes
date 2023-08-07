namespace WeConnect
{
    partial class Messaging
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
            this.table1 = new System.Windows.Forms.DataGridView();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.search_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.AllowUserToAddRows = false;
            this.table1.AllowUserToDeleteRows = false;
            this.table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table1.Location = new System.Drawing.Point(143, 157);
            this.table1.Name = "table1";
            this.table1.RowTemplate.Height = 28;
            this.table1.Size = new System.Drawing.Size(584, 193);
            this.table1.TabIndex = 12;
            this.table1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table1_CellContentClick);
            // 
            // search_textBox
            // 
            this.search_textBox.Location = new System.Drawing.Point(257, 88);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(189, 26);
            this.search_textBox.TabIndex = 13;
            this.search_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.search_textBox_KeyPress_1);
            // 
            // search_label
            // 
            this.search_label.AutoSize = true;
            this.search_label.Location = new System.Drawing.Point(144, 121);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(139, 20);
            this.search_label.TabIndex = 14;
            this.search_label.Text = "Suggested for you";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Search People";
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(751, 356);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(91, 36);
            this.back_button.TabIndex = 16;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // Messaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 506);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.search_label);
            this.Controls.Add(this.search_textBox);
            this.Controls.Add(this.table1);
            this.Name = "Messaging";
            this.Text = "Messaging";
            this.Load += new System.EventHandler(this.Messaging_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table1;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button back_button;
    }
}