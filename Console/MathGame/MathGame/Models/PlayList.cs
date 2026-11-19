namespace MathGame.Models;

public class PlayList
{
    public string Operation { get; set; }
    public int Point { get; set; }

    public PlayList(string operation, int point)
    {
        Operation = operation;
        Point = point;
    }
}
