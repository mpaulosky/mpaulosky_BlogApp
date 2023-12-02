namespace BlazorBlogs.Contracts;

public interface IMongoDbContextFactory
{
	string ConnectionString { get; }

	string DbName { get; }

	IMongoDatabase Database { get; }

	MongoClient Client { get; }

	IMongoCollection<T> GetCollection<T>(string name);
}