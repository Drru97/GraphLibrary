using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphLibrary.Source;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            FunctionOperations operations = new FunctionOperations(textBox1.Text, 2);
            int count = operations.NumberOfPoints;
            for (int i = 0; i < count; i++)
                chart1.Series["Series1"].Points.AddXY(operations.X[i], operations.Y[i]);
        }
    }
}
