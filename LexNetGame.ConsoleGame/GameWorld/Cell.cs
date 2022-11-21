
using LexNetGame.ConsoleGame.GameWorld;

public class Cell : IDrawable
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; }

    public Position Position { get; set; }
    public List<Item> Items { get; } = new List<Item>();

    public Cell(Position position)
    {
        Color = ConsoleColor.Red;
        Position = position;
    }
}