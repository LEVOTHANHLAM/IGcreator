using System.Text.Json;

namespace InstargramCreator.Files
{
    public class ReadFileJson
    {
        public string GetStringFileJson(string filePath)
        {
            string jsonText = File.ReadAllText(filePath);
            List<string> surnames = JsonSerializer.Deserialize<List<string>>(jsonText);
            Random random = new Random();
            int randomIndex = random.Next(0, surnames.Count);
            string randomSurname = surnames[randomIndex];
            return randomSurname;
        }
        public string GetDate()
        {
            string result = "";
            var check = DateTime.Now.ToString().Split(':', '/', ' ');
            result = check[0] + "_" + check[1] + "_" + check[3] +"_"+ check[4];
            return result;
        }
        public string GetStringsFileTxt(string filePath)
        {
            var body = File.ReadAllLines(filePath);
            List<string> listFiles= new List<string>();
            foreach(var item in body)
            {
                listFiles.Add(item.Trim());
            }
            Random random = new Random();
            int randomIndex = random.Next(0, listFiles.Count);
            string randomSurname = listFiles[randomIndex];
            return randomSurname;
        }
    }
}