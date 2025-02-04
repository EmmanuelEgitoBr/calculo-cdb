using System.Collections.Generic;
using System.Web.Http;

namespace Calculo.Cdb.App.Api.Controllers
{
    [Route("api/calculations")]
    public class CalculationsController : ApiController
    {
        // GET: api/Calculations
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Calculations/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Calculations
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Calculations/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Calculations/5
        public void Delete(int id)
        {
        }
    }
}
