using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DataPipeline.Net.Core.Tests
{
    public class DataPipelineTest
    {
        private IDataPipeline _dataPipeline;

        [Fact]
        public void TestPassing1()
        {
            Assert.True(true);
        }

        [Fact]
        public void TestPassing2()
        {
            Assert.False(false);
        }

        [Fact]
        public void InstanceShouldNotBeNull()
        {
            Assert.NotNull(_dataPipeline);
        }
    }
}
