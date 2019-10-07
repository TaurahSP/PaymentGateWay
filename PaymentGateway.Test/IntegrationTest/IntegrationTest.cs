using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PaymentGateway.ApiDto;

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
