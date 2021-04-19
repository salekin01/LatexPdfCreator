using LatexDocument;
using ScintillaNET;
using System.Drawing;

namespace LatexDoc
{
    public class PdfGenerator
    {
        LatexDocument.Document lt;
        Scintilla TextArea;

        public void CreatePdf()
        {
            TextArea = new Scintilla();

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;

            InitNumberMargin();

            //lt = new LatexDocument.Document(@"C:\Program Files\MiKTeX 2.9\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");
            lt = new LatexDocument.Document(@"C:\Users\salekin\AppData\Local\Programs\MiKTeX\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");


            LatexPageTitle title = new LatexPageTitle("Test File", "Sirajus Salekin Prodhan", "19 April 2021");
            lt.Add(title);

            LatexFont font = new LatexFont();
            font.Size = LatexFont.TEXT_Huge;

            lt.Add(new LatexTextTitle("Big Title", font));
            LatexImage img = new LatexImage(@"C:\Users\salekin\Desktop\ExtinctCoder.jpg", "Test Image");
            lt.Add(img);
            TextArea.Text = lt.ToString();
            lt.CreatePdf("Test1", true);
        }

        #region Numbers, Bookmarks, Code Folding

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0xB7B7B7;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0x2A211C;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        #endregion

        private void InitNumberMargin()
        {

            TextArea.Styles[ScintillaNET.Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            TextArea.Styles[ScintillaNET.Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[ScintillaNET.Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            TextArea.Styles[ScintillaNET.Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = TextArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
