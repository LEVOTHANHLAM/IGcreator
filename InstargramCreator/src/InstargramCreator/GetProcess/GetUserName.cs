using InstargramCreator.Files;
using InstargramCreator.Models;

namespace InstargramCreator.GetProcess
{
    public class GetUserName
    {
        public static UserInfoModel GetUser()
        {
            try
            {
                lock (GlobalModel.LockUers)
                {
                    if (GlobalModel.Users.Count() == 0) return null;
                    List<UserInfoModel> userInfoavailable = GlobalModel.Users.FindAll(x => !x.IsUsing).ToList();
                    if (userInfoavailable.Count() > 0)
                    {
                        int indexUsertName = GlobalModel.Users.IndexOf(userInfoavailable.First());
                        GlobalModel.Users[indexUsertName].IsUsing = true;
                        return GlobalModel.Users[indexUsertName];
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
