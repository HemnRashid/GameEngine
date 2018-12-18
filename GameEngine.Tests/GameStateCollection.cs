
using Xunit;

namespace GameEngine.Tests
{
    // Sharing Context Across Test Classes
    [CollectionDefinition("GameState collection")]
    public class GameStateCollection:ICollectionFixture<GameStateFixture>
    {
    }
}
