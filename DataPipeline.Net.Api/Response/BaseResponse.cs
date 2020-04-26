using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPipeline.Net.Api.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
    }
}
