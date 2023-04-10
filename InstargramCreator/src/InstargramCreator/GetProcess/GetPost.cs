using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.GetProcess
{
    public class GetPost
    {
        public PostInfoModel GetImgPost()
        {
            try
            {
                lock (GlobalModel.LockPost)
                {
                    Log.Information("GetImgPost " + GlobalModel.Post.Count);
                    if (GlobalModel.Post.Count == 0) return null;
                    List<AvatarInfoModel> postavailable = GlobalModel.Post.Where(x => x.IsRunning == false).ToList();
                    if (postavailable.Count > 0)
                    {
                        var result = postavailable.Where(x => x.Img == postavailable.First().Img).FirstOrDefault();
                        result.IsRunning = true;
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
