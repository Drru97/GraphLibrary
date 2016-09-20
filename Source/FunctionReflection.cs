using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace GraphLibrary.Source
{
    public class FunctionReflection
    {
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

        public FunctionReflection(string function)
        {
            Function = function;
            _codeProvider = new CSharpCodeProvider();
            _compilerParameters = new CompilerParameters { GenerateInMemory = true, ReferencedAssemblies = { "System.dll" } };
            Compile();
        }

        private void Compile()
        {
            _compilerResults = _codeProvider.CompileAssemblyFromSource(_compilerParameters,
                BeginString + Function + EndString);
            var cls = _compilerResults.CompiledAssembly.GetType("Test.FunctionCreator");
            var method = cls.GetMethod("CreateFunction", BindingFlags.Static | BindingFlags.Public);
            _delegate = (method.Invoke(null, null) as Delegate);
        }

        public double InvokeMethod(double x)
        {
            return (double)_delegate.DynamicInvoke(x);
        }
    }
}
