using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLook.Database.Interfaces
{
    public interface IDatabaseDeviceFlowAuthorization
    {
        public  string GetDeviceCode();
        public void AddDeviceFlowAuth(DeviceFlowAuth auth);
        public void DropDeviceFlowAuth() ;


    }
}
