using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace KatanaSelfHosting.Tests
{
    [TestFixture]
    public class OwinTests
    {
        // To host this for Testing we need the package "microsoft.owin.testing"

        [Test]
        public async Task OwinReturns200OKOnNavigateToRoot()
        {
            using (var server = TestServer.Create<Startup>())
            {
                HttpResponseMessage response = await server.HttpClient.GetAsync("/");

                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

        [Test]
        public async Task OwinReturnsGreetingContentOnNavigateToRoot()
        {
            using (var server = TestServer.Create<Startup>())
            {
                HttpResponseMessage response = await server.HttpClient.GetAsync("/");

                var content = await response.Content.ReadAsStringAsync();

                Assert.That(content, Is.EqualTo("Hello from self-host!"));
            }
        }
    }
}
