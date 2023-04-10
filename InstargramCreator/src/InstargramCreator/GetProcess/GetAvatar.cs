using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.GetProcess
{
    public class GetAvatar
    {
        public AvatarInfoModel GetImgAvatar()
        {
            try
            {
                lock (GlobalModel.LockAvatar)
                {
                    Log.Information("GetImgAvatar " + GlobalModel.Avatar.Count);
                    if (GlobalModel.Avatar.Count == 0) return null;
                    List<AvatarInfoModel> avartaravailable = GlobalModel.Avatar.Where(x => x.IsRunning == false).ToList();
                    if (avartaravailable.Count > 0)
                    {
                        var result = avartaravailable.Where(x => x.Img == avartaravailable.First().Img).FirstOrDefault();
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
