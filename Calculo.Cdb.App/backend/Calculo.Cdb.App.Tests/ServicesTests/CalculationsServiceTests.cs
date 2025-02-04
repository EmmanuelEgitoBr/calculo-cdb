namespace Calculo.Cdb.App.Tests.ServicesTests;

public class CalculationsServiceTests
{
    [Fact]
    public void DeveRetornarErroCasoMesSejaMenorIgualZero
    {
        // Arrange
        var mockRepositorio = new Mock<IRepositorioCliente>();
        var servico = new ServicoCliente(mockRepositorio.Object);

    // Act & Assert
    Assert.Throws<ArgumentException>(() => servico.ObterClientePorId(0));
    }
}
