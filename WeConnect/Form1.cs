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
    public partial class Form1 : Form
    {
        private Rectangle buttonOriginalRectangle;
        private Rectangle originalFormSize;
        public Form1()
        { 
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            originalFormSize = new Rectangle(this.Location.X,this.Location.Y,this.Size.Width,this.Size.Height);
            buttonOriginalRectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
            

        }
           
        private void resizeControl(Rectangle r,Control c)
        {
            float xratio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yratio = (float)(this.Height) / (float)(originalFormSize.Height);
            int newX = (int)(r.Width * xratio);
            int newY = (int)(r.Height * yratio);
            int newWidth = (int)(r.Width * xratio);
            int newHeight = (int)(r.Height * yratio);
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resizeControl(buttonOriginalRectangle, button1);
        }
    }
}
