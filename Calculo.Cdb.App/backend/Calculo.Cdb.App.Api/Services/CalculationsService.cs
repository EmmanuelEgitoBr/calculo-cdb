using Calculo.Cdb.App.Api.Models;
using Calculo.Cdb.App.Api.Services.Interfaces;
using Calculo.Cdb.App.Api.Utils;

namespace Calculo.Cdb.App.Api.Services
{
    public class CalculationsService : ICalculationsService
    {
        public ResponseModel GetValues(RequestModel model)
        {
            CdbParameters parameters = new CdbParameters(model);

            return CdbUtil.CalculateGrossAndNetValues(parameters);
        }
    }
}