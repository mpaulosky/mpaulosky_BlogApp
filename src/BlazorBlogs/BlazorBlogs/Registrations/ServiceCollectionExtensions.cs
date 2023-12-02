using Microsoft.EntityFrameworkCore;

namespace BlazorBlogs.Registrations;

public static partial class ServiceCollectionExtensions
{
	public static void Register(this WebApplicationBuilder builder)
	{
		builder.RegisterApplicationDbContext();

		builder.RegisterMongoDbContext();
	}
}

public static partial class ServiceCollectionExtensions
{
	public static void RegisterApplicationDbContext(this WebApplicationBuilder builder)
	{
		// Get the default connection string from the appsettings.json file.
		string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
		                          ?? throw new InvalidOperationException(
			                          "Connection string 'DefaultConnection' not found.");

		// Register the ApplicationDbContext with the DI container.
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));

		builder.Services.AddScoped<ApplicationDbContext>();
	}
}

public static partial class ServiceCollectionExtensions
{
	public static void RegisterMongoDbContext(this WebApplicationBuilder builder)
	{
		// Get the MongoDbSettings section from the appsettings.json file.
		IConfigurationSection section = builder.Configuration.GetSection("MongoDbSettings")
		                                ?? throw new InvalidOperationException("Section 'MongoDbSettings' not found.");

		// Register the MongoDbSettings with the DI container.
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>()!;
		builder.Services.AddSingleton<IDatabaseSettings>(mongoSettings);

		// Register the MongoDbContext with the DI container.
		builder.Services.AddDbContext<MongoDbContext>(options =>
			options.UseMongoDB(mongoSettings.ConnectionStrings, mongoSettings.DatabaseName));

		builder.Services.AddScoped<MongoDbContext>();
	}
}