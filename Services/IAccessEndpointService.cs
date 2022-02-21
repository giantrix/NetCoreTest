using NetCoreTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTest.Services
{
    public interface IAccessEndpointService
    {
        Task<ResponseOne> GetResponseOne(string endPoint);
        Task<IEnumerable<ResponseTwo>> GetResponseTwo(string endPoint);
        Task<IEnumerable<ResponseThreeFlatten>> GetResponseThree(string endPoint);
    }
}
