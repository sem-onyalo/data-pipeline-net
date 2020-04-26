using DataPipeline.Net.Core.Tests;
using System;

namespace DataPipelineNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRunner testRunner = new TestRunner("DataPipeline.Net.Core.dll");

            TestResult result = testRunner.RunTests();

            Console.WriteLine($"{result.TotalTests} tests, {result.TestsFailed} failed.");

            Console.ReadKey();
        }
    }
}
