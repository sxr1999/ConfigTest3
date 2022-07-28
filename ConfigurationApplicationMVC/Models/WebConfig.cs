namespace ConfigurationApplicationMVC;

public class WebConfig
{
   
    public ConnectStr[] Strs { get; set; }
    public Server server { get; set; }
}

public class ConnectStr
{
    public string name { get; set; }
    public string connectionString { get; set; }
    public string providerName { get; set; }
}