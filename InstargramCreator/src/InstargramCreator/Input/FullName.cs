using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.Input
{
    public class FullName
    {

        public FullName()
        {
        }
        public static string opendialogFirstname(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var Line = File.ReadAllLines(openFileDialog.FileName);
                MessageBox.Show("Add  " + Line.Length + " First Name");
                TextInfoModel.txtFullname = openFileDialog.FileName;
                return TextInfoModel.txtFullname;
            }
            return null;
        }
        public static string opendialoLatsname(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var Line = File.ReadAllLines(openFileDialog.FileName);
                MessageBox.Show("Add  " + Line.Length + " Last Name");
                TextInfoModel.txtLastName = openFileDialog.FileName;
                return TextInfoModel.txtLastName;
            }
            return null;
        }
        public void AddFirstname(string filePath)
        {
            try
            {
                Log.Information("AddFullname " + filePath);
                var line = File.ReadAllLines(filePath);
                GlobalModel.FullNames.Clear();
                for (int i = 0; i < line.Length; i++)
                {
                    if (!string.IsNullOrEmpty(line[i]))
                    {
                        FullNameInfoModel fullNameinfomodel = new FullNameInfoModel();
                        fullNameinfomodel.FirstName = line[i];
                        GlobalModel.FullNames.Add(fullNameinfomodel);
                        BindingSource soureFullname = new BindingSource();
                        soureFullname.DataSource = GlobalModel.FullNames;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
        public void AddLastName(string filePath)
        {
            try
            {
                Log.Information("AddFullname " + filePath);
                var line = File.ReadAllLines(filePath);
                GlobalModel.FullNames.Clear();
                for (int i = 0; i < line.Length; i++)
                {
                    if (!string.IsNullOrEmpty(line[i]))
                    {
                        FullNameInfoModel fullNameinfomodel = new FullNameInfoModel();
                        fullNameinfomodel.LastName = line[i];
                        GlobalModel.FullNames.Add(fullNameinfomodel);
                        BindingSource soureFullname = new BindingSource();
                        soureFullname.DataSource = GlobalModel.FullNames;
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
