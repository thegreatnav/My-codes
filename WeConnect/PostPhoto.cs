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
    public partial class PostPhoto : Form
    {
        OracleConnection conn;
        String imagename;
        int userid;
        public PostPhoto(int user_id)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(userid);
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception e12)
            {
                imagename = " ";
                MessageBox.Show(e12.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagename != "")
                {
                    FileStream fls;
                    fls = new FileStream(@imagename, FileMode.Open, FileAccess.Read);
                    byte[] blob = new byte[fls.Length];
                    fls.Read(blob, 0, System.Convert.ToInt32(fls.Length));
                    fls.Close();

                    DB_Connect();
                    OracleCommand cmnd;
                    string query;
                    int creatorid = userid;
                    query = "insert into posts values(create_photoid(),'"+ richTextBox1.Text+"',"+ creatorid+",:BlobParameter)";
                    //insert the byte as oracle parameter of type blob 
                    OracleParameter blobParameter = new OracleParameter();
                    blobParameter.OracleDbType = OracleDbType.Blob;
                    blobParameter.ParameterName = "BlobParameter";
                    blobParameter.Value = blob;
                    cmnd = new OracleCommand(query, conn);
                    cmnd.Parameters.Add(blobParameter);
                    cmnd.ExecuteNonQuery();
                    //MessageBox.Show("added to blob field");
                    cmnd.Dispose();
                    conn.Close();
                    conn.Dispose();

                    addHashtags();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Form6 f = new Form6(userid);
            f.Show();
            this.Hide();
        }

        private void addHashtags()
        {
            bool check1 = checkBox1.Checked;
            bool check2 = checkBox2.Checked;
            bool check3 = checkBox3.Checked;
            bool check4 = checkBox4.Checked;

            DB_Connect();
            OracleDataAdapter adap = new OracleDataAdapter();
            String query1 = "select max(photo_id) from posts";
            adap.SelectCommand = new OracleCommand(query1, conn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            DataRow dataRow = dt.Rows[0];
            int photoid = Convert.ToInt32(dataRow[0]);
            conn.Close();

            if (check1)
            {
                DB_Connect();
                OracleDataAdapter adap1 = new OracleDataAdapter();
                String query = "insert into postinterest values('" + photoid + "','1')";
                adap1.SelectCommand = new OracleCommand(query, conn);
                adap1.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (check2)
            {
                DB_Connect();
                OracleDataAdapter adap2 = new OracleDataAdapter();
                String query = "insert into postinterest values('" + photoid + "','2')";
                adap2.SelectCommand = new OracleCommand(query, conn);
                adap2.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (check3)
            {
                DB_Connect();
                OracleDataAdapter adap3 = new OracleDataAdapter();
                String query = "insert into postinterest values('" + photoid + "','3')";
                adap3.SelectCommand = new OracleCommand(query, conn);
                adap3.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }

            if (check4)
            {
                DB_Connect();
                OracleDataAdapter adap4 = new OracleDataAdapter();
                String query = "insert into postinterest values('" + photoid + "','4')";
                adap4.SelectCommand = new OracleCommand(query, conn);
                adap4.SelectCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PostPhoto_Load(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
