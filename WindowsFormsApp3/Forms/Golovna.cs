using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class Golovna : Form
    {
        public Golovna()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Propozicii propoz = new Propozicii();

            propoz.StartPosition = FormStartPosition.CenterScreen;

            propoz.Show();

            this.Hide();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PoshukForm poshukForm = new PoshukForm();

            poshukForm.StartPosition = FormStartPosition.CenterScreen;

            poshukForm.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Width = this.Width - panel1.Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();


            SpisokKramnic spisokKr = new SpisokKramnic(this);


            spisokKr.Show();
        }
        private void PoshukForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
