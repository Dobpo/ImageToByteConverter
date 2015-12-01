using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace ImageToByteConverter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Title = "Select an image";
            ofg.Filter = "Images (.jpg, .png, .gif, .bmp)|*.jpg;*.png;*.gif;*.bmp";
            ofg.Multiselect = false;

            if (ofg.ShowDialog() == true)
            {
                if (ofg.FileName != null && ofg.FileName.Length > 0)
                {
                    ofg.OpenFile();
                    FileStream fs = new FileStream(ofg.FileName, FileMode.Open, FileAccess.Read);
                    TextBox.Text = ByteImageConverter.ImageToByte(fs);

                    byte[] imgStr = Convert.FromBase64String(TextBox.Text);
                    Image.Source = ByteImageConverter.ByteToImage(imgStr);
                }
            }
        }
    }
}
