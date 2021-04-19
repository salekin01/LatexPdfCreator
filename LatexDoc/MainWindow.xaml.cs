using System.Windows;

namespace LatexDoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PdfGenerator pdfGenerator = new PdfGenerator();
            pdfGenerator.CreatePdf();
        }

    }
}
