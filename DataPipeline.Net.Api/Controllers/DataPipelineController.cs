using DataPipeline.Net.Api.Response;
using DataPipeline.Net.Core;
using DataPipeline.Net.Core.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace DataPipeline.Net.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPipelineController : ControllerBase
    {
        private readonly string _cacheKeyDataPipeline = "datapipeline";

        private readonly string _cacheKeyTestResult = "testresult";

        private readonly IMemoryCache _memoryCache;

        private readonly IConfiguration _config;

        public DataPipelineController(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _config = configuration;

            _memoryCache = memoryCache;
        }

        [HttpGet("version/")]
        public string GetVersion()
        {
            return "0.1";
        }

        [HttpGet("run/")]
        public bool Run()
        {
            IDataExtractor dataExtractor = new DataExtractor();

            IDataLoader dataLoader = new DataLoader();

            IDataPipeline dataPipeline = new Core.DataPipeline(dataExtractor, dataLoader);

            _memoryCache.Set(_cacheKeyDataPipeline, dataPipeline);

            Task.Run(() => dataPipeline.Run());

            return true;
        }

        [HttpGet("tests/")]
        public bool RunTests()
        {
            _memoryCache.Remove(_cacheKeyTestResult);

            Task.Run(() =>
            {
                TestRunner testRunner = new TestRunner(_config["TestAssembyFileName"]);

                TestResult result = testRunner.RunTests();

                _memoryCache.Set(_cacheKeyTestResult, result);
            });

            return true;
        }

        [HttpGet("status/{status}")]
        public BaseResponse GetStatus(string status)
        {
            switch (status)
            {
                case "run":
                    return GetRunStatus();

                case "tests":
                    return GetTestStatus();

                default:
                    return new ErrorResponse { Message = "Invalid status", Success = false };
            }
        }

        private GetDataPipelineStatusResponse GetRunStatus()
        {
            IDataPipeline dataPipeline;

            GetDataPipelineStatusResponse response = new GetDataPipelineStatusResponse();
            
            if (_memoryCache.TryGetValue(_cacheKeyDataPipeline, out dataPipeline) && dataPipeline != null)
            {
                response.RunState = (int)dataPipeline.RunState;
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }

        private GetTestStatusResponse GetTestStatus()
        {
            TestResult testResult;

            GetTestStatusResponse response = new GetTestStatusResponse();

            if (_memoryCache.TryGetValue(_cacheKeyTestResult, out testResult) && testResult != null)
            {
                response.TotalTests = testResult.TotalTests;
                response.TestsFailed = testResult.TestsFailed;
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }
    }
}