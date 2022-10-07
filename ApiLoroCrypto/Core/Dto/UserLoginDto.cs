using System.ComponentModel.DataAnnotations;

namespace ApiLoroCrypto.Core.Dto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}
