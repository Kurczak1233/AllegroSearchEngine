using Server.Controllers;
using AllLook.Database;
using Xunit;
using FakeItEasy;
using Moq;
using Server.Services;
using AllLook.Database.Interfaces;
using Server;
using Microsoft.Extensions.Options;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace AllLook.Tests
{
    public class AllLookControllerTests
    {

        [Fact]
        public async Task GetProducts_Returns_Correct_Number_Of_Products()
        {
            //Arange
            
            //Act

            //Assert

        }
    }
}