using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using InlineIL;
using static InlineIL.IL.Emit;
#pragma warning disable IDE0060 // Remove unused parameter

namespace Internal.UnsafeNumerics
{
    public static class MathOps
    {
        private static readonly double DoubleEps = Math.Pow(2, -52);
        private static readonly float FloatEps = (float)Math.Pow(2, -23);

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static bool AlmostEqual(this double @this, double that, double relComp = 1d)
        {
            if (double.IsInfinity(@this) || double.IsInfinity(that))
                return @this == that;

            if (double.IsNaN(@this) || double.IsNaN(that))
                return false;

            var thisAbs = Math.Abs(@this);
            var thatAbs = Math.Abs(that);

            if (thisAbs == 0d)
                return (thatAbs < relComp * DoubleEps);
            if (thatAbs == 0d)
                return (thisAbs < relComp * DoubleEps);

            return Math.Abs(@this - that) < relComp * DoubleEps * Math.Max(thisAbs, thatAbs);
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static bool AlmostEqual(this float @this, float that, float relComp = 1f)
        {
            if (float.IsInfinity(@this) || float.IsInfinity(that))
                return @this == that;

            if (float.IsNaN(@this) || float.IsNaN(that))
                return false;

            var thisAbs = Math.Abs(@this);
            var thatAbs = Math.Abs(that);

            if (thisAbs == 0f)
                return (thatAbs < relComp * FloatEps);
            if (thatAbs == 0f)
                return (thisAbs < relComp * FloatEps);
            
            return Math.Abs(@this - that) < relComp * FloatEps * Math.Max(thisAbs, thatAbs);
        }

        public static void Test() => 123.0.AlmostEqual(3);

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
#pragma warning restore IDE0060 // Remove unused parameter
        {
            Ldarg_0();
            Neg();
            return IL.Return<T>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousEquals<T>(T left, T right) where T : unmanaged
        {
            Ldtoken(new TypeRef(typeof(T)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(double)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Float");
            Ldarg_0();
            Ldarg_1();
            Ldc_R8(1d);
            Call(new MethodRef(typeof(MathOps), nameof(AlmostEqual), typeof(double), typeof(double), typeof(double)));
            Ret();

            IL.MarkLabel("To_Float");
            Ldtoken(new TypeRef(typeof(T)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(float)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("Default");
            Ldarg_0();
            Ldarg_1();
            Ldc_R4(1f);
            Call(new MethodRef(typeof(MathOps), nameof(AlmostEqual), typeof(float), typeof(float), typeof(float)));
            Ret();


            IL.MarkLabel("Default");
            Ldarg_0();
            Ldarg_1();
            Ceq();
         
            return IL.Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousNotEquals<T>(T left, T right) where T : unmanaged
            => !DangerousEquals(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousGreaterThan<T>(T left, T right) where T : unmanaged
        { 
            Ldarg_0();
            Ldarg_1();
            Call(new MethodRef(typeof(MathOps), nameof(DangerousEquals), 1, typeof(T), typeof(T)).MakeGenericMethod(typeof(T)));
            Brtrue("Equal");

            Ldarg_0();
            Ldarg_1();
            Cgt();
            Ret();

            IL.MarkLabel("Equal");
            Ldc_I4_0();
            return IL.Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousLessThan<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Call(new MethodRef(typeof(MathOps), nameof(DangerousEquals), 1, typeof(T), typeof(T)).MakeGenericMethod(typeof(T)));
            Brtrue("Equal");

            Ldarg_0();
            Ldarg_1();
            Clt();
            Ret();

            IL.MarkLabel("Equal");
            Ldc_I4_0();
            return IL.Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousGreaterEquals<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Call(new MethodRef(typeof(MathOps), nameof(DangerousEquals), 1, typeof(T), typeof(T)).MakeGenericMethod(typeof(T)));
            Brtrue("Equal");

            Ldarg_0();
            Ldarg_1();
            Cgt();
            Ret();

            IL.MarkLabel("Equal");
            Ldc_I4_1();
            return IL.Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool DangerousLessEquals<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Call(new MethodRef(typeof(MathOps), nameof(DangerousEquals), 1, typeof(T), typeof(T)).MakeGenericMethod(typeof(T)));
            Brtrue_S("Equal");

            Ldarg_0();
            Ldarg_1();
            Clt();
            Ret();

            IL.MarkLabel("Equal");
            Ldc_I4_1();
            return IL.Return<bool>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int DangerousCompare<T>(T left, T right) where T : unmanaged
        {
            Ldarg_0();
            Ldarg_1();
            Call(new MethodRef(typeof(MathOps), nameof(DangerousEquals), 1, typeof(T), typeof(T)).MakeGenericMethod(typeof(T)));
            Brtrue_S("Equal");

            Ldarg_0();
            Ldarg_1();
            Cgt();
            Brfalse_S("Less");
            Ldc_I4_1();
            Ret();

            IL.MarkLabel("Less");
            Ldc_I4_M1();
            Ret();

            
            IL.MarkLabel("Equal");
            Ldc_I4_0();
            return IL.Return<int>();

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

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_Float");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(float)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Int64");
            
            Ldarg_0();
            Conv_R4();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_Int64");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(long)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Int32");
            
            Ldarg_0();
            Conv_I8();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_Int32");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(int)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Int16");

            Ldarg_0();
            Conv_I4();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_Int16");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(short)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Int8");

            Ldarg_0();
            Conv_I2();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_Int8");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(sbyte)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_UInt64");

            Ldarg_0();
            Conv_I1();
            Ret();


            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_UInt64");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(ulong)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_UInt32");

            Ldarg_0();
            Conv_U8();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_UInt32");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(uint)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_UInt16");

            Ldarg_0();
            Conv_U4();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_UInt16");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(ushort)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_UInt8");

            Ldarg_0();
            Conv_U2();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_UInt8");
            Ldtoken(new TypeRef(typeof(TTo)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Ldtoken(new TypeRef(typeof(byte)));
            Call(new MethodRef(typeof(Type), nameof(Type.GetTypeFromHandle), typeof(RuntimeTypeHandle)));
            Call(new MethodRef(typeof(Type), "op_Equality", typeof(Type), typeof(Type)));
            Brfalse_S("To_Throw");

            Ldarg_0();
            Conv_U1();
            Ret();

            // ---------------------------------------------------------------------------------------------
            IL.MarkLabel("To_Throw");
            Newobj(MethodRef.Constructor(typeof(ArithmeticException)));
            Throw();

            throw IL.Unreachable();
        }

    }
}

