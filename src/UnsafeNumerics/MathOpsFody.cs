using System;
using System.Runtime.CompilerServices;
using InlineIL;
using static InlineIL.IL.Emit;

namespace Internal.UnsafeNumerics
{
    public static class MathOps
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DangerousAdd<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Add();
            return IL.Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DangerousSubtract<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Sub();
            return IL.Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DangerousMultiply<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Mul();
            return IL.Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DangerousDivide<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Div();
            return IL.Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T DangerousNegate<T>(T item) where T : unmanaged
        {
            Ldarg_0();
            Neg();
            return IL.Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousEquals<T>(T left, T right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousNotEquals<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Call(new MethodRef(typeof(MathOps), nameof(DangerousEquals), 1, TypeRef.MethodGenericParameters[0], TypeRef.MethodGenericParameters[0]));
            Ldc_I4_0();
            Ceq();
            return IL.Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousGreaterThan<T>(T left, T right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousLessThan<T>(T left, T right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousGreaterEquals<T>(T left, T right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousLessEquals<T>(T left, T right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DangerousCompare<T>(T left, T right) where T : unmanaged
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTo DangerousCast<TFrom, TTo>(TFrom item)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(double)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Float");

            Ldarg_0();
            Conv_R8();
            Ret();

            IL.MarkLabel("To_Float");
            Newobj(MethodRef.Constructor(typeof(ArithmeticException)));
            Throw();

            throw IL.Unreachable();
        }


    }
}

