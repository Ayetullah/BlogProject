using BlogP.Core.Entities;
using System.Linq.Expressions;

namespace BlogP.Data.Repositories.Abstractions
{
	public interface IRepository<T> where T : class, IEntityBase, new()
	{
		Task AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);

		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
		Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);


		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetByIdAsync(Guid id);

	}
}
