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
    public partial class Myprofile : Form
    {
        OracleConnection conn;
        OracleDataAdapter empadap,empadap2;
        DataTable dtable;
        int userid;
        String currpostid = "";
        String imagename;
        public Myprofile(int user_id)
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
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                imagename = opnfd.FileName;
                DB_Connect();
                FileStream fls;
                fls = new FileStream(imagename, FileMode.Open, FileAccess.Read);
                byte[] blob = new byte[fls.Length];
                fls.Read(blob, 0, Convert.ToInt32(fls.Length));
                fls.Close();
                String query1 = "update details set p_pict=:BlobParameter where user_id='" + userid + "'";
                OracleParameter blobParameter = new OracleParameter();
                blobParameter.OracleDbType = OracleDbType.Blob;
                blobParameter.ParameterName = "BlobParameter";
                blobParameter.Value = blob;
                OracleCommand cmnd = new OracleCommand(query1, conn);
                cmnd.Parameters.Add(blobParameter);
                cmnd.ExecuteNonQuery();
                //MessageBox.Show("added to blob field");
                conn.Close();
            }
        }

        private void Myprofile_Load(object sender, EventArgs e)
        {
            refreshmyprofile();            
        }

        private void refreshmyprofile()
        {
            DB_Connect();
            empadap = new OracleDataAdapter();
            empadap2 = new OracleDataAdapter();
            try
            {
                String query = "Select caption,photo,photo_id from posts natural join details where details.user_id=posts.creator_id and details.user_id='" + userid + "'";
                empadap.SelectCommand = new OracleCommand(query, conn);
                dtable = new DataTable();
                empadap.Fill(dtable);
                comboBox1.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    comboBox1.Items.Add(drow[0].ToString());
                    comboBox1.SelectedIndex = 0;
                }

                String query1 = "Select * from details where user_id='" + userid + "'";
                empadap2.SelectCommand = new OracleCommand(query1, conn);
                DataTable dtable1 = new DataTable("Data1");
                empadap2.Fill(dtable1);
                DataRow dataRow1 = dtable1.Rows[0];
                byte[] blob = (byte[])dataRow1[9];

                Image img = null;
                FileStream fs = null;
                try
                {
                    fs = new FileStream("pfp1.jpg", FileMode.Open, FileAccess.ReadWrite);
                    fs.Write(blob, 0, blob.Length);
                    img = Image.FromStream(fs);
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Refresh();
                }
                finally
                {
                    fs.Close();
                }

                String name2 = Convert.ToString(dataRow1[0]);
                String username2 = Convert.ToString(dataRow1[1]);
                String password2 = Convert.ToString(dataRow1[2]);
                String email2 = Convert.ToString(dataRow1[3]);
                String org2 = Convert.ToString(dataRow1[4]);
                String age2 = Convert.ToString(dataRow1[8]);
                name1.Text = name2;
                username1.Text = username2;
                password1.Text = password2;
                email1.Text = email2;
                org1.Text = org2;
                age1.Text = age2;
                label8.Text = userid.ToString();
                commentbox.Text = "Enter comment here";
                panel1.Visible = false;
                panel1.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
            conn.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void countlikes()
        {
            DB_Connect();
            OracleDataAdapter adap4 = new OracleDataAdapter();
            String query = "select count(like_id) from likes where post_id='" + currpostid + "'";
            adap4.SelectCommand = new OracleCommand(query, conn);
            /*OracleDataReader dr1 = adap4.SelectCommand.ExecuteReader();
            if (dr1.Read())
                MessageBox.Show("Countlikes query executed");
            else
                MessageBox.Show("Countlikes query not executed");*/
            DataTable dt4 = new DataTable();
            adap4.Fill(dt4);
            DataRow dr4 = dt4.Rows[0];
            String numlikes = dr4[0].ToString();
            like_num.Text = numlikes;
            conn.Close();
        }

        public void countcomments()
        {
            DB_Connect();
            OracleDataAdapter adap5 = new OracleDataAdapter();
            String query5 = "select count(comment_id) from comments where post_id='" + currpostid + "'";
            adap5.SelectCommand = new OracleCommand(query5, conn);
            /*OracleDataReader dr1 = adap5.SelectCommand.ExecuteReader();
            if (dr1.Read())
                MessageBox.Show("Countcomments query executed");
            else
                MessageBox.Show("Countcomments query not executed");*/
            DataTable dt5 = new DataTable();
            adap5.Fill(dt5);
            DataRow dr5 = dt5.Rows[0];
            String numcomments = dr5[0].ToString();
            comment_num.Text = numcomments;
            conn.Close();
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            DB_Connect();
            String name2 = name1.Text;
            String username2 = username1.Text;
            String password2 = password1.Text;
            String email2 = email1.Text;
            String org2 = org1.Text;
            String age2 = age1.Text;
            String query = "update details set name='" + name2 + "',username='" + username2 + "',password='" + password2 + "',email='" + email2 + "',org='" + org2 + "',age='" + age2 + "' where user_id='"+userid+"'";
            OracleDataAdapter adap1 = new OracleDataAdapter();
            adap1.SelectCommand = new OracleCommand(query, conn);
            if (adap1.SelectCommand.ExecuteNonQuery() > 0)
                MessageBox.Show("Details updated");
            else
                MessageBox.Show("Details not updated");
            conn.Close();
            Form6 frm = new Form6(userid);
            frm.Show();
            this.Hide();
        }

        private void show_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            Image img = null;
            FileStream fs = null;
            fs = new FileStream("image1.jpg", FileMode.Open, FileAccess.ReadWrite);
            try
            {   
                foreach (DataRow dataRow2 in dtable.Rows)
                {
                    if (dataRow2[0].ToString() == comboBox1.SelectedItem.ToString())
                    {
                        byte[] blob = (byte[])dataRow2[1];
                        fs.Write(blob, 0, blob.Length);
                        img = Image.FromStream(fs);
                        pictureBox2.Image = img;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox2.Refresh();
                        currpostid = dataRow2[2].ToString();
                        richTextBox1.Text = dataRow2[0].ToString();
                        countcomments();
                        countlikes();
                        DB_Connect();
                        String query6 = "select * from likes where user_id='" + userid + "' and post_id='" + currpostid + "'";
                        OracleDataAdapter adap6 = new OracleDataAdapter();
                        adap6.SelectCommand = new OracleCommand(query6, conn);
                        OracleDataReader dr6 = adap6.SelectCommand.ExecuteReader();
                        if (dr6.Read())
                        {
                            like_button.Text = "Remove Like";
                        }
                        else
                        {
                            like_button.Text = "Like Post";
                        }
                        conn.Close();
                    }
                }
            }
            finally
            {
                fs.Close();
            }
        }

        private void name1_TextChanged(object sender, EventArgs e)
        {

        }

        private void like_button_Click(object sender, EventArgs e)
        {
            if (like_button.Text == "Like Post")
            {
                DB_Connect();
                String query_inslike = "insert into likes values('" + userid + "','" + currpostid + "',generate_likeid())";
                OracleDataAdapter adap = new OracleDataAdapter();
                adap.SelectCommand = new OracleCommand(query_inslike, conn);
                if (adap.SelectCommand.ExecuteNonQuery() > 0)
                    MessageBox.Show("Like inserted");
                else
                    MessageBox.Show("Like not inserted");
                conn.Close();
                like_button.Text = "Remove Like";
                like_num.Text = (Convert.ToInt32(like_num.Text) + 1).ToString();

            }
            else if (like_button.Text == "Remove Like")
            {
                DB_Connect();
                String query_remlike = "delete from likes where user_id = '" + userid + "' and post_id ='" + currpostid + "'";
                OracleDataAdapter adap = new OracleDataAdapter();
                adap.SelectCommand = new OracleCommand(query_remlike, conn);
                if (adap.SelectCommand.ExecuteNonQuery() > 0)
                    MessageBox.Show("Like removed");
                else
                    MessageBox.Show("Like not removed");
                conn.Close();
                like_button.Text = "Like post";
                like_num.Text = (Convert.ToInt32(like_num.Text) - 1).ToString();
            }
        }

        private void comment_label_Click(object sender, EventArgs e)
        {
            ViewAllComments f = new ViewAllComments(userid, currpostid, Convert.ToInt32(comment_num.Text));
            f.Show();
        }

        private void like_label_Click(object sender, EventArgs e)
        {
            ViewAllLikes f = new ViewAllLikes(userid, currpostid, Convert.ToInt32(like_num.Text));
            f.Show();
        }

        private void comment_button_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            String comment1 = commentbox.Text;
            DB_Connect();
            String query_inscomm = "insert into comments values('" + userid + "','" + currpostid + "',generate_commentid(),'" + comment1 + "')";
            OracleDataAdapter adap = new OracleDataAdapter();
            adap.SelectCommand = new OracleCommand(query_inscomm, conn);
            if (adap.SelectCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Comment inserted");
                comment_num.Text = (Convert.ToInt32(comment_num.Text) + 1).ToString();
            }
            else
            {
                MessageBox.Show("Comment not inserted");
            }
            conn.Close();

            panel2.Visible = false;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void commentbox_Enter(object sender, EventArgs e)
        {
            if (commentbox.Text == "Enter comment here")
            {
                commentbox.Text = "";
            }
        }

        private void commentbox_Leave(object sender, EventArgs e)
        {
            if (commentbox.Text == "")
            {
                commentbox.Text = "Enter comment here";
                commentbox.ForeColor = Color.Gray;
            }
        }

        private void editcaption_button_Click(object sender, EventArgs e)
        {
            DB_Connect();
            String query = "update posts set caption = '"+richTextBox1.Text+"' where photo_id='"+currpostid+"'";
            OracleDataAdapter adap = new OracleDataAdapter();
            adap.SelectCommand = new OracleCommand(query, conn);
            if (adap.SelectCommand.ExecuteNonQuery() > 0)
                MessageBox.Show("Caption updated");
            else
                MessageBox.Show("Caption not updated");
            conn.Close();
            refreshmyprofile();
        }

        private void deletepost_button_Click(object sender, EventArgs e)
        {
            String query1 = "delete from postinterest where photo_id='" + currpostid + "'";
            String query2 = "delete from posts where photo_id='" + currpostid + "'";
            DB_Connect();
            OracleDataAdapter adap1 = new OracleDataAdapter();
            adap1.SelectCommand = new OracleCommand(query1, conn);
            if (adap1.SelectCommand.ExecuteNonQuery() > 0)
                MessageBox.Show("Deleted from postinterest");
            else
                MessageBox.Show("Not deleted from postinterest");
            conn.Close();

            DB_Connect();
            OracleDataAdapter adap2 = new OracleDataAdapter();
            adap2.SelectCommand = new OracleCommand(query2, conn);
            if (adap2.SelectCommand.ExecuteNonQuery() > 0)
                MessageBox.Show("Deleted from posts");
            else
                MessageBox.Show("Not deleted from posts");
            conn.Close();
            refreshmyprofile();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
