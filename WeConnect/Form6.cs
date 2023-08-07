using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WeConnect
{

    public partial class Form6 : Form
    {
        OracleConnection conn;
        String currpostid="";
        int i=0,max_i;
        int userid;

        public Form6(int user_id)
        {
            InitializeComponent();
            userid = user_id;
        }

        private void LoadPFP()
        {
            DB_Connect();
            OracleDataAdapter adap = new OracleDataAdapter();
            String query = "select * from details where user_id='" + userid +"'";
            adap.SelectCommand = new OracleCommand(query,conn);
            OracleDataReader dr2 = adap.SelectCommand.ExecuteReader();
            /*if (dr2.Read())
                MessageBox.Show("Following query executed");
            else
                MessageBox.Show("Following query not executed");*/
            DataTable dtable1 = new DataTable();
            adap.Fill(dtable1);
            DataRow dataRow = dtable1.Rows[0];
            Image img = null;
            FileStream fs = null;
            fs = new FileStream("image1.jpg", FileMode.Open, FileAccess.ReadWrite);
            byte[] blob = (byte[])dataRow[9];
            try
            {
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
            conn.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            commentbox.Text = "Enter comment here";
            LoadPFP();
            loadfeed();
        }

        private void loadfeed()
        {
            DB_Connect();
            OracleDataAdapter adap1 = new OracleDataAdapter();
            String query2 = "select count(*) from posts where photo_id in(select photo_id from postinterest where interest_id in(select interest_id from interests where interest_id in(select interest_id from userinterest where user_id='" + userid + "'))) and creator_id in(select followee_id from following where follower_id='" + userid + "')";
            adap1.SelectCommand = new OracleCommand(query2, conn);
            /*OracleDataReader dr2 = adap1.SelectCommand.ExecuteReader();
            if (dr2.Read())
                MessageBox.Show("Following query executed");
            else
                MessageBox.Show("Following query not executed");*/
            DataTable dt2 = new DataTable();
            adap1.Fill(dt2);
            DataRow dataRow2 = dt2.Rows[0];
            max_i = Convert.ToInt32(dataRow2[0]);
            conn.Close();

            if (max_i != 0)
            {
                DB_Connect();
                OracleDataAdapter adap = new OracleDataAdapter();
                String query1 = "select * from posts where photo_id in(select photo_id from postinterest where interest_id in(select interest_id from interests where interest_id in(select interest_id from userinterest where user_id='" + userid + "'))) and creator_id in(select followee_id from following where follower_id='" + userid + "')";
                adap.SelectCommand = new OracleCommand(query1, conn);
                /*OracleDataReader dr1 = adap.SelectCommand.ExecuteReader();
                if (dr1.Read())
                    MessageBox.Show("Following query executed");
                else
                    MessageBox.Show("Following query not executed");*/

                DataTable dt1 = new DataTable();
                adap.Fill(dt1);
                DataRow dataRow = dt1.Rows[i];
                String caption1 = dataRow[1].ToString();
                int creatorid1 = Convert.ToInt32(dataRow[2]);
                byte[] blob = (byte[])dataRow[3];
                currpostid = dataRow[0].ToString();

                Image img = null;
                FileStream fs = null;
                try
                {
                    fs = new FileStream("pfp1.jpg", FileMode.Open, FileAccess.ReadWrite);
                    fs.Write(blob, 0, blob.Length);
                    img = Image.FromStream(fs);
                    pictureBox3.Image = img;
                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox3.Refresh();
                }
                finally
                {
                    fs.Close();
                }

                conn.Close();

                DB_Connect();
                OracleDataAdapter adap3 = new OracleDataAdapter();
                String query3 = "select name,username from details where user_id='" + creatorid1 + "'";
                adap3.SelectCommand = new OracleCommand(query3, conn);
                DataTable dt3 = new DataTable();
                adap3.Fill(dt3);
                DataRow dr3 = dt3.Rows[0];
                String creatorname = dr3[0].ToString();
                String creatorusername = dr3[1].ToString();

                Creator_name.Text = creatorname;
                creatorusername1.Text = creatorusername;
                caption_textbox.Text = caption1;
                conn.Close();

                countlikes();

                countcomments();

                DB_Connect();
                String query6 = "select * from likes where user_id='"+userid+"' and post_id='"+currpostid+"'";
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

                noposts.Visible = false;
                panel2.Visible = true;
                button_prev.Visible = true;
                button_next.Visible = true;
            }
            else
            {
                noposts.Visible = true;
                panel2.Visible = false;
                button_prev.Visible = false;
                button_next.Visible = false;
            }   

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
            likes_num.Text = numlikes;
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
            comments_num.Text = numcomments;
            conn.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Myprofile m = new Myprofile(userid);
            m.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadfeed();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            PostPhoto pp = new PostPhoto(userid);
            pp.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FollowersFollowing f = new FollowersFollowing(userid);
            f.Show();
            this.Hide();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (i != max_i-1)
            {
                i = i + 1;
                loadfeed();
            }
        }

        private void comments_label_Click(object sender, EventArgs e)
        {
            ViewAllComments f = new ViewAllComments(userid,currpostid,Convert.ToInt32(comments_num.Text));
            f.Show();
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            String comment1 = commentbox.Text;
            DB_Connect();
            String query_inscomm = "insert into comments values('" + userid + "','" + currpostid + "',generate_commentid(),'" + comment1 +"')";
            OracleDataAdapter adap = new OracleDataAdapter();
            adap.SelectCommand = new OracleCommand(query_inscomm, conn);
            if (adap.SelectCommand.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Comment inserted");
                comments_num.Text = (Convert.ToInt32(comments_num.Text) + 1).ToString();
            }
            else
            {
                MessageBox.Show("Comment not inserted");
            }
            conn.Close();

            panel3.Visible = false;
        }

        private void comment_button_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
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

        private void cancel_button_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
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
                likes_num.Text = (Convert.ToInt32(likes_num.Text) + 1).ToString();

            }
            else if( like_button.Text == "Remove Like" )
            {
                DB_Connect();
                String query_remlike="delete from likes where user_id = '" + userid + "' and post_id ='" + currpostid + "'";
                OracleDataAdapter adap = new OracleDataAdapter();
                adap.SelectCommand = new OracleCommand(query_remlike, conn);
                if (adap.SelectCommand.ExecuteNonQuery() > 0)
                    MessageBox.Show("Like removed");
                else
                    MessageBox.Show("Like not removed");
                conn.Close();
                like_button.Text = "Like post";
                likes_num.Text = (Convert.ToInt32(likes_num.Text) - 1).ToString();
            }
        }

        private void likes_label_Click(object sender, EventArgs e)
        {
            ViewAllLikes f = new ViewAllLikes(userid, currpostid, Convert.ToInt32(likes_num.Text));
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Messaging f = new Messaging(userid);
            f.Show();
            this.Hide();
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            if (i != 0)
            {
                i = i - 1;
                loadfeed();
            }
        }
    }
}
