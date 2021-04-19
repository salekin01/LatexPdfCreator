using System;
using System.Collections.Generic;

namespace LatexPdfCreatorTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to latex pdf generator using .net core 5.0!");
            PdfGenerator pdfGenerator = new PdfGenerator(@"C:\Users\salekin\AppData\Local\Programs\MiKTeX\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");

            List<string> listOfItems = new List<string>(){ @"C:\Users\salekin\Desktop\ExtinctCoder.jpg" };
            pdfGenerator.CreatePdf(listOfItems);
        }
    }
}
