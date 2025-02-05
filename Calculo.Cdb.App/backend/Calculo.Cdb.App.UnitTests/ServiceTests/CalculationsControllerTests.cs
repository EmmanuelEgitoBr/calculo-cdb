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

        //[Fact]
        //public void Post_DeveRetornarNotFound_QuandoProdutoNaoExiste()
        //{
        //    // Arrange
        //    _calculationsServiceMock.Setup(s => s.ObterProduto(It.IsAny<int>())).Returns((Produto)null);
        //
        //    // Act
        //    var result = _controller.Get(99);
        //
        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}
    }
}
