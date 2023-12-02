
namespace BlazorBlogs.Registrations;

/// <summary>
/// ServiceCollectionExtensions
/// </summary>
[ExcludeFromCodeCoverage]
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Configures the services method.
	/// </summary>
	/// <param name="builder">WebApplicationBuilder</param>
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{

		// Add services to the container.
		builder.RegisterApplicationServices();

		builder.AddAuthentication();

		builder.AddAuthorizationPolicy();

		builder.RegisterApplicationDbContext();

		builder.RegisterDataBaseSettings();

		builder.RegisterDataSources();

	}

}