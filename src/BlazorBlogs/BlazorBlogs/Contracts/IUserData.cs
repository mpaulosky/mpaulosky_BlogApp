namespace BlazorBlogs.Contracts;

public interface IUserData
{
	Task ArchiveAsync(User user);

	Task CreateAsync(User user);

	Task<User> GetAsync(string id);

	Task<User> GetFromAuthenticationAsync(string objectId);

	Task<List<User>> GetAllAsync();

	Task UpdateAsync(User user);
}