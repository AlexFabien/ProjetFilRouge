using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApi.Utils
{
    public class QueryBuilder
    {
        public StringBuilder query = new StringBuilder();
        public QueryBuilder() { }
        internal QueryBuilder Select(params string[] values)
        {
            query.Clear();
            query.Append("SELECT ");
            if (values.Length > 0)
            {
                foreach (string value in values)
                    query.Append($"{value},");
                query.Remove((query.Length - 1), 1);
            }
            else
                query.Append("*");
            return this;
        }

        internal QueryBuilder Insert(string table)
        {
            query.Clear();
            query.Append($"INSERT INTO {table}");
            return this;
        }
        
        //FIXIT : adapter à nos données
        internal string Values(Dictionary<string, dynamic> obj)
        {
            query.Append("(");
            foreach (var key in obj.Keys)
            {
                query.Append($"{key},");
            }
            query.Remove((query.Length - 1), 1);
            query.Append(") VALUES (");
            foreach (var key in obj.Keys)
            {
                if (obj[key] is string)
                {
                    query.Append($"'{obj[key]}',");
                } else if (obj[key] is int || obj[key] is bool)
                {
                    query.Append($"{obj[key]},");
                } else if (obj[key] is double)
                {
                    string val = obj[key].ToString();
                    query.Append($"{val.Replace(',', '.')},");
                } else
                {
                    query.Append($"'{obj[key]}',");
                }
            }
            query.Remove((query.Length - 1), 1);
            query.Append(");");
            return query.ToString();
        }

        internal string Delete(string table, int id)
        {
            query.Clear();
            return query.Append($"DELETE FROM {table} where id = {id}").ToString();
        }

        internal string Get()
        {
            return query.ToString();
        }

        internal QueryBuilder Where(string key, dynamic value, string type = "=")
        {
            query.Append($" WHERE {key} {type} {value}");
            return this;
        }

        internal QueryBuilder From(string table)
        {
            query.Append($" FROM {table} ");
            return this;
        }

        internal QueryBuilder Update(string table)
        {
            query.Clear();
            query.Append($"UPDATE {table} ");
            return this;
        }

        internal QueryBuilder Set(Dictionary<string, dynamic> obj)
        {
            query.Append("SET ");
            foreach (var key in obj.Keys)
            {
                if (obj[key] is string)
                {
                    query.Append($"{key} = '{obj[key]}',");
                }
                else if (obj[key] is int || obj[key] is bool)
                {
                    query.Append($"{key} = {obj[key]},");
                }
                else if (obj[key] is double)
                {
                    string val = obj[key].ToString();
                    query.Append($"{key} = {val.Replace(',', '.')},");
                }
                else
                {
                    query.Append($"{key} = '{obj[key]}',");
                }
            }
            query.Remove((query.Length - 1), 1);
            return this;
        }
    }
}
