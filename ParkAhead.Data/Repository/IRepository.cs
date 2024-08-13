namespace ParkAhead.Data.Repository
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();
		Task<T> GetByIdAsync(int id);

		void Add(T entity);

		void Update(T entity);

		void Delete(T entity);

		Task SaveAsync();
	}
}
