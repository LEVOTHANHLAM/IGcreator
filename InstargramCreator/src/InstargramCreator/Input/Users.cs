
using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.Input
{
    public class Users
    {

        public Users()
        {
        }
        public static string OpendialogFileUser(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var User = File.ReadAllLines(openFileDialog.FileName);
                MessageBox.Show("Add  " + User.Length + " User ");
                TextInfoModel.txtUser = openFileDialog.FileName;
                return TextInfoModel.txtUser;
            }
            return null;
        }
        public void AddUser(string filePath)
        {
            try
            {
                var useerinstagramfile = File.ReadAllLines(filePath);
                Log.Information("AddUser " + filePath + "\n" + useerinstagramfile.Length);
                GlobalModel.Users.Clear();
                for (int i = 0; i < useerinstagramfile.Length; i++)
                {
                    if (!string.IsNullOrEmpty(useerinstagramfile[i]))
                    {
                        UserInfoModel userinstagrammodel = new UserInfoModel();
                        userinstagrammodel.UserName = useerinstagramfile[i];
                        GlobalModel.Users.Add(userinstagrammodel);
                        BindingSource soureUserInstagram = new BindingSource();
                        soureUserInstagram.DataSource = GlobalModel.Users;
                    }
                }
            }
            catch (Exception ex)
            {
                 Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
    }
}