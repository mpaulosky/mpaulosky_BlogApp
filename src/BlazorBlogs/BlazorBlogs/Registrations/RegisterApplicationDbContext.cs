using Microsoft.EntityFrameworkCore;

namespace BlazorBlogs.Registrations;

/// <summary>
/// ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{

	/// <summary>
	/// Register ApplicationDbContext
	/// </summary>
	/// <param name="builder">WebApplicationBuilder</param>
	/// <exception cref="InvalidOperationException">If DefaultConnection does not exist</exception>
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

		builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
										.AddEntityFrameworkStores<ApplicationDbContext>()
										.AddSignInManager()
										.AddDefaultTokenProviders();

	}

}
