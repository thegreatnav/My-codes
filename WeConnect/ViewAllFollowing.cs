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
    public partial class ViewAllFollowing : Form
    {
        OracleConnection conn;
        int userid;
        public ViewAllFollowing(int user_id)
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

        private void back_button_Click(object sender, EventArgs e)
        {
            FollowersFollowing f = new FollowersFollowing(userid);
            f.Show();
            this.Hide();
        }

        private void ViewAllFollowing_Load(object sender, EventArgs e)
        {
            DB_Connect();
            OracleDataAdapter adap = new OracleDataAdapter();
            DataTable dt = new DataTable("Data2");
            String query = "select user_id,name,username from details where user_id in (select followee_id from following where follower_id='" + userid + "')";
            adap.SelectCommand = new OracleCommand(query, conn);
            OracleDataReader dr = adap.SelectCommand.ExecuteReader();
            /*if (dr.Read())
                MessageBox.Show("Query Executed");
            else
                MessageBox.Show("Query not executed");*/
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
