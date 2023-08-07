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
    public partial class Form5 : Form
    {
        OracleConnection conn;
        String username, password;
        int user_id;
        public Form5()
        {
            InitializeComponent();
        }

        void DBConnect()
        {
            conn = new OracleConnection("Data Source=localhost:1521/orclpdb;User ID = NAV;Password = vkohli18");
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection not established");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            DBConnect();
            Login();
            conn.Close();
        }

        private void Login()
        {
            OracleDataAdapter adap = new OracleDataAdapter();
            string selectString = "SELECT user_id " + " FROM details " + " WHERE username = '" + username + "' AND password = '" + password + "'";
            adap.SelectCommand = new OracleCommand(selectString, conn);
            OracleDataReader dr = adap.SelectCommand.ExecuteReader();
            if(dr.Read())
            {
                try
                {
                    DataTable dtable1 = new DataTable("Data1");
                    adap.Fill(dtable1);
                    DataRow dataRow = dtable1.Rows[0];
                    user_id = Convert.ToInt32(dataRow[0]);
                    //MessageBox.Show(user_id.ToString());
                }
                catch(Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
                Form6 frm = new Form6(user_id);
                this.Hide();
                frm.Show();
            }
            else
            {
                    MessageBox.Show("Login denied. Invalid Credentials");
                    textBox1.Text = "";
                    textBox2.Text = "";
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
