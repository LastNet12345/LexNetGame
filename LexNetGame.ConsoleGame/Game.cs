
//public delegate void SomeMethod();
using LexNetGame.ConsoleGame.Entities.Items;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

internal class Game
{
    private IMap map;
    private Hero hero = null!;
    private bool gameInProgress;
    private readonly IUI ui;
    private readonly IConfiguration config;

    public Game(IUI ui, IConfiguration config)
    {
        this.ui = ui;
        this.config = config;

        map = new Map(config);
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;

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
        var keyPressed = ui.GetKey();

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
                    { ConsoleKey.I, Inventory},
                    { ConsoleKey.D, Drop}
                };

        if (actionMeny.ContainsKey(keyPressed))
            actionMeny[keyPressed]?.Invoke();

    }

    private void Drop()
    {
        var item = hero.BackPack.FirstOrDefault();

        if (item != null && hero.BackPack.Remove(item))
        {
            hero.Cell.Items.Add(item);
            ui.AddMessage($"Hero dropped the {item}");
        }
        else
            ui.AddMessage("Backpack is empty");
    }

    private void Inventory()
    {
        ui.AddMessage(hero.BackPack.Count > 0 ? "Inventory:" : "No items");

        for (int i = 0; i < hero.BackPack.Count; i++)
        {
            ui.AddMessage($"{i + 1}: {hero.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (hero.BackPack.IsFull)
        {
            ui.AddMessage("Backpack is full");
            return;
        }

        var items = hero.Cell.Items;
        var item = items.FirstOrDefault();
        if (item is null) return;

        if(item is IUsable usable)
        {
           // usable.Use(hero);
            usable.Use(hero, c => c.Health += 25);
            hero.Cell.Items.Remove(item);
            ui.AddMessage($"Hero use the {item}");
            return;
        }

        if (hero.BackPack.Add(item))
        {
            ui.AddMessage($"Hero pick up {item}");
            items.Remove(item);
        }

    }

    private void Move(Position movement)
    {
        Position newPosition = hero.Cell.Position + movement;
        Cell? newCell = map.GetCell(newPosition);

        Creature? opponent = map.CreatureAt(newCell);
        if(opponent is not null)
        {
            hero.Attack(opponent);
            opponent.Attack(hero);
        }

        gameInProgress = !hero.IsDead;

        if (newCell is not null)
        {
            hero.Cell = newCell;
            if (newCell.Items.Any())
                ui.AddMessage($"You see {string.Join(", ", newCell.Items)}");
        }
    }

    private void DrawMap()
    {
        ui.Clear();
        ui.Draw(map);
        ui.PrintStats($"Health {hero.Health}, Enemys: {map.Creatures.Where(c => !c.IsDead).Count()  - 1}  ");
        ui.PrintLog();
    }

    private void Initialize()
    {
        //var width = config.GetMapSizeFor("x");
        //var height = config.GetMapSizeFor("y");

        //map = new Map(width, height);
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


        //map.GetCell(1, 1).Items.Add(Item.Coin());
        //map.GetCell(1, 1).Items.Add(Item.Coin());
        //map.GetCell(1, 1).Items.Add(Item.Stone());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Potion.HealthPotion());
        RCell().Items.Add(Potion.HealthPotion());
        RCell().Items.Add(Potion.HealthPotion());

        // map.Creatures.ForEach(c => c.AddToLog = Console.WriteLine);
        map.Creatures.ForEach(c =>
        {
            c.AddToLog = ui.AddMessage;
           // c.AddToLog += (m) => Debug.WriteLine(m);
        });

        Cell RCell()
        {
            var width = r.Next(0, map.Width);
            var height = r.Next(0, map.Height);

            var cell = map.GetCell(height, width);

            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            return cell;
        }

    }

}