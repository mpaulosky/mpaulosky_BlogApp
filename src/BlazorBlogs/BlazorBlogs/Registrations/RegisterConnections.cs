namespace BlogService.UI.Registrations;

public static partial class ServiceCollectionExtensions
{
	public static void RegisterConnection(this IServiceCollection services, ConfigurationManager config)
	{
		IConfigurationSection section = config.GetSection("MongoDbSettings");
		ArgumentNullException.ThrowIfNull(nameof(section));
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>()!;
		services.AddSingleton<IDatabaseSettings>(mongoSettings);
	}
}