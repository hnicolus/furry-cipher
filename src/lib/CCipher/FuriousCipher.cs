using System;
using System.Linq;
using System.Text;

namespace CCipher
{
    public static class FuriousCipher
    {
        public static string Encrypt(string message, int key = 5)
        {
            var text = message.ToCharArray();

            var encryptedCharArray = text.Select(x =>
            {
                var value = Convert.ToInt32(x);

                if ((value >= 65 && value <= 90) || (value >= 97 && value <= 122))
                {
                    value = value + (key % 26);
                }

                return (char)value;
            }).ToList();
            var sb = new StringBuilder();

            foreach (var c in encryptedCharArray)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public static string Decrypt(string message, int key = 5)
        {
            var text = message.ToCharArray();

            var encryptedCharArray = text.Select(x =>
            {
                var value = Convert.ToInt32(x);
                
                if (value != 32)
                    value = value - (key % 26);

                return (char)value;
            });
            var sb = new StringBuilder();

            foreach (var c in encryptedCharArray)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
