using MathGame.Models;
using Spectre.Console;

namespace MathGame;

public class GameEngine
{
    private readonly Player _player;
    private readonly Random _random;

    public GameEngine(Player player)
    {
        _player = player;
        _random = new();
    }

    public void AddNumberGame(int playTime)
    {
        for (int i = 0; i < playTime; i++)
        {
            int num1 = _random.Next(1000);
            int num2 = _random.Next(1000);

            AnsiConsole.Write(new Rule("[bold cyan]Addition Challenge[/]").RuleStyle("cyan"));
            AnsiConsole.MarkupLine($"[bold white]{num1}[/] [grey]+[/] [bold white]{num2}[/]");

            int answer = AnsiConsole.Prompt(
                new TextPrompt<int>("[bold yellow]Your answer:[/]").PromptStyle("green")
            );
            int correctAnswer = num1 + num2;
            bool isCorrect = answer == correctAnswer;
            int points = isCorrect ? 1 : 0;

            _player.Score += points;
            _player.SetPlayList($"{num1} + {num2} : result {answer}", points);

            string feedback = isCorrect
                ? $"[bold green]Correct![/]\n[white]Score: {_player.Score}[/]"
                : $"[bold red]Not quite.[/]\n[white]Correct answer: {correctAnswer}[/]\n[white]Score: {_player.Score}[/]";

            AnsiConsole.Write(
                new Panel(new Markup(feedback))
                    .Border(BoxBorder.Rounded)
                    .BorderColor(isCorrect ? Color.Green : Color.Red)
            );
        }
    }

    public void SubNumberGame(int playTime)
    {
        for (int i = 0; i < playTime; i++)
        {
            int num1 = _random.Next(1000);
            int num2 = _random.Next(1000);

            AnsiConsole.Write(new Rule("[bold cyan]Subtraction Challenge[/]").RuleStyle("cyan"));
            AnsiConsole.MarkupLine($"[bold white]{num1}[/] [grey]-[/] [bold white]{num2}[/]");

            int answer = AnsiConsole.Prompt(
                new TextPrompt<int>("[bold yellow]Your answer:[/]").PromptStyle("green")
            );
            int correctAnswer = num1 - num2;
            bool isCorrect = answer == correctAnswer;
            int points = isCorrect ? 1 : 0;

            _player.Score += points;
            _player.SetPlayList($"{num1} - {num2} : result {answer}", points);

            string feedback = isCorrect
                ? $"[bold green]Correct![/]\n[white]Score: {_player.Score}[/]"
                : $"[bold red]Not quite.[/]\n[white]Correct answer: {correctAnswer}[/]\n[white]Score: {_player.Score}[/]";

            AnsiConsole.Write(
                new Panel(new Markup(feedback))
                    .Border(BoxBorder.Rounded)
                    .BorderColor(isCorrect ? Color.Green : Color.Red)
            );
        }
    }

    public void MultiNumberGame(int playTime)
    {
        for (int i = 0; i < playTime; i++)
        {
            int num1 = _random.Next(1000);
            int num2 = _random.Next(1000);

            AnsiConsole.Write(new Rule("[bold cyan]Multiplication Challenge[/]").RuleStyle("cyan"));
            AnsiConsole.MarkupLine($"[bold white]{num1}[/] [grey]×[/] [bold white]{num2}[/]");

            int answer = AnsiConsole.Prompt(
                new TextPrompt<int>("[bold yellow]Your answer:[/]").PromptStyle("green")
            );
            int correctAnswer = num1 * num2;
            bool isCorrect = answer == correctAnswer;
            int points = isCorrect ? 1 : 0;

            _player.Score += points;
            _player.SetPlayList($"{num1} × {num2} : result {answer}", points);

            string feedback = isCorrect
                ? $"[bold green]Correct![/]\n[white]Score: {_player.Score}[/]"
                : $"[bold red]Not quite.[/]\n[white]Correct answer: {correctAnswer}[/]\n[white]Score: {_player.Score}[/]";

            AnsiConsole.Write(
                new Panel(new Markup(feedback))
                    .Border(BoxBorder.Rounded)
                    .BorderColor(isCorrect ? Color.Green : Color.Red)
            );
        }
    }

    public void DivNumberGame(int playTime)
    {
        for (int i = 0; i < playTime; i++)
        {
            int[] numbers = Helper.GetDividableNumbers();
            int num1 = numbers[0];
            int num2 = numbers[1];

            AnsiConsole.Write(new Rule("[bold cyan]Division Challenge[/]").RuleStyle("cyan"));
            AnsiConsole.MarkupLine($"[bold white]{num1}[/] [grey]÷[/] [bold white]{num2}[/]");

            int answer = AnsiConsole.Prompt(
                new TextPrompt<int>("[bold yellow]Your answer:[/]").PromptStyle("green")
            );
            int correctAnswer = num1 / num2;
            bool isCorrect = answer == correctAnswer;
            int points = isCorrect ? 1 : 0;

            _player.Score += points;
            _player.SetPlayList($"{num1} + {num2} : result {answer}", points);

            string feedback = isCorrect
                ? $"[bold green]Correct![/]\n[white]Score: {_player.Score}[/]"
                : $"[bold red]Not quite.[/]\n[white]Correct answer: {correctAnswer}[/]\n[white]Score: {_player.Score}[/]";

            AnsiConsole.Write(
                new Panel(new Markup(feedback))
                    .Border(BoxBorder.Rounded)
                    .BorderColor(isCorrect ? Color.Green : Color.Red)
            );
        }
    }
}
