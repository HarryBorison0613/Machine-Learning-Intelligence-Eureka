using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;

using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace FinanceProcessor.Core.Aggregates.security
{
    public class SecurityCrypts : ISecurity
    {
        private readonly byte[] _iv = {0x44, 0x76, 0x21, 0x6e, 0x20, 0x4d, 0x55, 0x2a,
                                        0x65, 0x64, 0x76, 0x65, 0x68, 0x65, 0x76, 0x33};

        private readonly byte[] _key = {0x12, 0x67, 0x16, 0x5d, 0x19, 0x3c, 0x45, 0x1c,
                                         0x29, 0x46, 0x67, 0x29, 0x48, 0x55, 0x33, 0x59};

        public string? DecryptStringFromBytes(byte[] cipherText)
        {
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
                //return null;
            }

            string plaintext;

            using (AesManaged aesAlg = new())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                // Create a decry-tor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using MemoryStream msDecrypt = new(cipherText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);

                plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }

        public byte[] EncryptStringToBytes(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText) || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            byte[] encrypted;

            using (AesManaged? aesAlg = new())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                // Create a decry-tor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }

            return encrypted;
        }

        public string GeneratePassword()
        {
            char c;
            Random rnd = new();
            StringBuilder newPassword = new();
            for (int i = 0; i < 4; i++)
            {
                c = (char)rnd.Next(48, 123);
                if (char.IsLetterOrDigit(c))
                {
                    newPassword.Append(c);
                }
                else
                {
                    i--;
                }
            }

            c = (char)rnd.Next(35, 38); // for special character
            newPassword.Append(c);

            c = (char)rnd.Next(48, 57); // for number
            newPassword.Append(c);

            c = (char)rnd.Next(65, 90); // for uppercase character
            newPassword.Append(c);

            c = (char)rnd.Next(97, 122); // for lowercase character
            newPassword.Append(c);
            return newPassword.ToString();
        }

        public bool IsEmail(string username)
        {
            bool flag = false;
            if (!username.Contains(".")) return flag;
            if (username.Length < 5) return flag;
            flag = username.Contains("@");
            return flag;
        }

        public bool IsPasswordValid(string pass)
        {
            if (pass.Length >= 8 && pass.Length <= 20)
            {
                return Regex.IsMatch(pass, @"[a-z]") // min 1 lowercase
                       && Regex.IsMatch(pass, @"[A-Z]") // min 1 uppercase
                       && Regex.IsMatch(pass, @"\d") // min 1 digit
                       && !Regex.IsMatch(pass, @"^[a-zA-Z0-9]*$") // min 1 symbol
                       && pass.IndexOf(' ') < 0;
            }

            return false;
        }
    }
}
