using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Pubpiler
{
    /// <summary>
    /// Protobuf & Grpc's script compiler
    /// </summary>
    public class Pubpiler
    {
        private const string procToolName = "google.protobuf.tools";
        private const string procToolVersion = "3.8.0";
        private const string procToolExeName = "protoc.exe";

        private const string grpcToolName = "google.protobuf.tools";
        private const string grpcToolVersion = "1.22.0";
        private const string grpcToolExeName = "grpc_csharp_plugin.exe";

        /// <summary>
        /// Compile
        /// </summary>
        /// <param name="protoRuntimeRootPath">Proto files' root folder path.This path should be root path when write proto files.(When use import clause in proto script inside)</param>
        /// <param name="folder">Sub-folder name in root folder</param>
        /// <param name="grpcOutputPath">If has grpc service defined, please specific the output path</param>
        /// <param name="langOutputs">K-V type array, to indicate different langs with different paths</param>
        public static void Compile(string protoRuntimeRootPath,
            string folder, string grpcOutputPath, params (Langs lang, string outputPath)[] langOutputs)
        {
            var procToolPath = GetProcToolPath();
            var grpcToolPath = GetGrpcToolPath();

            var generator = new Generator(procToolPath, grpcToolPath);
            generator.Compile(protoRuntimeRootPath, folder, grpcOutputPath, langOutputs);
        }

        /// <summary>
        /// Get protoc.exe path from nuget
        /// </summary>
        /// <returns></returns>
        private static string GetProcToolPath()
        {
            var nugetPath = GetNugetPackagePath();
            var osArchPath = GetOsPath();

            var path = Path.Combine(nugetPath,
                procToolName,
                procToolVersion,
                "tools",
                osArchPath,
                procToolExeName);
            return path;
        }

        /// <summary>
        /// Get protoc.exe path from nuget
        /// </summary>
        /// <returns></returns>
        private static string GetGrpcToolPath()
        {
            var nugetPath = GetNugetPackagePath();
            var osArchPath = GetOsPath();

            var path = Path.Combine(nugetPath,
                grpcToolName,
                grpcToolVersion,
                "tools",
                osArchPath,
                grpcToolExeName);
            return path;
        }

        /// <summary>
        /// Get os and architecture directory path
        /// </summary>
        /// <returns></returns>
        private static string GetOsPath()
        {
            var os = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                os = "windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                os = "macosx";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                os = "linux";
            }

            var arch = RuntimeInformation.OSArchitecture;
            var archStr = arch.ToString().ToLower();

            return $"{os}_{archStr}";
        }

        /// <summary>
        /// Get nuget package directory path
        /// </summary>
        /// <returns></returns>
        private static string GetNugetPackagePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                @".nuget\packages");
        }
    }
}
