

internal class Hero : Creature
{
    public LimitedList<Item> BackPack { get; }
   

    public Hero(Cell cell) : base(cell, "H ")
    {
        Color = ConsoleColor.Blue;
        //ToDo read from config
        BackPack = new LimitedList<Item>(3); 
    }
}