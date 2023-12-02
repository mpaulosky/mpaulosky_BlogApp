namespace BlazorBlogs.Contracts;

public interface IUserService
{
	Task ArchiveAsync(User user);

	Task CreateAsync(User user);

	Task<User> GetAsync(string id);

	Task<List<User>> GetAllAsync();

	Task<User> GetByAuthIdAsync(string objectId);

	Task UpdateAsync(User user);
}