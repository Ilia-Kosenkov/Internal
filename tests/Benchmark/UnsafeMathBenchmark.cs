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
        }

        //[Benchmark]
        //public void MethodSum()
        //{
        //    var sum = 0.0;
        //    foreach (var item in _data)
        //        sum = Add(sum, Multiply(item, item));

        //    sum = Divide(sum, N);
        //}

        [Benchmark]
        public void ExpressionSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum = Ops.DangerousAdd(sum, Ops.DangerousMultiply(item, item));

            sum = Ops.DangerousDivide(sum, Ops.DangerousCast<int, double>(N));
        }

        [Benchmark]
        public void UnsafeSum()
        {
            var sum = 0.0;
            foreach (var item in _data)
                sum = UOps.DangerousAdd(sum, UOps.DangerousMultiply(item, item));

            sum = UOps.DangerousDivide(sum, UOps.DangerousCast<int, double>(N));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Add(double x, double y)
        {
            return x + y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Multiply(double x, double y)
        {
            return x * y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double Divide(double x, double y)
        {
            return x / y;
        }
    }
}
