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
    public partial class Chats : Form
    {
        OracleConnection conn;
        int sid,rid;

        public Chats(int user_id,int user_id2)
        {
            InitializeComponent();
            sid = user_id;
            rid = user_id2;
        }

        private void Chats_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Sender :" + (sid.ToString()) + " Reciever :" + (rid.ToString()));
            DB_Connect();
            OracleDataAdapter adap = new OracleDataAdapter();
            DataTable dt = new DataTable();
            String query = "select message_id,s_id,text from messages where s_id='" + sid + "' and r_id='" + rid + "' union select message_id,s_id,text from messages where s_id='" + rid + "' and r_id='" + sid + "'";
            adap.SelectCommand = new OracleCommand(query, conn);
            OracleDataReader dr = adap.SelectCommand.ExecuteReader();
            if (dr.Read())
                MessageBox.Show("Query Executed");
            else
                MessageBox.Show("Query not executed");
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Messaging f = new Messaging(sid);
            f.Show();
            this.Hide();
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
    }
}
