using JobApprovalWeb;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobApprovalWebTests
{
    public class JobApprovalControllerTests
    {
        private TestServer _server;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
            .UseStartup<Startup>()
            .UseEnvironment("Development"));
            _client = _server.CreateClient();
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client.Dispose();
            _server.Dispose();
        }

        private StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");

        //"{\"tyres\":\"2\",\"brake_discs\":\"1\",\"brake_pads\":\"1\",\"oil\":\"1\",\"exhaust\":\"1\"}"

        [Test]
        public async Task ItRespondsOk()
        {
            var request = new
            {
                Url = "JobApproval/submit",
                Body = new
                {
                    TotalHours = 2,
                    TotalPrice = 1,
                    RequestedItems = "{\"tyres\":\"2\"}"
                }
            };

            HttpResponseMessage response = await _client.PostAsync(request.Url, GetStringContent(request.Body));

            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task ItRespondsWithTheJobSheet()
        {
            var request = new
            {
                Url = "JobApproval/submit",
                Body = new
                {
                    TotalHours = 2,
                    TotalPrice = 1,
                    RequestedItems = "{\"tyres\":\"2\"}"
                }
            };

            var content = GetStringContent(request.Body);
            HttpResponseMessage response = await _client.PostAsync(request.Url, content);

            response.EnsureSuccessStatusCode();
            var expected = new Dictionary<string, object>();
            expected.Add("TotalHours", 2);
            expected.Add("TotalPrice", 1);
            expected.Add("RequestedItems", request.Body.RequestedItems);
            Assert.AreEqual(JsonConvert.SerializeObject(expected), await content.ReadAsStringAsync());
        }
    }
}