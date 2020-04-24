using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataPipeline.Net.Core
{
    public class RawZone
    {
        private readonly IDataExtractor _dataExtractor;

        public RawZone(IDataExtractor dataExtractor)
        {
            _dataExtractor = dataExtractor;
        }

        public void extractData()
        {
            Thread.Sleep(3500);
        }
    }
}
