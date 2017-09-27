using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess.Repository
{
    interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(bool noTracking = false);
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate, bool noTracking = false);
        TEntity Find(params object[] key);
        void Update(TEntity obj, bool saveChanges = false);
        void Insert(TEntity obj, bool saveChanges = false);
        void Delete(Func<TEntity, bool> predicate, bool saveChanges = false);
    }
}
