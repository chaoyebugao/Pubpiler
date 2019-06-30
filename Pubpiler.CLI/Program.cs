using System;
using System.Diagnostics;

namespace Pubpiler.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var exePath = @"C:\Users\Cybg\.nuget\packages\google.protobuf.tools\3.8.0\tools\windows_x64\protoc.exe";

            var scriptPath = @"C:\Users\Cybg\Desktop\ProtoScripts";

            var outPutPath = @"C:\Users\Cybg\Desktop\cc";

            var myProcess = new Process();
            //myProcess.StartInfo.FileName = exePath;
            myProcess.StartInfo.UseShellExecute = true;
            var ps = $@"-I={scriptPath} --swift_out={outPutPath} {scriptPath}\Test\SysEnumeration.proto {scriptPath}\Test\ResponseModel.proto";
            myProcess.StartInfo = new ProcessStartInfo(exePath, ps);
            myProcess.StartInfo.CreateNoWindow = false;
            myProcess.OutputDataReceived += (s, e) =>
            {
                Console.WriteLine($"收到Data:{e.Data}");
            };
            myProcess.Start();


            Console.WriteLine("执行完毕");
            Console.ReadKey();
        }
    }
}
