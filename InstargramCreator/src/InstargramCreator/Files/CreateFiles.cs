using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.Files
{
    public class CreateFiles
    {
        public static void CreateFile()
        {
            string fileTextPath = @"DataFile";
            if (!Directory.Exists(fileTextPath))
            {
                Directory.CreateDirectory(fileTextPath);
                File.Create(GlobalModel.LogPath);
                File.Create(GlobalModel.ResutlPath);
            }
            if (!File.Exists("adb.exe"))
            {
                File.Copy(GlobalModel.SourcePath + "\\adb.exe", "adb.exe");
                File.Copy(GlobalModel.SourcePath + "\\AdbWinApi.dll", "AdbWinApi.dll");
                File.Copy(GlobalModel.SourcePath + "\\AdbWinUsbApi.dll", "AdbWinUsbApi.dll");
            }
        }
        public static void RemoveFile(List<string> listName, string filePath)
        {   
            try
            {
                List<string> listTMP = new List<string>();
                string fileTMP = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + ".tmp");
                using (StreamWriter writer = new StreamWriter(fileTMP))
                {
                    var line = File.ReadAllLines(filePath);
                    for (int i = 0; i < line.Length; i++)
                    {
                        bool isUsed = false;
                        foreach (string name in listName)
                        {
                            if (line[i].StartsWith(name))
                            {
                                isUsed = true;
                                break;
                            }
                        }
                        if (!isUsed)
                        {
                            listTMP.Add(line[i]);
                        }
                    }
                    foreach (string name in listTMP)
                    {
                        writer.WriteLine(name);
                    }
                    Log.Information($"{listTMP.Count}");
                }
                File.Delete(filePath);
                File.Move(fileTMP, filePath);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}
        