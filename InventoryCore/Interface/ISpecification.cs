using System;
using System.Linq.Expressions;

namespace InventoryCore.Interface
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}

