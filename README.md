# Introduction
Pubpiler is a tool that can generate proto type messages and gRPC services to different languages, by simple configuration / class.

# Usage

## STEP 1
Install nuget package from:	[Nuget](https://www.nuget.org/packages/Pubpiler/)

## STEP 2
Just use the codes below:
```C#
var outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PubpilerTests");
Directory.CreateDirectory(outputPath);

var outputs = new (Langs lang, string outputPath)[]
{
    (Langs.CSharp, outputPath),
    (Langs.Js, outputPath),
};
Pubpiler.Compile("Scripts", "Common", null, outputs);
```

