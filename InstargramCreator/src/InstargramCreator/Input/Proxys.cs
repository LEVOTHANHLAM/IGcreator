using InstargramCreator.Models;
using Serilog;
using System.Net;
using System.Text;

namespace InstargramCreator.Input
{
    public class Proxys
    {

        public Proxys()
        {
        }
        public static string OpendialogFileProxy(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var proxyline = File.ReadAllLines(openFileDialog.FileName);
                MessageBox.Show("Add " + proxyline.Length + " Proxy ");
                TextInfoModel.txtFileProxy = openFileDialog.FileName;
                return TextInfoModel.txtFileProxy;
            }
            return null;
        }
        public void AddFileproxy(string filePath)
        {
            try
            {
                var proxyfile = File.ReadAllLines(filePath);
                GlobalModel.Proxys.Clear();
                for (int i = 0; i < proxyfile.Length; i++)
                {
                    string[] proxy = proxyfile[i].Split(',', ':', ';', '/', '|');
                    if (!string.IsNullOrEmpty(proxy[0]) && !string.IsNullOrEmpty(proxy[1]))
                    {
                        ProxyInfoModel proxyinfo = new ProxyInfoModel();
                        proxyinfo.Ip = proxy[0];
                        proxyinfo.Port = proxy[1];
                        if (proxy.Count() == 2)
                        {
                            proxyinfo.User = null;
                            proxyinfo.Pass = null;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(proxy[2]) && !string.IsNullOrEmpty(proxy[3]))
                            {
                                proxyinfo.User = proxy[2];
                                proxyinfo.Pass = proxy[3];
                            }
                        }
                        GlobalModel.Proxys.Add(proxyinfo);
                        BindingSource soureProxy = new BindingSource();
                        soureProxy.DataSource = GlobalModel.Proxys;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        public void RequsetProxy(string Url)
        {
            try
            {
                HashSet<string> strings = new HashSet<string>();
                var result = GetFileViaHttp(Url);
                string str = Encoding.UTF8.GetString(result);
                string[] strArr = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);                
                foreach (string str1 in strArr)
                {
                    if (!strings.Contains(str1))
                    {
                        string[] STR = str1.Split(new[] { ",", ":", ";", "/", "|" }, StringSplitOptions.RemoveEmptyEntries);
                        strings.Add(str1);
                        ProxyInfoModel proxyinfo = new ProxyInfoModel();
                        proxyinfo.Ip = STR[0];
                        proxyinfo.Port = STR[1];
                        if (STR.Count() == 2)
                        {
                            proxyinfo.User = string.Empty;
                            proxyinfo.Pass = string.Empty;
                        }
                        else
                        {
                            proxyinfo.User = STR[2];
                            proxyinfo.Pass = STR[3];
                        }
                        GlobalModel.Proxys.Add(proxyinfo);
                        BindingSource soureProxy = new BindingSource();
                        soureProxy.DataSource = GlobalModel.Proxys;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
                Log.Error("RequsetProxy");
            }

        }
        private static byte[] GetFileViaHttp(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadData(url);
            }
        }
    }
}



