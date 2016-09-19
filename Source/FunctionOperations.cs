using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Data;
using System.Reflection;

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

        private const string beginString = @"using System;
                                       namespace Test
                                       {
                                            public delegate double Calc(double x);
                                            public static class FunctionCreator
                                            {
                                                public static Calc CreateFunction()
                                                {
                                                    return x=>";

        private const string endString = @";
                                 }
                            }
                        }";

        private void Tabulation()
        {
            double h = (RightLimit - LeftLimit) / NumberOfPoints;
            X[0] = LeftLimit;
            for (int i = 0; i < NumberOfPoints - 1; i++)
            {
                Y[i] = BuildFunction(X[i]);
                X[i + 1] = X[i] + h;
            }
            Y[Y.Length - 1] = BuildFunction(X[X.Length - 1]);
        }

        private double BuildFunction(double x)
        {
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters { GenerateInMemory = true, ReferencedAssemblies = { "System.dll" } };
            CompilerResults compilerResults = codeProvider.CompileAssemblyFromSource(compilerParameters,
                beginString + Function + endString);
            var cls = compilerResults.CompiledAssembly.GetType("Test.FunctionCreator");
            var method = cls.GetMethod("CreateFunction", BindingFlags.Static | BindingFlags.Public);
            var del = (method.Invoke(null, null) as Delegate);
            return (double)del.DynamicInvoke(x);
        }

        public FunctionOperations(string function)
        {
            Function = function;
            LeftLimit = 0;
            RightLimit = 1;
            NumberOfPoints = 100;
            X = new double[NumberOfPoints];
            Y = new double[NumberOfPoints];
            Tabulation();
        }
    }
}
