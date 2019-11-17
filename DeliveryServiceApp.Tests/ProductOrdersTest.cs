using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeliveryServiceApp.Tests
{
    public  class ProductOrdersTest: IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ProductOrdersTest(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestOrderPriceAsync()
        {
            // Arrange
            var request = "api/Orders/order-cost?customerId=123&distence=12";

            Console.WriteLine("Client Base Address:"+Client.BaseAddress);
            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}
