using MailKit;
using MailKit.Net.Imap;
using Serilog;

namespace InstargramCreator.Input
{
    public class MailKits
    {
        public static bool CheckLogin(string email, string pass, string imap, int port)
        {
            bool check = false;
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(imap) && port != null)
                {
                    using (var client = new ImapClient())
                    {
                        using (var cancel = new CancellationTokenSource())
                        {
                            client.Connect(imap, port, true, cancel.Token);
                            client.Authenticate(email, pass, cancel.Token);
                            client.Disconnect(true, cancel.Token);
                            check = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("LOGIN failed" + email + ":" + pass + ":" + imap + ":" + port);
                Log.Error(ex, ex.Message, ex.StackTrace);
            }
            return check;
        }
        public static string VerifyMail(string email, string pass, string imap, int port, string toEmail,string fromEmail)
        {
            try
            {
                Log.Information("VerifyMail " + email + ":" + pass + ":" + imap + ":" + port);
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(imap) && port != null)
                {
                    using (var client = new ImapClient())
                    {
                        client.Connect(imap, port, true);
                        client.Authenticate(email, pass);
                        var inbox = client.Inbox;
                        inbox.Open(FolderAccess.ReadWrite);
                        int index = inbox.Count - 1;
                        for (int i = index; i > 0; i--)
                        {
                            var message = inbox.GetMessage(i);
                            if (message.To.ToString() == toEmail&& message.From[0].Name == fromEmail)
                            {
                               string body =  message.Subject;
                                string[] s = body.Split(' ');
                                string macode = s[0];
                                if (int.TryParse(macode, out int code))
                                {
                                    return macode;
                                }
                                else
                                {
                                    Log.Error($" {macode} is not valid integer type");
                                }
                                client.Disconnect(true);
                            }
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
            return null;
        }
    }
}                