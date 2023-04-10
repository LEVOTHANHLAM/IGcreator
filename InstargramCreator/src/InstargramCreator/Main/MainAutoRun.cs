using AppAuto.Mission;
using InstargramCreator.ApiQnibot;
using InstargramCreator.Mission;
using InstargramCreator.Models;
using InstargramCreator.Repositories;
using LDPlayerNTC;

namespace InstargramCreator.Mains
{
    public class MainAutoRun
    {
        private readonly IAccountRepository _accountRepository;
        public int Index { get; set; }
        public string IP { get; set; }
        public string name { get; set; }
        bool IsRunning { get; set; }
        FullNameInfoModel fullName { get; set; }
        UserInfoModel userName { get; set; }
        PostInfoModel postInfo { get; set; }
        AvatarInfoModel avatarInfo { get; set; }
        BioInfoModel bioInfo { get; set; }   
        ProxyInfoModel proxy { get; set; }
        MailInfoModel eMail { get; set; }
        ProxyDroid _ProxyDroid;
        Instagram _Instagram;
        public MainAutoRun(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _Instagram = new Instagram(_accountRepository);
            proxy = new ProxyInfoModel();
            fullName = new FullNameInfoModel();
            userName = new UserInfoModel();
            postInfo = new PostInfoModel();
            avatarInfo = new AvatarInfoModel();
            bioInfo = new BioInfoModel();
            eMail = new MailInfoModel();
            _ProxyDroid = new ProxyDroid();
        }
        public void SetProxy(ProxyInfoModel proxy)
        {
            this.proxy = proxy;
        }
        public void SetFullName(FullNameInfoModel fullName)
        {
            this.fullName = fullName;
        }
        public void SetUserName(UserInfoModel userName)
        {
            this.userName = userName;
        }
        public void SetBio(BioInfoModel bioInfo)
        {
            this.bioInfo = bioInfo;
        }
        public void SetImgPost(PostInfoModel postInfo)
        {
            this.postInfo = postInfo;
        }
        public void SetImgAvatar(AvatarInfoModel avatarInfo)
        {
            this.avatarInfo = avatarInfo;
        }
        public void SetEmail(MailInfoModel email)
        {
            this.eMail = email;
        }
        async void AutoMain()
        {
            try
            {
                LDController.Open("index", this.Index.ToString());
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Open LdPlayer " + this.Index);
                if (this.Index == 1)
                {
                    HttpHelper httpHelper = new HttpHelper();
                    string hardwareId = httpHelper.GetHardwareId();
                    var softwareId = Constant.SoftwareId;
                    var checkLicenseResult = await httpHelper.CheckLicense(Constant.licenseKey, hardwareId, softwareId);
                    if (checkLicenseResult.Data is false)
                    {
                        LDController.CloseAll();
                        MessageBox.Show(checkLicenseResult.Message);
                    }
                }
                var checkGetDevices = LDController.CheckLDStartDone("index", this.Index.ToString());
                if (checkGetDevices == false)
                {                   
                    LDController.Close("index", this.Index.ToString());
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") +"Error " + " LdPlayer " + this.Index.ToString() + " Connect Fail");
                    return;
                }
                if (RadioInfoModel.radioNoProxy == false)
                {
                    _ProxyDroid.ProxyDroid_(Index, proxy, eMail);
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + this.Index + " Connect Proxy " + eMail.Proxy);
                }
                _Instagram.Auto(this.Index, this.eMail, this.fullName, this.userName, this.bioInfo, this.avatarInfo, this.postInfo);
                LDController.Close("index", this.Index.ToString());
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Close LdPlayer " + this.Index);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") +"Error " + " LDPlayer " + this.Index + ex.Message);
                LDController.Close("index", this.Index.ToString());
            }
        }
        public void BeginAuto()
        {
            Thread.Sleep(3000);
            try
            {
                GlobalModel.MainThreadAuto = new Thread(AutoMain);
                GlobalModel.MainThreadAuto.IsBackground = true;
                GlobalModel.MainThreadAuto.Start();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, ex.Message.ToString());
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + ex.Message);
            }
        }
    }
}