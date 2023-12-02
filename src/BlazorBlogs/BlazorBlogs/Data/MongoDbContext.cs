using Microsoft.EntityFrameworkCore;

using MongoDB.EntityFrameworkCore.Extensions;

namespace BlazorBlogs.Data;

public class MongoDbContext : DbContext
{
	public MongoDbContext(DbContextOptions options)
		: base(options)
	{
	}

	public DbSet<BlogPost> BlogPosts { get; init; }
	public DbSet<User> Users { get; init; }

	public static MongoDbContext Create(IMongoDatabase database)
	{
		return new MongoDbContext(new DbContextOptionsBuilder<MongoDbContext>()
			.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
			.Options);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<BlogPost>()
			.HasQueryFilter(x => x.IsArchived == false)
			.ToCollection("posts");

		modelBuilder.Entity<User>()
			.HasQueryFilter(x => x.IsArchived == false)
			.ToCollection("users");
	}
}