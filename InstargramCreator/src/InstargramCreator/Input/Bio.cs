using InstargramCreator.Models;
using Serilog;

namespace InstargramCreator.Input
{
    public class Bio
    {

        public Bio()
        {
        }
        public static string OpendialogBioFile(OpenFileDialog openFileDialog)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var Line = File.ReadAllLines(openFileDialog.FileName);
                MessageBox.Show("Add  " + Line.Length + " Bio");
                TextInfoModel.txtBio = openFileDialog.FileName;
                return TextInfoModel.txtBio;
            }
            return null;
        }
        public void AddBio(string filePath)
        {
            try
            {
                Log.Information("AddBio " + filePath);
                var line = File.ReadAllLines(filePath);
                GlobalModel.Bio.Clear();
                for (int i = 0; i < line.Length; i++)
                {
                    if (!string.IsNullOrEmpty(line[i]))
                    {
                        BioInfoModel biomodel = new BioInfoModel();
                        biomodel.Bio = line[i];
                        GlobalModel.Bio.Add(biomodel);
                        BindingSource soureBio = new BindingSource();
                        soureBio.DataSource = GlobalModel.Bio;
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + ex.Message);
            }
        }
    }
}
