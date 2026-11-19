using Spectre.Console;

namespace MathGame.Models;

public class Player
{
    public string Name { set; get; }
    public int Score { set; get; }
    private List<PlayList> PlayLists { set; get; }

    public Player(string name)
    {
        Name = name;
        PlayLists = new();
    }

    public void SetPlayList(string operation, int point)
    {
        PlayLists.Add(new PlayList(operation, point));
    }

    public void DisplayPlayerDetails()
    {
        var table = new Table().AddColumn("Player").AddColumn("Operation").AddColumn("Points");

        if (PlayLists.Count == 0)
        {
            table.AddRow(
                new Text(Name ?? string.Empty),
                new Text("No playlist entries"),
                new Text(string.Empty)
            );
        }
        else
        {
            foreach (var playList in PlayLists)
            {
                table.AddRow(
                    new Text(Name ?? string.Empty),
                    new Text(playList.Operation),
                    new Text(playList.Point.ToString())
                );
            }
        }

        AnsiConsole.Write(table);
    }
}
