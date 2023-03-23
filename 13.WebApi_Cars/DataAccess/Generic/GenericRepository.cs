using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Generic
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAsync();
		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
						   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
						   string includeProperties = "");
		Task<bool> CreateAsync(T entity);
		Task<bool> UpdateAsync(T entity);

		Task<bool> DeleteAsync(Expression<Func<T, bool>> whereCondition);
	}

	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly IUnitOfWork _unitOfWork;

		public GenericRepository(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<bool> CreateAsync(T entity)
		{
			bool created = false;

			try
			{
				var save = await _unitOfWork.Context.Set<T>().AddAsync(entity);

				if (save != null)
					created = true;
			}
			catch (Exception)
			{
				throw;
			}
			return created;
		}

		public async Task<IEnumerable<T>> GetAsync()
		{
			return await _unitOfWork.Context.Set<T>().ToListAsync();
		}

		public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
		{
			IQueryable<T> query = _unitOfWork.Context.Set<T>();

			if (whereCondition != null)
			{
				query = query.Where(whereCondition);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return await orderBy(query).ToListAsync();
			}
			else
			{
				return await query.ToListAsync();
			}
		}

		public async Task<bool> UpdateAsync(T entity)
		{
			bool updated = false;
			try
			{
				_unitOfWork.Context.Set<T>().Attach(entity);
				_unitOfWork.Context.Entry(entity).State = EntityState.Modified;

				updated = true;
			}
			catch (Exception)
			{

				throw;
			}

			return updated;
		}

		public async Task<bool> DeleteAsync(Expression<Func<T, bool>> whereCondition)
		{
			bool deleted = false;

			var found = _unitOfWork.Context.Set<T>().Where(whereCondition).FirstOrDefault();

			if (found != null)
			{
				_unitOfWork.Context.Set<T>().Attach(found);
				_unitOfWork.Context.Entry(found).State = EntityState.Deleted;

				deleted = true;
			}

			return deleted;
		}
	}
}
