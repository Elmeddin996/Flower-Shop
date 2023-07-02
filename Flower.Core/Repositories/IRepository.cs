using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    namespace Shop.Core.Repositories
    {
        public interface IRepository<T>
        {
            void Add(T entity);
            IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> exp, params string[] includes);
            List<T> GetAll(Expression<Func<T, bool>> exp, params string[] includes);
            T Get(Expression<Func<T, bool>> exp, params string[] includes);
            bool IsExist(Expression<Func<T, bool>> exp, params string[] includes);
            void Remove(T entity);
            int Commit();
        }
    }

}
