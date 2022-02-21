using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreTest.Model;
using NetCoreTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QTwoController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccessEndpointService _accessEndPointService;

        public QTwoController(IConfiguration configuration,
            IAccessEndpointService accessEndPointTestService)
        {
            _configuration = configuration;
            _accessEndPointService = accessEndPointTestService;
        }

        
        [HttpGet]
        public async Task<ActionResult> GetResponseTwo()
        {
            try
            {
                string endPoint = _configuration.GetValue<string>("BasedUrl") + "backend/question/two";
                IEnumerable<ResponseTwo> responseTwoList = await _accessEndPointService.GetResponseTwo(endPoint);
                if (responseTwoList.Count() > 0)
                {
                    IEnumerable<ResponseTwo> fileteredList = responseTwoList.Where(p => (p.Description.Contains("Ergonomic")
                        || p.Title.Contains("Ergonomic")) && (p.Tags != null && p.Tags.Contains("Sports"))).OrderByDescending(o => o.Id)
                        .Take(3).ToList();

                    return Ok(fileteredList);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "failed accessing endpoint");
            }
        }


    }
}
