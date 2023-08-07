namespace WeConnect
{
    partial class FollowersFollowing
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
            this.components = new System.ComponentModel.Container();
            this.dataSet_Follower = new WeConnect.DataSet_Follower();
            this.dataSetFollowerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.follwoing_label = new System.Windows.Forms.Label();
            this.followers_label = new System.Windows.Forms.Label();
            this.following_num = new System.Windows.Forms.Label();
            this.followers_num = new System.Windows.Forms.Label();
            this.viewfollowing_button = new System.Windows.Forms.Button();
            this.viewfollowers_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.table1 = new System.Windows.Forms.DataGridView();
            this.back_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Follower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFollowerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataSet_Follower
            // 
            this.dataSet_Follower.DataSetName = "DataSet_Follower";
            this.dataSet_Follower.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetFollowerBindingSource
            // 
            this.dataSetFollowerBindingSource.DataSource = this.dataSet_Follower;
            this.dataSetFollowerBindingSource.Position = 0;
            // 
            // follwoing_label
            // 
            this.follwoing_label.AutoSize = true;
            this.follwoing_label.Location = new System.Drawing.Point(156, 49);
            this.follwoing_label.Name = "follwoing_label";
            this.follwoing_label.Size = new System.Drawing.Size(83, 20);
            this.follwoing_label.TabIndex = 1;
            this.follwoing_label.Text = "Following :";
            // 
            // followers_label
            // 
            this.followers_label.AutoSize = true;
            this.followers_label.Location = new System.Drawing.Point(586, 48);
            this.followers_label.Name = "followers_label";
            this.followers_label.Size = new System.Drawing.Size(84, 20);
            this.followers_label.TabIndex = 2;
            this.followers_label.Text = "Followers :";
            // 
            // following_num
            // 
            this.following_num.AutoSize = true;
            this.following_num.Location = new System.Drawing.Point(269, 49);
            this.following_num.Name = "following_num";
            this.following_num.Size = new System.Drawing.Size(51, 20);
            this.following_num.TabIndex = 3;
            this.following_num.Text = "label1";
            this.following_num.Click += new System.EventHandler(this.following_num_Click);
            // 
            // followers_num
            // 
            this.followers_num.AutoSize = true;
            this.followers_num.Location = new System.Drawing.Point(697, 49);
            this.followers_num.Name = "followers_num";
            this.followers_num.Size = new System.Drawing.Size(51, 20);
            this.followers_num.TabIndex = 4;
            this.followers_num.Text = "label2";
            // 
            // viewfollowing_button
            // 
            this.viewfollowing_button.Location = new System.Drawing.Point(213, 90);
            this.viewfollowing_button.Name = "viewfollowing_button";
            this.viewfollowing_button.Size = new System.Drawing.Size(163, 47);
            this.viewfollowing_button.TabIndex = 5;
            this.viewfollowing_button.Text = "View all following";
            this.viewfollowing_button.UseVisualStyleBackColor = true;
            this.viewfollowing_button.Click += new System.EventHandler(this.viewfollowing_button_Click);
            // 
            // viewfollowers_button
            // 
            this.viewfollowers_button.Location = new System.Drawing.Point(630, 90);
            this.viewfollowers_button.Name = "viewfollowers_button";
            this.viewfollowers_button.Size = new System.Drawing.Size(163, 47);
            this.viewfollowers_button.TabIndex = 6;
            this.viewfollowers_button.Text = "View all followers";
            this.viewfollowers_button.UseVisualStyleBackColor = true;
            this.viewfollowers_button.Click += new System.EventHandler(this.viewfollowers_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Suggested for you :";
            // 
            // search_textBox
            // 
            this.search_textBox.Location = new System.Drawing.Point(268, 168);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(191, 26);
            this.search_textBox.TabIndex = 8;
            this.search_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.search_textBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Search people";
            // 
            // table1
            // 
            this.table1.AllowUserToAddRows = false;
            this.table1.AllowUserToOrderColumns = true;
            this.table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table1.Location = new System.Drawing.Point(154, 245);
            this.table1.Name = "table1";
            this.table1.RowTemplate.Height = 28;
            this.table1.Size = new System.Drawing.Size(584, 193);
            this.table1.TabIndex = 11;
            this.table1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.table1_CellContentClick);
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(816, 341);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(106, 45);
            this.back_button.TabIndex = 12;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // FollowersFollowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 653);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.search_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewfollowers_button);
            this.Controls.Add(this.viewfollowing_button);
            this.Controls.Add(this.followers_num);
            this.Controls.Add(this.following_num);
            this.Controls.Add(this.followers_label);
            this.Controls.Add(this.follwoing_label);
            this.Name = "FollowersFollowing";
            this.Text = "FollowersFollowing";
            this.Load += new System.EventHandler(this.FollowersFollowing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Follower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFollowerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource dataSetFollowerBindingSource;
        private DataSet_Follower dataSet_Follower;
        private System.Windows.Forms.Label follwoing_label;
        private System.Windows.Forms.Label followers_label;
        private System.Windows.Forms.Label following_num;
        private System.Windows.Forms.Label followers_num;
        private System.Windows.Forms.Button viewfollowing_button;
        private System.Windows.Forms.Button viewfollowers_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView table1;
        private System.Windows.Forms.Button back_button;
    }
}