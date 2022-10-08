using ApiLoroCrypto.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiLoroCrypto.Core.DTO
{
    public class UserDto : Entity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
