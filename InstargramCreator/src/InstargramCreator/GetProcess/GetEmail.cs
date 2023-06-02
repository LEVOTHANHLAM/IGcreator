using InstargramCreator.Files;
using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.GetProcess
{
    public class GetEmail
    {
        public static void CheckMailFail(List<MailInfoModel>mailfile)
        {
            try
            {
                lock (GlobalModel.LockEmails)
                {
                    mailfile = mailfile.Where(x => x.Status != true).ToList();
                    if (mailfile.Count > 0)
                    {
                        mailfile.All(x => x.IsUsing == false);
                    }
                }                  
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);            
            }   
        }
        public static MailInfoModel GetMail(List<MailInfoModel> mailfile)
        {
            try
            {
                lock (GlobalModel.LockEmails)
                {
                    if (mailfile.Count == 0) return null;
                    List<MailInfoModel> mailavailable = mailfile.Where(x => x.IsUsing == false).ToList();
                    if (mailavailable.Count > 0)
                    {
                        var result = mailfile.Where(x => x.Email == mailavailable.First().Email).FirstOrDefault();
                        result.IsUsing = true;
                        return result;
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
