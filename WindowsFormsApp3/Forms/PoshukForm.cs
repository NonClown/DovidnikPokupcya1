using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class PoshukForm : Form
    {
        private ClassCollection utility;
        private DataTable dataTable;

        public PoshukForm()
        {
            InitializeComponent();
            utility = new ClassCollection();
            string jsonFilePath = "C:\\Users\\Lenovo\\.vscode\\data.json";
            dataTable = utility.LoadJsonToDataTable(jsonFilePath);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
            try
            {
                DataTable results = utility.Search(dataTable, searchQuery);
                PopulateListView(results);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка!: " + ex.Message);
            }
        }

        private void PopulateListView(DataTable dataTable)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();

            foreach (DataColumn column in dataTable.Columns)
            {
                listView1.Columns.Add(column.ColumnName);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < dataTable.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listView1.Items.Add(item);
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Golovna form1 = new Golovna();
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Show();
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt";
                saveFileDialog.Title = "Виберіть місце для збереження файлу";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    utility.ExportToTextFile(listView1, filePath);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
