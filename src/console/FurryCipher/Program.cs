using System;
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
                var option = DisplayMenu();

                if (option == MenuOption.ExitProgram && AnsiConsole.Confirm("Are you sure you want to exit?"))
                    break;

                var text = AnsiConsole.Ask<string>("Enter your [green] text[/]");
                int key = AnsiConsole.Ask<int>("Enter [red] secret key[/]");

                AnsiConsole.WriteLine("Output Message :" + CipherCommand(option, text, key));
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

        private static string CipherCommand(string option, string text, int key)
        {
            var cipherService = new CipherService();

            return cipherService.DoCipher(option, text, key);

        }
    }
}
