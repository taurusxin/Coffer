using Newtonsoft.Json;

namespace CofferBackend;

public class DbConfig
{
    // string ConnString = "server=localhost;database=library;user=user;password=password";

    public static string GetConnString()
    {
        var sr = new StreamReader("DbConfig.json");
        var json = sr.ReadToEnd();
        var config = JsonConvert.DeserializeObject<Config>(json);
        return config?.ConnStr;
    }

    public class Config
    {
        public string ConnStr;
    }
}