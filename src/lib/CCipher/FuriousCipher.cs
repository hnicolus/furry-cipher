using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCipher
{
    /// <summary>
    /// Contains Cipher code to Encrypt and Decrypt text
    /// </summary>
    public static class FuriousCipher
    {
        public static string Encrypt(string message, int secretKey)
        {
            var text = message.Trim().ToCharArray();

            var encryptedcharacters = text.Select(x =>
            {
                var value = Convert.ToInt32(x);

                //only change char from A-Z and a-z
                if ((value >= 65 && value <= 90) || (value >= 97 && value <= 122))
                {
                    // encrypting formula
                    value += (secretKey % 26);
                }
                return (char)value;
            }).ToList();

            return buildText(encryptedcharacters);
        }


        public static string Decrypt(string message, int secretKey)
        {
            var text = message
            .Trim()
            .ToCharArray();

            var decryptedChars = text.Select(x =>
            {
                var value = Convert.ToInt32(x);

                if (value >= 65 || value >= 97)
                    value -= (secretKey % 26); //decrypting formula

                return (char)value;
            }).ToList();

            return buildText(decryptedChars);
        }

        private static string buildText(List<char> characters)
        {
            var sb = new StringBuilder();

            characters.ForEach(c => sb.Append(c));

            return sb.ToString();
        }
    }
}
