using System;
using System.Collections.Generic;

namespace Pubpiler.Core
{
    public class Generator
    {
        public virtual void BuildCommand(string scriptRootPath, IEnumerable<(Langs, string)> langOutputPath, string relativeFolder)
        {

        }
    }
}
