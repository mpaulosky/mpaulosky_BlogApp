using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlazorBlogs.Data;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(
		DbContextEventData eventData,
		InterceptionResult<int> result)
	{
		if (eventData.Context is null)
		{
			return result;
		}

		foreach (EntityEntry entry in eventData.Context.ChangeTracker.Entries())
		{
			if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete })
			{
				continue;
			}

			entry.State = EntityState.Modified;
			delete.IsArchived = true;
		}

		return result;
	}
}