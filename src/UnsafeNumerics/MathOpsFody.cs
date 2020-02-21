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

