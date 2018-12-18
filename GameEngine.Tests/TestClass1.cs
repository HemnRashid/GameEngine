using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Collection("GameState collection")]
    public class TestClass1
    {
        private readonly ITestOutputHelper _output;
        private readonly GameStateFixture _gameStateFixture;

        public TestClass1(GameStateFixture gameStateFixture,ITestOutputHelper output )
        {
            _output = output;
            _gameStateFixture = gameStateFixture;
        }

        [Fact]        
        public void Test1()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test2()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }
    }
}
