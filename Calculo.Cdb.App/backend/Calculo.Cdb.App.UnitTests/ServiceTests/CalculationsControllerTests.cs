using Calculo.Cdb.App.Api.Controllers;
using Calculo.Cdb.App.Api.Models;
using Calculo.Cdb.App.Api.Services.Interfaces;
using Moq;

namespace Calculo.Cdb.App.UnitTests.ServiceTests
{
    public class CalculationsControllerTests
    {
        private readonly CalculationsController _controller;
        private readonly Mock<ICalculationsService> _calculationsServiceMock;

        public CalculationsControllerTests()
        {
            _calculationsServiceMock = new Mock<ICalculationsService>();
            _controller = new CalculationsController(_calculationsServiceMock.Object);
        }

        [Fact]
        public void Post_MustReturnNonZeroValues_WhenInputValuesAreValid()
        {
            // Arrange
            var inputValues = new RequestModel { InitialValue = 1000, Months = 5 };
            var resultValues = new ResponseModel(1049.55, 1038.4);

            _calculationsServiceMock.Setup(s => s.GetValues(inputValues)).Returns(resultValues);

            // Act

            var result = _controller.CalculateCBD(inputValues);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultValues, result);
        }

        [Fact]
        public void Post_MustReturnZeroValues_WhenInitialValueIsZero()
        {
            // Arrange
            var requestValues = new RequestModel { InitialValue = 0, Months = 10 };
            var resultValues = new ResponseModel(0, 0);
            _calculationsServiceMock.Setup(s =>
                s.GetValues(requestValues)).Returns(resultValues);

            // Act
            var result = _controller.CalculateCBD(requestValues);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultValues, result);
        }

        [Fact]
        public void Post_MustReturnZeroValues_WhenInitialValueIsNegative()
        {
            // Arrange
            var requestValues = new RequestModel { InitialValue = -50000, Months = 10 };
            var resultValues = new ResponseModel(0, 0);
            _calculationsServiceMock.Setup(s =>
                s.GetValues(requestValues)).Returns(resultValues);

            // Act
            var result = _controller.CalculateCBD(requestValues);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultValues, result);
        }

        [Fact]
        public void Post_MustReturnZeroValues_WhenMonthIsOne()
        {
            // Arrange
            var requestValues = new RequestModel { InitialValue = 1000, Months = 1 };
            var resultValues = new ResponseModel(0, 0);
            _calculationsServiceMock.Setup(s =>
                s.GetValues(requestValues)).Returns(resultValues);

            // Act
            var result = _controller.CalculateCBD(requestValues);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultValues, result);
        }

        [Fact]
        public void Post_MustReturnZeroValues_WhenMonthIsZero()
        {
            // Arrange
            var requestValues = new RequestModel { InitialValue = 1000, Months = 0 };
            var resultValues = new ResponseModel(0, 0);
            _calculationsServiceMock.Setup(s =>
                s.GetValues(requestValues)).Returns(resultValues);

            // Act
            var result = _controller.CalculateCBD(requestValues);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultValues, result);
        }

        [Fact]
        public void Post_MustReturnZeroValues_WhenMonthIsNegative()
        {
            // Arrange
            var requestValues = new RequestModel { InitialValue = 1000, Months = -8 };
            var resultValues = new ResponseModel(0, 0);
            _calculationsServiceMock.Setup(s =>
                s.GetValues(requestValues)).Returns(resultValues);

            // Act
            var result = _controller.CalculateCBD(requestValues);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultValues, result);
        }
    }
}
