using Models;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface ISearchCode
    {
        public  Task<DeviceFlowAuth> GetCode(string clientId, string clientSecret);
    }
}