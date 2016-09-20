using System;
using System.Windows.Forms;
using GraphLibrary.Source;

namespace TestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //   FunctionOperations operations = new FunctionOperations(textBox1.Text);
            //    int count = operations.NumberOfPoints;
            //    for (int i = 0; i < count; i++)
            //     chart1.Series["Series1"].Points.AddXY(operations.X[i], operations.Y[i]);
            WindowsOperations lib = new WindowsOperations();
            double[] x = {1, 2, 3, 4, 5};
            double[] y = {2, 4, 6, 8, 10};
            double[] k = {3, 6, 9, 12, 15};
            double[] t = {5, 5, 5, 5, 5};
            lib.Draw(x, y, k);
            //try
            //{
            //    if (left.Text == string.Empty && right.Text == string.Empty)
            //        lib.Draw(function.Text);
            //    else
            //        lib.Draw(function.Text, double.Parse(left.Text), double.Parse(right.Text));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }
    }
}
