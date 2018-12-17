using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]  // indicated its a test.
        public void BeInexperirencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();  // Assing

            // sut = system under test
            sut.Sleep();  // Act

            Assert.True(sut.IsNoob);
            //Assert.InRange(sut.Health, 101, 200);

        }

        [Fact]
        public void CalculateFullName()
        {
            // Assing
            PlayerCharacter sut = new PlayerCharacter();  


            // Acting
            sut.FirstName = "Adam";
            sut.LastName = "Rashid";



            // Asserting
            Assert.Equal("Adam Rashid", sut.FullName);
           

        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            // Assing
            PlayerCharacter sut = new PlayerCharacter();


            // Acting
            sut.FirstName = "Adam";
            sut.LastName = "RASHID";



            // Asserting
            Assert.Equal("Adam Rashid", sut.FullName,ignoreCase :  true);
             

        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            // Assing
            PlayerCharacter sut = new PlayerCharacter();


            // Acting
            sut.FirstName = "Adam";
            sut.LastName = "Rashid";



            // Asserting
            Assert.EndsWith("Rashid", sut.FullName);


        }


        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Assing
            PlayerCharacter sut = new PlayerCharacter();

            // Acting
            sut.FirstName = "Adam";
            sut.LastName = "Rashid";

            // Asserting
            Assert.Contains("Ad", sut.FullName);
        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {

            // Assing
            PlayerCharacter sut = new PlayerCharacter();
            var regx = "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]";

            // Acting
            sut.FirstName = "Adam";
            sut.LastName = "Rashid";

            // Asserting
            Assert.Matches(regx, sut.FullName);
        }

         [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep(); // Expect increase between 1 to 100 inclusive

            //Assert.True(sut.Health >= 101 && sut.Health <= 200);  // Alternativ 1.
            Assert.InRange(sut.Health, 101, 200); // Alternativ 2. This is rekommended because it gives more information.
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
           
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            //Checks if there is a null or empty sting in the list of the weapons
            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

    }
}
