using LatexDocument;
using ScintillaNET;
using System.Collections.Generic;
using System.Drawing;

namespace LatexDoc_Console
{
    public class PdfGenerator
    {
        private LatexDocument.Document lt;
        private Scintilla TextArea;
        private string _laTeXExecutable;
        private string _saveInDirectory;
        private string _loremIpsum ="Lorem ipsum dolor sit amet, consectetur adipiscing elit.Donec orci tortor, tempus at vulputate vel, cursus vitae quam.Aliquam tincidunt eget odio id posuere. Donec rhoncus consectetur erat, sed tempus erat interdum a.Aliquam dictum imperdiet massa non vestibulum. Quisque rutrum ligula non nisl maximus fringilla.Proin condimentum fermentum accumsan. Morbi venenatis eros sed mi fermentum efficitur.Donec auctor, diam nec gravida egestas, magna libero interdum enim, at venenatis justo libero sed lectus. Nullam lectus nibh, porttitor ut turpis cursus, eleifend iaculis augue.Vivamus mollis, eros nec sagittis accumsan, quam ipsum hendrerit erat, eget fringilla ante nunc sed metus. Sed hendrerit dui ut ultrices faucibus. Nulla velit turpis, pretium a nibh sit amet, dapibus suscipit magna.Sed feugiat a sapien vitae pellentesque. Nam et dolor nec magna ultrices lobortis.Nulla gravida lobortis magna bibendum volutpat.";

        public PdfGenerator(string laTeXExecutable, string saveInDirectory)
        {
            _laTeXExecutable = laTeXExecutable;
            _saveInDirectory = saveInDirectory;
        }
        public void CreatePdf(List<string> fullPathOfItems)
        {
            TextArea = new Scintilla();

            // INITIAL VIEW CONFIG
            TextArea.WrapMode = WrapMode.None;
            TextArea.IndentationGuides = IndentView.LookBoth;

            InitNumberMargin();

            //lt = new LatexDocument.Document(@"C:\Program Files\MiKTeX 2.9\miktex\bin\x64\pdflatex.exe", @"D:\Latex\");
            lt = new LatexDocument.Document(_laTeXExecutable, _saveInDirectory);


            /****page1****/
            LatexPageTitle title = new LatexPageTitle("Test File", "Sirajus Salekin Prodhan", "19 April 2021");
            lt.Add(title);


            /****page2****/
            LatexFont font = new LatexFont();
            font.Size = LatexFont.TEXT_Huge;

            lt.Add(new LatexTextTitle("Big Title", font));
            LatexImage img = new LatexImage(fullPathOfItems[0], "Test Image");
            lt.Add(img);
            font.Color = "blue";
            lt.Add(new LatexParagraph("Blue paragraph", _loremIpsum, font));
            lt.NewLine();

            font.Color = null;
            font.Type = LatexFont.TEXT_BOLD;

            lt.Add(new LatexText("Bold text, ", font));

            font.Type = LatexFont.TEXT_ITALIC;
            lt.Add(new LatexText("Italic text, ", font));

            font.Type = LatexFont.TEXT_UNDERLINE;
            lt.Add(new LatexText("UnderLine text", font));

            font.Type = null;
            font.Color = "red";
            lt.Add(new LatexText("Red text", font));

            lt.Font = "cmss";
            LatexImage img2 = new LatexImage(fullPathOfItems[0], "Test Image");
            lt.Add(img2);
            lt.Add(new LatexParagraph("Change Font: Computer Modern Sans Serif", _loremIpsum));

            lt.Font = LatexFont.DEFAULT_FONT;
            lt.NewPage();


            /****page3****/
            font.Size = LatexFont.TEXT_Huge;
            font.Color = "red";

            lt.Add(new LatexTextTitle("Formulas (red title)", font));
            lt.AddMath(@"\lim_{x \to \infty} \exp(-x) = 0");
            lt.NewLine();
            lt.AddMath(@"\frac{n!}{k!(n-k)!} = \binom{n}{k}");
            lt.NewLine();
            lt.AddMath(@"\cos (2\theta) = \cos^2 \theta - \sin^2 \theta");

            lt.NewLine(); lt.NewLine();

            font.Color = null;
            lt.Add(new LatexTextTitle("Table", font));
            lt.NewLine();
            string[,] elements = new string[3, 3];

            elements[0, 0] = "Pizza";
            elements[0, 1] = "Pane";
            elements[0, 2] = "Spaghetti";

            elements[1, 0] = "1";
            elements[1, 1] = "2";
            elements[1, 2] = "3";

            elements[2, 0] = "4";
            elements[2, 1] = "5";
            elements[2, 2] = "6";

            lt.Add(new LatexTable(elements));

            lt.Add(new LatexParagraph(_loremIpsum));

            lt.NewLine(); lt.NewLine();
            lt.Add(new LatexTextTitle("Table (no borders) Wrapped", font));

            lt.Add(new LatexTable(elements, false, true));
            lt.Add(new LatexParagraph(_loremIpsum));
            lt.NewPage();


            /****page4****/
            lt.Add(new LatexTextTitle("Bullet List", font));
            List<string> items = new List<string>();
            items.Add("Pizza");
            items.Add("Pane");
            items.Add("Pasta");
            items.Add("Spaghetti");
            lt.Add(new LatexList(LatexList.BULLET, items));

            lt.Add(new LatexTextTitle("Enumerate List", font));
            lt.Add(new LatexList(LatexList.ENUMERATE, items));

            lt.Add(new LatexTextTitle("Descriptive List", font));
            Dictionary<string, string> desc = new Dictionary<string, string>();
            desc.Add("Pizza", _loremIpsum.Substring(0, 175));
            desc.Add("Pane", _loremIpsum.Substring(0, 175));
            desc.Add("Pasta", _loremIpsum.Substring(0, 175));
            desc.Add("Spaghetti", _loremIpsum.Substring(0, 175));

            lt.Add(new LatexList(desc));
            lt.NewPage();


            /****page5****/
            lt.Add(new LatexTextTitle("Pie Graph", font));
            lt.NewLine();
            List<LatexGraphValue> datas = new List<LatexGraphValue>();
            datas.Add(new LatexGraphValue(10, "Pizza", "red"));
            datas.Add(new LatexGraphValue(20, "Pane", "green"));
            datas.Add(new LatexGraphValue(30, "Pasta", "blue"));
            datas.Add(new LatexGraphValue(40, "Spaghetti", "orange"));

            LatexPieGraph graph = new LatexPieGraph(datas);
            lt.Add(graph);

            lt.Add(new LatexTextTitle("Bar Graph", font));
            lt.NewLine();

            LatexBarGraph graph2 = new LatexBarGraph(datas);
            lt.Add(graph2);

            lt.NewPage();


            /****page6****/
            font.Size = LatexFont.TEXT_Huge;
            lt.Add(new LatexTextTitle("Coordinates Graph", font));
            LatexPlotGraph plotGraph = new LatexPlotGraph();
            plotGraph.Title = @"Temperature dependence of CuSO$_4\cdot$5H$_2$O solubility";
            plotGraph.XLabel = "Temperature in celsius";
            plotGraph.YLabel = "Solubility[g per 100 g water]";
            plotGraph.XMin = 0;
            plotGraph.XMax = 100;
            plotGraph.YMin = 0;
            plotGraph.YMax = 100;
            plotGraph.XTick = new int[] { 0, 20, 40, 60, 80, 100 };
            plotGraph.YTick = new int[] { 0, 20, 40, 60, 80, 100, 120 };
            plotGraph.LegendPosition = "north west";
            plotGraph.YMajorGrids = true;
            plotGraph.GridStyle = "dashed";

            LatexPlot plot = new LatexPlot();

            plot.LineColor = "blue";
            plot.MarksStyle = "square";

            
            System.Windows.Point[] coordinates = new System.Windows.Point[8];
            coordinates[0] = new System.Windows.Point(0, 23.1);
            coordinates[1] = new System.Windows.Point(10, 27.5);
            coordinates[2] = new System.Windows.Point(20, 32);
            coordinates[3] = new System.Windows.Point(30, 37.8);
            coordinates[4] = new System.Windows.Point(40, 44.6);
            coordinates[5] = new System.Windows.Point(60, 61.8);
            coordinates[6] = new System.Windows.Point(80, 83.8);
            coordinates[7] = new System.Windows.Point(100, 114);

            plot.Coordinates = coordinates; 
            plot.Legend = @"CuSO$_4\cdot$5H$_2$O";

            plotGraph.Plots = new LatexPlot[] { plot };

            lt.Add(plotGraph);

            lt.Add(new LatexTextTitle("Math Graph", font));
            LatexPlotGraph plotGraph2 = new LatexPlotGraph();

            LatexPlot plot2 = new LatexPlot();
            plot2.LineColor = "red";
            plot2.Expression = "x^2 - 2*x - 1";
            plot2.Legend = "$x^2 - 2*x - 1$";

            LatexPlot plot3 = new LatexPlot();
            plot3.LineColor = "blue";
            plot3.Expression = "x^2 + 2*x + 1";
            plot3.Legend = "$x^2 + 2*x + 1$";

            plotGraph2.Plots = new LatexPlot[] { plot2, plot3 };

            lt.Add(plotGraph2);
            /****End of page6****/

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
