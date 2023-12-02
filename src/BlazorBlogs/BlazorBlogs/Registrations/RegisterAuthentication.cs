using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorBlogs.Registrations;

/// <summary>
///   ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Add Authentication Services
	/// </summary>
	/// <param name="builder">WebApplicationBuilder</param>
	/// <returns>void</returns>
	public static void AddAuthentication(this WebApplicationBuilder builder)
	{

		builder.Services.AddCascadingAuthenticationState();
		builder.Services.AddScoped<IdentityUserAccessor>();
		builder.Services.AddScoped<IdentityRedirectManager>();
		builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

		builder.Services.AddAuthentication(options =>
		{
			options.DefaultScheme = IdentityConstants.ApplicationScheme;
			options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
		})
			.AddIdentityCookies();

	}
}