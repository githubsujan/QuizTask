using System;
using System.Collections.Generic;

namespace QuizApi.DataModels
{
    public partial class PlayerScore
    {
        public int ScoreId { get; set; }
        public Guid PlayerId { get; set; }
        public int Score { get; set; }

        public virtual PlayerDetails Player { get; set; }
    }
}
