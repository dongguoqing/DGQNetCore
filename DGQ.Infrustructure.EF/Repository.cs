using DGQ.Infrustructure.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Model;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DGQ.Infrustructure.EF
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected ApiDBContent Context;
        protected DbSet<TEntity> DbSet;

        public Repository(ApiDBContent context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = this.DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            TEntity addEntity = DbSet.Add(entity).Entity;
            return addEntity;
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            //获取当前的所有的属性 判断属性值是不是 null 如果是null 那么就不进行更新改字段
            PropertyInfo[] properties = entityToUpdate.GetType().GetProperties();
            // Context.Entry(entityToUpdate).State = EntityState.Modified;
            foreach (PropertyInfo prop in properties)
            {
                if (prop.GetValue(entityToUpdate, null) != null)
                {
                    if (prop.GetValue(entityToUpdate, null).ToString() == "&nbsp;")
                        Context.Entry(entityToUpdate).Property(prop.Name).CurrentValue = null;
                    if (!Context.Entry(entityToUpdate).Property(prop.Name).Metadata.IsPrimaryKey())//主键是不能进行修改的 否则无法进行更新
                        Context.Entry(entityToUpdate).Property(prop.Name).IsModified = true;
                }
            }
            //Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}