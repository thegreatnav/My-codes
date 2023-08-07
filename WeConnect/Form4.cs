using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.IO;

namespace WeConnect
{
    public partial class Form4 : Form
    {
        OracleConnection conn;
        int userid;
        public Form4(int user_id)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            String check1 = checkBox_food.CheckState.ToString();
            String check2 = checkBox_entertainment.CheckState.ToString();
            String check3 = checkBox_sports.CheckState.ToString();
            String check4 = checkBox_travel.CheckState.ToString();

            if(check1=="Checked")
            {
                DB_Connect();
                OracleDataAdapter adap1 = new OracleDataAdapter();
                String query = "insert into userinterest values(" + userid + ",1)";
                adap1.SelectCommand = new OracleCommand(query, conn);
                adap1.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (check2=="Checked")
            {
                DB_Connect();
                OracleDataAdapter adap2 = new OracleDataAdapter();
                String query = "insert into userinterest values(" + userid + ",2)";
                adap2.SelectCommand = new OracleCommand(query, conn);
                adap2.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (check3=="Checked")
            {
                DB_Connect();
                OracleDataAdapter adap3 = new OracleDataAdapter();
                String query = "insert into userinterest values(" + userid + ",3)";
                adap3.SelectCommand = new OracleCommand(query, conn);
                adap3.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (check4=="Checked")
            {
                DB_Connect();
                OracleDataAdapter adap4 = new OracleDataAdapter();
                String query = "insert into userinterest values(" + userid + ",4)";
                adap4.SelectCommand = new OracleCommand(query, conn);
                adap4.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            Form6 frm = new Form6(userid);
            this.Hide();
            frm.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
