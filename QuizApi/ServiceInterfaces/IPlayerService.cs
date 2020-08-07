using QuizApi.ApiModels;
using QuizApi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.ServiceInterfaces
{
    public interface IPlayerService
    {
        //register player
        Task<int> RegisterPlayer(PlayerRegisterApiModel playerRegisterApiModel);

        //login
        Task<PlayerDetails> Login(PlayerLoginApiModel playerLoginApiModel);

        //validate email
        Task<PlayerDetails> GetPlayerByEmail(string email);

        //save quiz score
        Task<int> SaveScore(PlayerScoreApiModel score);
    }
}
