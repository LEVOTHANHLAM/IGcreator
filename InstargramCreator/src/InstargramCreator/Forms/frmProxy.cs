using InstargramCreator.Input;
using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator
{
    public partial class frmProxy : Form
    {
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
        public frmProxy()
        {
            InitializeComponent();
            InitializeSavedValues();
            txtFileProxy.Enabled = false;
        }
        private void InitializeSavedValues()
        {
            radioNoProxy.Checked = (bool)Properties.Settings.Default["radioNoProxy"];
            radioSock5.Checked = (bool)Properties.Settings.Default["radioSock5"];
            radioHTTP.Checked = (bool)Properties.Settings.Default["radioHTTP"];
            radioFileProxy.Checked = (bool)Properties.Settings.Default["radioFileProxy"];          
            radioUrl.Checked = (bool)Properties.Settings.Default["radioUrl"];
            txtUrl.Text = (string)Properties.Settings.Default["txtUrl"];
            txtFileProxy.Text = (string)Properties.Settings.Default["txtFileProxy"];
        }
        private void btnProxy_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            Proxys.OpendialogFileProxy(openFileDialog);
            txtFileProxy.Text = TextInfoModel.txtFileProxy;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            RadioInfoModel.radioNoProxy = radioNoProxy.Checked;
            RadioInfoModel.radioSock5 = radioSock5.Checked;
            RadioInfoModel.radioHTTP = radioHTTP.Checked;
            RadioInfoModel.radioFileProxy = radioFileProxy.Checked;
            RadioInfoModel.radioUrl = radioUrl.Checked;
            TextInfoModel.txtFileProxy = txtFileProxy.Text;
            TextInfoModel.txtUrl = txtUrl.Text;          
            this.Hide();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void radioNoProxy_CheckedChanged(object sender, EventArgs e)
        {
            txtFileProxy.Enabled = false;
            btnProxy.Enabled = false;
            radioFileProxy.Enabled = false;
            radioUrl.Enabled = false;
            txtUrl.Enabled = false;
            Properties.Settings.Default["radioNoProxy"] = radioNoProxy.Checked;
            Properties.Settings.Default.Save();
        }
        private void radioHTTP_CheckedChanged(object sender, EventArgs e)
        {
            radioFileProxy.Enabled = true;
            radioUrl.Enabled = true;
            txtUrl.Enabled = false;
            btnProxy.Enabled = false;
            if (radioUrl.Checked == true)
            {
                txtUrl.Enabled = true;
                btnProxy.Enabled = false;
            }
            else
            {
                txtUrl.Enabled = false;
                btnProxy.Enabled = true;
            }
            Properties.Settings.Default["radioHTTP"] = radioHTTP.Checked;
            Properties.Settings.Default.Save();
        }
        private void txtFileProxy_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtFileProxy"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }
        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtUrl"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }
        private void radioUrl_CheckedChanged(object sender, EventArgs e)
        {
            btnProxy.Enabled = false;
            txtUrl.Enabled= true;
            Properties.Settings.Default["radioUrl"] = radioUrl.Checked;
            Properties.Settings.Default.Save();
        }
        private void radioSock5_CheckedChanged(object sender, EventArgs e)
        {
            radioFileProxy.Enabled = true;
            radioUrl.Enabled = true;
            txtUrl.Enabled = false;
            btnProxy.Enabled = false;
            if (radioUrl.Checked == true)
            {
                txtUrl.Enabled = true;
                btnProxy.Enabled = false;
            }
            else
            {
                txtUrl.Enabled = false;
                btnProxy.Enabled = true;
            }
            Properties.Settings.Default["radioSock5"] = radioSock5.Checked;
            Properties.Settings.Default.Save();
        }
        private void radioFileProxy_CheckedChanged(object sender, EventArgs e)
        {
            txtUrl.Enabled = false;
            btnProxy.Enabled = true;        
            Properties.Settings.Default["radioFileProxy"] = radioFileProxy.Checked;
            Properties.Settings.Default.Save();
        }
        private void frmProxy_Load(object sender, EventArgs e)
        {
            if (radioNoProxy.Checked == true)
            {
                radioFileProxy.Enabled = false;
                radioUrl.Enabled = false;
            }
            else
            {
                radioFileProxy.Enabled = true;
                radioUrl.Enabled = true;
            }
            if (radioUrl.Checked== true)
            {
                txtUrl.Enabled= true;
                btnProxy.Enabled = false;
            }
            else
            {
                txtUrl.Enabled = false;
                btnProxy.Enabled = false;
            }              
        }
    }
}