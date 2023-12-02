namespace BlogService.UI.Registrations;

/// <summary>
///   IServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Register DI Services
	/// </summary>
	/// <param name="services">IServiceCollection</param>
	/// <returns>IServiceCollection</returns>
	public static void RegisterApplicationServices(this IServiceCollection services)
	{
		services.AddRazorPages();
		services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
		services.AddMemoryCache();
		services.AddControllersWithViews().AddMicrosoftIdentityUI();
	}
}