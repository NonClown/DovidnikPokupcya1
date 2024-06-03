using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp3
{
    
    internal class ClassCollection
    {
        public class MegaCursachData
        {
            public List<Magazin> MegaCursach { get; set; }
        }

        public List<Magazin> LoadMagazins(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<MegaCursachData>(json);
                return data.MegaCursach;
            }
        }

        public DataTable LoadJsonToDataTable(string jsonFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                var jsonObject = JObject.Parse(json);
                var jsonArray = jsonObject["MegaCursach"] as JArray;

                if (jsonArray == null)
                {
                    throw new Exception("JSON не містить масиву 'MegaCursach'.");
                }

                return JsonConvert.DeserializeObject<DataTable>(jsonArray.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка з завантаженням JSON: " + ex.Message);
            }
        }

        public DataTable Search(DataTable dataTable, string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery)) return dataTable;

            string lowerSearchQuery = searchQuery.ToLower();
            DataTable filteredTable = dataTable.Clone();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    if (item.ToString().ToLower().Contains(lowerSearchQuery))
                    {
                        filteredTable.ImportRow(row);
                        break;
                    }
                }
            }

            return filteredTable;
        }

        public void ExportToTextFile(ListView listView, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        string line = "";
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            line += item.SubItems[i].Text + "\t";
                        }
                        writer.WriteLine(line.TrimEnd('\t'));
                    }
                }
                MessageBox.Show("Дані успішно збережено у " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка!: " + ex.Message);
            }
        }
    }

    public static class ClassVidalennya
    {
        private static string jsonFilePath = "C:\\Users\\Lenovo\\.vscode\\data.json";

        public static void InitializeComponents(vidalennya form)
        {
            var stores = LoadStores();
            if (stores == null) return;

            form.comboBox1.Items.Clear();
            form.comboBox1.Items.AddRange(stores.Select(s => s.MagazinName).ToArray());

            form.comboBox1.SelectedIndexChanged += (sender, e) =>
            {
                var selectedStore = stores.FirstOrDefault(s => s.MagazinName == form.comboBox1.SelectedItem.ToString());
                if (selectedStore != null)
                {
                    form.textBox1.Text = selectedStore.Adresa;
                    form.textBox2.Text = selectedStore.Kontakti;
                    form.textBox3.Text = selectedStore.ChasRoboti;
                    form.textBox4.Text = selectedStore.FormaVlasnosti;
                    form.textBox5.Text = selectedStore.Specializacia;
                }
            };

            form.button1.Click += (sender, e) =>
            {
                var selectedStore = stores.FirstOrDefault(s => s.MagazinName == form.comboBox1.SelectedItem.ToString());
                if (selectedStore != null)
                {
                    stores.Remove(selectedStore);
                    SaveStores(stores);
                    MessageBox.Show("Перемога! Магазин успішно видалено");
                    form.Close();
                }
            };
        }

        private static List<Magazin> LoadStores()
        {
            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("Файл з даними не знайдено!");
                return null;
            }

            var json = File.ReadAllText(jsonFilePath);
            var data = JsonConvert.DeserializeObject<ClassCollection.MegaCursachData>(json);
            return data?.MegaCursach ?? new List<Magazin>();
        }

        private static void SaveStores(List<Magazin> stores)
        {
            var data = new ClassCollection.MegaCursachData { MegaCursach = stores };
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }

    public class ClassRedag
    {
        private List<Magazin> magazins;

        public ClassRedag(string jsonFilePath)
        {
            LoadMagazins(jsonFilePath);
        }

        private void LoadMagazins(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            var megaCursachData = JsonConvert.DeserializeObject<ClassCollection.MegaCursachData>(json);
            magazins = megaCursachData.MegaCursach;
        }

        public List<Magazin> GetMagazins()
        {
            return magazins;
        }

        public void SaveMagazins(string jsonFilePath)
        {
            var megaCursachData = new ClassCollection.MegaCursachData { MegaCursach = magazins };
            string json = JsonConvert.SerializeObject(megaCursachData, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }

    public static class ClassDodavannya
    {
        private static string jsonFilePath = "C:\\Users\\Lenovo\\.vscode\\data.json";

        public static void InitializeComponents(dodavannya form)
        {
            form.button1.Click += (sender, e) => AddStore(form);
        }

        private static void AddStore(dodavannya form)
        {
            var stores = LoadStores();
            if (stores == null) return;

            var newStore = new Magazin
            {
                MagazinName = form.textBox1.Text,
                Adresa = form.textBox2.Text,
                Kontakti = form.textBox3.Text,
                ChasRoboti = form.textBox4.Text,
                FormaVlasnosti = form.textBox5.Text,
                Specializacia = form.textBox6.Text
            };

            stores.Add(newStore);
            SaveStores(stores);
            MessageBox.Show("Магазин успішно додано!");
            form.Close();
        }

        private static List<Magazin> LoadStores()
        {
            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("Файл з даними не знайдено!");
                return new List<Magazin>();
            }

            var json = File.ReadAllText(jsonFilePath);
            var data = JsonConvert.DeserializeObject<ClassCollection.MegaCursachData>(json);
            return data?.MegaCursach ?? new List<Magazin>();
        }

        private static void SaveStores(List<Magazin> stores)
        {
            var data = new ClassCollection.MegaCursachData { MegaCursach = stores };
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(jsonFilePath, json);
        }
    }
}
