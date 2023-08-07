using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WeConnect
{
    public partial class Messaging : Form
    {
        OracleConnection conn;
        int userid;
        public Messaging(int user_id)
        {
            InitializeComponent();
            userid = user_id;
        }

        public void DB_Connect()
        {
            String oradb = "Data Source=localhost:1521/orclpdb;User ID = NAV;Password = vkohli18";
            conn = new OracleConnection(oradb);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Messaging_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn msgButton = new DataGridViewButtonColumn();
            msgButton.Name = "Message Status";
            msgButton.HeaderText = "Message Status";
            msgButton.Text = "Message";
            msgButton.UseColumnTextForButtonValue = true;
            table1.Columns.Add(msgButton);
        }

        private void search_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(userid);
            f.Show();
            this.Hide();
        }

        private void search_textBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (search_textBox.Text != "")
            {
                DB_Connect();
                OracleDataAdapter adap = new OracleDataAdapter();
                DataTable dt = new DataTable("Data");
                String query = "select name,username,user_id from details where user_id in(select follower_id from following where follower_id in(select followee_id from following where follower_id='"+userid+"')) and name like '%"+search_textBox.Text+"%'";
                adap.SelectCommand = new OracleCommand(query, conn);
                adap.Fill(dt);
                table1.DataSource = dt;
                conn.Close();
                foreach (DataGridViewRow dataRow in table1.Rows)
                {
                    DataGridViewButtonCell msgcell = new DataGridViewButtonCell();
                    msgcell.Value = "Message";
                    conn.Close();
                }
            }
            else
            {
                table1.Refresh();
            }
        }

        private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (table1.Columns[e.ColumnIndex].Name == "Message Status")
            {
                DataGridViewButtonCell a = (DataGridViewButtonCell)table1.Rows[e.RowIndex].Cells[0];
                int messagetoid= Convert.ToInt32(table1.Rows[e.RowIndex].Cells[3].Value);
                Chats f = new Chats(userid,messagetoid);
                f.Show();
                this.Hide();

            }
            table1.Refresh();
        }
    }
}
