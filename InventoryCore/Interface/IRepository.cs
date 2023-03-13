using System;
using InventoryCore.Entity;

namespace InventoryCore.Interface
{
	public interface IRepository
	{
        T GetById<T>(int id) where T : BaseEntity;
        T GetById<T>(int id, string include) where T : BaseEntity;
        List<T> List<T>(ISpecification<T> spec = null) where T : BaseEntity;
        Task<T> Add<T>(T entity) where T : BaseEntity;
        Task Update<T>(T entity) where T : BaseEntity;
        Task Delete<T>(T entity) where T : BaseEntity;
    }
}

