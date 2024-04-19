using rpgAPI.Model;
using rpgAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgAPITest
{
    public class CharacterServiceTest
    {
        [Fact]
        public void GetAllCharacterGivenValidRequestReturnsResult()
        {
            // Arrange
            var cs = new CharacterService();

            // Act
            var result = cs.GetAllCharacter();

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public void AddCharacterGivenValidCharacterReturnsUpdatedListWithAddedCharacter()
        {
            // Arrange
            var cs = new CharacterService();
            var newCharacter = new Character { Name = "Frodo", Id = 2 };

            // Act
            var result = cs.AddCharacter(newCharacter);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Contains(newCharacter, result.Data);
        }

        [Fact]
        public void GetCharacterByIdGivenExistingIdReturnsCharacter()
        {
            // Arrange
            var cs = new CharacterService();
            int existingId = 1;

            // Act
            var result = cs.GetCharacterById(existingId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal(existingId, result.Data.Id);
        }

        [Fact]
        public void GetCharacterByIdGivenNonExistingIdReturnsFailure()
        {
            // Arrange
            var cs = new CharacterService();
            int nonExistingId = -1;

            // Act
            var result = cs.GetCharacterById(nonExistingId);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Null(result.Data);
            Assert.Equal("Id Doesn't Exist", result.Message);
        }

        [Fact]
        public void UpdateCharacterGivenExistingCharacterReturnsUpdatedListWithModifiedCharacter()
        {
            // Arrange
            var cs = new CharacterService();
            var updatedCharacter = new Character { Name = "Gandalf", Id = 1 };

            // Act
            var result = cs.UpdateCharacter(updatedCharacter);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Contains(updatedCharacter, result.Data);
        }

        [Fact]
        public void DeleteCharacterGivenExistingIdReturnsUpdatedListWithoutDeletedCharacter()
        {
            // Arrange
            var cs = new CharacterService();
            int existingId = 1;

            // Act
            var result = cs.DeleteCharacter(existingId);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.DoesNotContain(result.Data, c => c.Id == existingId);
        }
    }
}

