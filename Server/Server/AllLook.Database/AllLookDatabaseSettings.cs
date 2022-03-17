using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLook.Database
{
    public class AllLookDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductsCollectionName { get; set; }
        public string TokenCollectionName { get; set; }
        public string DeviceFlowAuthorizationCollectionName { get; set; }
    }
}
