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
            PdfGenerator pdfGenerator = new PdfGenerator(@"C:\Users\salekin\AppData\Local\Programs\MiKTeX\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");
            pdfGenerator.CreatePdf();
        }

    }
}
