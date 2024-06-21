using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace DocumentsAndPrinting
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

        private void cleaningButton_Click(object sender, RoutedEventArgs e)
        {
            doc.ClearValue(FlowDocumentReader.DocumentProperty);
        }

        private void readingButton_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Open("1.xaml", FileMode.Open))
            {
                doc.Document = XamlReader.Load(fs) as FlowDocument;
            }

        }

        private void writingButton_Click(object sender, RoutedEventArgs e)
        {           
            using (FileStream fs = File.Open("1.xaml", FileMode.Create))
            {
                XamlWriter.Save(doc.Document, fs);
            }
        }
    }
}
