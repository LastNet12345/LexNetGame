using LexNetGame.ConsoleGame.GameWorld;
using LexNetGame.ConsoleGame.Services;
using Moq;

namespace LexNetGame.Test
{
    public class MapTests
    {
        [Fact]
        public void Map_Constructor_SetCorrectWidth()
        {
            const int expectedWidth = 10;
            const int expectedHeight = 10;

            var mockMapService = new Mock<IMapService>();
            mockMapService.Setup(x => x.GetMap()).Returns((expectedWidth, expectedHeight));

            var map = new Map(mockMapService.Object);
            
            Assert.Equal(expectedWidth, map.Width);
        }
    }
}