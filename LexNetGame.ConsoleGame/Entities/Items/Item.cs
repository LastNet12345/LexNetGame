public class Item : IDrawable
{
    private readonly string name;

    public ConsoleColor Color { get; }
    public string Symbol { get; }

    public Item(string symbol, ConsoleColor color, string name)
    {
        Symbol = symbol;
        Color = color;
        this.name = name;
    }

    public override string ToString() => name;
    //{
    //    return name;
    //}

    public static Item Coin() => new Item("c ", ConsoleColor.Yellow, "coin");
    public static Item Stone() => new Item("s ", ConsoleColor.Gray, "stone");
}