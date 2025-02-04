using Calculo.Cdb.App.Api.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Calculo.Cdb.App.Tests.Controllers
{
    [TestClass]
    public class CalculationsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Organizar
            CalculationsController controller = new CalculationsController();

            // Agir
            IEnumerable<string> result = controller.Get();

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Organizar
            CalculationsController controller = new CalculationsController();

            // Agir
            string result = controller.Get(5);

            // Declarar
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Organizar
            CalculationsController controller = new CalculationsController();

            // Agir
            controller.Post("value");

            // Declarar
        }

        [TestMethod]
        public void Put()
        {
            // Organizar
            CalculationsController controller = new CalculationsController();

            // Agir
            controller.Put(5, "value");

            // Declarar
        }

        [TestMethod]
        public void Delete()
        {
            // Organizar
            CalculationsController controller = new CalculationsController();

            // Agir
            controller.Delete(5);

            // Declarar
        }
    }
}
