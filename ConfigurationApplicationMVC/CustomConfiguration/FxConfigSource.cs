namespace ConfigurationApplicationMVC;

public class FxConfigSource : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        EnsureDefaults(builder);
        return new FxConfigProvider(this);
    }
}