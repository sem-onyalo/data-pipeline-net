using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataPipeline.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPipelineController : ControllerBase
    {

        [HttpGet("version/")]
        public string GetVersion()
        {
            return "0.1";
        }
    }
}