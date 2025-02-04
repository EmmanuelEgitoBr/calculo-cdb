using Calculo.Cdb.App.Api.Models;

namespace Calculo.Cdb.App.Api.Services.Interfaces
{
    public interface ICalculationsService
    {
        ResponseModel GetValues(RequestModel model);
    }
}
