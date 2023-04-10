using InstargramCreator.Mains;
using InstargramCreator.Models;
using InstargramCreator.MultiTask;
using InstargramCreator.Repositories;

namespace AppAuto.LDPlayer
{
    public class LDPlayers
    {
        LdCmd ldCmd = new LdCmd();       
        public BindingSource soureLDPlayer = new BindingSource();
        IAccountRepository _accountRepository;
        public LDPlayers(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void LoadLdPlayer(List<DeviceInfo> ListDevices)
        {
            try
            {
                string listdevice = ldCmd.RunEmuConsole("list2");
                ListDevices.Clear();
                string[] devicelist = listdevice.Split('|');
                foreach (string deviceitem in devicelist)
                {
                    if (string.IsNullOrEmpty(deviceitem)) continue;
                    string[] s = deviceitem.Split(',');
                    DeviceInfo driver = new DeviceInfo();
                    driver.Index = int.Parse(s[0]);
                    driver.Email = new MailInfoModel();
                    driver.Proxy = new ProxyInfoModel();
                    driver.Avatar = new AvatarInfoModel();  
                    driver.FullName = new FullNameInfoModel();
                    driver.User = new UserInfoModel();
                    driver.Post = new PostInfoModel();
                    ListDevices.Add(driver);
                }
                soureLDPlayer.DataSource = ListDevices;
            }
            catch (Exception ex) { Serilog.Log.Error(ex.ToString()); }          
        }
    }
}
