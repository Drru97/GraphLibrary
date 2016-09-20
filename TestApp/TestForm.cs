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
            WindowsOperations lib;
            try
            {
                if (left.Text == string.Empty && right.Text == string.Empty)
                    lib = new WindowsOperations(function.Text);
                else
                    lib = new WindowsOperations(function.Text, double.Parse(left.Text), double.Parse(right.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
