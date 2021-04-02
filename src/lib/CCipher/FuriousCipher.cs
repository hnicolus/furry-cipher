using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCipher
{
    public static class FuriousCipher
    {
        public static string Encrypt(string message, int key )
        {
            var text = message.ToCharArray();

            var encryptedcharacters = text.Select(x =>
            {
                var value = Convert.ToInt32(x);

                if ((value >= 65 && value <= 90) || (value >= 97 && value <= 122))
                {
                    value = value + (key % 26);
                }

                return (char)value;
            }).ToList();

            return buildText(encryptedcharacters);
        }

        public static string Decrypt(string message, int key)
        {
            var text = message.ToCharArray();

            var decryptedChars = text.Select(x =>
            {
                var value = Convert.ToInt32(x);

                if (value != 32)
                    value = value - (key % 26);

                return (char)value;
            }).ToList();

            return buildText(decryptedChars);
        }

        private static string buildText(List<char> characters)
        {
            var sb = new StringBuilder();

            foreach (var c in characters)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
