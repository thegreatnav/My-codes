namespace WeConnect
{
    partial class Chats
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.back_button = new System.Windows.Forms.Button();
            this.profpictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.name_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profpictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 129);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(963, 509);
            this.dataGridView1.TabIndex = 0;
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(411, 654);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(97, 44);
            this.back_button.TabIndex = 1;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // profpictureBox
            // 
            this.profpictureBox.Location = new System.Drawing.Point(3, 3);
            this.profpictureBox.Name = "profpictureBox";
            this.profpictureBox.Size = new System.Drawing.Size(134, 87);
            this.profpictureBox.TabIndex = 2;
            this.profpictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.username_label);
            this.panel1.Controls.Add(this.name_label);
            this.panel1.Controls.Add(this.profpictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 94);
            this.panel1.TabIndex = 3;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_label.Location = new System.Drawing.Point(144, 4);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(126, 46);
            this.name_label.TabIndex = 3;
            this.name_label.Text = "label1";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(145, 56);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(93, 32);
            this.username_label.TabIndex = 4;
            this.username_label.Text = "label2";
            // 
            // Chats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 710);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Chats";
            this.Text = "Chats";
            this.Load += new System.EventHandler(this.Chats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profpictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.PictureBox profpictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label name_label;
    }
}