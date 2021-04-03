using System;
using System.Threading;
using Spectre.Console;
namespace FurryCipher
{
    partial class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                DisplayHeading();
                var option = DisplayMenuPrompt();

                if (option == MenuOption.ExitProgram && AnsiConsole.Confirm("Are you sure you want to exit?"))
                    break;

                var text = AnsiConsole.Ask<string>("Enter your [green] text[/]");
                int secretkey = AnsiConsole.Ask<int>("Enter [red] secret key[/]");

                var output = getCipherOutput(option, text, secretkey);

                AnsiConsole.Markup($"Output Message : [green]{ output}[/]");
                Console.ReadKey();

            } while (true);
        }

        private static string DisplayMenuPrompt()
        {
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green] What do you want to do with the program [/]?")
                    .AddChoice(MenuOption.EncryptMessage)
                    .AddChoices(new[] {
                    MenuOption.DecryptMessage, MenuOption.ExitProgram
                    }));

            return option;
        }

        private static void DisplayHeading()
        {
            var rollDice = new Random();

            AnsiConsole.Render(
                new FigletText("Furious Cipher")
                    .LeftAligned()
                    .Color((Color)rollDice.Next(0, 80)));

            AnsiConsole.Markup("[underline green]Created By :[/] ");
            AnsiConsole.MarkupLine("[bold]Nicolas Maluleke[/] ");

            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine();
        }

        private static string getCipherOutput(string option, string text, int key)
        {
            var cipherService = new CipherService();

            var output = string.Empty;
            var currentOperation = option == MenuOption.EncryptMessage ? "Encrypting" : "Decrypting";

            AnsiConsole.Status()
                .Start($"{currentOperation}...", ctx =>
                {
                    // Simulate Encryption
                    AnsiConsole.MarkupLine($"Starting {currentOperation} Operation...");
                    Thread.Sleep(1000);
                    AnsiConsole.MarkupLine($"{currentOperation} Message...");
                    ctx.Spinner(Spinner.Known.Star);
                    Thread.Sleep(1000);
                    output = cipherService.DoCipher(option, text, key);
                    AnsiConsole.MarkupLine($"Message Successfully {currentOperation}...");
                    ctx.SpinnerStyle(Style.Parse("green"));
                });

            return output;

        }
    }
}
