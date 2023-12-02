namespace BlazorBlogs.Registrations;

public static class RegisterDatabases
{
	public static void RegisterDataSources(this IServiceCollection services)
	{
		// Add services to the container.
		services.AddSingleton<IMongoDbContextFactory, MongoDbContextFactory>();
		services.AddSingleton<IBlogPostData, MongoBlogPostData>();
		services.AddSingleton<IUserData, MongoUserData>();
		services.AddSingleton<IBlogService, BlogPostService>();
		services.AddSingleton<IUserService, UserService>();
	}
}