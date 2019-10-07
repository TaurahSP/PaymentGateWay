using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace PaymentGateway.Test.IntegrationTest
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public HttpClient TestClients { get; }

        public IntegrationTest()
        {
            var appfactory = new WebApplicationFactory<Startup>();

            TestClient = appfactory.CreateClient();

        }

    }
}
