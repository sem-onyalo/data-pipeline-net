using System;
using System.Collections.Generic;
using System.Text;

namespace DataPipeline.Net.Core
{
    public interface IDataPipeline
    {
        DataPipelineRunState RunState { get; }

        bool Run();
    }
}
