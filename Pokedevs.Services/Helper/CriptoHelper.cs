using System.Security.Cryptography;
using System.Text;

namespace Pokedevs.Services.Helper
{
    public static class CriptoHelper
    {
        public static string Md5Hash(this string text)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sBuilder = new();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}