using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class SpisokKramnic : Form
    {
        private Form previousForm;
        private List<Magazin> magazins;
        private ClassCollection utility;

        public SpisokKramnic(Form previous)
        {
            InitializeComponent();
            previousForm = previous;
            this.StartPosition = FormStartPosition.CenterScreen;
            utility = new ClassCollection();
            LoadData();
        }

        private void LoadData()
        {
            string filePath = @"C:\Users\Lenovo\.vscode\data.json";
            magazins = utility.LoadMagazins(filePath);

            foreach (var magazin in magazins)
            {
                ListViewItem item = new ListViewItem(new[]
                {
                    magazin.MagazinName,
                    magazin.Adresa,
                    magazin.Kontakti,
                    magazin.ChasRoboti,
                    magazin.FormaVlasnosti,
                    magazin.Specializacia
                });
                listView1.Items.Add(item);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
