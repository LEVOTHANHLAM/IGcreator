using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.GetProcess
{
    public class GetBio
    {
        public  BioInfoModel GetsBio()
        {
            try
            {
                lock (GlobalModel.LockBio)
                {
                    Log.Information("GetBio " + GlobalModel.Bio.Count);
                    if (GlobalModel.Bio.Count() == 0) return null;
                    List<BioInfoModel> biovailable = GlobalModel.Bio.Where(x => x.IsRunning == false).ToList();
                    if (biovailable.Count > 0)
                    {
                        var result = biovailable.Where(x => x.Bio == biovailable.First().Bio).FirstOrDefault();
                        result.IsRunning = true;
                        return result;
                    }
                }
            }
            catch (Exception ex) 
            {
                Log.Error(ex, ex.Message);
            }
            return null;
        }
    }
}
