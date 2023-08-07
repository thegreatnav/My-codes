namespace WeConnect
{
    partial class ViewAllFollowers
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
            this.back_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new WeConnect.DataSet1();
            this.dataSet_followingtableonly = new WeConnect.DataSet_followingtableonly();
            this.fOLLOWINGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fOLLOWINGTableAdapter = new WeConnect.DataSet_followingtableonlyTableAdapters.FOLLOWINGTableAdapter();
            this.dataSet_Follower = new WeConnect.DataSet_Follower();
            this.dataSetFollowerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_followingtableonly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fOLLOWINGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Follower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFollowerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(330, 403);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(105, 35);
            this.back_button.TabIndex = 0;
            this.back_button.Text = "Back";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(776, 366);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet_followingtableonly
            // 
            this.dataSet_followingtableonly.DataSetName = "DataSet_followingtableonly";
            this.dataSet_followingtableonly.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fOLLOWINGBindingSource
            // 
            this.fOLLOWINGBindingSource.DataMember = "FOLLOWING";
            this.fOLLOWINGBindingSource.DataSource = this.dataSet_followingtableonly;
            // 
            // fOLLOWINGTableAdapter
            // 
            this.fOLLOWINGTableAdapter.ClearBeforeFill = true;
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
            // ViewAllFollowers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.back_button);
            this.Name = "ViewAllFollowers";
            this.Text = "ViewAllFollowers";
            this.Load += new System.EventHandler(this.ViewAllFollowers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_followingtableonly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fOLLOWINGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Follower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFollowerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet_followingtableonly dataSet_followingtableonly;
        private System.Windows.Forms.BindingSource fOLLOWINGBindingSource;
        private DataSet_followingtableonlyTableAdapters.FOLLOWINGTableAdapter fOLLOWINGTableAdapter;
        private DataSet_Follower dataSet_Follower;
        private System.Windows.Forms.BindingSource dataSetFollowerBindingSource;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet1;
    }
}