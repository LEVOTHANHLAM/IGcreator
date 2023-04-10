using System.Data;

namespace InstargramCreator.Models
{
    public static class GlobalModel
    {
        public static bool ResultRun = true;
        public static int MaxThreads { get; set; }
        public static string SourcePath { get; set; }
        public static int MaxAccount { get; set; }
        public static Thread FormThreadAuto;
        public static int createAccount = 0;
        public static bool IsStopAuto;
        public static string DataPath = Path.Combine(Environment.CurrentDirectory, "DataAccount.mdf");
        public static string MultiPlayerPath { get; set; }  
        public static List<UserInfoModel> Users { get; set; }
        public static Queue<string> rtbLogsQueue = new Queue<string>();
        public static Queue<string> rtbResultQueue = new Queue<string>();
        public static List<string> ListEmail = new List<string>();
        public static List<string> ListProxy = new List<string>();
        public static List<string> ListUserName = new List<string>();
        public static List<string> ListFullName = new List<string>();
        public static List<string> ListAvatar = new List<string>();
        public static List<string> ListBio = new List<string>();
        public static List<ProxyInfoModel> Proxys;
        public static List<UserInfoModel> User;
        public static List<AvatarInfoModel> Avatar;
        public static List<AvatarInfoModel> Post;
        public static List<FullNameInfoModel> FullNames;
        public static List<MailInfoModel> Emails;
        public static List<BioInfoModel> Bio;
        public static readonly object LockProxys = new object();
        public static readonly object LockUers = new object();
        public static readonly object LockAvatar = new object();
        public static readonly object LockPost = new object();
        public static readonly object LockEmails = new object();
        public static readonly object LockBio = new object();
        public static readonly object LookFullName = new object();
        public static string LogPath = Path.Combine(Environment.CurrentDirectory, "DataFile\\Log.txt");
        public static string ResutlPath = Path.Combine(Environment.CurrentDirectory, "DataFile\\Result.txt");
        public static string PathFistNameJsoin = Path.Combine(Environment.CurrentDirectory, "FileJsoin\\firstnames.json");
        public static string PathLastNameJsoin = Path.Combine(Environment.CurrentDirectory, "FileJsoin\\lastnames.json");
        public static string PathUserNameJsoin = Path.Combine(Environment.CurrentDirectory, "FileJsoin\\usernames.json");
        public static string PathFullnameVNJsion = Path.Combine(Environment.CurrentDirectory, "FileJsoin\\FirstNameVN.txt");
        public static string PathDevicesXMLFile = Path.Combine(Environment.CurrentDirectory, "Setting\\Android\\Device.xml");
        public static string PathDevicesJsonFile = Path.Combine(Environment.CurrentDirectory, "Setting\\Android\\DevicesAndroid.json");
    }
}