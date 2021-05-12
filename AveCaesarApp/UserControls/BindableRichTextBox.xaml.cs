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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AveCaesarApp.UserControls
{
    /// <summary>
    /// Interaction logic for BindableRichTextBox.xaml
    /// </summary>
    public partial class BindableRichTextBox : UserControl
    {
        private bool _isDocumentChanging;

        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(string), typeof(BindableRichTextBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    DocumentPropertyChangedCallback, null, false, UpdateSourceTrigger.PropertyChanged));

        private static void DocumentPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
                if (d is BindableRichTextBox bindablePasswordBox)
                {
                    bindablePasswordBox.UpdateDocument();
                }
        }

        public string Document
        {
            get { return (string)GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        private void RichTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _isDocumentChanging = true;
            Document = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd).Text;
            _isDocumentChanging = false;
        }

        private void UpdateDocument()
        {
            if (!_isDocumentChanging)
                RichTextBox.Document = new FlowDocument(new Paragraph(new Run(Document)));
        }
        public BindableRichTextBox()
        {
            InitializeComponent();
        }

       
    }
}
