using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace CapSoft.Core.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        #region Properties
        private DBModel dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DBModel DbContext
        {
            get
            {
                //dataContext= dataContext ?? (dataContext = DbFactory.Init());



                return dataContext ?? (dataContext = DbFactory.Init());
            }
        }
        #endregion


        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        
        public virtual void Detach(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            DbContext.Commit();
        }

        public virtual void Update(T entity)
        {


            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            DbContext.Commit();
            
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
            DbContext.Commit();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            

            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);

            }

            DbContext.Commit();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {

            return dbSet.ToList();

        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }


        #endregion
      

     
    }
}
