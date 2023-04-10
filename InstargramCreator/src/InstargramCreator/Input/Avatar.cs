
using InstargramCreator.Models;
using System.Windows.Forms;

namespace InstargramCreator.Input
{
    public class Avatar
    {

        public Avatar( )
        {
        }
        public void AddAvatar(string folderPath)
        {
            try
            {
                Serilog.Log.Error("AddAvatar " + folderPath);
                DirectoryInfo folder = new DirectoryInfo(folderPath);
                FileInfo[] images = folder.GetFiles();
                foreach (var image in images)
                {
                    if (image.Extension.ToLower() == ".png" || image.Extension.ToLower() == ".jpg")
                    {
                        if (!image.Name.Contains(" "))
                        {
                            AvatarInfoModel avatar = new AvatarInfoModel();
                            avatar.Img = image.FullName;
                            avatar.NameImg = image.Name;
                            GlobalModel.Avatar.Add(avatar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
    }
}