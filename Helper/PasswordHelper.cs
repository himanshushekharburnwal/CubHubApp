using System;
using System.Security.Cryptography;
using System.Text;

namespace CubHubApp.Helper
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Generates a password hash and salt using HMACSHA512.
        /// </summary>
        /// <param name="password">The plain text password</param>
        /// <returns>A tuple containing Hash and Salt as base64 strings</returns>
        public static (string Hash, string Salt) CreatePasswordHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            using var hmac = new HMACSHA512();
            string salt = Convert.ToBase64String(hmac.Key);
            string hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return (hash, salt);
        }

        /// <summary>
        /// Verifies a plain text password against a stored hash and salt.
        /// </summary>
        /// <param name="password">The password to verify</param>
        /// <param name="storedHash">The stored hash as a base64 string</param>
        /// <param name="storedSalt">The stored salt as a base64 string</param>
        /// <returns>True if match is successful; otherwise false</returns>
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(storedHash) ||
                string.IsNullOrWhiteSpace(storedSalt))
                throw new ArgumentException("Password, hash, or salt cannot be null or empty");

            using var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt));
            string computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return computedHash == storedHash;
        }
    }
}
