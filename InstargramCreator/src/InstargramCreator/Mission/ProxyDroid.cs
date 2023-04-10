using InstargramCreator.Models;
using LDPlayerNTC;
using Serilog;

namespace AppAuto.Mission
{
    public class ProxyDroid
    {

        public ProxyDroid()
        {
        }
        public void ProxyDroid_(int Index, ProxyInfoModel proxy, MailInfoModel mail)
        {
            try
            {
                LDController.ClearCaches("index", Index.ToString(), "org.proxydroid");
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Clear Caches");
                LDController.Delay();
                LDController.RunApp("index", Index.ToString(), "org.proxydroid");
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Open ProxyDroid ");
                LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Host, 120000);
                LDController.Delay();
                LDController.InputText("index", Index.ToString(), proxy.Ip);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Import Host: " + proxy.Ip);
                LDController.Delay();
                LDController.TapByPercent("index", Index.ToString(), 79.5, 61.4);
                LDController.Delay();
                LDController.TapByPercent("index", Index.ToString(), 41.3, 81.6);
                LDController.Delay();
                LDController.TapByPercent("index", Index.ToString(), 26.2, 51.4);
                LDController.Delay();
                LDController.LongPress("index", Index.ToString(), 100, 500, 1000);
                LDController.Delay();
                LDController.Key("index", Index.ToString(), ADBKeyEvent.KEYCODE_DEL);
                LDController.Delay();
                LDController.InputText("index", Index.ToString(), proxy.Port);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Import Port: " + proxy.Port);
                LDController.Delay();
                LDController.TapByPercent("index", Index.ToString(), 79.5, 61.4);
                LDController.Delay();
                if (RadioInfoModel.radioSock5 == true)
                {
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Type);
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Sock5);
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Click Sock5 ");
                }
                if (proxy.User != null)
                {
                    LDController.SwipeByPercent("index", Index.ToString(), 47.6, 88.8, 47.6, 20, 4000);
                    LDController.SwipeByPercent("index", Index.ToString(), 47.6, 88.8, 47.6, 30, 4000);
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Enable);
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.User);
                    LDController.Delay();
                    LDController.InputText("index", Index.ToString(), proxy.User);
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Import User: " + proxy.User);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 79.5, 61.4);
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Password);
                    LDController.Delay();
                    LDController.InputText("index", Index.ToString(), proxy.Pass);
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " Import Password: " + proxy.Pass);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 79.5, 61.4);
                    LDController.Delay();
                    LDController.SwipeByPercent("index", Index.ToString(), 47.6, 40, 47.6, 108.8, 200);
                    LDController.SwipeByPercent("index", Index.ToString(), 47.6, 30, 47.6, 110.8, 2000);
                    LDController.Delay();
                }
                LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Switch);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + " LDPlayer " + Index + " On ProxyDroid ");
                LDController.Delay();
                if (proxy.User != null)
                {
                    mail.Proxy = proxy.Ip + ":" + proxy.Port + ":" + proxy.User + ":" + proxy.Pass;
                }
                else
                {
                    mail.Proxy = proxy.Ip + ":" + proxy.Port;
                }
                LDController.Key("index", Index.ToString(), ADBKeyEvent.KEYCODE_HOME);
                LDController.Delay();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}