using AppAuto.Mission;
using InstargramCreator.ApiQnibot;
using InstargramCreator.ChangeInfo.ChangeInfoAndroid;
using InstargramCreator.GetProcess;
using InstargramCreator.Input;
using InstargramCreator.Mission;
using InstargramCreator.Models;
using InstargramCreator.MultiTask;
using InstargramCreator.Repositories;
using LDPlayerNTC;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Org.BouncyCastle.Asn1.Tsp;
using Serilog;
using System.Collections.Concurrent;
using System.Runtime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InstargramCreator.MultiTask
{
    public class MultiTaskManager
    {
        private readonly IAccountRepository _accountRepository;
        private ConcurrentDictionary<int, Task> _runningTasks;
        private CancellationTokenSource _cancellationTokenSource;
        private TaskFactory _taskFactory;
        GetAvatar getAvatar = new GetAvatar();
        GetBio getBio = new GetBio();
        GetPost getPost = new GetPost();
        Proxys _proxys;
        ProxyDroid _ProxyDroid;
        Instagram _Instagram;
        ChangeInfoAndroid _changeInfoAndroid;
        public MultiTaskManager(IAccountRepository accountRepository)
        {
            _runningTasks = new ConcurrentDictionary<int, Task>();
            _cancellationTokenSource = new CancellationTokenSource();
            _taskFactory = new TaskFactory(_cancellationTokenSource.Token,
                                            TaskCreationOptions.LongRunning,
                                            TaskContinuationOptions.None,
                                            TaskScheduler.Default);
            _proxys = new Proxys();
            _accountRepository = accountRepository;
            _Instagram = new Instagram(_accountRepository);
            _ProxyDroid = new ProxyDroid();
            _changeInfoAndroid = new ChangeInfoAndroid();
        }
        public async void StartTasks(List<DeviceInfo> devices)
        {
            try
            {
                int i = 0;
                foreach (var device in devices)
                {
                    if (device != null && device.Index != 99999 && i < GlobalModel.MaxThreads)
                    {
                        var cancellationTokenSource = new CancellationTokenSource();
                        // PauseTokenSource pauseToken = new PauseTokenSource();
                        var task = _taskFactory.StartNew(() => DoWorking(device), cancellationTokenSource.Token);
                        _runningTasks.TryAdd(device.Index, task);
                        Thread.Sleep(1000);
                        i++;
                    }

                }
            }catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
          
        }
        private async void DoWorking(DeviceInfo device)
        {
            while (GlobalModel.ResultRun)
            {
                if (GlobalModel.createAccount >= GlobalModel.MaxAccount)
                {
                    MessageBox.Show("Accomplished");
                    GlobalModel.IsStopAuto = true;
                    GlobalModel.ResultRun = false;
                }
                if (device.IsUsing == false)
                {
                    device.IsUsing = true;
                    //////////////////////////gan du lieu/////////////////////////
                    MailInfoModel mail = new MailInfoModel();
                    if (TextInfoModel.cbCatch == true)
                    {
                        mail.Email = GlobalModel.Emails[0].Email;
                        mail.PassMail = GlobalModel.Emails[0].PassMail;
                        mail.PortImap = GlobalModel.Emails[0].PortImap;
                        mail.Imap = GlobalModel.Emails[0].Imap;
                        device.Email = mail;
                    }
                    else
                    {
                        GetEmail.CheckMailFail(GlobalModel.Emails);
                        mail = GetEmail.GetMail(GlobalModel.Emails);
                        if (mail == null)
                        {
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Run out of Email");
                            GlobalModel.ResultRun = false;
                        }
                        var checkLoginMail = MailKits.CheckLogin(mail.Email, mail.PassMail, mail.Imap, mail.PortImap);
                        if (checkLoginMail == false)
                        {
                            GlobalModel.ListEmail.Add(mail.Email);
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + " LOGIN failed " + mail.Email);
                            continue;
                        }
                        else
                        {
                            device.Email.Email = mail.Email;
                            device.Email.PassMail = mail.PassMail;
                            device.Email.PortImap = mail.PortImap;
                            device.Email.Imap = mail.Imap;
                        }
                    }
                    if (RadioInfoModel.radioUrl == true)
                    {
                        _proxys.RequsetProxy(TextInfoModel.txtUrl);
                    }
                    if (RadioInfoModel.radioNoProxy == false)   
                    {
                        GetProxys.CheckProxy(GlobalModel.Proxys);
                        ProxyInfoModel proxyInfoModel = GetProxys.GetProxy();
                        if (proxyInfoModel == null)
                        {
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Run out of Proxy");
                            GlobalModel.ResultRun = false;
                        }
                        else
                        {
                            device.Proxy = proxyInfoModel;
                        }
                    }
                    if (RadioInfoModel.radioUserCustomize == true)
                    {
                        UserInfoModel userInfoModel = GetUserName.GetUser();
                        if (userInfoModel == null)
                        {
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Run out of UserName");
                            GlobalModel.ResultRun = false;
                        }
                        else
                        {
                            device.User = userInfoModel;
                        }
                    }
                    if (RadioInfoModel.cbAvatar == true)
                    {
                        AvatarInfoModel avatarInfoModel = getAvatar.GetImgAvatar();
                        if (avatarInfoModel != null)
                        {
                            device.Avatar = avatarInfoModel;
                        }
                        lock (GlobalModel.LockAvatar)
                        {
                            if (GlobalModel.Avatar[(GlobalModel.Avatar.Count - 1)].IsRunning == true)
                            {
                                GlobalModel.Avatar.All(x => x.IsRunning == false);
                            }
                        }

                    }
                    if (RadioInfoModel.cbBio == true)
                    {
                        BioInfoModel bioInfoModel = getBio.GetsBio();
                        if (bioInfoModel != null)
                        {
                            device.Bio = bioInfoModel;
                        }
                        lock (GlobalModel.LockBio)
                        {
                            if (GlobalModel.Bio[(GlobalModel.Bio.Count - 1)].IsRunning == true)
                            {
                                GlobalModel.Bio.All(x => x.IsRunning == false);
                            }
                        }
                    }
                    if(RadioInfoModel.cbPost == true)
                    {
                        PostInfoModel postModel = getPost.GetImgPost();
                        if (postModel != null)
                        {
                            device.Post = postModel;
                        }
                    }
                    ///////////////////////Thuc thi kick ban////////////////////////
                    LDController.Open("index", device.Index.ToString());
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Open LdPlayer " + device.Index);
                    if (device.Index == 1)
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
                    var checkGetDevices = LDController.CheckLDStartDone("index", device.Index.ToString());
                    if (checkGetDevices == false)
                    {
                        LDController.Close("index", device.Index.ToString());
                        GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + " LdPlayer " + device.Index.ToString() + " Connect Fail");
                        return;
                    }
                    if (RadioInfoModel.radioNoProxy == false)
                    {
                        _ProxyDroid.ProxyDroid_(device.Index, device.Proxy, device.Email);
                        GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + device.Index + " Connect Proxy " + device.Email.Proxy);
                    }
                    _Instagram.Auto(device.Index, device.Email, device.FullName, device.User, device.Bio, device.Avatar, device.Post);
                    ///////////////////////////////////Change Info/////////////////////////////
                    _changeInfoAndroid.ChangeDevice(device.Id, GlobalModel.PathDevicesJsonFile, GlobalModel.PathDevicesXMLFile);
                    LDController.Delay(2);
                    LDController.Close("index", device.Index.ToString());
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Close LdPlayer " + device.Index);
                    ///////////////////////Add Database/////////////////////////////


                    ///////////////////////Change Info Devices//////////////////////
                    device.IsUsing = false;// cho run lai


                }
            }
        }
    }
}
