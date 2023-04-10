using InstargramCreator.Models;

namespace InstargramCreator.Input
{
    public class Post
    {
        public Post()
        {
        }
        public void AddPost(string folderPath)
        {
            try
            {
                Serilog.Log.Error("AddPost " + folderPath);
                DirectoryInfo folder = new DirectoryInfo(folderPath);
                FileInfo[] images = folder.GetFiles();
                foreach (var image in images)
                {
                    if (image.Extension.ToLower() == ".png" || image.Extension.ToLower() == ".jpg")
                    {
                        if (!image.Name.Contains(" "))
                        {
                            PostInfoModel post = new PostInfoModel();
                            post.Img = image.FullName;
                            post.NameImg = image.Name;
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