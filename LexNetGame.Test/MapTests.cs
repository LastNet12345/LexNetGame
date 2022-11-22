using Castle.Components.DictionaryAdapter.Xml;
using LexNetGame.ConsoleGame.Extensions;
using LexNetGame.ConsoleGame.GameWorld;
using LexNetGame.ConsoleGame.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace LexNetGame.Test
{
    public class MapTests
    {
        //[Fact]
        //public void Map_Constructor_SetCorrectWidth()
        //{
        //    const int expectedWidth = 10;
        //    const int expectedHeight = 10;

        //    var mockMapService = new Mock<IMapService>();
        //    mockMapService.Setup(x => x.GetMap()).Returns((expectedWidth, expectedHeight));

        //    var map = new Map(mockMapService.Object);
            
        //    Assert.Equal(expectedWidth, map.Width);
        //} 
        

        //With Class and InterFace
        //[Fact]
        //public void Map_Constructor_SetCorrectWidth()
        //{
        //    const int expected = 10;

        //    var mockConfig = new Mock<IConfiguration>();
        //    var getMapSizeMock = new Mock<IGetMapSize>();

        //    getMapSizeMock.Setup(m => m.GetMapSizeFor(mockConfig.Object, It.IsAny<string>())).Returns(expected);
        //    TestExtensions.Implementation = getMapSizeMock.Object;

        //    var map = new Map(mockConfig.Object);

        //    Assert.Equal(expected, map.Width);
        //}
     
        //With Func
       [Fact]
        public void Map_Constructor_SetCorrectWidth()
        {
            const int expected = 10;

            var mockConfig = new Mock<IConfiguration>();

            ExtensionTestFunc.Implementation = (c, v) => expected;
          
            var map = new Map(mockConfig.Object);

            Assert.Equal(expected, map.Width);
        }
    }
}