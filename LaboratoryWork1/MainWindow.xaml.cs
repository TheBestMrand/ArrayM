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
        private readonly int[] _test = { 2, 3, -6, 7, -14, 10 };

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets or sets the Numbers property and updates the UI accordingly
        /// </summary>
        public int[] Numbers { get => _numbers; 
            set 
            { 
                _numbers = value;
                OnPropertyChanged(nameof(Numbers));
                ArrayBox.ItemsSource = Numbers;
                Update();
            } 
        }

        /// <summary>
        /// Updates the UI elements
        /// </summary>
        private void Update()
        {
            DeleteFirstButton.IsEnabled = Numbers.Length > 0;
            DeleteLastButton.IsEnabled = Numbers.Length > 0;
            RunButton.IsEnabled = Numbers.Length > 2;
        }

        /// <summary>
        /// Initializes the MainWindow and sets the standart values
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Numbers = Array.Empty<int>();

            ArrayBox.ItemsSource = Numbers;
        }

        /// <summary>
        /// Handles the AddElementsButton click event and validates the input before adding it to the Numbers array
        /// </summary>
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
                CustomMessageBox customMessageBox = new CustomMessageBox("Please enter valid integer input. Examples: [1,2,3,4,5]; 1 2 3 4 5; 1,2,3,4,5", "Error.png");
                customMessageBox.ShowDialog();
            }
            
        }

        /// <summary>
        /// Raises the PropertyChanged event
        /// </summary>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Removes selected items from the Numbers array
        /// </summary>
        private void DeleteSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            List<int> conver = Numbers.ToList();

            for (int i = ArrayBox.Items.Count - 1; i >= 0; i--)
            {
                ListBoxItem listBoxItem = ArrayBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                if (listBoxItem != null && listBoxItem.IsSelected)
                {
                    conver.RemoveAt(i);
                }
            }

            Numbers = conver.ToArray();

            ArrayBox.UnselectAll();
        }

        /// <summary>
        /// Updates the DeleteSelectedButton state
        /// </summary>
        private void ArrayBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => DeleteSelectedButton.IsEnabled = ArrayBox.SelectedItems.Count > 0;

        /// <summary>
        /// Clears the Input TextBox
        /// </summary>
        private void Input_GotFocus(object sender, RoutedEventArgs e) => Input.Text = string.Empty;

        /// <summary>
        /// Checks if the DeleteFirstButton and DeleteLastButton should be enabled
        /// </summary>
        private bool DeletesHandler(object sender, RoutedEventArgs e) => Numbers.Length > 0;

        /// <summary>
        /// Removes the first element from the Numbers array
        /// </summary>
        private void DeleteFirstButton_Click(object sender, RoutedEventArgs e) => Numbers = Numbers.Remove(0);

        /// <summary>
        /// Removes the last element from the Numbers array.
        /// </summary>
        private void DeleteLastButton_Click(object sender, RoutedEventArgs e) => Numbers = Numbers.Remove(Numbers.Length - 1);

        /// <summary>
        /// Clears the Numbers array.
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e) => Numbers = Array.Empty<int>();

        /// <summary>
        /// Returns an array of elements that are not divisible by the product of any two other elements in the input array
        /// </summary>
        public int[] NonDivisibleElements(int[] arr)
        {
            int[] products = arr.SelectMany((x, i) => arr.Skip(i + 1).Select(y => x * y)).ToArray();

            int[] nonDivisibleElements = arr.Where(element => !products.Any(product => element % product == 0)).ToArray();

            return nonDivisibleElements;
        }

        /// <summary>
        /// Displays a message with the results of the NonDivisibleElements method
        /// </summary>
        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox($"Elements that are not are not divisible by the product of any two other elements: {NonDivisibleElements(Numbers).Stringify()} ", "Info.png");
            customMessageBox.ShowDialog();
        }

        /// <summary>
        /// Fills the Numbers array with predefined test values
        /// </summary>
        private void FillButton_Click(object sender, RoutedEventArgs e) => Numbers = _test;
    }
}
