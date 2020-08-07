using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApi.ApiModels
{
    public class PlayerRegisterApiModel
    {
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(100, ErrorMessage = "Maximum Username characters allowed is 100")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Invalid Email Adress")]
        [MaxLength(100, ErrorMessage = "Maximum Email characters allowed is 100")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(100, ErrorMessage = "Maximum Password characters allowed is 100")]
        public string Password { get; set; }
    }
}
