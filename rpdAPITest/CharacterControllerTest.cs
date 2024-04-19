using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using rpgAPI.Controller;
using rpgAPI.Model;
using rpgAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace rpgAPITest
{
    public class CharacterControllerTest
    {
        public Mock<ICharacterService> mockService = new Mock<ICharacterService>();
        public Fixture fixture = new Fixture();

        [Fact]
        public void GetAllCharacterGivenValidRequestReturnsOk()
        {
            // Arrange
            var serviceResponse = fixture.Create<ServiceResponse<List<Character>>>();
            mockService.Setup(x => x.GetAllCharacter()).Returns(serviceResponse);
            var charController = new CharacterController(mockService.Object);

            // Act
            var result = charController.GetCharacter();
            var okResult = (ObjectResult)result.Result;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void GetIdGivenValidIdReturnsOk()
        {
            // Arrange
            var id = 1;
            var serviceResponse = fixture.Create<ServiceResponse<Character>>();
            mockService.Setup(x => x.GetCharacterById(id)).Returns(serviceResponse);
            var charController = new CharacterController(mockService.Object);

            // Act
            var result = charController.GetId(id);
            var okResult = (ObjectResult)result.Result;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void PostCharacterGivenValidCharacterReturnsOk()
        {
            // Arrange
            var newCharacter = fixture.Create<Character>();
            var serviceResponse = fixture.Create<ServiceResponse<List<Character>>>();
            mockService.Setup(x => x.AddCharacter(newCharacter)).Returns(serviceResponse);
            var charController = new CharacterController(mockService.Object);

            // Act
            var result = charController.PostCharacter(newCharacter);
            var okResult = (ObjectResult)result.Result;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void UpdateCharacterGivenValidCharacterReturnsOk()
        {
            // Arrange
            var character = fixture.Create<Character>();
            var serviceResponse = fixture.Create<ServiceResponse<List<Character>>>();
            mockService.Setup(x => x.UpdateCharacter(character)).Returns(serviceResponse);
            var charController = new CharacterController(mockService.Object);

            // Act
            var result = charController.UpdateCharacter(character);
            var okResult = (ObjectResult)result.Result;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void DeleteCharacterGivenValidIdReturnsOk()
        {
            // Arrange
            var id = 1;
            var serviceResponse = fixture.Create<ServiceResponse<List<Character>>>();
            mockService.Setup(x => x.DeleteCharacter(id)).Returns(serviceResponse);
            var charController = new CharacterController(mockService.Object);

            // Act
            var result = charController.DeleteCharacter(id);
            var okResult = (ObjectResult)result.Result;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
    }
}
