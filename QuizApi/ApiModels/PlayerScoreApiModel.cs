using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.ApiModels
{
    public class PlayerScoreApiModel
    {
        public int ScoreId { get; set; }
        public Guid PlayerId { get; set; }
        public int Score { get; set; }
    }
}
