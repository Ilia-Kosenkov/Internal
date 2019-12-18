﻿using System.Runtime.CompilerServices;

namespace Internal.UnsafeNumerics
{
    public static class MathOps
    {
        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern T DangerousAdd<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern T DangerousSubtract<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern T DangerousMultiply<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern T DangerousDivide<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern T DangerousNegate<T>(T item) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern bool DangerousEquals<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern bool DangerousNotEquals<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern bool DangerousGreaterThan<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern bool DangerousLessThan<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern bool DangerousGreaterEquals<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern bool DangerousLessEquals<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern int DangerousCompare<T>(T left, T right) where T : unmanaged;

        [MethodImpl(MethodImplOptions.ForwardRef | MethodImplOptions.AggressiveInlining, MethodCodeType = MethodCodeType.IL)]
        public static extern TTo DangerousCast<TFrom, TTo>(TFrom item)
            where TFrom : unmanaged
            where TTo : unmanaged;

        
    }
}
