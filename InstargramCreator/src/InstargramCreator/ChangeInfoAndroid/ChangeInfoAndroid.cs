
using LDPlayerNTC;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Xml;

namespace InstargramCreator.ChangeInfo.ChangeInfoAndroid
{
    public class ChangeInfoAndroid
    {
        public bool ChangeDevice(string deviceId, string pathToJsonFile, string pathToXMLFile)
        {
            bool result = false;    
            string push1 = "";
            try
            {
                var check = RandomlySetJsonValueToXML(pathToJsonFile, pathToXMLFile);
                if (check == true)
                {
                    push1 = LDController.ExecuteCMD_Result("adb -s " + deviceId + " push "+ pathToXMLFile + " /data/data/com.minsoftware.maxchanger/shared_prefs/Device.xml");
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error("ChangeInfo " + deviceId + "|||" + pathToJsonFile + "||||" + pathToXMLFile +  "||||" + push1);
                Log.Error(ex, ex.Message);
            }
            return result;
        }

        public void GetSetFileXML(string pathFileXML, string nodeName, string valueXML)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathFileXML);
                XmlNode root = doc.DocumentElement;
                XmlNode myNode = root.SelectSingleNode(string.Format("/map/string[@name='{0}']", nodeName));
                myNode.InnerText = valueXML;
                doc.Save(pathFileXML);
            }
            catch (Exception e)
            {
                Log.Error("GetSetFileXML " + pathFileXML + "||||" + nodeName + "||||" + valueXML);
                Log.Error(e, e.Message);

            }
        }

        public bool RandomlySetJsonValueToXML(string pathToJsonFile, string pathToXMLFile)
        {
            bool result = false;
            try
            {
                // Đọc file json
                string jsonText = File.ReadAllText(pathToJsonFile);
                // Chuyển file json sang đối tượng JObject
                JObject jsonObj = JObject.Parse(jsonText);
                // Lấy danh sách các phần tử trong file json
                List<JToken> jsonList = jsonObj.Children().ToList();
                // Chọn một phần tử ngẫu nhiên trong list
                Random rnd = new Random();
                JToken randomJson = jsonList[rnd.Next(jsonList.Count)];
                if (randomJson is JProperty prop)
                {
                    // Truy xuất đến giá trị của JProperty
                    JToken propValue = prop.Value;

                    // Kiểm tra xem giá trị của JProperty có phải là JObject hay không
                    if (propValue is JObject randomJsonObj)
                    {
                        if (propValue != null)
                        {
                            foreach (var property in randomJsonObj.Properties())
                            {
                                string nodeName = property.Name;
                                JToken jsonValue = property.Value;
                                string valueXML = jsonValue.ToString(); // Chuyển đổi giá trị jsonObject sang chuỗi string để truyền vào phương thức GetSetFileXML                  
                                GetSetFileXML(pathToXMLFile, nodeName, valueXML);  // Gọi phương thức GetSetFileXML để thực hiện việc truyền nodeName và valueXML vào
                            }
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("RandomlySetJsonValueToXML " + pathToJsonFile + "||||" + pathToXMLFile);
                Log.Error(ex, ex.Message);
            }
            return result;
        }
    }
}
