namespace LexNetGame.ConsoleGame.Entities.Items
{
    internal interface IUsable
    {
        void Use(Creature creature);
        void Use(Creature creature, Action<Creature> action);
    }
}