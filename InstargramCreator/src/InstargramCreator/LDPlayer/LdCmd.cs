using LDPlayerNTC;
using System.Diagnostics;

namespace AppAuto.LDPlayer
{
    public class LdCmd
    {
        public string FolderPath = string.Empty;
        string RootFolderPath = string.Empty;
        public LdCmd()
        {       
        }
        public string RunEmuConsole(string args, int Timeout = 10000, bool showConsole = true)
        {           
            if (!File.Exists(LDController.pathLDConsole))
            {
                return string.Empty;
            }         
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = LDController.pathLDConsole;     
            pProcess.StartInfo.Arguments = args;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;       
            pProcess.StartInfo.RedirectStandardOutput = true;         
            pProcess.Start();
            string strOutput = "";
            pProcess.OutputDataReceived += new DataReceivedEventHandler((object sender, DataReceivedEventArgs e) =>
            {              
                strOutput += e.Data + "|";
            });
            pProcess.BeginOutputReadLine();        
            for (int i = 0; i < Timeout / 100; i++)
            {
                Thread.Sleep(100);
                if (pProcess.HasExited) break;
            }
            if (!pProcess.HasExited) pProcess.Kill();
            if (showConsole) Console.WriteLine(strOutput);
            if (strOutput.Contains("ADB server didn't ACK"))
            {             
                Thread.Sleep(1000);
                RunCommand("taskkill /f /im adb.exe");
                Thread.Sleep(15000);
            }
            return strOutput;
        }
        public static string RunCommand(string args, int Timeout = 10000, bool showConsole = true)
        {          
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "cmd.exe";
            pProcess.StartInfo.Arguments = "/c " + args;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.Start();          
            string strOutput = "";
            pProcess.OutputDataReceived += new DataReceivedEventHandler((object sender, DataReceivedEventArgs e) =>
            {
                strOutput += e.Data + "\n";
            });
            pProcess.BeginOutputReadLine();     
            for (int i = 0; i < Timeout / 100; i++)
            {
                Thread.Sleep(100);
                if (pProcess.HasExited) break;
            }
            if (!pProcess.HasExited) pProcess.Kill();
            if (showConsole) Console.WriteLine(strOutput);
            return strOutput;
        }
    }
}
