using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;

namespace GameEngine.Tests
{
    // Sharing Context Across Test Classes
    [Collection("GameState collection")]
    public class TestClass2 
    {
        private readonly ITestOutputHelper _output;
        private readonly GameStateFixture _gameStateFixture;

        public TestClass2(GameStateFixture gameStateFixture, ITestOutputHelper output)
        {
            _output = output;
            _gameStateFixture = gameStateFixture;
        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");
        }
    }
}
