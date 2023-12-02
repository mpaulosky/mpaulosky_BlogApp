namespace BlazorBlogs.Registrations;

/// <summary>
///   ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{
	/// <summary>
	///   Add Authorization Services
	/// </summary>
	/// <param name="builder">WebApplicationBuilder</param>
	/// <returns>void</returns>
	public static void AddAuthorizationPolicy(this WebApplicationBuilder builder)
	{

		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("Admin", policy =>
			{
				policy.RequireClaim("jobTitle", "Admin");
			});
		});

	}
}