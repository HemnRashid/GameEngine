using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {


        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture  ,ITestOutputHelper output)
        {

            _output           = output;
            _gameStateFixture = gameStateFixture;
                
        }


        [Fact]
        public void DamageAllPlayersWhenErathquake()
        {

            _output.WriteLine($"Gamestate ID={_gameStateFixture.State.Id}");

            

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEartquake = player1.Health - GameState.EarthquakeDamage;

            _gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEartquake, player1.Health);
            Assert.Equal(expectedHealthAfterEartquake, player2.Health);

        }

        [Fact]
        public void Reset()
        {

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);


            _gameStateFixture.State.Reset();

            Assert.Empty(_gameStateFixture.State.Players);

        }

    }
}
