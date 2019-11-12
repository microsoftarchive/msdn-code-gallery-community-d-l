using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkNorthWind_cs
{
    public interface IRepository
    {
        void Update<T>(T obj, params Expression<Func<T, object>>[] propertiesToUpdate) where T : class;
    }
}
