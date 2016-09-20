using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphLibrary.Source
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowsOperations
    {
        private FunctionOperations _operations { get; set; }
        private Form _form;
        private Chart _chart;
        /// <summary>
        /// 
        /// </summary>
        public WindowsOperations(string function)
        {
            _operations = new FunctionOperations(function);
            CreateWindow(_operations.X, _operations.Y);
        }

        private void CreateWindow(double[] x, double[] y)
        {
            _form = new Form {ClientSize = new Size(400, 400)};
            _chart = new Chart
            {
                Location = new Point(0, 0),
                Size = new Size((Point) _form.ClientSize),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            _chart.Series.Add("Series1");
            _chart.Series["Series1"].ChartType = SeriesChartType.Line; ;
            _chart.ChartAreas.Add("Area1");
            _chart.Series["Series1"].Points.Clear();
            _form.Controls.Add(_chart);
            _form.Show();
            for (int i = 0; i < x.Length; i++)
            {
                _chart.Series["Series1"].Points.AddXY(x[i], y[i]);
            }
        }
    }
}
