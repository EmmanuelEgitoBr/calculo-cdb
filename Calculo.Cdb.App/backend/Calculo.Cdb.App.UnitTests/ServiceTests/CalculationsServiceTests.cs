using Calculo.Cdb.App.Api.Models;
using Calculo.Cdb.App.Api.Services;
using Calculo.Cdb.App.Api.Services.Interfaces;
using Moq;

namespace Calculo.Cdb.App.UnitTests.ServiceTests
{
    public class CalculationsServiceTests
    {
        [Fact]
        public void MustReturnPositiveValueIfMonthAndInitialValuePositives()
        {
            // Arrange
            var mockService = new Mock<ICalculationsService>();
            var service = new CalculationsService();

            var inputValues = new RequestModel()
            {
                InitialValue = 10000,
                Months = 6
            };

            var result = service.GetValues(inputValues);

            // Act & Assert
            Assert.NotNull(result);
            Assert.True(result.GrossValue > 0);
            Assert.True(result.NetValue > 0);
        }

        [Fact]
        public void MustReturnZeroIfInitialValueIsNegative()
        {
            // Arrange
            var mockService = new Mock<ICalculationsService>();
            var service = new CalculationsService();

            var inputValues = new RequestModel()
            {
                InitialValue = -10000,
                Months = 8
            };

            var result = service.GetValues(inputValues);

            // Act & Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.GrossValue);
            Assert.Equal(0, result.NetValue);
        }

        [Fact]
        public void MustReturnZeroIfMonthlyValueIsNegative()
        {
            // Arrange
            var mockService = new Mock<ICalculationsService>();
            var service = new CalculationsService();

            var inputValues = new RequestModel()
            {
                InitialValue = 10000,
                Months = -5
            };

            var result = service.GetValues(inputValues);

            // Act & Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.GrossValue);
            Assert.Equal(0, result.NetValue);
        }

        [Fact]
        public void MustReturnZeroIfMonthlyValueIsZero()
        {
            // Arrange
            var mockService = new Mock<ICalculationsService>();
            var service = new CalculationsService();

            var inputValues = new RequestModel()
            {
                InitialValue = 10000,
                Months = 0
            };

            var result = service.GetValues(inputValues);

            // Act & Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.GrossValue);
            Assert.Equal(0, result.NetValue);
        }

        [Fact]
        public void MustReturnZeroIfInitialValueIsZero()
        {
            // Arrange
            var mockService = new Mock<ICalculationsService>();
            var service = new CalculationsService();

            var inputValues = new RequestModel()
            {
                InitialValue = 0,
                Months = 20
            };

            var result = service.GetValues(inputValues);

            // Act & Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.GrossValue);
            Assert.Equal(0, result.NetValue);
        }

        [Fact]
        public void MustReturnZeroIfMonthlyValueIsOne()
        {
            // Arrange
            var mockService = new Mock<ICalculationsService>();
            var service = new CalculationsService();

            var inputValues = new RequestModel()
            {
                InitialValue = 10000,
                Months = 0
            };

            var result = service.GetValues(inputValues);

            // Act & Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.GrossValue);
            Assert.Equal(0, result.NetValue);
        }
    }
}
