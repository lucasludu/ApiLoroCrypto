using System.ComponentModel.DataAnnotations;

namespace ApiLoroCrypto.Core.Models
{
    public class User : Entity
    {
        [Required(ErrorMessage = "Firstname is Required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is Required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
