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
    public class QThreeController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccessEndpointService _accessEndPointService;

        public QThreeController(IConfiguration configuration,
            IAccessEndpointService accessEndPointTestService)
        {
            _configuration = configuration;
            _accessEndPointService = accessEndPointTestService;
        }


        [HttpGet]
        public async Task<ActionResult> GetResponseOne()
        {
            try
            {
                string endPoint = _configuration.GetValue<string>("BasedUrl") + "backend/question/three";
                IEnumerable<ResponseThreeFlatten> responseThreeFlattenList =
                    await _accessEndPointService.GetResponseThree(endPoint);

                if (responseThreeFlattenList.ToList().Count > 0)
                {
                    return Ok(responseThreeFlattenList);
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
