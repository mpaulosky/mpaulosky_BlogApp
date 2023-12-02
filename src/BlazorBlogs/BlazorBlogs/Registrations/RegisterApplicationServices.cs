namespace BlazorBlogs.Registrations;

/// <summary>
/// ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Register DI Services
	/// </summary>
	/// <param name="builder">WebApplicationBuilder</param>
	/// <returns>void</returns>
	public static void RegisterApplicationServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddRazorComponents()
			.AddInteractiveServerComponents()
			.AddInteractiveWebAssemblyComponents();

		builder.Services.AddMemoryCache();
	}
}