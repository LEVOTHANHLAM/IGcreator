using InstargramCreator.Models;

namespace InstargramCreator.GetProcess
{
    public class GetFullName
    {
        public static FullNameInfoModel GetName()
        {
            try
            {
                lock (GlobalModel.LookFullName)
                {
                    if (GlobalModel.FullNames.Count() == 0) return null;
                    List<FullNameInfoModel> fullNameavailable = GlobalModel.FullNames.FindAll(x => !x.IsRunning).ToList();
                    if (fullNameavailable.Count() > 0)
                    {
                        int indexFullName = GlobalModel.FullNames.IndexOf(fullNameavailable.First());
                        GlobalModel.FullNames[indexFullName].IsRunning = true;
                        return GlobalModel.FullNames[indexFullName];
                    }
                }
            }
            catch (Exception ex) 
            {
                Serilog.Log.Error(ex.ToString());
            }
            return null;
        }
    }
}
