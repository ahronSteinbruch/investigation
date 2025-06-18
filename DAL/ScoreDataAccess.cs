using DataAccess;
using investigation;
using System.Collections.Generic;

namespace DataAccess
{
    public static class ScoreDataAccess
    {
        public static List<Score> GetTopScores(int count = 5)
        {
            string query = $@"
                SELECT s.Id, s.UserId, s.TurnsUsed, s.Timestamp, u.Username 
                FROM InvestigationScores s
                JOIN Users u ON s.UserId = u.Id
                ORDER BY s.TurnsUsed ASC 
                LIMIT {count}";

            return GenericDataAccess.ExecuteReader(query, reader =>
                new Score
                {
                    Id = reader.GetInt32("Id"),
                    UserId = reader.GetInt32("UserId"),
                    Username = reader.GetString("Username"),
                    TurnsUsed = reader.GetInt32("TurnsUsed"),
                    Timestamp = reader.GetDateTime("Timestamp")
                });
        }

        public static void AddScore(int userId, int turnsUsed)
        {
            string query = "INSERT INTO InvestigationScores (UserId, TurnsUsed) VALUES (@userId, @turns)";
            var parameters = new Dictionary<string, object>
            {
                { "@userId", userId },
                { "@turns", turnsUsed }
            };

            GenericDataAccess.ExecuteNonQuery(query, parameters);
        }

        public static bool IsTopScore(int newScore, int topCount = 5)
        {
            string queryMin = "SELECT MIN(TurnsUsed) FROM InvestigationScores";
            int minTopScore = GenericDataAccess.ExecuteScalar<int>(queryMin);

            if (minTopScore == 0) return true;

            var currentTopScores = GetTopScores(topCount);
            return currentTopScores.Count < topCount || newScore < currentTopScores.Last().TurnsUsed;
        }
    }
}