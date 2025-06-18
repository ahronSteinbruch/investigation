using System;

namespace investigation
{
    public class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } // Joined from Users table
        public int TurnsUsed { get; set; }
        public DateTime Timestamp { get; set; }
    }
}