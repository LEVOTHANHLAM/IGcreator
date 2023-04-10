using InstargramCreator.Models;

namespace InstargramCreator.MultiTask
{
    public class DeviceInfo
    {
        public int Index { get; set; }
        public string Id { get; set; }
        public bool IsUsing { get; set; }
        public string Status { get; set; }
        public MailInfoModel Email { get; set; }
        public ProxyInfoModel Proxy { get; set; }
        public AvatarInfoModel Avatar { get; set; }
        public UserInfoModel User { get; set; }
       public FullNameInfoModel FullName { get; set; }
        public BioInfoModel Bio { get; set; }
        public PostInfoModel Post { get; set; }
    }
}
