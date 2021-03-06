using NetCoreTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NetCoreTest.Services
{
    public class AccessEndPointService : IAccessEndpointService
    {
        private readonly HttpClient _httpClient;

        public AccessEndPointService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseOne> GetResponseOne(string endPoint)
        {
            return await _httpClient.GetFromJsonAsync<ResponseOne>(endPoint);
        }

        public async Task<IEnumerable<ResponseTwo>> GetResponseTwo(string endPoint)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ResponseTwo>>(endPoint);
        }

        public async Task<IEnumerable<ResponseThreeFlatten>> GetResponseThree(string endPoint)
        {
            IEnumerable<ResponseThree> responseThrees =
                await _httpClient.GetFromJsonAsync<IEnumerable<ResponseThree>>(endPoint);

            List<ResponseThreeFlatten> responseThreeFlattens = new List<ResponseThreeFlatten>();
            if (responseThrees.ToList().Count > 0)
            {
                foreach (ResponseThree responseThree in responseThrees.ToList())
                {
                    if (responseThree.Items!=null && responseThree.Items.Any())
                    {
                        foreach (Item item in responseThree.Items)
                        {
                            ResponseThreeFlatten responseThreeFlatten = new()
                            {
                                Id = responseThree.Id,
                                Category = responseThree.Category,
                                Title = item.Title,
                                Description = item.Description,
                                Footer = item.Footer,
                                CreatedAt = responseThree.CreatedAt
                            };

                            responseThreeFlattens.Add(responseThreeFlatten);
                        }
                    }
                }
            }

            return responseThreeFlattens.AsEnumerable();
        }
    }
}
