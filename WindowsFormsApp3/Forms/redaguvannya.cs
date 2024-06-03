using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class redaguvannya : Form
    {
        private ClassRedag magazinManager;
        private List<Magazin> magazins;

        public redaguvannya()
        {
            InitializeComponent();
            InitializeUI();
            magazinManager = new ClassRedag("C:\\Users\\Lenovo\\.vscode\\data.json");
            magazins = magazinManager.GetMagazins();

            foreach (var magazin in magazins)
            {
                comboBox1.Items.Add(magazin.MagazinName);
            }
        }

        private void InitializeUI()
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            button1.Click += button1_Click;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < magazins.Count)
            {
                var selectedMagazin = magazins[selectedIndex];
                textBox6.Text = selectedMagazin.MagazinName;
                textBox1.Text = selectedMagazin.Adresa;
                textBox2.Text = selectedMagazin.Kontakti;
                textBox3.Text = selectedMagazin.ChasRoboti;
                textBox4.Text = selectedMagazin.FormaVlasnosti;
                textBox5.Text = selectedMagazin.Specializacia;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < magazins.Count)
            {
                var selectedMagazin = magazins[selectedIndex];
                selectedMagazin.MagazinName = textBox6.Text;
                selectedMagazin.Adresa = textBox1.Text;
                selectedMagazin.Kontakti = textBox2.Text;
                selectedMagazin.ChasRoboti = textBox3.Text;
                selectedMagazin.FormaVlasnosti = textBox4.Text;
                selectedMagazin.Specializacia = textBox5.Text;

                magazinManager.SaveMagazins("C:\\Users\\Lenovo\\.vscode\\data.json");

                MessageBox.Show("Перемога! Магазин успішно збережено");
                this.Close();
            }

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void redaguvannya_Load(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}




