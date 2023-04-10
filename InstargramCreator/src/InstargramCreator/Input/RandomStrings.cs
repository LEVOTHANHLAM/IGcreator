namespace InstargramCreator.Input
{
    public class RandomStrings
    {
        public static string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        public static string Numeric = "1234567890";
        public static string Special = "!@#.$";
        public static string RandomAllString(int number, string charsString)
        {
            try
            {
                var chars = charsString.ToCharArray();
                var Result = string.Empty;
                var random = new Random();
                for (var i = 0; i < number; i++)
                {
                    var x = random.Next(1, chars.Length);
                    if (!Result.Contains(chars.GetValue(x).ToString()))
                    {
                        Result += chars.GetValue(x);
                    }
                    else
                    {
                        i--;
                    }
                }
                return Result;
            }
            catch (Exception ex) { Serilog.Log.Error(ex.ToString()); }
            return null;
        }
        public static int RandomNumber(int start = 3, int end = 8)
        {
            Random radom = new Random();
            var result = radom.Next(start, end);
            return result;
        }
    }
}
