using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Markup;

namespace AveCaesarApp.Converters
{
    class RichTextBoxDocumentToStringConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string note)
            {
                FlowDocument flowDoc = new FlowDocument();
                flowDoc.Blocks.Add(new Paragraph(new Run(note)));
                return flowDoc;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is FlowDocument rtbDocument)
            {
                return new TextRange(rtbDocument.ContentStart, rtbDocument.ContentEnd).Text;
            }
            return null;
        }
    }
}
