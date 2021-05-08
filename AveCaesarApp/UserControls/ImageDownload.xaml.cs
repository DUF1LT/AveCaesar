using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace AveCaesarApp.UserControls
{
    public partial class ImageDownload : UserControl
    {
        public static readonly DependencyProperty ImageProperty = 
            DependencyProperty.Register("ImagePath", typeof(string), typeof(ImageDownload),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault ));

        public static readonly RoutedEvent ImageDownloadEvent = EventManager.RegisterRoutedEvent(
        "ImageDownloaded",
        RoutingStrategy.Direct,
        typeof(RoutedEventHandler),
        typeof(ImageDownload));

     
        public string ImagePath
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public event RoutedEventHandler ImageDownloaded
        {
            add => AddHandler(ImageDownloadEvent, value);
            remove => RemoveHandler(ImageDownloadEvent, value);
        }


        private void DownloadButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            var status = ofd.ShowDialog();
            if (status != null && (bool)status)
            {
                ImagePath = ofd.FileName;
                ImageField.Source = new BitmapImage(new Uri(@$"{ofd.FileName}"));
                RaiseEvent(new RoutedEventArgs(ImageDownloadEvent, this));
            }

        }
        public ImageDownload()
        {
            InitializeComponent();
        }
    }
}
