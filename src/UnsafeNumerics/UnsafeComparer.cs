using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Internal.UnsafeNumerics.Comparer;

#nullable enable

namespace Internal.UnsafeNumerics.Comparer
{
    public class UnsafeStructComparer<T> : IEqualityComparer<T>, IComparer<T>
        where T : unmanaged
    {
        private static UnsafeStructComparer<T> Instance { get; } = new UnsafeStructComparer<T>();

        public static IEqualityComparer<T> DefaultEqualityComparer => Instance;
        public static IComparer<T> DefaultComparer => Instance;

        public bool Equals(T x, T y) => MathOps.DangerousEquals(x, y);

        public int GetHashCode(T obj) => obj.GetHashCode();

        public int Compare(T x, T y) => MathOps.DangerousCompare(x, y);
    }
}

namespace Internal.UnsafeNumerics
{
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public static class UnsafeComparer
    {
        private static readonly Type[] UnsafeTypes = {
            typeof(double),
            typeof(float),
            typeof(long),
            typeof(int),
            typeof(short),
            typeof(sbyte),
            typeof(ulong),
            typeof(uint),
            typeof(ushort),
            typeof(byte)
        };

        private static MethodInfo GetEqualityRef { get; } = typeof(UnsafeComparer)
            .GetMethod(nameof(GetEqualityComparerImpl), BindingFlags.NonPublic | BindingFlags.Static);

        private static MethodInfo GetCompRef { get; } = typeof(UnsafeComparer)
            .GetMethod(nameof(GetEqualityComparerImpl), BindingFlags.NonPublic | BindingFlags.Static);

        private static IEqualityComparer<T> GetEqualityComparerImpl<T>() where T : unmanaged 
            => UnsafeStructComparer<T>.DefaultEqualityComparer;

        private static IComparer<T> GetComparerImpl<T>() where T : unmanaged
            => UnsafeStructComparer<T>.DefaultComparer;

        public static IEqualityComparer<T> GetEqualityComparer<T>()
        {
            var t = typeof(T);
            if (t.IsClass)
                return EqualityComparer<T>.Default;

            if (Array.IndexOf(UnsafeTypes, t) >= 0)
            {
                return GetEqualityRef
                    .MakeGenericMethod(t)
                    .Invoke(null, Array.Empty<object>()) as IEqualityComparer<T>
                    ?? throw new NullReferenceException();
            }
            return EqualityComparer<T>.Default;

        }

        public static IComparer<T> GetComparer<T>()
        {
            var t = typeof(T);
            if (t.IsClass)
                return Comparer<T>.Default;

            if (Array.IndexOf(UnsafeTypes, t) >= 0)
            {
                return GetCompRef
                           .MakeGenericMethod(t)
                           .Invoke(null, Array.Empty<object>()) as IComparer<T>
                       ?? throw new NullReferenceException();
            }
            return Comparer<T>.Default;

        }
    }
}
