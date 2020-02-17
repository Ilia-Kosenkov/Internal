namespace Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            //var x = new UnsafeMathBenchmark { N = 1000 };
            //x.GlobalSetup();
            //x.DirectSum();
            //x.UnsafeSum();
            //x.BranchSum();
            //x.UnsafeBranchSum();
            BenchmarkDotNet.Running.BenchmarkRunner.Run<UnsafeMathBenchmark>();
        }
    }
}
