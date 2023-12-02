namespace BlazorBlogs.Data.Models;

/// <summary>
///   DatabaseSettings class
/// </summary>
public class DatabaseSettings : IDatabaseSettings
{
	public DatabaseSettings(string connectionStrings, string databaseName)
	{
		ConnectionStrings = connectionStrings;
		DatabaseName = databaseName;
	}

	public string ConnectionStrings { get; init; }

	public string DatabaseName { get; init; }
}