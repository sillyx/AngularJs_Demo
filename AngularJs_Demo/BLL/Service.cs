using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;

namespace BLL
{
    public class Service : IService
    {
        public bool Add<T>(T entity)
        {
            return false;
        }

        public List<T> FindList<T>()
        {
            List<T> list = new List<T>();
            string sql = "select * from Employee";
            using (var reader = SqlDBHelper.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    var t = typeof(T).Assembly.CreateInstance(typeof(T).ToString(), true);
                    var property = t.GetType().GetProperties();
                    foreach (var p in property)
                    {
                        p.SetValue(t, reader[p.Name].ToString(), null);
                    }
                    list.Add((T)t);
                }
            }
            return list;
        }

        public bool DelEntity<T>(T entity)
        {
            return false;
        }
        public bool UpdateEntity<T>(T entity)
        {
            return false;
        }
    }
}
