using System;
using System.IO;
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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        String imagename;
        String userid="";

        public Form3()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void DB_Connect()
        {
            String oradb = "Data Source=localhost:1521/orclpdb;User ID = NAV;Password = vkohli18";
            conn = new OracleConnection(oradb);
            try
            {
                conn.Open();
                //MessageBox.Show("Connection Open");
            }
            catch(Exception e)
            {
                MessageBox.Show("Connection not established!");
            }
        }
        private void Signup_Click(object sender, EventArgs e)
        {
            DB_Connect();
            OracleCommand command = conn.CreateCommand();
            
            String name = textBox1.Text;
            String User_n = textBox2.Text;
            String password = textBox3.Text;
            String email = textBox4.Text;
            String org = textBox6.Text;
            String sec_q = comboBox1.Text;
            String sec_a = textBox5.Text;
            String age = textBox7.Text;
            //String user_id = textBox8.Text;

            try
            {
                //proceed only when the image has a valid path 
                if (imagename != "")
                {
                    FileStream fls;
                    fls = new FileStream(@imagename, FileMode.Open, FileAccess.Read);
                    byte[] blob = new byte[fls.Length];
                    fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                    fls.Close();
                    OracleCommand cmnd;
                    string query;
                    query = "insert into details values('" + name + "','" + User_n + "','" + password + "','" + email + "','" + org + "','" + sec_q + "','" + sec_a + "'," + "generate_user()" + ",'" + age + "',:BlobParameter)";
                    OracleParameter blobParameter = new OracleParameter();
                    blobParameter.OracleDbType = OracleDbType.Blob;
                    blobParameter.ParameterName = "BlobParameter";
                    blobParameter.Value = blob;
                    cmnd = new OracleCommand(query, conn);
                    cmnd.Parameters.Add(blobParameter);
                    cmnd.ExecuteNonQuery();
                    MessageBox.Show("added to blob field");
                    cmnd.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            generateuserid();

            Form4 frm = new Form4(Convert.ToInt32(userid)-1);
            frm.Show();
            this.Hide();
        }

        private void generateuserid()
        {
            DB_Connect();
            OracleDataAdapter adap = new OracleDataAdapter();
            String query = "select generate_user() from dual";
            adap.SelectCommand = new OracleCommand(query, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            DataRow dr1 = dt.Rows[0];
            userid = dr1[0].ToString();
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DB_Connect();
            FileDialog fldlg = new OpenFileDialog();
            fldlg.InitialDirectory = @":C\Users\91949\";
            fldlg.Filter = "Image File (*.jpg;*.gif;*.bmp) | *.jpg;*.gif;*.bmp";
            if (fldlg.ShowDialog() == DialogResult.OK)
            {
                imagename = fldlg.FileName;
                Bitmap newimg = new Bitmap(imagename);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = (Image)newimg;
            }
            fldlg = null;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Name Should not be left blank!!");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string email = textBox4.Text;
            if (!IsValidEmail(email))
            {
                e.Cancel = true;
                textBox4.SelectAll();
                errorProvider2.SetError(textBox4, "Please enter a valid email address");
            }
            else
            {
                errorProvider2.SetError(textBox4, "");
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
