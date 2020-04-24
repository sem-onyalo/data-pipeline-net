using DataPipeline.Net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataPipeline.Net.Api
{
    public class DataLoader : IDataLoader
    {
        public bool loadData<T>(IEnumerable<T> dataset)
        {
            return true;
        }
    }
}
