using InstargramCreator.Mains;
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
        public void LoadLdPlayer(List<MainAutoRun> ListDevices)
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
                    MainAutoRun driver = new MainAutoRun(_accountRepository);
                    driver.Index = int.Parse(s[0]);
                    driver.name = s[0];
                    ListDevices.Add(driver);
                }
                soureLDPlayer.DataSource = ListDevices;
            }
            catch (Exception ex) { Serilog.Log.Error(ex.ToString()); }          
        }
    }
}
