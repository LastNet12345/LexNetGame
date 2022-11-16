
//public delegate void SomeMethod();
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

        switch (keyPressed)
        {
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
                //case ConsoleKey.P:
                //     PickUp();
                //    break;
                //case ConsoleKey.I:
                //     Inventory();
                //    break;
        }

        var actionMeny = new Dictionary<ConsoleKey, Action>
                {
                    { ConsoleKey.P, PickUp },
                    { ConsoleKey.I, Inventory}
                };

        if (actionMeny.ContainsKey(keyPressed))
            actionMeny[keyPressed]?.Invoke();

    }

    private void Inventory()
    {
        ConsoleUI.AddMessage(hero.BackPack.Count > 0 ? "Inventory:" : "No items");

        for (int i = 0; i < hero.BackPack.Count; i++)
        {
            ConsoleUI.AddMessage($"{i + 1}: {hero.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            ConsoleUI.AddMessage("Backpack is full");
            return;
        }

        var items = hero.Cell.Items;
        var item = items.FirstOrDefault();
        if (item is null) return;

        if (hero.BackPack.Add(item))
        {
            ConsoleUI.AddMessage($"Hero pick up {item}");
            items.Remove(item);
        }

    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);
        if (newCell is not null) hero.Cell = newCell;
    }

    private void DrawMap()
    {
        ConsoleUI.Clear();
        ConsoleUI.Draw(map);
        ConsoleUI.PrintStats($"Health {hero.Health}, Enemys: {map.Creatures.Count -1}");
        ConsoleUI.PrintLog();
    }

    private void Initialize()
    {
        //ToDo read from config
        map = new Map(width: 10, height: 10);
        var r = new Random();

        var heroCell = map.GetCell(0, 0);
        ArgumentNullException.ThrowIfNull(heroCell, nameof(heroCell));
        hero = new Hero(heroCell);
        map.Creatures.Add(hero);

        map.Place(new Orc(RCell(), 120));
        map.Place(new Orc(RCell(), 120));
        map.Place(new Troll(RCell(), 160));
        map.Place(new Troll(RCell(), 160));
        map.Place(new Goblin(RCell(), 200));
        map.Place(new Goblin(RCell(), 200));

        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Stone());

        Cell RCell()
        {
            var width = r.Next(0, map.Width);
            var height = r.Next(0, map.Height);

            var cell = map.GetCell(width, height);

            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            return cell;
        }

    }

}