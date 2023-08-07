using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace WeConnect
{
    public partial class ViewAllComments : Form
    {
        int userid,numcomments;
        String currpostid;
        OracleConnection conn;
        public ViewAllComments(int user_id,String post_id,int numcom)
        {
            InitializeComponent();
            userid = user_id;
            currpostid = post_id;
            numcomments = numcom;
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
            this.Hide();
        }

        private void ViewAllComments_Load(object sender, EventArgs e)
        {
            DB_Connect();
            OracleDataAdapter adap1 = new OracleDataAdapter();
            DataTable dt1 = new DataTable("Data1");
            String query1 = "select name,username,text from details natural join comments where post_id='" + currpostid + "'";
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
    }
}
