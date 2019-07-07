using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Pubpiler.Core
{
    public class Generator
    {
        /// <summary>
        /// Compile
        /// </summary>
        /// <param name="protoRuntimeRootPath">Proto files' root folder path.This path should be root path when write proto files.(When use import clause in proto script inside)</param>
        /// <param name="protoFiles">target proto files's absolute path array in root path</param>
        /// <param name="langOutputs">K-V type array, to indicate different langs with different paths</param>
        public virtual void Compile(string protoRuntimeRootPath,
            IEnumerable<string> protoFiles, IEnumerable<(string lang, string outputPath)> langOutputs)
        {
            var procPath = @"C:\Users\Cybg\.nuget\packages\google.protobuf.tools\3.8.0\tools\windows_x64\protoc.exe";
            var grpcPath = @"C:\Users\Cybg\.nuget\packages\grpc.tools\1.21.0\tools\windows_x64\grpc_csharp_plugin.exe";

            var proc = new Process();

            var langOutPutStr = string.Join(" ", langOutputs.Select(m => $"--{m.lang}_out={m.outputPath}"));
            var protoFilesStr = string.Join(" ", protoFiles);
            var ps = $@"-I={protoRuntimeRootPath} {langOutPutStr} {protoFilesStr} -I C:\Users\Cybg\Desktop\cc --grpc_out C:\Users\Cybg\Desktop\cc --plugin=protoc-gen-grpc={grpcPath}";
            proc.StartInfo = new ProcessStartInfo(procPath, ps)
            {
                UseShellExecute = false,
                CreateNoWindow = false
            };
            proc.OutputDataReceived += (s, e) =>
            {
                Console.WriteLine($"OUTPUT:{e.Data}");
            };
            proc.Start();
        }

        /// <summary>
        /// Compile
        /// </summary>
        /// <param name="protoRuntimeRootPath">Proto files' root folder path.This path should be root path when write proto files.(When use import clause in proto script inside)</param>
        /// <param name="folder">Sub-folder name in root folder</param>
        /// <param name="langOutputs">K-V type array, to indicate different langs with different paths</param>
        public virtual void Compile(string protoRuntimeRootPath,
            string folder, params (Langs lang, string outputPath)[] langOutputs)
        {
            var langsOutputStr = langOutputs.Select(m => (GetLangOutCmd(m.lang), m.outputPath));

            var targetProtoDirectory = Path.Combine(protoRuntimeRootPath, folder);
            var allProtoFiles = Directory.GetFiles(targetProtoDirectory, $"*.proto");

            Compile(protoRuntimeRootPath, allProtoFiles, langsOutputStr);
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
                        throw new ArgumentNullException("Unspecific language");
                    }
            }
        }


    }
}
