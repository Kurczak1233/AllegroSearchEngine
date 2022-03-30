using AllLook.Database;
using AllLook.Database.Interfaces;
using AllLook.Database.Services;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllLook.Tests
{
    public class DatabaseTokenTest
    {
        private IOptions<AllLookDatabaseSettings> _options;
    

        public DatabaseTokenTest()
        {
        
            AllLookDatabaseSettings sampleOptions = new AllLookDatabaseSettings() { ConnectionString = "mongodb+srv://darek:darek123@alllookdatabase.em2k8.mongodb.net/AllLook?retryWrites=true&w=majority", DatabaseName= "AllLook", TokenCollectionName= "Token" };
            _options = Microsoft.Extensions.Options.Options.Create(sampleOptions);
           

        }

        [Fact]
        public void Checking_Exeption_Message_Corretness()
        {
            //Arrange
            DatabaseTokenService service = new DatabaseTokenService(_options);
            string expectedMessage = "Błąd przesłania tokenu do bazy";
            //Act
            var ex = Assert.Throws<Exception>(() => service.AddToken(null));

            //Assert
            Assert.Matches(expectedMessage, ex.Message);
           
          
        }

        [Fact]
        public void There_is_token_in_database()
        {
            //Arrange
            DatabaseTokenService service = new DatabaseTokenService(_options);

            //Act
            var token = service.GetToken();

            //Assert
            Assert.NotNull(token);


        }


        //[Fact]
        //public void Is_DropToken_Working()
        //{
        //    //Arrange
        //    DatabaseTokenService service = new DatabaseTokenService(_options);

        //    //Act
        //    service.DropToken();
        //  var token =   service.GetToken();
        //    //Assert
        //    Assert.Null(token);


        //}





    }

}
