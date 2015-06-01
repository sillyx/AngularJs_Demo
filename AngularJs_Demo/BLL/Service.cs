using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
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
            var tableName = typeof(T).Name;
            var t = typeof(T).Assembly.CreateInstance(typeof(T).ToString(), true);
            var property = t.GetType().GetProperties();
            string id = string.Empty;
            foreach (var p in property)
            {
                if (p.Name.Equals("Id"))
                    id = p.GetValue(entity, null).ToString();
            }
            string sql = string.Format("delete from {0} where Id='{1}'", tableName, id);
            var res = SqlDBHelper.ExecuteSql(sql) > 0;
            return res;
        }
        public bool UpdateEntity<T>(T entity)
        {
            var tableName = typeof(T).Name;
            var sql = new StringBuilder("update ");
            sql.Append(tableName);
            sql.Append(" set ");
            var t = typeof(T).Assembly.CreateInstance(typeof(T).ToString(), true);
            var property = t.GetType().GetProperties();
            var id = string.Empty;
            foreach (var p in property)
            {
                if (!p.Name.Equals("Id"))
                {
                    sql.Append(p.Name);
                    sql.Append("='");
                    sql.Append(p.GetValue(entity, null));
                    sql.Append("',");
                }
                else
                    id = p.GetValue(entity, null).ToString();
            }
            sql.Length--;
            sql.AppendFormat("where Id='{0}'", id);
            var res = SqlDBHelper.ExecuteSql(sql.ToString()) > 0;
            return res;
        }
    }
}
