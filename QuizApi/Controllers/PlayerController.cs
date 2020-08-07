using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApi.ApiModels;
using QuizApi.ServiceInterfaces;
using QuizApi.Helper;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public string Get()
        {
            return "Hello! This is Quiz Api.";
        }

        //Register Player
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromForm] PlayerRegisterApiModel playerRegisterApiModel)
        {
            Object jsonResponse = null;
            if (ModelState.IsValid)
            {
                try
                {
                    var playerByEmail = await _playerService.GetPlayerByEmail(playerRegisterApiModel.Email);
                    if (playerByEmail != null)
                    {
                        jsonResponse = MessageHelper.Get400JsonResponse(MessageHelper.EmailAlreadyExists);
                    }
                    else
                    {
                        playerRegisterApiModel.Password = EncryptDecrypt.EncryptPasswordToBase64(playerRegisterApiModel.Password);
                        var dbResponse = await _playerService.RegisterPlayer(playerRegisterApiModel);
                        if (dbResponse == 1)
                        {
                            jsonResponse = MessageHelper.Get200JsonResponse(MessageHelper.RegisterPlayerSuccess,null);
                        }
                        else
                        {
                            jsonResponse = MessageHelper.Get500JsonResponse(MessageHelper.RegisterPlayerFail);
                        }
                    }
                }
                catch (Exception exception)
                {
                    jsonResponse = MessageHelper.Get500JsonResponse(MessageHelper.ServerFail);
                }
            }
            else
            {
                jsonResponse = MessageHelper.Get400JsonResponse();
            }
            return new JsonResult(jsonResponse);
        }

        //Login Player
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromForm] PlayerLoginApiModel playerLoginApiModel)
        {
            Object jsonResponse = null;
            if (ModelState.IsValid)
            {
                try
                {
                    var playerByEmail = await _playerService.GetPlayerByEmail(playerLoginApiModel.Email);
                    if (playerByEmail != null)
                    {
                        playerByEmail.Password = EncryptDecrypt.DecryptFromBase64(playerByEmail.Password);
                        if(playerLoginApiModel.Email==playerByEmail.Email && playerLoginApiModel.Password == playerByEmail.Password)
                        {
                            jsonResponse = MessageHelper.Get200JsonResponse(MessageHelper.LoginSuccess, Convert.ToString(playerByEmail.PlayerId));
                        }
                        else
                        {
                            jsonResponse = MessageHelper.Get400JsonResponse(MessageHelper.InvalidPassword);
                        }
                    }
                    else
                    {
                        jsonResponse = MessageHelper.Get400JsonResponse(MessageHelper.InvalidEmail);
                    }
                }
                catch (Exception exception)
                {
                    jsonResponse = MessageHelper.Get500JsonResponse(MessageHelper.ServerFail);
                }
            }
            else
            {
                jsonResponse = MessageHelper.Get400JsonResponse();
            }
            return new JsonResult(jsonResponse);
        }

        //Save Score
        [Route("SaveScore")]
        [HttpPost]
        public async Task<ActionResult> SaveScore([FromForm] PlayerScoreApiModel playerScoreModel)
        {
            Object jsonResponse = null;
            if (ModelState.IsValid)
            {
                try
                {
                    var dbResponse = await _playerService.SaveScore(playerScoreModel);
                    if (dbResponse == 1)
                    {
                        jsonResponse = MessageHelper.Get200JsonResponse(MessageHelper.SaveScoreSuccess,null);
                    }
                    else
                    {
                        jsonResponse = MessageHelper.Get500JsonResponse(MessageHelper.SaveScoreFail);
                    }
                }
                catch (Exception exception)
                {
                    jsonResponse = MessageHelper.Get500JsonResponse(MessageHelper.ServerFail);
                }
            }
            else
            {
                jsonResponse = MessageHelper.Get400JsonResponse();
            }
            return new JsonResult(jsonResponse);
        }

        
    }
}
