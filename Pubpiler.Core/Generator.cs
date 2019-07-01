using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Pubpiler.Core
{
    public class Generator
    {
        public virtual void Compile(string protoRuntimeRootPath, IEnumerable<(string lang, string outputPath)> langsOutput, params string[] protoFiles)
        {
            var procPath = @"C:\Users\Cybg\.nuget\packages\google.protobuf.tools\3.8.0\tools\windows_x64\protoc.exe";
            var grpcPath = @"‪C:\Users\Cybg\.nuget\packages\grpc.tools\1.21.0\tools\windows_x64\grpc_csharp_plugin.exe";

            var proc = new Process();

            var langOutPutStr = string.Join(" ", langsOutput.Select(m => $"--{m.lang}_out={m.outputPath}"));
            var protoFilesStr = string.Join(" ", protoFiles);
            var ps = $@"-I={protoRuntimeRootPath} {langOutPutStr} {protoFilesStr} -I C:\Users\Cybg\Desktop\cc --grpc_out C:\Users\Cybg\Desktop\cc --plugin=protoc-gen-grpc={grpcPath}";
            proc.StartInfo = new ProcessStartInfo(procPath, ps)
            {
                UseShellExecute = false,
                CreateNoWindow = false
            };
            proc.OutputDataReceived += (s, e) =>
            {
                Console.WriteLine($"收到Data:{e.Data}");
            };
            proc.Start();
        }

        public virtual void Compile(string protoRuntimeRootPath,
            IEnumerable<(Langs lang, string outputPath)> langsOutput, string folder)
        {
            var langsOutputStr = langsOutput.Select(m => (GetLangOutCmd(m.lang), m.outputPath));

            var targetProtoDirectory = Path.Combine(protoRuntimeRootPath, folder);
            var allProtoFiles = Directory.GetFiles(targetProtoDirectory, $"*.proto");

            Compile(protoRuntimeRootPath, langsOutputStr, allProtoFiles);
        }



        /// <summary>
        /// Get all langs' output cmd name
        /// </summary>
        /// <param name="lang">Language enum</param>
        /// <returns></returns>
        public virtual string GetLangOutCmd(Langs lang)
        {
            switch (lang)
            {
                case Langs.CPlusPlus:
                    {
                        return "cpp";
                    }
                case Langs.CSharp:
                    {
                        return "csharp";
                    }
                case Langs.Dart:
                    {
                        return "dart";
                    }
                case Langs.Go:
                    {
                        return "go";
                    }
                case Langs.Java:
                    {
                        return "java";
                    }
                case Langs.JavaNano:
                    {
                        return "javanano";
                    }
                case Langs.Js:
                    {
                        return "js";
                    }
                case Langs.ObjC:
                    {
                        return "objc";
                    }
                case Langs.PHP:
                    {
                        return "php";
                    }
                case Langs.Python:
                    {
                        return "python";
                    }
                case Langs.Ruby:
                    {
                        return "ruby";
                    }
                case Langs.Swift:
                    {
                        return "swift";
                    }
                default:
                    {
                        return null;
                    }
            }
        }


    }
}
