using AllLook.Database.Interfaces;
using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLook.Database.Services
{
    public class DatabaseTokenService:IDatabaseTokenService
    {
        private readonly IMongoCollection<Token> _token;
        public DatabaseTokenService(IOptions<AllLookDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _token = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<Token>(options.Value.TokenCollectionName);

        }

        public Token GetToken() => _token.Find(token => true).Single();
        public void AddToken(Token token) => _token.InsertOne(token);
        public void DropToken() => _token.DeleteMany(x => true);
    }
}
