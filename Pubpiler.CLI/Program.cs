using Pubpiler.Core;
using System;
using System.Diagnostics;

namespace Pubpiler.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptPath = @"C:\Users\Cybg\Desktop\ProtoScripts";

            var outputPath = @"C:\Users\Cybg\Desktop\cc";

            var gen = new Generator();
            var outputs = new (Langs lang, string outputPath)[]
            {
                (Langs.CSharp, outputPath),
                (Langs.Js, outputPath),
            };
            gen.Compile(scriptPath, outputs, "Test");


            Console.WriteLine("Finished.");
            Console.ReadKey();
        }
    }
}
