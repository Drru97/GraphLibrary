using System;

namespace GraphLibrary.Source
{
    /// <summary>
    /// Class which contains information about
    /// function and processing methods
    /// </summary>
    public class FunctionOperations
    {
        private double _right;
        private int _n;
        /// <value> Minimum value of function </value>
        public double LeftLimit { get; set; }

        /// <value> Maximum value of function</value>
        public double RightLimit
        {
            get { return _right; }
            set
            {
                if (value < LeftLimit)
                    throw new ArgumentOutOfRangeException(nameof(value), "Right limit must be higher than left");
                _right = value;
            }
        }

        /// <value> Number of points which will be used in charting </value>
        public int NumberOfPoints
        {
            get { return _n; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Number of points must be higher than 1");
                _n = value;
            }
        }

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
        /// <param name="h"> Tabulation step </param>
        private void Tabulation(double h = 0)
        {
            if (Math.Abs(h) < 0.000001)
                h = (RightLimit - LeftLimit) / NumberOfPoints;
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
            LeftLimit = -10;
            RightLimit = 10;
            NumberOfPoints = 100;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }

        /// <summary>
        /// Create an instance of this class
        /// with preset mathematical function, 
        /// tabulation step and tabulate it
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        /// <param name="step"> Tabulation step </param>
        public FunctionOperations(string function, double step) : this(function)
        {
            NumberOfPoints = (int)((RightLimit - LeftLimit) / step + 1);
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation(step);
        }

        /// <summary>
        /// Create an instance of this class
        /// with preset mathematical function
        /// and number of tabulation points
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        /// <param name="numberOfPoints"> Number of tabulation points </param>
        public FunctionOperations(string function, int numberOfPoints) : this(function)
        {
            NumberOfPoints = numberOfPoints;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }

        /// <summary>
        /// Create an instance of this class
        /// with preset mathematical function, 
        /// left and right limits
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        /// <param name="leftLimit"> Minimum value of function argument </param>
        /// <param name="rightLimit"> Maximum value of function argument </param>
        public FunctionOperations(string function, double leftLimit, double rightLimit)
        {
            Function = function;
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            NumberOfPoints = (int)(RightLimit - LeftLimit) * 100;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }

        /// <summary>
        /// Create an instance of this class
        /// with preset mathematical function, 
        /// limits and number of tabulation points
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        /// <param name="leftLimit"> Minimum value of function argument </param>
        /// <param name="rightLimit"> Maximum value of function argument </param>
        /// <param name="numberOfPoints"> Number of points for tabulation </param>
        public FunctionOperations(string function, double leftLimit, double rightLimit, int numberOfPoints) : this(function, leftLimit, rightLimit)
        {
            NumberOfPoints = numberOfPoints;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }

        /// <summary>
        /// Create an instance of this class
        /// with preset mathematical function,
        /// limits and tabulation step
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        /// <param name="leftLimit"> Minimum value of function argument </param>
        /// <param name="rightLimit"> Maximum value of function argument </param>
        /// <param name="step"> Tabulation step </param>
        public FunctionOperations(string function, double leftLimit, double rightLimit, double step) : this(function, leftLimit, rightLimit)
        {
            NumberOfPoints = (int)((RightLimit - LeftLimit) / step + 1);
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation(step);
        }
    }
}
