using System;
using System.Collections.Generic;

namespace QuizApi.DataModels
{
    public partial class PlayerDetails
    {
        public PlayerDetails()
        {
            PlayerScore = new HashSet<PlayerScore>();
        }

        public Guid PlayerId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<PlayerScore> PlayerScore { get; set; }
    }
}
