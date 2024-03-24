using DormitoryManagement.Models;
using Microsoft.CodeAnalysis.Diagnostics;

namespace DormitoryManagement.Utils
{
    public static class TokenUtil
    {
        private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateToken()
        {
            Random random = new Random();
            char[] token = new char[32];

            for (int i = 0; i < 32; i++)
            {
                token[i] = AllowedChars[random.Next(0, AllowedChars.Length)];
            }

            return new string(token);
        }


    }
}
