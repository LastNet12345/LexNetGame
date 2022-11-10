using LexNetGame.ConsoleGame.UserInterface;
using System.Data;

internal class Game
{
    private Map map = null!;
    private Hero hero = null!;

    public Game()
    {
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;

        do
        {
            //DrawMap
            DrawMap();

            //GetCommand
            GetCommand();

            //Act

            //DrawMap

            //EnemyAction

            //DrawMap

        } while (gameInProgress);

    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch(keyPressed)
        {
            case ConsoleKey.LeftArrow:
                Move(hero.Cell.Y, hero.Cell.X - 1);
                break; 
            case ConsoleKey.RightArrow:
                Move(hero.Cell.Y, hero.Cell.X + 1);
                break;
            case ConsoleKey.UpArrow:
                Move(hero.Cell.Y - 1, hero.Cell.X);
                break; 
            case ConsoleKey.DownArrow:
                Move(hero.Cell.Y + 1, hero.Cell.X);
                break;
        }
    }

    private void Move(int y, int x)
    {
        var newPosition = map.GetCell(y, x);
        if (newPosition is not null) hero.Cell = newPosition;
    }

    private void DrawMap()
    {
           Console.Clear();

        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                IDrawable? drawable = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(drawable, nameof(drawable));

                foreach (var creature in map.Creatures)
                {
                    if(creature.Cell == drawable)
                    {
                        drawable = creature;
                        break;
                    }
                }

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.White;
    }

    private void Initialize()
    {
        //ToDo read from config
        map = new Map(width: 10, height: 10);
        var heroCell = map.GetCell(0, 0)!;
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);
    }
}