using System.Data;

internal class Game
{
    private Map map;
    private Hero hero;

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
        //DrawMap

        //GetCommand

        //Act

        //DrawMap

        //EnemyAction

        //DrawMap
        
    }

    private void Initialize()
    {
        map = new Map(width: 10,height: 10);
        hero = new Hero();
    }
}