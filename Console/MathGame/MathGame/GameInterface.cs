using MathGame.Models;
using Spectre.Console;

namespace MathGame;

public class GameInterface
{
    private readonly Player _player;

    public GameInterface(Player player)
    {
        _player = player;
    }

    public void MainMenu()
    {
        var gameEngine = new GameEngine(_player);

        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[bold cyan]Game Menu[/]").RuleStyle(Color.Cyan1));
            AnsiConsole.MarkupLine(
                $"[grey]Player:[/] [cyan]{Markup.Escape(_player.Name)}[/]  [grey]Score:[/] [green]{_player.Score}[/]");

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold]Choose a game[/]")
                    .AddChoices(
                        "Addition",
                        "Subtraction",
                        "Multiplication",
                        "Division",
                        "View score details",
                        "Back to main menu"));

            switch (choice)
            {
                case "Addition":
                    PlayGame(gameEngine.AddNumberGame);
                    break;
                case "Subtraction":
                    PlayGame(gameEngine.SubNumberGame);
                    break;
                case "Multiplication":
                    PlayGame(gameEngine.MultiNumberGame);
                    break;
                case "Division":
                    PlayGame(gameEngine.DivNumberGame);
                    break;
                case "View score details":
                    AnsiConsole.Clear();
                    _player.DisplayPlayerDetails();
                    WaitForEnter();
                    break;
                case "Back to main menu":
                    return;
            }
        }
    }

    private static void PlayGame(Action<int> game)
    {
        int playTime = AnsiConsole.Prompt(
            new TextPrompt<int>("[cyan]How many questions would you like to answer?[/]")
                .Validate(count =>
                    count > 0
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]Enter a positive whole number.[/]")));

        game(playTime);
        WaitForEnter();
    }

    private static void WaitForEnter()
    {
        AnsiConsole.Prompt(
            new TextPrompt<string>("[grey]Press Enter to return to the menu...[/]").AllowEmpty());
    }
}
