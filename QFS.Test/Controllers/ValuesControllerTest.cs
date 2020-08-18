using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using QFS.Controllers;

namespace QFS.Test.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        private IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> {});
            IConfiguration config = builder.Build();
            return config;
        }


        [TestMethod]
        public void GetTest()
        {
            IConfiguration config = GetConfig();
            ValuesController valuesController = new ValuesController(null);

            var result = valuesController.Get();
            Assert.IsNotNull(result);
        }

        //put grocery item into storage location
        //also forgot to assign date


    }
}
