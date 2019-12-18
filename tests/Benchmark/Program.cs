namespace Benchmark
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<UnsafeMathBenchmark>();
        }
    }
}
