/*using MySql.Data.MySqlClient;
using DataAccess;
using investigation;

namespace DataAccess
{
    public static class UserDataAccess
    {
        public static int AddUser(string username)
        {
            string query = "INSERT INTO Users (Username) VALUES (@username); SELECT LAST_INSERT_ID();";

            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };

            return GenericDataAccess.ExecuteScalar<int>(query, parameters);
        }

        public static User GetUserByUsername(string username)
        {
            string query = "SELECT Id, Username, CreatedAt FROM Users WHERE Username = @username LIMIT 1";

            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };

            return GenericDataAccess.ExecuteReader(query, reader =>
                new User
                {
                    Id = reader.GetInt32("Id"),
                    Username = reader.GetString("Username"),
                    CreatedAt = reader.GetDateTime("CreatedAt")
                }).FirstOrDefault();
        }
    }
}*/
using MySql.Data.MySqlClient;
using DataAccess;
using investigation;

namespace DataAccess
{
    public static class UserDataAccess
    {
        public static int AddUser(string username)
        {
            string query = "INSERT INTO Users (Username) VALUES (@username); SELECT LAST_INSERT_ID();";

            var parameters = new Dictionary<string, object>
            {
                { "@username", username }
            };

            // השתמש ב-Convert.ToInt32 כדי למנוע InvalidCastException
            object result = GenericDataAccess.ExecuteScalar<object>(query, parameters);

            return Convert.ToInt32(result);
        }

        public static User GetUserByUsername(string username)
        {
            Console.WriteLine("[DEBUG] Searching for username:");
            Console.WriteLine($"Input value: {username}");

            string query = "SELECT Id, Username, CreatedAt FROM Users WHERE Username = @username LIMIT 1";

            var parameters = new Dictionary<string, object>
    {
        { "@username", username }
    };

            Console.WriteLine("\n[DEBUG] Executing query:");
            Console.WriteLine(query);

            Console.WriteLine("\n[DEBUG] With Parameters:");
            foreach (var p in parameters)
            {
                Console.WriteLine($"{p.Key} = {p.Value}");
            }

            return GenericDataAccess.ExecuteReader(query, reader =>
                new User
                {
                    Id = reader.GetInt32("Id"),
                    Username = reader.GetString("Username"),
                    CreatedAt = reader.GetDateTime("CreatedAt")
                }, parameters).FirstOrDefault();
        }
    }
}