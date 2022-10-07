using ApiLoroCrypto.Core.Models;
using System.Security.Cryptography;
using System.Text;

namespace ApiLoroCrypto.Core.Helper
{
    public static class ApiHelper
    {
        public static string GetSHA256(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
       
        }

        public static User ValidateUser(User user, string password)
        {
            string encriptedPassword = GetSHA256(password);
            if (user.Password != encriptedPassword)
            {
                return null;
            }
            return user;
        }



    }


}
