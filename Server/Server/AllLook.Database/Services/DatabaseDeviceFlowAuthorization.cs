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
    public class DatabaseDeviceFlowAuthorization:IDatabaseDeviceFlowAuthorization
    {
        private readonly IMongoCollection<DeviceFlowAuth> _DeviceFlow;
        public DatabaseDeviceFlowAuthorization(IOptions<AllLookDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _DeviceFlow = mongoClient.GetDatabase(options.Value.DatabaseName)
                .GetCollection<DeviceFlowAuth>(options.Value.DeviceFlowAuthorizationCollectionName);

        }

        public string GetDeviceCode() =>  _DeviceFlow.Find(x => true).Single().device_code;
        public void AddDeviceFlowAuth(DeviceFlowAuth auth) =>  _DeviceFlow.InsertOne(auth);
        public void DropDeviceFlowAuth() => _DeviceFlow.DeleteMany(x=>true);

    }
}
