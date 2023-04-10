using AppAuto.Files;
using AppAuto.LDPlayer;
using InstargramCreator.Files;
using InstargramCreator.GetProcess;
using InstargramCreator.Input;
using InstargramCreator.Mains;
using InstargramCreator.Models;
using InstargramCreator.Repositories;
using LDPlayerNTC;
using Serilog;
using System.Diagnostics;

namespace InstargramCreator
{
    public partial class frmAuto : Form
    {
        private readonly frmMail _frmMail;
        private readonly frmProxy _frmProxy;
        private readonly frmData _frmData;
        private readonly IAccountRepository _accountRepository;
        Email _email;
        Avatar _avatar;
        Post _post;
        Bio _bio;
        Proxys _proxys;
        FullName _fullName;
        Users _users;
        private const int WS_SYSMENU = 0x80000;
        List<MainAutoRun> Devices = new List<MainAutoRun>();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }
        public frmAuto(frmProxy frmProxy, frmMail frmMail, IAccountRepository accountRepository, frmData frmData)
        {
            InitializeComponent();
            InitializeSavedValues();
            _accountRepository = accountRepository;
            _frmProxy = frmProxy;
            _frmMail = frmMail;
            _frmData = frmData;
            txtFullname.Enabled = false;
            txtAvatar.Enabled = false;
            txtPost.Enabled = false;
            txtBio.Enabled = false;
            txtUser.Enabled = false;
            GlobalModel.Proxys = new List<ProxyInfoModel>();
            GlobalModel.Emails = new List<MailInfoModel>();
            GlobalModel.Avatar = new List<AvatarInfoModel>();
            GlobalModel.Bio = new List<BioInfoModel>();
            GlobalModel.Users = new List<UserInfoModel>();
            _email = new Email();
            _avatar = new Avatar();
            _post = new Post();
            _bio = new Bio();
            _proxys = new Proxys();
            _fullName = new FullName();
            _users = new Users();
            GlobalModel.FullNames = new List<FullNameInfoModel>();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Begin);
            thread.IsBackground = true;
            thread.Start();
            Thread thread1 = new Thread(WriteToRichTextbox);
            thread1.IsBackground = true;
            thread1.Start();
            btnStart.Enabled = false;
        }
        public void WriteToRichTextbox()
        {
            while (true)
            {
                if (GlobalModel.rtbLogsQueue.Count > 0)
                {
                    var message = GlobalModel.rtbLogsQueue.Dequeue();
                    if (message.Contains("Error"))
                    {
                        rtbLog.InvokeEx(s => s.AppendText(message, Color.Red, this.Font, true));
                    }
                    else
                    {
                        rtbLog.InvokeEx(s => s.AppendText(message, Color.Orange, this.Font, true));
                    }
                }
                if (GlobalModel.rtbResultQueue.Count > 0)
                {
                    var message = GlobalModel.rtbResultQueue.Dequeue();
                    rtbResult.InvokeEx(s => s.AppendText(message, Color.Orange, this.Font, true));
                }
            }
        }
        private void BeginAuto()
        {
            try
            {
                GlobalModel.FormThreadAuto = new Thread(Auto);
                GlobalModel.FormThreadAuto.IsBackground = true;
                GlobalModel.FormThreadAuto.Start();
            }
            catch (Exception ex)
            {
                Log.Error("BeginAuto");
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void Auto()
        {
            Log.Information("Auto");
            try
            {
                GlobalModel.IsStopAuto = false;
                while (!GlobalModel.IsStopAuto)
                {
                    for (int i = 1; i <= GlobalModel.MaxThreads; i++)
                    {
                        if (GlobalModel.createAccount >= GlobalModel.MaxAccount)
                        {
                            MessageBox.Show("Accomplished");
                            GlobalModel.IsStopAuto = true;
                            break;
                        }
                        int indexLD = i;
                        if (LDController.IsDevice_Running("index", indexLD.ToString()) == false)
                        {
                            LDController.Delay(10);
                            MailInfoModel mail = new MailInfoModel();
                            if (TextInfoModel.cbCatch == true)
                            {
                                mail = GlobalModel.Emails[0];
                            }
                            else
                            {
                                GetEmail.CheckMailFail(GlobalModel.Emails);
                                mail = GetEmail.GetMail(GlobalModel.Emails);
                                if (mail == null)
                                {
                                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Run out of Email");
                                    return;
                                }
                                var check = MailKits.CheckLogin(mail.Email, mail.PassMail, mail.Imap, mail.PortImap);
                                if (check == false)
                                {
                                    GlobalModel.ListEmail.Add(mail.Email);
                                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + " LOGIN failed " + mail.Email);
                                    continue;
                                }
                            }

                            Devices[indexLD].SetEmail(mail);
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
                                    return;
                                }
                                Devices[indexLD].SetProxy(proxyInfoModel);
                            }
                            if (RadioInfoModel.radioUserCustomize == true)
                            {
                                UserInfoModel userInfoModel = GetUserName.GetUser();
                                if (userInfoModel == null)
                                {
                                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Run out of UserName");
                                    return;
                                }
                                Devices[indexLD].SetUserName(userInfoModel);
                            }
                            if (RadioInfoModel.cbAvatar == true)
                            {
                                AvatarInfoModel avatarInfoModel = getAvatar.GetImgAvatar();
                                lock (GlobalModel.LockAvatar)
                                {
                                    if (GlobalModel.Avatar[(GlobalModel.Avatar.Count - 1)].IsRunning == true)
                                    {
                                        GlobalModel.Avatar.All(x => x.IsRunning == false);
                                    }
                                }
                                Devices[indexLD].SetImgAvatar(avatarInfoModel);
                            }
                            if (RadioInfoModel.cbBio == true)
                            {
                                BioInfoModel bioInfoModel = getBio.GetsBio();
                                lock (GlobalModel.LockBio)
                                {
                                    if (GlobalModel.Bio[(GlobalModel.Bio.Count - 1)].IsRunning == true)
                                    {
                                        GlobalModel.Bio.All(x => x.IsRunning == false);
                                    }
                                }
                                Devices[indexLD].SetBio(bioInfoModel);
                            }
                            Devices[indexLD].BeginAuto();

                        }
                        LDController.Delay(10);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void InitializeSavedValues()
        {
            NumberRun.Value = int.Parse((string)Properties.Settings.Default["NumberRun"]);
            NumberThreads.Value = int.Parse((string)Properties.Settings.Default["NumberThreads"]);
            radioPasswordCustomize.Checked = (bool)Properties.Settings.Default["radioPasswordCustomize"];
            txtPasswordCustomize.Text = (string)Properties.Settings.Default["txtPasswordCustomize"];
            radioPasswordRandom.Checked = (bool)Properties.Settings.Default["radioPasswordRandom"];
            txtPasswordRandom.Value = int.Parse((string)Properties.Settings.Default["txtPasswordRandom"]);
            radioFullnameRandom.Checked = (bool)Properties.Settings.Default["radioFullnameRandom"];
            radioFullnameCustomize.Checked = (bool)Properties.Settings.Default["radioFullnameCustomize"];
            txtFullname.Text = (string)Properties.Settings.Default["txtFullname"];
            radioUserRandom.Checked = (bool)Properties.Settings.Default["radioUserRandom"];
            radioUserCustomize.Checked = (bool)Properties.Settings.Default["radioUserCustomize"];
            txtUser.Text = (string)Properties.Settings.Default["txtUser"];
            cbAvatar.Checked = (bool)Properties.Settings.Default["cbAvatar"];
            txtAvatar.Text = (string)Properties.Settings.Default["txtAvatar"];
            cbPost.Checked = (bool)Properties.Settings.Default["cbPost"];
            txtPost.Text = (string)Properties.Settings.Default["txtPost"];
            cbBio.Checked = (bool)Properties.Settings.Default["cbBio"];
            txtBio.Text = (string)Properties.Settings.Default["txtBio"];
            radioRandomVN.Checked = (bool)Properties.Settings.Default["radioRandomVN"];
            txtLastName.Text = (string)Properties.Settings.Default["txtLastName"];
        }
        private void Begin()
        {
            try
            {
                if ((int)NumberThreads.Value > Devices.Count - 2)
                {
                    DialogResult thongbao;
                    thongbao = (MessageBox.Show("LDPlayer has not been initialized.\n Do you want to initialize it now?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
                    if (thongbao == DialogResult.Yes)
                    {
                        GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Initializing LDPlayer! Please Wait...");
                        try
                        {
                            while (true)
                            {
                                int i = Devices.Count - 2;
                                LDController.Copy("LDPlayer " + i, "0");
                                LDPlayers lDPlayers = new LDPlayers(_accountRepository);
                                lDPlayers.LoadLdPlayer(Devices);
                                if ((int)NumberThreads.Value <= Devices.Count - 2)
                                {
                                    MessageBox.Show("LDPlayer Initialization Success");
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, ex.Message);
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Initialize LDPlayer!");
                        return;
                    }
                }
                TextInfoModel.NumberRequest = RandomStrings.RandomNumber(1, (int)NumberThreads.Value);
                procces();
                BeginAuto();
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void procces()
        {
            RadioInfoModel.radioNoProxy = (bool)Properties.Settings.Default["radioNoProxy"];
            RadioInfoModel.radioSock5 = (bool)Properties.Settings.Default["radioSock5"];
            RadioInfoModel.radioHTTP = (bool)Properties.Settings.Default["radioHTTP"];
            RadioInfoModel.radioFileProxy = (bool)Properties.Settings.Default["radioFileProxy"];
            RadioInfoModel.radioUrl = (bool)Properties.Settings.Default["radioUrl"];
            TextInfoModel.txtFileProxy = (string)Properties.Settings.Default["txtFileProxy"];
            TextInfoModel.txtUrl = (string)Properties.Settings.Default["txtUrl"];
            if (RadioInfoModel.radioNoProxy == false)
            {
                if (RadioInfoModel.radioFileProxy == true)
                {
                    _proxys.AddFileproxy(TextInfoModel.txtFileProxy);
                }
            }
            TextInfoModel.cbCatch = (bool)Properties.Settings.Default["cbCatch"];
            TextInfoModel.txtIMap = (string)Properties.Settings.Default["txtIMap"];
            TextInfoModel.txtPortEmail = (string)Properties.Settings.Default["txtPortEmail"];
            TextInfoModel.txtEmaifile = (string)Properties.Settings.Default["txtEmaifile"];
            _email.AddEmail(TextInfoModel.txtEmaifile, GlobalModel.Emails);
            RadioInfoModel.cbAvatar = cbAvatar.Checked;
            TextInfoModel.txtAvatar = txtAvatar.Text;

            if (RadioInfoModel.cbAvatar == true)
            {
                _avatar.AddAvatar(TextInfoModel.txtAvatar);
            }
            RadioInfoModel.cbPost = cbPost.Checked;
            TextInfoModel.txtPost = txtPost.Text;
            if (RadioInfoModel.cbPost == true)
            {
                _post.AddPost(TextInfoModel.txtPost);
            }
            RadioInfoModel.cbBio = cbBio.Checked;
            TextInfoModel.txtBio = txtBio.Text;
            if (RadioInfoModel.cbBio == true)
            {
                _bio.AddBio(TextInfoModel.txtBio);
            }
            RadioInfoModel.radioUserCustomize = radioUserCustomize.Checked;
            RadioInfoModel.radioUserRandom = radioUserRandom.Checked;
            TextInfoModel.txtUser = txtUser.Text;
            if (radioUserCustomize.Checked == true)
            {
                _users.AddUser(TextInfoModel.txtUser);
            }
            TextInfoModel.txtPasswordRandom = (int)txtPasswordRandom.Value;
            TextInfoModel.txtPasswordCustomize = txtPasswordCustomize.Text;
            RadioInfoModel.radioPasswordRandom = radioPasswordRandom.Checked;
            RadioInfoModel.radioPasswordCustomize = radioPasswordCustomize.Checked;
            RadioInfoModel.radioFullnameRandom = radioFullnameRandom.Checked;
            RadioInfoModel.radioFullnameCustomize = radioFullnameCustomize.Checked;
            TextInfoModel.txtFullname = txtFullname.Text;
            TextInfoModel.txtLastName = txtLastName.Text;
            RadioInfoModel.radioRandomVN = radioRandomVN.Checked;
            if (radioFullnameCustomize.Checked == true)
            {
                _fullName.AddFirstname(TextInfoModel.txtFullname);
                _fullName.AddLastName(TextInfoModel.txtLastName);
            }
            if (RadioInfoModel.radioPasswordCustomize == true && string.IsNullOrEmpty(txtPasswordCustomize.Text))
            {
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Password not found");
                return;
            }
            else if (radioPasswordCustomize.Checked == true)
            {
                if (txtPasswordCustomize.Text.Length < 6)
                {
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "Password must be at least 6 characters long. Please try again!");
                    return;
                }
            }

        }
        private void proxySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmProxy.Show();
        }
        private void MailSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _frmMail.Show();
        }
        private void MenuIremsData_Click(object sender, EventArgs e)
        {
            _frmData.Show();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = (MessageBox.Show("Do you want to exit ?", "Notify", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
            if (thongbao == DialogResult.Yes)
            {
                try
                {
                    if (GlobalModel.ListProxy.Count > 0)
                    {
                        CreateFiles.RemoveFile(GlobalModel.ListProxy, TextInfoModel.txtFileProxy);
                    }
                    if (GlobalModel.ListEmail.Count > 0)
                    {
                        CreateFiles.RemoveFile(GlobalModel.ListEmail, TextInfoModel.txtEmaifile);
                    }
                    if (GlobalModel.ListFullName.Count > 0)
                    {
                        CreateFiles.RemoveFile(GlobalModel.ListFullName, TextInfoModel.txtFullname);
                    }
                    if (GlobalModel.ListUserName.Count > 0)
                    {
                        CreateFiles.RemoveFile(GlobalModel.ListUserName, TextInfoModel.txtUser);
                    }
                    if (GlobalModel.ListBio.Count > 0)
                    {
                        CreateFiles.RemoveFile(GlobalModel.ListBio, TextInfoModel.txtBio);
                    }
                    if (GlobalModel.ListAvatar.Count > 0)
                    {
                        CreateFiles.RemoveFile(GlobalModel.ListAvatar, TextInfoModel.txtAvatar);
                    }
                    if (GlobalModel.MainThreadAuto != null)
                    {
                        try
                        {
                            LDController.CloseAll();
                            GlobalModel.MainThreadAuto.Abort();
                            GlobalModel.MainThreadAuto = null;
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, ex.Message);
                            Environment.Exit(Environment.ExitCode);
                        }
                    }
                    Environment.Exit(Environment.ExitCode);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.Message);
                    Log.Error("Exit");
                    Environment.Exit(Environment.ExitCode);
                }
            }
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            Users.OpendialogFileUser(openFileDialog);
            txtUser.Text = TextInfoModel.txtUser;
        }
        private void btnFullname_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FullName.opendialogFirstname(openFileDialog);
            txtFullname.Text = TextInfoModel.txtFullname;
        }
        private void btnAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtAvatar.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void btnBio_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            Bio.OpendialogBioFile(openFileDialog);
            txtBio.Text = TextInfoModel.txtBio;
        }
        private void numberThreads_ValueChanged(object sender, EventArgs e)
        {
            int run = (int)((NumericUpDown)sender).Value;
            Properties.Settings.Default["numberThreads"] = run.ToString();
            Properties.Settings.Default.Save();
            GlobalModel.MaxThreads = (int)run;
        }
        private void numberRun_ValueChanged(object sender, EventArgs e)
        {
            int run = (int)((NumericUpDown)sender).Value;
            Properties.Settings.Default["numberRun"] = run.ToString();
            Properties.Settings.Default.Save();
            GlobalModel.MaxAccount = (int)run;
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (GlobalModel.IsStopAuto == true)
            {
                btnPause.Text = "Pause";

                GlobalModel.IsStopAuto = false;
            }
            else
            {
                btnPause.Text = "Countine";

                GlobalModel.IsStopAuto = true;
            }
        }
        private void radioPasswordCustomize_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["radioPasswordCustomize"] = radioPasswordCustomize.Checked;
            Properties.Settings.Default.Save();
            txtPasswordCustomize.Enabled = true;
            txtPasswordRandom.Enabled = false;
        }
        private void txtPasswordCustomize_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtPasswordCustomize"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtPasswordCustomize = txtPasswordCustomize.Text;
        }
        private void txtPasswordRandom_ValueChanged(object sender, EventArgs e)
        {
            int run = (int)((NumericUpDown)sender).Value;
            Properties.Settings.Default["txtPasswordRandom"] = run.ToString();
            Properties.Settings.Default.Save();
        }
        private void radioPasswordRandom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPasswordRandom.Checked == true)
            {
                txtPasswordCustomize.Text = null;
            }
            txtPasswordCustomize.Enabled = false;
            txtPasswordRandom.Enabled = true;
            txtPasswordCustomize.Text = null;
            Properties.Settings.Default["radioPasswordRandom"] = radioPasswordRandom.Checked;
            Properties.Settings.Default.Save();
        }
        private void radioFullnameRandom_CheckedChanged(object sender, EventArgs e)
        {
            txtFullname.Text = null;
            Properties.Settings.Default["radioFullnameRandom"] = radioFullnameRandom.Checked;
            Properties.Settings.Default.Save();
            pFullname.Enabled = false;
        }
        private void radioFullnameCustomize_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["radioFullnameCustomize"] = radioFullnameCustomize.Checked;
            Properties.Settings.Default.Save();
            pFullname.Enabled = true;
        }
        private void radioUserRandom_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Text = null;
            btnUser.Enabled = false;
            Properties.Settings.Default["radioUserRandom"] = radioUserRandom.Checked;
            Properties.Settings.Default.Save();
        }
        private void radioUserCustomize_CheckedChanged(object sender, EventArgs e)
        {
            RadioInfoModel.radioUserCustomize = radioUserCustomize.Checked;
            btnUser.Enabled = true;
            Properties.Settings.Default["radioUserCustomize"] = radioUserCustomize.Checked;
            Properties.Settings.Default.Save();
        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtUser"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtUser = txtUser.Text;
        }
        private void txtFullname_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtFullname"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtFullname = txtFullname.Text;
        }
        private void txtAvatar_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtAvatar"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtAvatar = txtAvatar.Text;
        }
        private void txtBio_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtBio"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtBio = txtBio.Text;
        }
        private void cbAvatar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbAvatar.Checked == true)
                {
                    btnAvatar.Enabled = true;
                }
                else
                {

                    btnAvatar.Enabled = false;
                    txtAvatar.Text = null;
                }
                Properties.Settings.Default["cbAvatar"] = cbAvatar.Checked;
                Properties.Settings.Default.Save();
                RadioInfoModel.cbAvatar = cbAvatar.Checked;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void cbBio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbBio.Checked == true)
                {
                    btnBio.Enabled = true;
                }
                else
                {
                    btnBio.Enabled = false;
                    txtBio.Text = null;
                }
                Properties.Settings.Default["cbBio"] = cbBio.Checked;
                Properties.Settings.Default.Save();
                RadioInfoModel.cbBio = cbBio.Checked;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void btnResult_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Result.txt"))
            {
                if (!File.Exists("Result.txt"))
                {
                    File.WriteAllBytes("Result.txt", new byte[0]);
                }
                writer.Write(rtbResult.Text);
                writer.Close();
            }
            string notepadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe");
            Process.Start(notepadPath, Path.Combine("Result.txt"));
        }
        private void btnlog_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("Log.txt"))
            {
                if (!File.Exists("Log.txt"))
                {
                    File.WriteAllBytes("Log.txt", new byte[0]);
                }

                writer.Write(rtbLog.Text);
                writer.Close();
            }
            string notepadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "notepad.exe");
            Process.Start(notepadPath, Path.Combine("Log.txt"));
        }
        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }
        private void rtbResult_TextChanged(object sender, EventArgs e)
        {
            rtbResult.SelectionStart = rtbResult.Text.Length;
            rtbResult.ScrollToCaret();
        }
        private void frmAuto_Load(object sender, EventArgs e)
        {
            try
            {
                LDPlayers lDPlayers = new LDPlayers(_accountRepository);
                lDPlayers.LoadLdPlayer(Devices);
                if (cbAvatar.Checked == true)
                {
                    btnAvatar.Enabled = true;
                }
                else
                {
                    btnAvatar.Enabled = false;
                    txtAvatar.Text = null;
                }

                if (cbPost.Checked == true)
                {
                    btnPost.Enabled = true;
                }
                else
                {
                    btnPost.Enabled = false;
                    txtPost.Text = null;
                }
                if (cbBio.Checked == true)
                {
                    btnBio.Enabled = true;
                }
                else
                {
                    btnBio.Enabled = false;
                    txtBio.Text = null;
                }
                if (radioFullnameCustomize.Checked == true)
                {
                    pFullname.Enabled = true;
                }
                else
                {
                    pFullname.Enabled = false;
                }
                if (radioUserCustomize.Checked == true)
                {
                    btnUser.Enabled = true;
                }
                else
                {
                    btnUser.Enabled = false;
                }
                if (radioPasswordRandom.Checked == true)
                {
                    txtPasswordRandom.Enabled = false;
                    txtPasswordRandom.Enabled = true;
                    txtPasswordCustomize.Text = null;
                }
                else
                {
                    txtPasswordCustomize.Enabled = true;
                    txtPasswordRandom.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Log.Error("AutoLoad");
                Log.Error(ex, ex.Message);
            }
        }
        GetAvatar getAvatar = new GetAvatar();
        GetBio getBio = new GetBio();
        GetPost getPost = new GetPost();
        private void btnSort_Click(object sender, EventArgs e)
        {
            LDController.SortWnd();
        }
        private void SettingsLDPlayer_Click(object sender, EventArgs e)
        {
            Process.Start(GlobalModel.MultiPlayerPath);
        }
        private void txtPost_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtPost"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtAvatar = txtAvatar.Text;
        }
        private void cbPost_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbPost.Checked == true)
                {
                    btnPost.Enabled = true;
                }
                else
                {
                    btnPost.Enabled = false;
                    txtPost.Text = null;
                }
                Properties.Settings.Default["cbPost"] = cbPost.Checked;
                Properties.Settings.Default.Save();
                RadioInfoModel.cbPost = cbPost.Checked;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtPost.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (cbAvatar.Checked == false)
            {
                cbPost.Checked = false;
                btnPost.Enabled = false;
            }
        }

        private void radioRandomVN_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["radioRandomVN"] = radioRandomVN.Checked;
            Properties.Settings.Default.Save();
            pFullname.Enabled = false;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtLastName"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            TextInfoModel.txtLastName = txtLastName.Text;
        }

        private void btnLastname_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FullName.opendialoLatsname(openFileDialog);
            txtLastName.Text = TextInfoModel.txtLastName;
        }
    }
}