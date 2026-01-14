using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics; 

namespace WpfInventory
{
    public partial class MainWindow : Window
    {
        // Lista obiektów wyświetlana w tabeli
        private ObservableCollection<Przedmiot> _items = new ObservableCollection<Przedmiot>();
        private string _dbFile = "inventory.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadData(); // Wczytaj dane z pliku przy starcie
            DgInventory.ItemsSource = _items;
        }

        // --- OBSŁUGA PLIKÓW ---
        private void LoadData()
        {
            if (File.Exists(_dbFile))
            {
                var json = File.ReadAllText(_dbFile);
                _items = JsonConvert.DeserializeObject<ObservableCollection<Przedmiot>>(json) ?? new ObservableCollection<Przedmiot>();
            }
        }

        private void SaveData()
        {
           
            var json = JsonConvert.SerializeObject(_items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(_dbFile, json);
        }

        // --- WALIDACJA ---
        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(InpNazwa.Text))
            {
                MessageBox.Show("Nazwa nie może być pusta!");
                return false;
            }
            if (!int.TryParse(InpIlosc.Text, out int qty) || qty < 0)
            {
                MessageBox.Show("Ilość musi być liczbą całkowitą dodatnią!");
                return false;
            }
            return true;
        }

        // --- PRZYCISKI ---
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                _items.Add(new Przedmiot
                {
                    Nazwa = InpNazwa.Text,
                    Kategoria = ((ComboBoxItem)InpKat.SelectedItem).Content.ToString(),
                    Ilosc = int.Parse(InpIlosc.Text),
                    Status = "Dostępny"
                });
                SaveData();
                ClearFields();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DgInventory.SelectedItem is Przedmiot selected && Validate())
            {
                selected.Nazwa = InpNazwa.Text;
                selected.Ilosc = int.Parse(InpIlosc.Text);
                selected.Kategoria = ((ComboBoxItem)InpKat.SelectedItem).Content.ToString();

                DgInventory.Items.Refresh(); // Odśwież widok tabeli
                SaveData();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzamy, czy w ogóle coś jest zaznaczone na liście
            if (DgInventory.SelectedItem is Przedmiot selected)
            {
                // Wyświetlamy okno z pytaniem
                MessageBoxResult result = MessageBox.Show(
                    $"Czy na pewno chcesz usunąć przedmiot: \"{selected.Nazwa}\"? \n\nTej operacji nie da się cofnąć!",
                    "Potwierdzenie usunięcia",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                // Jeśli użytkownik kliknął TAK, usuwamy przedmiot
                if (result == MessageBoxResult.Yes)
                {
                    _items.Remove(selected);
                    SaveData();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Najpierw wybierz przedmiot z listy, który chcesz usunąć.");
            }
        }

        // --- EKSPORT DO TXT ---
        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string raportPath = "Raport_Inwentaryzacji.txt";

                using (StreamWriter sw = new StreamWriter(raportPath))
                {
                    sw.WriteLine("============================================");
                    sw.WriteLine($"RAPORT INWENTARYZACJI - {DateTime.Now}");
                    sw.WriteLine("============================================");
                    sw.WriteLine(string.Format("{0,-10} | {1,-20} | {2,-10}", "ID", "Nazwa", "Ilość"));
                    sw.WriteLine("--------------------------------------------");

                    foreach (var p in _items)
                    {
                        sw.WriteLine(string.Format("{0,-10} | {1,-20} | {2,-10}", p.Id, p.Nazwa, p.Ilosc));
                    }

                    sw.WriteLine("============================================");
                    sw.WriteLine($"Łączna liczba pozycji: {_items.Count}");
                }

                // Autmatyczne otwieranie pliku po wygenerowwaniu 
                Process.Start(new ProcessStartInfo(raportPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas generowania raportu: " + ex.Message);
            }
        }

        // --- SZUKANIE I WYBÓR ---
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = TxtSearch.Text.ToLower();
            DgInventory.ItemsSource = _items.Where(x => x.Nazwa.ToLower().Contains(filter)).ToList();
        }

        private void DgInventory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgInventory.SelectedItem is Przedmiot p)
            {
                InpNazwa.Text = p.Nazwa;
                InpIlosc.Text = p.Ilosc.ToString();

                
                foreach (ComboBoxItem item in InpKat.Items)
                {
                    if (item.Content.ToString() == p.Kategoria)
                    {
                        InpKat.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void ClearFields()
        {
            InpNazwa.Clear();
            InpIlosc.Clear();
        }

        private void InpKat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}