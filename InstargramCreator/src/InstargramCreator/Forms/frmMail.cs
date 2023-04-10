using InstargramCreator.GetProcess;
using InstargramCreator.Models;

namespace InstargramCreator
{
    public partial class frmMail : Form
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
        public frmMail()
        {
            InitializeComponent();
            InitializeSavedValues();
            txtEmaifile.Enabled = false;
        }
        private void InitializeSavedValues()
        {
            txtEmaifile.Text = (string)Properties.Settings.Default["txtEmaifile"];
            txtIMap.Text = (string)Properties.Settings.Default["txtImap"];
            txtPortEmail.Text = (string)Properties.Settings.Default["txtPortEmail"];
            cbCatch.Checked = (bool)Properties.Settings.Default["cbCatch"];
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOpenmail.Enabled = false;
            txtIMap.Enabled = false;
            txtPortEmail.Enabled = false;
            this.Hide();
        }
        private void btnCancelMail_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btnOpenmail_Click(object sender, EventArgs e)
        {
         
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var mail = File.ReadAllLines(openFileDialog.FileName);
                txtEmaifile.Text = openFileDialog.FileName;
                MessageBox.Show("Add " + mail.Length + " Email");
                var mail_length = mail.Length;
            }
            btnOpenmail.Enabled = true;        
        }        
        private void txtEmaifile_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtEmaiFile"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
            txtEmaifile.Enabled = false;
        }
        private void txtIMap_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtIMap"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();    
        }
        private void txtPortEmail_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["txtPortEmail"] = ((TextBox)sender).Text;
            Properties.Settings.Default.Save();
        }

        private void cbCatch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["cbCatch"] = cbCatch.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
