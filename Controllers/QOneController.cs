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
    public class QOneController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAccessEndpointService _accessEndPointService;

        public QOneController(IConfiguration configuration,
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
                string endPoint = _configuration.GetValue<string>("BasedUrl") + "backend/question/one";
                ResponseOne responseOne = await _accessEndPointService.GetResponseOne(endPoint);
                if (responseOne != null)
                {
                    return Ok(responseOne);
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
