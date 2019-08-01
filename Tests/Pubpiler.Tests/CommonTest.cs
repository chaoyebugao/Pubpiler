using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Pubpiler.Tests
{
    public class CommonTest
    {
        [Fact]
        public void Generate()
        {
            var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PubpilerTests");
            Directory.CreateDirectory(outputPath);

            var outputs = new (Langs lang, string outputPath)[]
            {
                (Langs.CSharp, outputPath),
                (Langs.Js, outputPath),
            };
            Pubpiler.Compile("Scripts", "Common", null, outputs);
        }
    }
}
