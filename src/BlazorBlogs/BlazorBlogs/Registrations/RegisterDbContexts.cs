using Microsoft.EntityFrameworkCore;

namespace BlazorBlogs.Registrations;

public static partial class ServiceCollectionExtensions
{
	public static void RegisterDbContexts(this WebApplicationBuilder builder)
	{
		// Get the default connection string from the appsettings.json file.
		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

		// Register the ApplicationDbContext with the DI container.
		builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseSqlServer(connectionString));

		// Get the MongoDbSettings section from the appsettings.json file.
		var section = builder.Configuration.GetSection("MongoDbSettings")
			?? throw new InvalidOperationException("Section 'MongoDbSettings' not found.");

		// Register the MongoDbSettings with the DI container.
		DatabaseSettings mongoSettings = section.Get<DatabaseSettings>()!;
		builder.Services.AddSingleton<IDatabaseSettings>(mongoSettings);

		// Register the MongoDbContext with the DI container.
		builder.Services.AddDbContext<MongoDbContext>(options =>
				options.UseMongoDB(mongoSettings.ConnectionStrings, mongoSettings.DatabaseName));

	}
}
