namespace BlazorBlogs.Registrations;

/// <summary>
/// ServiceCollectionExtensions
/// </summary>
public static partial class ServiceCollectionExtensions
{

	/// <summary>
	/// Register DataSources
	/// </summary>
	/// <param name="builder"></param>
	public static void RegisterDataSources(this WebApplicationBuilder builder)
	{

		// Add services to the container.
		builder.Services.AddSingleton<IMongoDbContextFactory, MongoDbContextFactory>();
		builder.Services.AddSingleton<IBlogPostData, MongoBlogPostData>();
		builder.Services.AddSingleton<IUserData, MongoUserData>();
		builder.Services.AddSingleton<IBlogService, BlogPostService>();
		builder.Services.AddSingleton<IUserService, UserService>();

	}

}