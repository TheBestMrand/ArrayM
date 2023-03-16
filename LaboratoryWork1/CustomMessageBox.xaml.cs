using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaboratoryWork1
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        /// <summary>
        /// New instance of the CustomMessageBox class with the specified message and icon path
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="iconPath">Image file to be displayed in the message box</param>
        public CustomMessageBox(string message, string iconPath)
        {
            InitializeComponent();
            Message.Text = message;
            iconPath = "pack://application:,,,/Resources/" + iconPath;
            Icon.Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Closes the message box.
        /// </summary>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
