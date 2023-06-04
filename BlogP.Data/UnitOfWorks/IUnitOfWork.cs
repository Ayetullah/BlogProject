using BlogP.Core.Entities;
using BlogP.Data.Repositories.Abstractions;

namespace BlogP.Data.UnitOfWorks
{
	public interface IUnitOfWork: IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
		Task<int> SaveAsync();
		int Save();
	}
}
