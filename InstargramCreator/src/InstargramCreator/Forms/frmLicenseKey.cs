using InstargramCreator.ApiQnibot;
using InstargramCreator.Files;
using InstargramCreator.Models;
using AutoUpdaterDotNET;
using LDPlayerNTC;
using Serilog;
using System.Diagnostics;
using System;
using InstargramCreator.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InstargramCreator
{
    public partial class frmLicenseKey : Form
    {
        private readonly frmAuto _frmAuto;
        public frmLicenseKey(frmAuto frmAuto)
        {
            InitializeComponent();
            InitializeSavedValues();
            _frmAuto = frmAuto;
        }
        private const int WS_SYSMENU = 0x80000; 
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }     
        private void InitializeSavedValues()
        {
            txtLicenkey.Text = (string)Properties.Settings.Default["txtLicenkey"];
            txtPath.Text = (string)Properties.Settings.Default["txtPath"];
            btnUpDate.Visible = false;
        }
        private async void btnLicenkey_Click(object sender, EventArgs e)
        {
            try
            {
                HttpHelper httpHelper = new HttpHelper();
                string hardwareId = httpHelper.GetHardwareId();
                Constant.licenseKey = txtLicenkey.Text.Trim();
                var softwareId = Constant.SoftwareId;
                var checkLicenseResult = await httpHelper.CheckLicense(Constant.licenseKey, hardwareId, softwareId);
                if (checkLicenseResult.Data is true)
                {
                    LDController.pathLDConsole = txtPath.Text + "\\ldconsole.exe";
                    LDController.pathADB = txtPath.Text + "\\adb.exe";
                    GlobalModel.SourcePath = txtPath.Text;
                    GlobalModel.MultiPlayerPath = txtPath.Text + "\\dnmultiplayer.exe";
                    CreateFiles.CreateFile();
                    _frmAuto.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(checkLicenseResult.Message.ToString());
                    var ps = new ProcessStartInfo("https://qnibot.com/")
                    {
                        UseShellExecute = true,
                        Verb = "open"
                    };
                    Process.Start(ps);
                    Environment.Exit(Environment.ExitCode);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void txtLicenkey_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtLicenkey"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }
        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtPath"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }
        private void btnUpDate_Click(object sender, EventArgs e)
        {
            try
            {
                AutoUpdater.Start(updateUrl);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        string updateUrl;
        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            try
            {
                if (AutoUpdater.DownloadUpdate(args))
                {
                    Application.Exit();
                    btnUpDate.Visible = false;
                    btnLicenkey.Visible = true;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception, exception.Message);
                MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private async void frmLicenseKey_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            HttpHelper httpHelper = new HttpHelper();
            var softwareId = Constant.SoftwareId;
            var checkLicenseResult = await httpHelper.CheckVersion(softwareId, version);
            if (checkLicenseResult.Data is false)
            {
                btnUpDate.Visible = true;
                updateUrl = checkLicenseResult.Message;
                btnLicenkey.Visible = false;
                AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;
                AutoUpdater.DownloadPath = "Update";
            }
        }
    }
}