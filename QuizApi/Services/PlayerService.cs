using Microsoft.EntityFrameworkCore;
using QuizApi.ApiModels;
using QuizApi.DataContext;
using QuizApi.DataModels;
using QuizApi.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Services
{
    public class PlayerService:IPlayerService
    {
        //register player
        public async Task<int> RegisterPlayer(PlayerRegisterApiModel playerRegisterApiModel)
        {
            using (var db = new QuizContext())
            {
                try
                {
                    PlayerDetails playerDetails = new PlayerDetails
                    {
                        Username = playerRegisterApiModel.Username,
                        Email = playerRegisterApiModel.Email,
                        Password = playerRegisterApiModel.Password
                    };
                    await db.PlayerDetails.AddAsync(playerDetails);
                    var dbResult = await db.SaveChangesAsync();
                    return dbResult;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //login
        public async Task<PlayerDetails> Login(PlayerLoginApiModel playerLoginApiModel)
        {
            using (var db = new QuizContext())
            {
                try
                {
                    var player = await db.PlayerDetails.FirstOrDefaultAsync(player => player.Email == playerLoginApiModel.Email && player.Password == playerLoginApiModel.Password);
                    if (player != null)
                    {
                        return player;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //validate email
        public async Task<PlayerDetails> GetPlayerByEmail(string email)
        {
            using (var db = new QuizContext())
            {
                try
                {
                    var player = await db.PlayerDetails.FirstOrDefaultAsync(player => player.Email == email);
                    if (player != null)
                    {
                        return player;
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //save quiz score
        public async Task<int> SaveScore(PlayerScoreApiModel score)
        {
            using (var db = new QuizContext())
            {
                try
                {
                    PlayerScore playerScore = new PlayerScore
                    {
                        PlayerId = score.PlayerId,
                        Score = score.Score,
                    };
                    await db.PlayerScore.AddAsync(playerScore);
                    var dbResponse = await db.SaveChangesAsync();
                    return dbResponse;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
