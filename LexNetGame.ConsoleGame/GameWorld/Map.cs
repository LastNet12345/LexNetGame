﻿
using LexNetGame.ConsoleGame.Entities.Creatures;

public class Map
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }
    public List<Creature> Creatures { get; } = new List<Creature>();

    public Map(int width, int height)
    {
        Width = width;
        Height = height;

        cells = new Cell[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                cells[y, x] = new Cell(new Position(y, x));
            }
        }

    }

    [return: MaybeNull]
    internal Cell GetCell(int y, int x)
    {
        return (x < 0 || x >= Width || y < 0 || y >= Height) ? null : cells[y, x];
    }

    internal Cell? GetCell(Position newPosition)
    {
        return GetCell(newPosition.Y, newPosition.X);
    }

    internal void Place(Creature creature)
    {
        // if (Creatures.Where(c => c.Cell == creature.Cell).Count() >= 1) return;
        if (Creatures.FirstOrDefault(c => c.Cell == creature.Cell) == null)
        {
            Creatures.Add(creature);
        }
    }

    internal Creature? CreatureAt(Cell? cell)
    {
        return Creatures.FirstOrDefault(creature => creature.Cell == cell);
    }
}