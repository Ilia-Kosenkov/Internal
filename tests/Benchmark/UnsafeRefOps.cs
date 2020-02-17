using System;
using System.Runtime.CompilerServices;

namespace Benchmark
{
    internal static class UnsafeRefOps
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static T DangerousAdd<T>(T left, T right)
            where T : unmanaged
        {
            if (typeof(T) == typeof(double))
            {
                var tmp = Unsafe.As<T, double>(ref left) + Unsafe.As<T, double>(ref right);
                return Unsafe.As<double, T>(ref tmp);
            }

            if (typeof(T) == typeof(float))
            {
                var tmp = Unsafe.As<T, float>(ref left) + Unsafe.As<T, float>(ref right);
                return Unsafe.As<float, T>(ref tmp);
            }

            if (typeof(T) == typeof(uint))
            {
                var tmp = Unsafe.As<T, uint>(ref left) + Unsafe.As<T, uint>(ref right);
                return Unsafe.As<uint, T>(ref tmp);
            }
            if (typeof(T) == typeof(int))
            {
                var tmp = Unsafe.As<T, int>(ref left) + Unsafe.As<T, int>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            if (typeof(T) == typeof(ushort))
            {
                var tmp = Unsafe.As<T, ushort>(ref left) + Unsafe.As<T, ushort>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }
            if (typeof(T) == typeof(short))
            {
                var tmp = Unsafe.As<T, short>(ref left) + Unsafe.As<T, short>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            if (typeof(T) == typeof(ulong))
            {
                var tmp = Unsafe.As<T, ulong>(ref left) + Unsafe.As<T, ulong>(ref right);
                return Unsafe.As<ulong, T>(ref tmp);
            }
            if (typeof(T) == typeof(long))
            {
                var tmp = Unsafe.As<T, long>(ref left) + Unsafe.As<T, long>(ref right);
                return Unsafe.As<long, T>(ref tmp);
            }

            if (typeof(T) == typeof(byte))
            {
                var tmp = Unsafe.As<T, byte>(ref left) + Unsafe.As<T, byte>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }
            if (typeof(T) == typeof(sbyte))
            {
                var tmp = Unsafe.As<T, sbyte>(ref left) + Unsafe.As<T, sbyte>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static T DangerousMultiply<T>(T left, T right)
            where T : unmanaged
        {
            if (typeof(T) == typeof(double))
            {
                var tmp = Unsafe.As<T, double>(ref left) * Unsafe.As<T, double>(ref right);
                return Unsafe.As<double, T>(ref tmp);
            }

            if (typeof(T) == typeof(float))
            {
                var tmp = Unsafe.As<T, float>(ref left) * Unsafe.As<T, float>(ref right);
                return Unsafe.As<float, T>(ref tmp);
            }

            if (typeof(T) == typeof(uint))
            {
                var tmp = Unsafe.As<T, uint>(ref left) * Unsafe.As<T, uint>(ref right);
                return Unsafe.As<uint, T>(ref tmp);
            }
            if (typeof(T) == typeof(int))
            {
                var tmp = Unsafe.As<T, int>(ref left) * Unsafe.As<T, int>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            if (typeof(T) == typeof(ushort))
            {
                var tmp = Unsafe.As<T, ushort>(ref left) * Unsafe.As<T, ushort>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }
            if (typeof(T) == typeof(short))
            {
                var tmp = Unsafe.As<T, short>(ref left) * Unsafe.As<T, short>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            if (typeof(T) == typeof(ulong))
            {
                var tmp = Unsafe.As<T, ulong>(ref left) * Unsafe.As<T, ulong>(ref right);
                return Unsafe.As<ulong, T>(ref tmp);
            }
            if (typeof(T) == typeof(long))
            {
                var tmp = Unsafe.As<T, long>(ref left) * Unsafe.As<T, long>(ref right);
                return Unsafe.As<long, T>(ref tmp);
            }

            if (typeof(T) == typeof(byte))
            {
                var tmp = Unsafe.As<T, byte>(ref left) * Unsafe.As<T, byte>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }
            if (typeof(T) == typeof(sbyte))
            {
                var tmp = Unsafe.As<T, sbyte>(ref left) * Unsafe.As<T, sbyte>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }


            throw new NotSupportedException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static T DangerousDivide<T>(T left, T right)
            where T : unmanaged
        {
            if (typeof(T) == typeof(double))
            {
                var tmp = Unsafe.As<T, double>(ref left) / Unsafe.As<T, double>(ref right);
                return Unsafe.As<double, T>(ref tmp);
            }

            if (typeof(T) == typeof(float))
            {
                var tmp = Unsafe.As<T, float>(ref left) / Unsafe.As<T, float>(ref right);
                return Unsafe.As<float, T>(ref tmp);
            }

            if (typeof(T) == typeof(uint))
            {
                var tmp = Unsafe.As<T, uint>(ref left) / Unsafe.As<T, uint>(ref right);
                return Unsafe.As<uint, T>(ref tmp);
            }
            if (typeof(T) == typeof(int))
            {
                var tmp = Unsafe.As<T, int>(ref left) / Unsafe.As<T, int>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            if (typeof(T) == typeof(ushort))
            {
                var tmp = Unsafe.As<T, ushort>(ref left) / Unsafe.As<T, ushort>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }
            if (typeof(T) == typeof(short))
            {
                var tmp = Unsafe.As<T, short>(ref left) / Unsafe.As<T, short>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            if (typeof(T) == typeof(ulong))
            {
                var tmp = Unsafe.As<T, ulong>(ref left) / Unsafe.As<T, ulong>(ref right);
                return Unsafe.As<ulong, T>(ref tmp);
            }
            if (typeof(T) == typeof(long))
            {
                var tmp = Unsafe.As<T, long>(ref left) / Unsafe.As<T, long>(ref right);
                return Unsafe.As<long, T>(ref tmp);
            }

            if (typeof(T) == typeof(byte))
            {
                var tmp = Unsafe.As<T, byte>(ref left) / Unsafe.As<T, byte>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }
            if (typeof(T) == typeof(sbyte))
            {
                var tmp = Unsafe.As<T, sbyte>(ref left) / Unsafe.As<T, sbyte>(ref right);
                return Unsafe.As<int, T>(ref tmp);
            }

            throw new NotSupportedException();
        }

    }
}
