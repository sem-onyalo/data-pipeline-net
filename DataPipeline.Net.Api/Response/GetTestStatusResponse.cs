using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPipeline.Net.Api.Response
{
    public class GetTestStatusResponse : BaseResponse
    {
        public int TotalTests { get; set; }

        public int TestsFailed { get; set; }
    }
}
