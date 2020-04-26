using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using Xunit.Runners;

namespace DataPipeline.Net.Core.Tests
{
    public class TestRunner
    {
        private readonly string _assemblyFileName;

        private ManualResetEvent finished;

        private int _totalTests;

        private int _testsFailed;

        public TestRunner(string assemblyFileName)
        {
            _assemblyFileName = assemblyFileName;
        }

        public TestResult RunTests()
        {
            _totalTests = 0;

            _testsFailed = 0;

            using (AssemblyRunner runner = AssemblyRunner.WithoutAppDomain(_assemblyFileName))
            using (finished = new ManualResetEvent(false))
            {
                runner.OnExecutionComplete = TestAssemblyExecutionFinished;

                runner.Start();

                finished.WaitOne();
            }

            TestResult result = new TestResult { TotalTests = _totalTests, TestsFailed = _testsFailed };

            return result;
        }

        private void TestAssemblyExecutionFinished(ExecutionCompleteInfo info)
        {
            _totalTests = info.TotalTests;

            _testsFailed = info.TestsFailed;

            if (finished != null) finished.Set();
        }
    }
}
