namespace ConfigurationApplicationMVC;

public static class Test
{
    public static IConfigurationBuilder AddSxrConfiguration(this IConfigurationBuilder builder,string path)
    {
        return builder.Add(new FxConfigSource() {Path = path});
    }
}