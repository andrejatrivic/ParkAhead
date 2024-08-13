using Microsoft.EntityFrameworkCore;

namespace ParkAhead.Data.Repository
{
	public class Repository<T> : IRepository<T>
		where T : class
	{
		protected readonly ParkAheadDbContext _context;

		public Repository(ParkAheadDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Create
		/// </summary>
		public void Add(T entity)
		{
			_context.Add(entity);
		}

		/// <summary>
		/// Read
		/// </summary>
		public IQueryable<T> GetAll()
		{
			return _context.Set<T>().AsNoTracking();
		}

		/// <summary>
		/// Get by id
		/// </summary>
		/// <param name="id">id</param>
		/// <returns></returns>
		public async Task<T> GetByIdAsync(int id)
		{
			_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			return await _context.Set<T>().FindAsync(id);
		}

		/// <summary>
		/// Update
		/// </summary>
		public void Update(T entity)
		{
			_context.Update(entity);
		}

		/// <summary>
		/// Delete
		/// </summary>
		public void Delete(T entity)
		{
			_context.Remove(entity);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
