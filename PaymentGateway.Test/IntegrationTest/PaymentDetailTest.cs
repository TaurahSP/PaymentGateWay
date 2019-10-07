using FluentAssertions;
using PaymentGateway.ApiDto;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Test.IntegrationTest
{


    public class PaymentDetailTest : IntegrationTest
    {


        [Fact]
        public async Task GetPaymentById_WithID_ReturnsResponse()
        {
            //Arrange

            //Act
            var response = await TestClient.GetAsync("/api/paymentdetail/4f218664-22a3-4ea6-f1eb-08d748f94977");

            //Assert

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await response.Content.ReadAsAsync<PaymentDetailsdto>();
        }



        
    }
}