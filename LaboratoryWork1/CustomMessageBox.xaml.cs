using System;
using System.Windows;
using System.Windows.Media.Imaging;

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
            this.Title = iconPath.Remove(iconPath.Length - 4);
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
