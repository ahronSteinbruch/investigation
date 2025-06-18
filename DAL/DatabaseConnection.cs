using MySql.Data.MySqlClient;

namespace DataAccess
{
    public static class DatabaseConnection
    {
        // עדכן את הפרטים בהתאם להתקנה שלך
        private static string connectionString =
            "server=localhost;" +
            "database=investigation_game;" + 
            "user=root;" +
            "port=3306;" +
            "Convert Zero Datetime=True;";

        public static MySqlConnection GetConnection()
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void InitializeDatabase()
        {
            using (var conn = GetConnection())
            {
                string createUsersTable = $@"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Username VARCHAR(50) UNIQUE NOT NULL,
                        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                    );";

                string createScoresTable = $@"
                    CREATE TABLE IF NOT EXISTS InvestigationScores (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        UserId INT NOT NULL,
                        TurnsUsed INT NOT NULL,
                        Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                        FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
                    );";

                using (var cmd = new MySqlCommand(createUsersTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new MySqlCommand(createScoresTable, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("[✔] Database initialized successfully.");
            }
        }
    }
}