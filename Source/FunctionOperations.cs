using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GraphLibrary.Source
{
    /// <summary>
    /// Class which contains information about
    /// function and processing methods
    /// </summary>
    public class FunctionOperations
    {
        /// <value> Minimum value of function </value>
        public double LeftLimit { get; set; }

        /// <value> Maximum value of function</value>
        public double RightLimit { get; set; }

        /// <value> Number of points which will be used in charting </value>
        public int NumberOfPoints { get; set; }

        /// <value> Array of function arguments x </value>
        public double[] X { get; set; }

        /// <value> Array of function values y </value>
        public double[] Y { get; set; }

        /// <value> Sets mathematical function as a string </value>
        public string Function { get; set; }

        /// <summary>
        /// Method is used to get a function values y
        /// from function arguments x
        /// </summary>
        private void Tabulation()
        {
            double h = (RightLimit - LeftLimit) / NumberOfPoints;
            X[0] = LeftLimit;
            FunctionReflection reflection = new FunctionReflection(Function);
            for (int i = 0; i < NumberOfPoints - 1; i++)
            {
                Y[i] = reflection.InvokeMethod(X[i]);
                X[i + 1] = X[i] + h;
            }
            Y[Y.Length - 1] = reflection.InvokeMethod(X[X.Length - 1]);
        }

        /// <summary>
        /// Creates an instance of this class
        /// with preset mathematical function and
        /// default parameters and tabulate it
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        public FunctionOperations(string function)
        {
            Function = function;
            LeftLimit = -5;
            RightLimit = 5;
            NumberOfPoints = 1000;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }
    }
}
