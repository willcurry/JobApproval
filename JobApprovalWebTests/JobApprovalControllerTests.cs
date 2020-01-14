using JobApprovalWeb;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using JobApproval;

namespace JobApprovalWebTests
{
    public class JobApprovalControllerTests
    {
        private TestServer _server;
        private HttpClient _client;
        private ReferenceData _referenceData;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
            .UseStartup<Startup>()
            .UseEnvironment("Development"));
            _client = _server.CreateClient();
            _referenceData = new ReferenceData();
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client.Dispose();
            _server.Dispose();
        }

        private StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");

        //"{\"tyre\":\"2\",\"brake_discs\":\"1\",\"brake_pads\":\"1\",\"oil\":\"1\",\"exhaust\":\"1\"}"

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
                    RequestedItems = "{\"tyre\":\"2\"}"
                }
            };

            HttpResponseMessage response = await _client.PostAsync(request.Url, GetStringContent(request.Body));

            response.EnsureSuccessStatusCode();
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test]
        public async Task ItRespondsWithApproveOutcome()
        {
            var request = new
            {
                Url = "JobApproval/submit",
                Body = new
                {
                    TotalHours = _referenceData.GetUnitMinutes("tyre") * 2,
                    TotalPrice = _referenceData.GetUnitCost("tyre") * 2,
                    RequestedItems = "{\"tyre\":\"2\"}"
                }
            };

            var content = GetStringContent(request.Body);
            HttpResponseMessage response = await _client.PostAsync(request.Url, content);

            response.EnsureSuccessStatusCode();
            Assert.AreEqual("Approve", await response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task ItRespondsWithDeclineOutcomeWhenTooManyTyres()
        {
            var request = new
            {
                Url = "JobApproval/submit",
                Body = new
                {
                    TotalHours = _referenceData.GetUnitMinutes("tyre") * 2,
                    TotalPrice = _referenceData.GetUnitCost("tyre") * 2,
                    RequestedItems = "{\"tyre\":\"5\"}"
                }
            };

            var content = GetStringContent(request.Body);
            HttpResponseMessage response = await _client.PostAsync(request.Url, content);

            response.EnsureSuccessStatusCode();
            Assert.AreEqual("Decline", await response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task ItRespondsWithDeclineOutcomeWhenItemsAreNotRecognised()
        {
            var request = new
            {
                Url = "JobApproval/submit",
                Body = new
                {
                    TotalHours = 1,
                    TotalPrice = 1,
                    RequestedItems = "{\"boat\":\"1\"}"
                }
            };

            var content = GetStringContent(request.Body);
            HttpResponseMessage response = await _client.PostAsync(request.Url, content);

            response.EnsureSuccessStatusCode();
            Assert.AreEqual("Decline", await response.Content.ReadAsStringAsync());
        }
    }
}