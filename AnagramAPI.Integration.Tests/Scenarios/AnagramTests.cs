using AnagramAPI.Integration.Tests.Fixtures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnagramAPI.Integration.Tests.Scenarios
{
    public class AnagramTests
    {
        private readonly TestContext _testContext;
        private string firstWordId { get; set; }
        private string secondWordId { get; set; }
        private string checkResult { get; set; }

        public AnagramTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task PingReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task SaveNewAnagramOkResponse()
        {
            var firstResponse = await _testContext.Client.PostAsync("/v1/anagram", new StringContent("{\"thing\"}", Encoding.UTF8, "application/json"));
            firstResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            firstWordId = await firstResponse.Content.ReadAsStringAsync();

            var secondResponse = await _testContext.Client.PostAsync("/v1/anagram", new StringContent("{\"night\"}", Encoding.UTF8, "application/json"));
            secondResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            secondWordId = await secondResponse.Content.ReadAsStringAsync();
        }

        [Fact]
        public async Task SaveNewAnagramReturnedIds()
        {
            firstWordId.Should().NotBeNullOrEmpty();
            secondWordId.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task CheckAnagramOkResponseAsUrl()
        {
            var response = await _testContext.Client.GetAsync($"/v1/anagram/{firstWordId}/{secondWordId}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            checkResult = await response.Content.ReadAsStringAsync();
            checkResult.Should().StartWith("http://");
        }

        [Fact]
        public async Task CheckResultOkResponseAsJSON()
        {
            var response = await _testContext.Client.GetAsync(checkResult);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            checkResult = await response.Content.ReadAsStringAsync();
            response.Content.Headers.ContentType.MediaType.Should().Be("application/json");
        }

    }
}
