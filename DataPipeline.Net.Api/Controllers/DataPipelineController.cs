using DataPipeline.Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DataPipeline.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPipelineController : ControllerBase
    {
        private readonly string _dataPipelineCacheKey = "datapipeline";

        private readonly IMemoryCache _memoryCache;

        public DataPipelineController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet("version/")]
        public string GetVersion()
        {
            return "0.1";
        }

        [HttpGet("run/")]
        public bool RunDataPipeline()
        {
            IDataExtractor dataExtractor = new DataExtractor();

            IDataLoader dataLoader = new DataLoader();

            IDataPipeline dataPipeline = new Core.DataPipeline(dataExtractor, dataLoader);

            _memoryCache.Set(_dataPipelineCacheKey, dataPipeline);

            Task.Run(() => dataPipeline.Run());

            return true;
        }

        [HttpGet("status/")]
        public int GetDataPipelineStatus()
        {
            IDataPipeline dataPipeline;
            if (_memoryCache.TryGetValue(_dataPipelineCacheKey, out dataPipeline) && dataPipeline != null)
            {
                return (int)dataPipeline.RunState;
            }
            else
            {
                return -1;
            }
        }
    }
}