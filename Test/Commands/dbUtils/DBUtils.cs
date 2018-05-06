using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Test.Commands.dbUtils
{
    public static class DBUtils
    {
        public static T ConvertToObject<T>(SqlDataReader rd) where T : class, new()
        {
            Type type = typeof(T);
            var accessor = TypeAccessor.Create(type);
            var members = accessor.GetMembers();
            var t = new T();

            for (int i = 0; i < rd.FieldCount; i++)
            {
                if (!rd.IsDBNull(i))
                {
                    string fieldName = rd.GetName(i);

                    if (members.Any(m => string.Equals(m.Name, fieldName, StringComparison.OrdinalIgnoreCase)))
                    {
                        accessor[t, fieldName] = rd.GetValue(i);
                    }
                }
            }

            return t;
        }

        public static void ExecuteBatchNonQuery(string sql, SqlConnection conn)
        {
            string sqlBatch = string.Empty;
            SqlCommand cmd = new SqlCommand(string.Empty, conn);
            conn.Open();
            //sql += "\nGO";
            try
            {
                foreach (string line in sql.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.ToUpperInvariant().Trim() == "GO")
                    {
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        sqlBatch = string.Empty;
                    }
                    else
                    {
                        sqlBatch += line + "\n";
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        public static void ExecuteBatchNonQueryWithSplit(string sql, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(string.Empty, conn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            foreach (var sqlBatch in sql.Split(new[] { "\nGO", "\ngo", "\nGo", "\ngO" }, StringSplitOptions.RemoveEmptyEntries))
            {
                cmd.CommandText = sqlBatch;
                cmd.ExecuteNonQuery();
            }
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }


}
