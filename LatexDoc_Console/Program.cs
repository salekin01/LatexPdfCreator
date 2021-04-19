using System;
using System.Collections.Generic;

namespace LatexDoc_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to latex pdf generator!");
            PdfGenerator pdfGenerator = new PdfGenerator(@"C:\Users\salekin\AppData\Local\Programs\MiKTeX\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");

            List<string> listOfItems = new List<string>(){ @"C:\Users\salekin\Desktop\ExtinctCoder.jpg" };
            pdfGenerator.CreatePdf(listOfItems);
        }
    }
}
