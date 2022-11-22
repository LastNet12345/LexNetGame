namespace LexNetGame.ConsoleGame.Services
{
    public interface IMapService
    {
        (int width, int height) GetMap();
    }
}