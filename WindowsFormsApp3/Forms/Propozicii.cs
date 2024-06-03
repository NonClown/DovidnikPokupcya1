using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Propozicii : Form
    {
        public Propozicii()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Golovna form1 = new Golovna();


            form1.StartPosition = FormStartPosition.CenterScreen;


            form1.Show();


            this.Close();
        }
        private void Propozicii_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {



            dodavannya redag = new dodavannya();
            redag.StartPosition = FormStartPosition.CenterScreen;

            redag.Show();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            vidalennya redag = new vidalennya();
            redag.StartPosition = FormStartPosition.CenterScreen;

            redag.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            redaguvannya redag = new redaguvannya();
            redag.StartPosition = FormStartPosition.CenterScreen;

            redag.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
