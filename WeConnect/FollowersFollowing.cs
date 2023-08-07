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
using System.IO;

namespace WeConnect
{
    public partial class FollowersFollowing : Form
    {
        OracleConnection conn;
        int userid;
        DataGridViewButtonColumn followButton;
        public FollowersFollowing(int user_id)
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

        private void following_num_Click(object sender, EventArgs e)
        {

        }

        private void search_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if(search_textBox.Text!="")
            {
                DB_Connect();
                OracleDataAdapter adap=new OracleDataAdapter();
                DataTable dt = new DataTable("Data");
                String query="select name,username,org,user_id from details where name like '%"+search_textBox.Text+"%' minus select name,username,org,user_id from details where user_id='"+userid+"'";
                adap.SelectCommand = new OracleCommand(query, conn);
                adap.Fill(dt);
                table1.DataSource = dt;
                conn.Close();
                foreach(DataGridViewRow dataRow in table1.Rows)
                {
                    DB_Connect();
                    String query1 = "select * from following where follower_id='" + userid + "' and followee_id='" + Convert.ToInt32(dataRow.Cells[4].Value) + "'";
                    OracleDataAdapter adap1 = new OracleDataAdapter();
                    adap1.SelectCommand = new OracleCommand(query1, conn);
                    OracleDataReader dr1 = adap1.SelectCommand.ExecuteReader();
                    DataGridViewButtonCell followcell = new DataGridViewButtonCell();
                    if (dr1.Read())
                    {
                        followcell.Value = "Following";
                        dataRow.Cells[0] = followcell;
                    }
                    else
                    {
                        followcell.Value = "Follow";
                        dataRow.Cells[0] = followcell;
                    }
                    conn.Close();
                }
            }
            else
            {
                table1.Refresh();
            }

        }

        private void FollowersFollowing_Load(object sender, EventArgs e)
        {
            int n1=0, n2=0;
            DB_Connect();
            OracleDataAdapter adap1 = new OracleDataAdapter();
            OracleDataAdapter adap2 = new OracleDataAdapter();
            String following1 = "select count(*) from details where user_id in (select followee_id from following where follower_id='" + userid + "')";
            String follower1 = "select count(*) from details where user_id in (select follower_id from following where followee_id='" + userid + "')";
            adap1.SelectCommand = new OracleCommand(following1, conn);
            /*OracleDataReader dr1 = adap1.SelectCommand.ExecuteReader();
            if (dr1.Read())
                MessageBox.Show("Following query executed");
            else
                MessageBox.Show("Following query not executed");*/
            adap2.SelectCommand = new OracleCommand(follower1, conn);
            /*OracleDataReader dr2 = adap2.SelectCommand.ExecuteReader();
            if (dr2.Read())
                MessageBox.Show("Follower query executed");
            else
                MessageBox.Show("Follower query not executed");*/
            DataTable dt1 = new DataTable();
            adap1.Fill(dt1);
            DataRow dataRow1 = dt1.Rows[0];
            n1 = Convert.ToInt32(dataRow1[0]);
            following_num.Text = n1.ToString();
            DataTable dt2 = new DataTable();
            adap2.Fill(dt2);
            DataRow dataRow2 = dt2.Rows[0];
            n2 = Convert.ToInt32(dataRow2[0]);
            followers_num.Text = n2.ToString();
            conn.Close();

            followButton = new DataGridViewButtonColumn();
            followButton.Name = "Follow Status";
            followButton.HeaderText = "Follow Status";
            followButton.Text = "Follow";
            followButton.UseColumnTextForButtonValue = true;
            table1.Columns.Add(followButton);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(userid);
            f.Show();
            this.Hide();
        }

        private void table1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (table1.Columns[e.ColumnIndex].Name == "Follow Status")
            {
                DataGridViewButtonCell a = (DataGridViewButtonCell)table1.Rows[e.RowIndex].Cells[0];
                //MessageBox.Show(a.Value.ToString());
                if (a.Value.ToString() == "Follow")
                {
                    int ans = Convert.ToInt32(table1.Rows[e.RowIndex].Cells[4].Value);
                    DB_Connect();
                    OracleDataAdapter adap = new OracleDataAdapter();
                    String query = "Insert into following values('" + userid + "','" + ans + "')";
                    adap.SelectCommand = new OracleCommand(query, conn);
                    if (adap.SelectCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Follow Executed");
                    }
                    else
                        MessageBox.Show("Follow not executed");
                    conn.Close();
                    a.Value = "Following";
                }
                else if(a.Value.ToString() == "Following")
                {
                    int ans = Convert.ToInt32(table1.Rows[e.RowIndex].Cells[4].Value);
                    //MessageBox.Show(ans.ToString());
                    DB_Connect();
                    OracleDataAdapter adap = new OracleDataAdapter();
                    String query = "delete from following where follower_id='" + userid + "' and followee_id='" + ans + "'";
                    adap.SelectCommand = new OracleCommand(query, conn);
                    if (adap.SelectCommand.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Query Executed");
                    }
                    else
                        MessageBox.Show("Query not executed");
                    conn.Close();
                    a.Value = "Follow";
                }
            }
            table1.Refresh();
        }

        private void viewfollowing_button_Click(object sender, EventArgs e)
        {
            ViewAllFollowing f = new ViewAllFollowing(userid);
            f.Show();
            this.Hide();
        }

        private void viewfollowers_button_Click(object sender, EventArgs e)
        {
            ViewAllFollowers f1 = new ViewAllFollowers(userid);
            f1.Show();
            this.Hide();
        }
    }
}
