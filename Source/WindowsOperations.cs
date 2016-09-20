using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphLibrary.Source
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowsOperations
    {
        private FunctionOperations Operations { get; set; }
        private Form _form;
        private Chart _chart;
        /// <summary>
        /// 
        /// </summary>
        public WindowsOperations(string function)
        {
            Operations = new FunctionOperations(function);
            CreateWindow();
        }

        public WindowsOperations(string function, double a, double b)
        {
            Operations = new FunctionOperations(function, a, b);
            CreateWindow();
        }

        public WindowsOperations(string function, double a, double b, int n)
        {
            Operations = new FunctionOperations(function, a, b, n);
            CreateWindow();
        }

        private void CreateWindow()
        {
            _form = new Form { ClientSize = new Size(400, 400) };
            _chart = new Chart
            {
                Location = new Point(0, 0),
                Size = new Size((Point)_form.ClientSize),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            _chart.Series.Add("Series1");
            _chart.Series["Series1"].ChartType = SeriesChartType.Line;
            _chart.ChartAreas.Add("Area1");
            _chart.Series["Series1"].Points.Clear();
            _form.Controls.Add(_chart);
            _form.Show();
            for (int i = 0; i < Operations.NumberOfPoints; i++)
            {
                _chart.Series["Series1"].Points.AddXY(Operations.X[i], Operations.Y[i]);
            }
        }
    }
}
