using InstargramCreator.Models;
using Serilog;
using System.Windows.Forms;

namespace InstargramCreator.Input
{
    public  class Email
    {

        public Email()
        {
        }
        public void AddEmail(string pathFilemail, List<MailInfoModel> listmail)
        {
            try
            {
                Log.Information("ADDMAIL");
                var mail = File.ReadAllLines(pathFilemail);
                Log.Information("AddEmail " + mail.Length);
                GlobalModel.Emails.Clear();
                for (int i = 0; i < mail.Length; i++)
                {
                    MailInfoModel mailinfo = new MailInfoModel();
                    string[] emails1 = mail[i].Split(',', ':', ';', '/', '|');
                    if (!string.IsNullOrEmpty(emails1[0]) && !string.IsNullOrEmpty(emails1[1]))
                    {
                        mailinfo.Email = emails1[0];
                        mailinfo.PassMail = emails1[1];
                        mailinfo.Imap = TextInfoModel.txtIMap;
                        mailinfo.PortImap = int.Parse(TextInfoModel.txtPortEmail);
                        listmail.Add(mailinfo);
                        BindingSource soureEmail = new BindingSource();
                        soureEmail.DataSource = GlobalModel.Emails;
                    }                 
                }
            }
            catch (Exception ex)
            { 
                Log.Error(ex.ToString());
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }       
    }
}
