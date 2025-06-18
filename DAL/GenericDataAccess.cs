using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public static class GenericDataAccess
    {
        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);

                return cmd.ExecuteNonQuery();
            }
        }

        public static T ExecuteScalar<T>(string query, Dictionary<string, object> parameters = null)
        {
            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.AddWithValue(p.Key, p.Value);

                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? default : (T)result;
            }
        }

        public static List<T> ExecuteReader<T>(string query, Func<MySqlDataReader, T> mapFunc, Dictionary<string, object> parameters = null)
        {
            var list = new List<T>();

            using (var conn = DatabaseConnection.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        // ✅ ודוק שאתה באמת מוסיף את הפרמטרים
                        cmd.Parameters.AddWithValue(p.Key, p.Value);
                    }
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(mapFunc(reader));
                    }
                }
            }

            return list;
        }
    }
}