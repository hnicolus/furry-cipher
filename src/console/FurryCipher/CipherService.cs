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

            var outputMessage = executionOptions[option](text, key);

            return outputMessage;
        }

        private string DecryptMessage(string message, int key)
        {
            var output = string.Empty;
            AnsiConsole.Status()
                .Start("Decrypting...", ctx =>
                {
                    // Simulate Encryption
                    AnsiConsole.MarkupLine("Starting Decrypting program...");
                    Thread.Sleep(1000);
                    AnsiConsole.MarkupLine("Decrypting Message...");
                    ctx.Spinner(Spinner.Known.Star);
                    Thread.Sleep(1000);
                    output = CCipher.FuriousCipher.Decrypt(message, key);
                    AnsiConsole.MarkupLine("Message Successfully Decrypting...");
                    ctx.SpinnerStyle(Style.Parse("green"));
                });

            return output;
        }
        private string EncryptMessage(string message, int key)
        {
            var output = string.Empty;
            AnsiConsole.Status()
                .Start("Encrypting...", ctx =>
                {
                    // Simulate Encryption
                    AnsiConsole.MarkupLine("Starting encryption program...");
                    Thread.Sleep(1000);
                    AnsiConsole.MarkupLine("Encrypting Message...");
                    ctx.Spinner(Spinner.Known.Star);
                    Thread.Sleep(2000);
                    AnsiConsole.MarkupLine("Message Successfully encrypted...");
                    ctx.SpinnerStyle(Style.Parse("green"));
                });
                    output = CCipher.FuriousCipher.Encrypt(message, key);

            return output;
        }
    }
}