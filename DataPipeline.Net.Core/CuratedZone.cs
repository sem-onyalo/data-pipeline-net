using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataPipeline.Net.Core
{
    public class CuratedZone
    {
        private readonly IDataLoader _dataLoader;

        public CuratedZone(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public void curateData()
        {
            Thread.Sleep(3500);
        }

        public void loadData()
        {
            Thread.Sleep(3500);
        }
    }
}
