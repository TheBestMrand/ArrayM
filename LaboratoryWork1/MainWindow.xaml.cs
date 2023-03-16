using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Input;

namespace LaboratoryWork1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int[] _numbers;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int[] Numbers { get => _numbers; 
            set 
            { 
                _numbers = value;
                OnPropertyChanged(nameof(Numbers));
                ArrayBox.ItemsSource = Numbers;
            } 
        }

        public MainWindow()
        {
            InitializeComponent();

            Numbers = new int[0];

            ArrayBox.ItemsSource = Numbers;
        }

        private void AddElementsButton_Click(object sender, RoutedEventArgs e)
        {
            Validation validation = new Validation();
            string proccesedInput = validation.ProccesInput(Input.Text);
            if (validation.ValidateInput(proccesedInput))
            {
                Numbers = Numbers.Concat(proccesedInput.ConvertToIEnumerable()).ToArray();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DeleteSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            Numbers = Numbers.Remove(ArrayBox.SelectedItems.Cast<string>().Select(item => Array.IndexOf(Numbers, item)));
        }

        private void ArrayBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteSelectedButton.IsEnabled = ArrayBox.SelectedItems.Count > 0;

            Numbers.
        }

        private void Input_GotFocus(object sender, RoutedEventArgs e)
        {
            Input.Text = string.Empty;
        }
    }
}
