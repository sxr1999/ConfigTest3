using Microsoft.Extensions.Options;

namespace ConfigurationApplicationMVC;

public class TestWebConfig
{
    private readonly IOptionsSnapshot<WebConfig> _options;

    public TestWebConfig(IOptionsSnapshot<WebConfig> options)
    {
        _options = options;
    }

    public void Test()
    {
        foreach (var item in _options.Value.Strs)
        {
            Console.WriteLine(item.name);
            Console.WriteLine(item.connectionString);
            Console.WriteLine(item.providerName);
        }

        Console.WriteLine(_options.Value.server.Age);
        Console.WriteLine(_options.Value.server.Name);
        Console.WriteLine(_options.Value.server.proxy.Address);

        foreach (var item in _options.Value.server.proxy.ids)
        {
            Console.WriteLine(item);
        }
        
    }
}