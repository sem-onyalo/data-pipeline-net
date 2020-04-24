using System;
using System.Collections.Generic;
using System.Text;

namespace DataPipeline.Net.Core
{
    public interface IDataLoader
    {
        bool loadData<T>(IEnumerable<T> dataset);
    }
}
