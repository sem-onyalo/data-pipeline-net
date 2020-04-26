using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPipeline.Net.Api.Response
{
    public class GetDataPipelineStatusResponse : BaseResponse
    {
        public int RunState { get; set; }
    }
}
