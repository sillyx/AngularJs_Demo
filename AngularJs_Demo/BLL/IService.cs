using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IService
    {
        bool Add<T>(T entity);
        List<T> FindList<T>();
        bool DelEntity<T>(T entity);
        bool UpdateEntity<T>(T entity);
    }
}
