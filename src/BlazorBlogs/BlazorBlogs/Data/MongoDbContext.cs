using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BlazorBlogs.Data;

public class MongoDbContext : DbContext
{
	public DbSet<BlogPost> BlogPosts { get; init; }

	public static MongoDbContext Create(IMongoDatabase database) =>
			new(new DbContextOptionsBuilder<MongoDbContext>()
					.UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
					.Options);
	public MongoDbContext(DbContextOptions options)
			: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<BlogPost>().ToCollection("blogposts");
	}
}
