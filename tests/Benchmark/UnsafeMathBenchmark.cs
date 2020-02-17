using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;


using Ops = Internal.Numerics.MathOps;
using UOps = Internal.UnsafeNumerics.MathOps;

namespace Benchmark
{
    [SimpleJob(RuntimeMoniker.NetCoreApp31)]
    [MarkdownExporter]
    public class UnsafeMathBenchmark
    {
        private Random _r;
        private double[] _data;

        [Params(1_000, 10_000, 100_000, 1_024_000)]
        public int N { get; set; }

        public object Sum { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _r = new Random();
            _data = new double[N];
            for (var i = 0; i < N; i++)
                _data[i] = _r.NextDouble();
        }

        [Benchmark(Baseline = true)]
        public void DirectSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum += item * item;

            sum /= N;
            Sum = sum;
        }

        [Benchmark]
        public void BranchSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum = RefOps.DangerousAdd(sum, RefOps.DangerousMultiply(item, item));

            sum = RefOps.DangerousDivide(sum, N);
            Sum = sum;
        }

        [Benchmark]
        public void UnsafeBranchSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum = UnsafeRefOps.DangerousAdd(sum, UnsafeRefOps.DangerousMultiply(item, item));

            sum = UnsafeRefOps.DangerousDivide(sum, N);
            Sum = sum;
        }


        [Benchmark]
        public void ExpressionSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum = Ops.DangerousAdd(sum, Ops.DangerousMultiply(item, item));

            //sum = Ops.DangerousDivide(sum, Ops.DangerousCast<int, double>(N));
            sum = Ops.DangerousDivide(sum, N);

            Sum = sum;
        }

        [Benchmark]
        public void UnsafeSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum = UOps.DangerousAdd(sum, UOps.DangerousMultiply(item, item));

            //sum = UOps.DangerousDivide(sum, UOps.DangerousCast<int, double>(N));
            sum = UOps.DangerousDivide(sum, N);

            Sum = sum;
        }

    }
}
