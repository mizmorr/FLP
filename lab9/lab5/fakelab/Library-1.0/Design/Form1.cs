using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "lab5";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Bitmap Image = new Bitmap("lab9funcs.bmp");
            pictureBox1.Image = (Image)Image;
            this.BackColor = Color.DarkSlateGray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
