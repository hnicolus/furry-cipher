using System;
using System.Collections.Generic;
using System.Threading;
using Spectre.Console;
namespace FurryCipher
{
    public class CipherService
    {
        public string DoCipher(string option, string text, int key)
        {
            var executionOptions = new Dictionary<string, Func<string, int, string>>();
            executionOptions.Add(MenuOption.EncryptMessage, (message, key) => EncryptMessage(message, key));
            executionOptions.Add(MenuOption.DecryptMessage, (message, key) => DecryptMessage(message, key));

            if (!executionOptions.ContainsKey(option)) return "";

            return executionOptions[option](text, key);
        }

        private string DecryptMessage(string message, int key) =>
            CCipher.FuriousCipher.Decrypt(message, key);
        private string EncryptMessage(string message, int key) =>
            CCipher.FuriousCipher.Encrypt(message, key);
    }
}