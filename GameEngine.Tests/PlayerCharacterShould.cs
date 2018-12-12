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

    }
}
