using DataAccess;
using System;
using System.Collections.Generic;

namespace investigation
{
    public static class ScoreHandler
    {
        public static void ShowTopScores()
        {
            Console.WriteLine("\n== Top 5 Scores (Lowest to Highest) ==");
            var scores = ScoreDataAccess.GetTopScores();

            if (scores.Count == 0)
            {
                Console.WriteLine("No scores recorded yet.");
            }
            else
            {
                foreach (var score in scores)
                {
                    Console.WriteLine($"{score.Username}: {score.TurnsUsed} turns");
                }
            }

            Console.WriteLine("Press any key to start...\n");
            Console.ReadKey();
        }

        public static void SaveScoreIfQualifies(string username, int totalTurns,int userId)
        {
            var user = UserDataAccess.GetUserByUsername(username);
            if (user == null)
            {
                user = new User
                {
                    Id = UserDataAccess.AddUser(username),
                    Username = username
                };
            }

            if (ScoreDataAccess.IsTopScore(totalTurns))
            {
                ScoreDataAccess.AddScore(user.Id, totalTurns);
                Console.WriteLine("[✔] New high score recorded!");
            }
            else
            {
                Console.WriteLine("[✘] Your score didn't make the top 5.");
            }
        }
    }
}