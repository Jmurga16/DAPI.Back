using System;
namespace DAL.Interfaces
{
	public interface IDALGeneric<TEntity> where TEntity : class
	{
		TEntity Get(int id);
		IEnumerable<TEntity> GetAll();
		bool Add(TEntity entity);
		bool Update(TEntity entity);
		bool Remove(TEntity entity);
	}
}

