namespace BlazorBlogs.Contracts;

public interface ISoftDelete
{
	public bool IsArchived { get; set; }

	public void Undo()
	{
		IsArchived = false;
	}
}