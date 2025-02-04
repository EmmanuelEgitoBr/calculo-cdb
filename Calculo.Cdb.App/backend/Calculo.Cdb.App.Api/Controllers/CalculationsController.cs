using Calculo.Cdb.App.Api.Models;
using Calculo.Cdb.App.Api.Services.Interfaces;
using System.Web.Http;

namespace Calculo.Cdb.App.Api.Controllers
{
    [Route("api/calculations")]
    public class CalculationsController : ApiController
    {
        private readonly ICalculationsService _calculationsService;

        public CalculationsController(ICalculationsService calculationsService)
        {
            _calculationsService = calculationsService;
        }

        [HttpPost]
        public ResponseModel CalculateCBD([FromBody] RequestModel model)
        {
            return _calculationsService.GetValues(model);
        }
    }
}
