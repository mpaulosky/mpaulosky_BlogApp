namespace BlazorBlogs.Registrations;

/// <summary>
/// ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{

	/// <summary>
	/// Register DataBaseSettings
	/// </summary>
	/// <param name="builder"></param>
	/// <exception cref="InvalidOperationException"></exception>
	public static void RegisterDataBaseSettings(this WebApplicationBuilder builder)
	{

		// Get the MongoDbSettings section from the appsettings.json file.
		IConfigurationSection section = builder.Configuration.GetSection("MongoDbSettings")
																		?? throw new InvalidOperationException("Section 'MongoDbSettings' not found.");

		// Get the DatabaseSettings from the appsettings.json file.
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>()!;

		// Register the IDatabaseSettings with the DI container.
		builder.Services.AddSingleton<IDatabaseSettings>(mongoSettings);

	}

}