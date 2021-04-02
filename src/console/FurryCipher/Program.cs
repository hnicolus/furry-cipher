using System.Collections.Generic;
using System;
using CCipher;
using Spectre.Console;
using System.Threading;
namespace FurryCipher
{
    partial class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                var option = DisplayMenu();

                if (option == MenuOption.ExitProgram && AnsiConsole.Confirm("Are you sure you want to exit?"))
                    break;

                var text = AnsiConsole.Ask<string>("Enter your [green] text[/]");
                int key = AnsiConsole.Ask<int>("Enter [red] secret key[/]");

                string outputMessage = DoCipher(option,text,key);
                AnsiConsole.WriteLine("Output Message :" + outputMessage);
                
                Console.ReadKey();

            } while (true);
        }


        private static string DisplayMenu()
        {
            var rollDice = new Random();

            AnsiConsole.Render(
                new FigletText("Furry Cipher")
                    .LeftAligned()
                    .Color((Color)rollDice.Next(0, 80)));

            AnsiConsole.Markup("[underline green]Created By :[/] ");
            AnsiConsole.MarkupLine("[bold]Nicolas Maluleke[/] ");

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();

            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green] What do you want to do with the program [/]?")
                    .AddChoice(MenuOption.EncryptMessage)
                    .AddChoices(new[] {
                    MenuOption.DecryptMessage, MenuOption.ExitProgram
                    }));

            return option;
        }
        private static string DoCipher(string option,string text,int key)
        {
            var executionOptions = new Dictionary<string, Func<string, int, string>>();

            executionOptions.Add(MenuOption.EncryptMessage, (message, key) => EncryptMessage(message, key));
            executionOptions.Add(MenuOption.DecryptMessage, (message, key) => DecryptMessage(message, key));

            var outputMessage = executionOptions[option](text, key);
            
            return outputMessage;
        }

        private static string DecryptMessage(string message, int key)
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
        private static string EncryptMessage(string message, int key)
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
                    output = CCipher.FuriousCipher.Encrypt(message, key);
                    AnsiConsole.MarkupLine("Message Successfully encrypted...");
                    ctx.SpinnerStyle(Style.Parse("green"));
                });

            return output;
        }
    }
}
