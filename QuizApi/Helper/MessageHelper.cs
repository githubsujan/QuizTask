using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Helper
{
    public class MessageHelper
    {
        public const string ServerFail = "server-fail";
        public const string RegisterPlayerFail = "register-player-fail";
        public const string RegisterPlayerSuccess = "register-player-success";
        public const string LoginFail = "login-fail";
        public const string LoginSuccess = "login-success";
        public const string InvalidEmail = "email-invalid";
        public const string EmailAlreadyExists = "email-alredy-exists";
        public const string InvalidPassword = "password-invalid";
        public const string SaveScoreSuccess = "save-score-success";
        public const string SaveScoreFail = "save-score-fail";

        public static Object Get500JsonResponse(string context)
        {
            string responseMessage = null;
            switch (context)
            {
                case ServerFail:
                    responseMessage = ResponseMessage.ServerError;
                    break;
                case RegisterPlayerFail:
                    responseMessage = ResponseMessage.RegisterPlayerFailure;
                    break;
                case LoginFail:
                    responseMessage = ResponseMessage.LoginFailure;
                    break;
                case SaveScoreFail:
                    responseMessage = ResponseMessage.SaveScoreFailure;
                    break;
            }
            return new
            {
                status = StatusCodes.Status500InternalServerError,
                message = responseMessage
            };
        }

        public static Object Get400JsonResponse(string context)
        {
            string responseMessage = null;
            switch (context)
            {
                case InvalidEmail:
                    responseMessage = ResponseMessage.InvalidEmail;
                    break;
                case EmailAlreadyExists:
                    responseMessage = ResponseMessage.EmailAlreadyExists;
                    break;
                case InvalidPassword:
                    responseMessage = ResponseMessage.InvalidPassword;
                    break;
            }
            return new
            {
                status = StatusCodes.Status400BadRequest,
                message = responseMessage
            };
        }

        public static Object Get400JsonResponse()
        {
            return new
            {
                status = StatusCodes.Status400BadRequest,
                message = ResponseMessage.BadRequest,
            };
        }

        public static Object Get200JsonResponse(string context,string id)
        {
            string responseMessage = null;
            switch (context)
            {
                case RegisterPlayerSuccess:
                    responseMessage = ResponseMessage.RegisterPlayerSuccess;
                    break;
                case LoginSuccess:
                    responseMessage = ResponseMessage.LoginSuccess;
                    break;
                case SaveScoreSuccess:
                    responseMessage = ResponseMessage.SaveScoreSuccess;
                    break;
            }
            if (id == null)
            {
                return new
                {
                    status = StatusCodes.Status200OK,
                    message = responseMessage
                };
            }
            return new
            {
                status = StatusCodes.Status200OK,
                message = responseMessage,
                playerid=id
            };
        }
    }
}
