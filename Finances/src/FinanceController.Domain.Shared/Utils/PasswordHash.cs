using System.Security.Cryptography;

namespace FinanceController.Domain.Shared.Utils
{
    public static class PasswordHash
    {
        public static string Hash(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] passwordHash;
            using (var sha256 = SHA256.Create())
            {
                passwordHash = sha256.ComputeHash(passwordBytes);
            }

            byte[] saltAndPasswordHash = new byte[salt.Length + passwordHash.Length];
            Buffer.BlockCopy(salt, 0, saltAndPasswordHash, 0, salt.Length);
            Buffer.BlockCopy(passwordHash, 0, saltAndPasswordHash, salt.Length, passwordHash.Length);

            string hashedPassword = Convert.ToBase64String(saltAndPasswordHash);

            return hashedPassword;
        }

        public static bool PasswordMatch(string password, string hashedPassword)
        {
            var saltAndPasswordHash = Convert.FromBase64String(hashedPassword);

            if (saltAndPasswordHash.Length <= 16)
            {
                return false;
            }

            var salt = new byte[16];
            var passwordHash = new byte[saltAndPasswordHash.Length - 16];
            Buffer.BlockCopy(saltAndPasswordHash, 0, salt, 0, 16);
            Buffer.BlockCopy(saltAndPasswordHash, 16, passwordHash, 0, saltAndPasswordHash.Length - 16);

            using (var sha256 = SHA256.Create())
            {
                var computedHash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (computedHash.SequenceEqual(passwordHash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
