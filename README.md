# Introduction
Pubpiler is a tool that can generate proto type messages and gRPC services to different languages, by simple configuration.

# Usage
```C#
<p>
var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PubpilerTests");
Directory.CreateDirectory(outputPath);

var outputs = new (Langs lang, string outputPath)[]
{
    (Langs.CSharp, outputPath),
    (Langs.Js, outputPath),
};
Pubpiler.Compile("Scripts", "Common", null, outputs);
</p>
```

