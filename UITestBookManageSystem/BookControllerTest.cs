using System;
using System.Net;
using System.Net.Http;
using BookManageSystem;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using Xunit.Abstractions;

namespace UITestBookManageSystem
{
    public class BookControllerTest
    {
        
        public BookControllerTest(ITestOutputHelper outputHelper)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
            Client = server.CreateClient();            
        }

        public HttpClient Client { get; }
        
        [Fact]
        public async void should_return_ok_when_get_all_books()
        {

            // Act
            var response = await Client.GetAsync($"/api/Books/getAllBooks");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}