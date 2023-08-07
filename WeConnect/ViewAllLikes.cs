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
    public partial class ViewAllLikes : Form
    {
        OracleConnection conn;
        int userid, numcomm;
        String postid;
        public ViewAllLikes(int user_id,String post_id,int num_comm)
        {
            InitializeComponent();
            userid = user_id;
            numcomm = num_comm;
            postid = post_id;
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

        private void ViewAllLikes_Load(object sender, EventArgs e)
        {
            DB_Connect();
            OracleDataAdapter adap1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable("Data1");
            String query1 = " select name,username from details natural join likes where post_id='" + postid +"'";
            adap1.SelectCommand = new OracleCommand(query1, conn);
            OracleDataReader dr = adap1.SelectCommand.ExecuteReader();
            /*if (dr.Read())
                MessageBox.Show("Query Executed");
            else
                MessageBox.Show("Query not executed");*/
            adap1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            conn.Close();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
