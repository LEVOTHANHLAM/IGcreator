using InstargramCreator.Repositories;
using System.Text;
using System.Text.RegularExpressions;

namespace AppAuto.Files
{
    public class Export
    {
        private readonly IAccountRepository _accountRepository;

        public Export(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void ExportTxt()
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                Regex reg = new Regex("[*'\",_&#^@/:\\s]");
                string datetime = reg.Replace(DateTime.Now.ToString(), ".");
                save.FileName = datetime.ToString() + "InstagramCreator.txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    var list = _accountRepository.GetAll();
                    StringBuilder commaDelimitedText = new StringBuilder();
                    foreach (var line in list)
                    {
                        string value = string.Format("{0},{1},{2},{3},{4},{5},", line.Email, line.Password, line.UserName, line.Proxy, line.FullName, line.CreateDate); // how you format is up to you (spaces, tabs, delimiter, etc)
                        commaDelimitedText.AppendLine(value);
                    }
                    File.WriteAllText(save.FileName, commaDelimitedText.ToString());
                }
                MessageBox.Show("Data exported successfully");
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.ToString());
            }
        }
    }
}
