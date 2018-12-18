using Xunit;

namespace GameEngine.Tests
{
    [Trait("Category","¨Boss")]
    public class BossEnemyShould
    {
        [Fact]
        
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.SpecialAttackPower, 3);
        }
    }
}
