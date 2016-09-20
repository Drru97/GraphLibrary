using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraphLibrary.Source
{
    /// <summary>
    /// Class which contains methods
    /// for drawing charts
    /// </summary>
    public class WindowsOperations
    {
        private FunctionOperations[] Operations { get; set; }
        private Form _form;
        private Chart _chart;

        /// <summary>
        /// Method which draw function graph
        /// preset by mathematical expression
        /// </summary>
        /// <param name="function"> Mathematical expression as string </param>
        public void Draw(string function)
        {
            Operations = new[] { new FunctionOperations(function) };
            CreateWindow();
        }

        /// <summary>
        /// Method which draw function graph
        /// preset by mathematical expression
        /// and its limits
        /// </summary>
        /// <param name="function"> Mathematical expression as string </param>
        /// <param name="leftLimit"> Minimum of argument x </param>
        /// <param name="rightLimit"> Maximum of argument x </param>
        public void Draw(string function, double leftLimit, double rightLimit)
        {
            Operations = new[] { new FunctionOperations(function, leftLimit, rightLimit) };
            CreateWindow();
        }

        /// <summary>
        /// Method which draw function graph
        /// preset by mathematical expression
        /// and tabulation step
        /// </summary>
        /// <param name="function"> Mathematical expression as string </param>
        /// <param name="step"> Tabulation step </param>
        public void Draw(string function, double step)
        {
            Operations = new[] { new FunctionOperations(function, step) };
            CreateWindow();
        }

        /// <summary>
        /// Method which draw function graph
        /// preset by mathematical expression
        /// and number of points
        /// </summary>
        /// <param name="function"> Mathematical expression as string </param>
        /// <param name="numberOfPoints"> Number of points which will be used in charting </param>
        public void Draw(string function, int numberOfPoints)
        {
            Operations = new[] { new FunctionOperations(function, numberOfPoints) };
            CreateWindow();
        }

        /// <summary>
        /// Method which draw function graph
        /// preset by mathematical expression,
        /// limits and tabulation step
        /// </summary>
        /// <param name="function"> Mathematical expression as string </param>
        /// <param name="leftLimit"> Minimum of argument x </param>
        /// <param name="rightLimit"> Maximum of argument x </param>
        /// <param name="step"> Tabulation step </param>
        public void Draw(string function, double leftLimit, double rightLimit, double step)
        {
            Operations = new[] { new FunctionOperations(function, leftLimit, rightLimit, step) };
            CreateWindow();
        }

        /// <summary>
        /// Method which draw function graph
        /// preset by mathematical expression
        /// and number of points
        /// </summary>
        /// <param name="function"> Mathematical expression as string </param>
        /// <param name="leftLimit"> Minimum of argument x </param>
        /// <param name="rightLimit"> Maximum of argument x </param>
        /// <param name="numberOfPoints"> Number of points which will be used in charting </param>
        public void Draw(string function, double leftLimit, double rightLimit, int numberOfPoints)
        {
            Operations = new[] { new FunctionOperations(function, leftLimit, rightLimit, numberOfPoints) };
            CreateWindow();
        }

        /// <summary>
        /// This function plots a chart between fisrt argument x and
        /// the next agruments. The size and type of first and second 
        /// arguments must be the same
        /// </summary>
        /// <param name="x"> First argument x </param>
        /// <param name="y"> Second, third and next arguments y </param>
        public void Draw(double[] x, params object[] y)
        {
            Operations = new FunctionOperations[y.Length];
            for (int i = 0; i < y.Length; i++)
                Operations[i] = new FunctionOperations { X = x, Y = (double[])y[i] };
            CreateWindow();
        }

        /// <summary>
        /// This method creates Windows Form and 
        /// Chart, adds new Series and Chart Area
        /// and plots
        /// </summary>
        private void CreateWindow()
        {
            _form = new Form { ClientSize = new Size(400, 400), Text = (Operations.Length == 0) ? $"y = {Operations[0].Function}" : "Function" };
            _chart = new Chart
            {
                Location = new Point(0, 0),
                Size = new Size((Point)_form.ClientSize),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            _chart.ChartAreas.Add("Area1");
            for (int i = 0; i < Operations.Length; i++)
            {
                _chart.Series.Add($"Series{i}");
                _chart.Series[$"Series{i}"].ChartType = SeriesChartType.Line;
                for (int j = 0; j < Operations[i].Y.Length; j++)
                    _chart.Series[$"Series{i}"].Points.AddXY(Operations[i].X[j], Operations[i].Y[j]);
            }
            _form.Controls.Add(_chart);
            _form.Show();
        }
    }
}
