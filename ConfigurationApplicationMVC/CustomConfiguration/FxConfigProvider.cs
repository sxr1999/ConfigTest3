using System.Xml;

namespace ConfigurationApplicationMVC;

public class FxConfigProvider : FileConfigurationProvider
{
    public FxConfigProvider(FxConfigSource source) : base(source)
    {
    }

    public override void Load(Stream stream)
    {
        var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(stream);
        var csNodes = xmlDocument.SelectNodes("/configuration/connectionStrings/add");
        int i = 0;
        foreach (var item in csNodes.Cast<XmlNode>())
        {
            string name = item.Attributes["name"].Value;
            data[$"Strs:{i}:name"] = name;
            string connectionString = item.Attributes["connectionString"].Value;
            data[$"Strs:{i}:connectionString"] = connectionString;

            var attProviderName = item.Attributes["providerName"];
            if (attProviderName!=null)
            {
                data[$"Strs:{i}:providerName"] = attProviderName.Value;
            }

            i++;
        }
        
        var asNodes = xmlDocument.SelectNodes("/configuration/appSettings/add");
        foreach (var item in asNodes.Cast<XmlNode>())
        {
            string key = item.Attributes["key"].Value;
            key.Replace(".", ":");
            
            string value = item.Attributes["value"].Value;
            data[key] = value;
        }

        this.Data = data;
    }
}