using System;
using System.Collections.Generic;
using System.Text;

namespace DataPipeline.Net.Core
{
    public interface IDataExtractor
    {
        IEnumerable<T> extractData<T>();
    }
}
