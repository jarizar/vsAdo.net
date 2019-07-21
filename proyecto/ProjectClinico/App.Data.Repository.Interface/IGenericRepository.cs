using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IGenericRepository<TEntity>
    {
        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Remove(TEntity entity);

        TEntity GetById<TId>(TId id);

        List<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> orderBy = null
            );

    }
}
