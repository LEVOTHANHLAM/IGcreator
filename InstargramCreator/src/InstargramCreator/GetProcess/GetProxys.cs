using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.GetProcess
{
    public class GetProxys
    {
        public static ProxyInfoModel GetProxy()
        {
            try
            {
                lock (GlobalModel.LockProxys)
                {
                    Log.Information("GetProxy " + GlobalModel.Proxys.Count);                
                    if (GlobalModel.Proxys.Count == 0)
                    {
                        return null;
                    }                        
                    List<ProxyInfoModel> proxyavailable = GlobalModel.Proxys.FindAll(x => !x.IsUsing).ToList();
                    if (proxyavailable.Count() > 0)
                    {
                        int indexproxy = GlobalModel.Proxys.IndexOf(proxyavailable.First());
                        GlobalModel.Proxys[indexproxy].IsUsing = true;
                        return GlobalModel.Proxys[indexproxy];
                    }
                }
            }
            catch (Exception ex) 
            {
                Log.Error(ex, ex.Message);
            }          
            return null;
        }
        public static void CheckProxy(List<ProxyInfoModel> resultProxy)
        {
            try
            {
                lock (GlobalModel.LockProxys)
                {
                    Log.Information("CheckProxy " + resultProxy.Count);
                    int indexProxy = resultProxy.Count - 1;
                    if (resultProxy[indexProxy].IsUsing == true)
                    {
                        resultProxy.All(x => x.IsUsing == false);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}
