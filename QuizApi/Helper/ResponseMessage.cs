using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.Helper
{
    public class ResponseMessage
    {
        // success message
        public const string RegisterPlayerSuccess = "Player registered successfully";
        public const string LoginSuccess = "Login successful";
        public const string SaveScoreSuccess = "Score saved successfully";

        // failure message
        public const string BadRequest = "Invalid request";
        public const string ServerError = "Error on processing request";
        public const string RegisterPlayerFailure = "Player Registration Failed";
        public const string LoginFailure = "Login Failed";
        public const string InvalidEmail = "No player with given email";
        public const string EmailAlreadyExists = "Given email already exists";
        public const string InvalidPassword = "Password Invalid";
        public const string SaveScoreFailure = "Saving score failed";
    }
}
