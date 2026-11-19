using MathGame.Models;
using Spectre.Console;

namespace MathGame;

public class UserInterface
{
    private readonly List<Player> _players = [];

    public void Run()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Math Game").Centered().Color(Color.Cyan1));

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[bold cyan]What would you like to do?[/]")
                    .AddChoices("Join a game", "View scores", "Exit"));

            switch (choice)
            {
                case "Join a game":
                    JoinGame();
                    break;
                case "View scores":
                    DisplayScores();
                    break;
                case "Exit":
                    return;
            }
        }
    }

    private void JoinGame()
    {
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("[cyan]Enter your name:[/]")
                .Validate(input =>
                    string.IsNullOrWhiteSpace(input)
                        ? ValidationResult.Error("[red]A name is required to join.[/]")
                        : ValidationResult.Success()));

        var player = new Player(name.Trim());
        _players.Add(player);
        new GameInterface(player).MainMenu();

        AnsiConsole.Write(
            new Panel(
                    new Table()
                        .AddColumn("Player")
                        .AddColumn("Final score")
                        .AddRow(new Text(player.Name), new Text(player.Score.ToString())))
                .Header("[bold green]Game complete[/]")
                .BorderColor(Color.Green));
        AnsiConsole.Write(new Rule("[bold cyan]Answer history[/]").RuleStyle(Color.Cyan1));
        player.DisplayPlayerDetails();
        WaitForEnter();
    }

    private void DisplayScores()
    {
        AnsiConsole.Clear();
        var table = new Table()
            .Title("[bold cyan]Scoreboard[/]")
            .AddColumn("Rank")
            .AddColumn("Player")
            .AddColumn(new TableColumn("Score").RightAligned());

        if (_players.Count == 0)
        {
            table.AddRow(new Text("-"), new Text("No players have joined yet"), new Text("-"));
        }
        else
        {
            var rankedPlayers = _players
                .OrderByDescending(player => player.Score)
                .ThenBy(player => player.Name, StringComparer.OrdinalIgnoreCase);

            int rank = 1;
            foreach (var player in rankedPlayers)
            {
                table.AddRow(
                    new Text((rank++).ToString()),
                    new Text(player.Name),
                    new Text(player.Score.ToString()));
            }
        }

        AnsiConsole.Write(table);
        WaitForEnter();
    }

    private static void WaitForEnter()
    {
        AnsiConsole.Prompt(
            new TextPrompt<string>("[grey]Press Enter to continue...[/]").AllowEmpty());
    }
}
