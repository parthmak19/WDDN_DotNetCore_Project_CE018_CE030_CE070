using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_News_System.ViewModels
{
    public class RegisterViewModel
    {
        public int id { get; set; }
        [Required, MinLength(6, ErrorMessage = "Username cannot less than 6.")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format.")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), MinLength(6, ErrorMessage = "Password cannot less than 6.")]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password is not matching!")]
        public string ConfirmPassword { get; set; }
    }
}
