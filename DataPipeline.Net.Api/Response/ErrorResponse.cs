using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPipeline.Net.Api.Response
{
    public class ErrorResponse : BaseResponse
    {
        public string Message { get; set; }
    }
}
