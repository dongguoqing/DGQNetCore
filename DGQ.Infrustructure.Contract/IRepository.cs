﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace DGQ.Infrustructure.Contract
{
    public interface IRepository
    {
    }

    /// <summary>
    /// Repository标记接口
    /// </summary>
    public interface IRepository<TEntity> : IRepository
        where TEntity : class
    {

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(object id);

        TEntity Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        int Delete(Expression<Func<TEntity, bool>> predicate);

        void Update(TEntity entityToUpdate);

        void Save();
    }
}
