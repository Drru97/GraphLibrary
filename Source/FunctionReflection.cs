using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using Microsoft.CSharp;

namespace GraphLibrary.Source
{
    /// <summary>
    /// This class is used to convert specifed as
    /// string functions into lambda expressions
    /// </summary>
    public class FunctionReflection
    {
        /// <value> Sets functions as a string </value>
        public string Function { get; set; }
        private readonly CSharpCodeProvider _codeProvider;
        private readonly CompilerParameters _compilerParameters;
        private CompilerResults _compilerResults;
        private Delegate _delegate;
        private const string BeginString = @"using System;
                                            namespace Test
                                             {
                                                   public delegate double Calc(double x);
                                                   public static class FunctionCreator
                                                   {
                                                       public static Calc CreateFunction()
                                                       {
                                                          return x=>";
        private const string EndString = @";
                                 }
                            }
                        }";

        /// <summary>
        /// Creates an instance of this class
        /// with specified comliler parameters
        /// </summary>
        /// <param name="function"> Mathematical function in string view </param>
        public FunctionReflection(string function)
        {
            Function = function;
            _codeProvider = new CSharpCodeProvider();
            _compilerParameters = new CompilerParameters
            {
                GenerateInMemory = true,
                ReferencedAssemblies = { "System.dll" }
            };
            Compile();
        }

        /// <summary>
        /// This method is used to compile source code
        /// from strings with specified parameters
        /// </summary>
        /// <exception cref="FileNotFoundException"> Throws when 
        /// given incorrect function and compiler cannot compile assembly</exception>
        private void Compile()
        {
            _compilerResults = _codeProvider.CompileAssemblyFromSource(_compilerParameters,
                BeginString + Function + EndString);
            try
            {
                var cls = _compilerResults.CompiledAssembly.GetType("Test.FunctionCreator");
                var method = cls.GetMethod("CreateFunction", BindingFlags.Static | BindingFlags.Public);
                _delegate = (method.Invoke(null, null) as Delegate);
            }
            catch (FileNotFoundException)
            {
                // ignored
            }
        }

        /// <summary>
        /// This method is used to dynamic invoke lambda
        /// expression as a result of compilation
        /// </summary>
        /// <param name="x"> Function argument x </param>
        /// <returns> Function value y </returns>
        /// <exception cref="ArgumentNullException"> Throws when
        /// given incorrect function </exception>
        public double InvokeMethod(double x)
        {
            if (_delegate == null)
                throw new ArgumentNullException(nameof(x), "Incorrect function");
            return (double)_delegate.DynamicInvoke(x);
        }
    }
}
