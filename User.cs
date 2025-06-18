using System;

namespace investigation
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}