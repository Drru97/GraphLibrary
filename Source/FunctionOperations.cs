using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace GraphLibrary.Source
{
    public class FunctionOperations
    {
        public double LeftLimit { get; set; }
        public double RightLimit { get; set; }
        public int NumberOfPoints { get; set; }
        public double[] X { get; set; }
        public double[] Y { get; set; }
        public string Function { get; set; }

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

        public FunctionOperations(string function)
        {
            Function = function;
            LeftLimit = -5;
            RightLimit = 5;
            NumberOfPoints = 100;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }
    }
}
