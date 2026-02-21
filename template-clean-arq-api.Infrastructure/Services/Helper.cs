using System.Security.Cryptography;
using System.Text;
using template_clean_arq_api.Application.Abstraction;

namespace template_clean_arq_api.Infrastructure.Services
{
    public class Helper : IHelper
    {
        public string GenerateRandom(int length)
        {
            const string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                int idx = RandomNumberGenerator.GetInt32(0, charset.Length);
                sb.Append(charset[idx]);
            }

            return sb.ToString();
        }
    }
}
