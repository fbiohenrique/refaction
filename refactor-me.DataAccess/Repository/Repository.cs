using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        public Repository(Entities context)
        {
            _context = context;
        }

        private Entities _context;

        protected Entities Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public IQueryable<TEntity> GetAll(bool noTracking = false)
        {
            if (noTracking)
                return _context.Set<TEntity>().AsNoTracking();

            return _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate, bool noTracking = false)
        {
            if (noTracking)
                return GetAll().AsNoTracking().Where(predicate).AsQueryable();

            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public void Update(TEntity obj, bool saveChanges = false)
        {
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Modified;

                if (saveChanges)
                    Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Insert(TEntity obj, bool saveChanges = false)
        {
            if (obj != null)
            {
                _context.Set<TEntity>().Add(obj);

                if (saveChanges)
                    Save();
            }
        }

        public void Delete(Func<TEntity, bool> predicate, bool saveChanges = false)
        {
            _context.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _context.Set<TEntity>().Remove(del));

            if (saveChanges)
                Save();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
