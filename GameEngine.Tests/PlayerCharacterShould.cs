using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould: IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;


        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating new PlayerCharacter");
            // create only one instanse of this obj for all the tests!.
            _sut = new PlayerCharacter();
            
        }

        [Fact]  // indicated its a test.
        public void BeInexperirencedWhenNew()
        {
            // PlayerCharacter _sut = new PlayerCharacter();       // Assing

            // _sut = system under test
            _sut.Sleep();  // Act

            Assert.True(_sut.IsNoob);
            //Assert.InRange(_sut.Health, 101, 200);

        }

        [Fact]
        public void CalculateFullName()
        {
            // Assing
            // PlayerCharacter _sut = new PlayerCharacter();       


            // Acting
            _sut.FirstName = "Adam";
            _sut.LastName = "Rashid";



            // Asserting
            Assert.Equal("Adam Rashid", _sut.FullName);


        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            // Assing
            // PlayerCharacter _sut = new PlayerCharacter();     


            // Acting
            _sut.FirstName = "Adam";
            _sut.LastName = "RASHID";



            // Asserting
            Assert.Equal("Adam Rashid", _sut.FullName, ignoreCase: true);


        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            // Assing
            // PlayerCharacter _sut = new PlayerCharacter();     


            // Acting
            _sut.FirstName = "Adam";
            _sut.LastName = "Rashid";



            // Asserting
            Assert.EndsWith("Rashid", _sut.FullName);


        }


        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            // Assing
            // PlayerCharacter _sut = new PlayerCharacter();     

            // Acting
            _sut.FirstName = "Adam";
            _sut.LastName = "Rashid";

            // Asserting
            Assert.Contains("Ad", _sut.FullName);
        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {

            // Assing
            // PlayerCharacter _sut = new PlayerCharacter();     
            var regx = "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]";

            // Acting
            _sut.FirstName = "Adam";
            _sut.LastName = "Rashid";

            // Asserting
            Assert.Matches(regx, _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            _sut.Sleep(); // Expect increase between 1 to 100 inclusive

            //Assert.True(_sut.Health >= 101 && _sut.Health <= 200);  // Alternativ 1.
            Assert.InRange(_sut.Health, 101, 200); // Alternativ 2. This is rekommended because it gives more information.
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));

        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            //Checks if there is a null or empty sting in the list of the weapons
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
            // PlayerCharacter _sut = new PlayerCharacter();     

            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing PlayerCharachter { _sut.FullName}");
            //_sut.Dispose();
        }
    }
}
