using System;
using System.Runtime.CompilerServices;

namespace Benchmark
{
    internal static class RefOps
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static T DangerousAdd<T>(T left, T right)
            where T : unmanaged
        {
            if (typeof(T) == typeof(double))
                return (T) (object) ((double) (object) left + (double) (object) right);
            if (typeof(T) == typeof(float))
                return (T)(object)((float)(object)left + (float)(object)right);

            if (typeof(T) == typeof(uint))
                return (T)(object)((uint)(object)left + (uint)(object)right);
            if (typeof(T) == typeof(int))
                return (T)(object)((int)(object)left + (int)(object)right);

            if (typeof(T) == typeof(ushort))
                return (T)(object)((ushort)(object)left + (ushort)(object)right);
            if (typeof(T) == typeof(short))
                return (T)(object)((short)(object)left + (short)(object)right);

            if (typeof(T) == typeof(ulong))
                return (T)(object)((ulong)(object)left + (ulong)(object)right);
            if (typeof(T) == typeof(long))
                return (T)(object)((long)(object)left + (long)(object)right);

            if (typeof(T) == typeof(byte))
                return (T)(object)((byte)(object)left + (byte)(object)right);
            if (typeof(T) == typeof(sbyte))
                return (T)(object)((sbyte)(object)left + (sbyte)(object)right);

            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static T DangerousMultiply<T>(T left, T right)
            where T : unmanaged
        {
            if (typeof(T) == typeof(double))
                return (T)(object)((double)(object)left * (double)(object)right);
            if (typeof(T) == typeof(float))
                return (T)(object)((float)(object)left * (float)(object)right);

            if (typeof(T) == typeof(uint))
                return (T)(object)((uint)(object)left * (uint)(object)right);
            if (typeof(T) == typeof(int))
                return (T)(object)((int)(object)left * (int)(object)right);

            if (typeof(T) == typeof(ushort))
                return (T)(object)((ushort)(object)left * (ushort)(object)right);
            if (typeof(T) == typeof(short))
                return (T)(object)((short)(object)left * (short)(object)right);

            if (typeof(T) == typeof(ulong))
                return (T)(object)((ulong)(object)left * (ulong)(object)right);
            if (typeof(T) == typeof(long))
                return (T)(object)((long)(object)left * (long)(object)right);

            if (typeof(T) == typeof(byte))
                return (T)(object)((byte)(object)left * (byte)(object)right);
            if (typeof(T) == typeof(sbyte))
                return (T)(object)((sbyte)(object)left * (sbyte)(object)right);

            throw new NotSupportedException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static T DangerousDivide<T>(T left, T right)
            where T : unmanaged
        {
            if (typeof(T) == typeof(double))
                return (T)(object)((double)(object)left / (double)(object)right);
            if (typeof(T) == typeof(float))
                return (T)(object)((float)(object)left / (float)(object)right);

            if (typeof(T) == typeof(uint))
                return (T)(object)((uint)(object)left / (uint)(object)right);
            if (typeof(T) == typeof(int))
                return (T)(object)((int)(object)left / (int)(object)right);

            if (typeof(T) == typeof(ushort))
                return (T)(object)((ushort)(object)left / (ushort)(object)right);
            if (typeof(T) == typeof(short))
                return (T)(object)((short)(object)left / (short)(object)right);

            if (typeof(T) == typeof(ulong))
                return (T)(object)((ulong)(object)left / (ulong)(object)right);
            if (typeof(T) == typeof(long))
                return (T)(object)((long)(object)left / (long)(object)right);

            if (typeof(T) == typeof(byte))
                return (T)(object)((byte)(object)left / (byte)(object)right);
            if (typeof(T) == typeof(sbyte))
                return (T)(object)((sbyte)(object)left / (sbyte)(object)right);

            throw new NotSupportedException();
        }

    }
}
