using System;

namespace LatexDoc_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to latex pdf generator!");
            PdfGenerator pdfGenerator = new PdfGenerator(@"C:\Users\salekin\AppData\Local\Programs\MiKTeX\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");
            pdfGenerator.CreatePdf();
        }
    }
}
