.class public sealed abstract auto ansi Internal.UnsafeNumerics.MathOps
{
	.method public static hidebysig !!T DangerousAdd<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		add
		ret
	}

	.method public static hidebysig !!T DangerousSubtract<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		sub
		ret
	}

	.method public static hidebysig !!T DangerousMultiply<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		mul
		ret
	}

	.method public static hidebysig !!T DangerousDivide<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		div
		ret
	}

	.method public static hidebysig !!T DangerousNegate<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T item) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		neg
		ret
	}

	.method public static hidebysig bool DangerousEquals<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldtoken		!!T
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Double
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s	IL_001 // If not double, goto
		ldarg.0
		ldarg.1
		call		bool [MathNet.Numerics]MathNet.Numerics.Precision::AlmostEqual(float64, float64)
		ret

		IL_001: ldtoken !!T
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken		[mscorlib]System.Single
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s	IL_002 // If not float, goto
		ldarg.0
		ldarg.1
		call		bool [MathNet.Numerics]MathNet.Numerics.Precision::AlmostEqual(float32, float32)
		ret

		IL_002: 
		ldarg.0
		ldarg.1
		ceq
		ret
	}

	.method public static hidebysig bool DangerousNotEquals<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
	
		ldarg.0
		ldarg.1
		call	bool Internal.UnsafeNumerics.MathOps::DangerousEquals<!!T>(!!T, !!T)
		ldc.i4.0
		ceq
		ret
	}

	.method public static hidebysig bool DangerousGreaterThan<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		cgt
		ret
	}

	.method public static hidebysig bool DangerousLessThan<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		clt
		ret
	}

	.method public static hidebysig bool DangerousGreaterEquals<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		ldarg.0
		ldarg.1
		cgt
		brfalse.s	IL_001
		ldc.i4.1
		ret

		IL_001:
		ldarg.0
		ldarg.1
		call		bool Internal.UnsafeNumerics.MathOps::DangerousEquals<!!T>(!!T, !!T)
		ret
	}

	.method public static hidebysig bool DangerousLessEquals<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		.maxstack 4

		ldarg.0
		ldarg.1
		clt
		brfalse.s	IL_001
		ldc.i4.1
		ret

		IL_001:
		ldarg.0
		ldarg.1
		call		bool Internal.UnsafeNumerics.MathOps::DangerousEquals<!!T>(!!T, !!T)
		ret
	}

	.method public static hidebysig int32 DangerousCompare<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) T>(!!T left, !!T right) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		.maxstack 4

		ldarg.0
		ldarg.1
		cgt
		brfalse.s	IL_001

		ldc.i4.1
		ret

		IL_001:
		ldarg.0
		ldarg.1
		call		bool Internal.UnsafeNumerics.MathOps::DangerousEquals<!!T>(!!T, !!T)
		brfalse.s	IL_002

		ldc.i4.0
		ret

		IL_002:
		ldarg.0
		ldarg.1
		clt
		brfalse.s	IL_003
		
		ldc.i4.1
		neg
		ret

		IL_003:
		newobj		instance void [mscorlib]System.ArithmeticException::.ctor()
		throw
	}

	.method public static hidebysig !!TTo DangerousCast
	<valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) TFrom, 
	valuetype .ctor (class [mscorlib]System.ValueType modreq ([mscorlib]System.Runtime.InteropServices.UnmanagedType)) TTo>(!!TFrom item) cil managed
	{
		.param type [1]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		.param type [2]
		.custom instance void System.Runtime.CompilerServices.IsUnmanagedAttribute::.ctor()
		= (01 00 00 00 )
		.maxstack 8
		// Double
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Double
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s	IL_001
		
		ldarg.0
		conv.r8		// Cast to double
		ret
		
		IL_001:		// Float
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Single
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_002
					
		ldarg.0
		conv.r4		// Cast to single
		ret
		
		
		IL_002:		//	Int64
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Int64
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_003
					
		ldarg.0
		conv.i8		// Cast to Int64
		ret
		
		
		IL_003:		//	Int32
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Int32
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_004
					
		ldarg.0
		conv.i4		// Cast to Int32
		ret
		
		
		IL_004:		//	Int16
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Int16
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_005
					
		ldarg.0
		conv.i2		// Cast to Int16
		ret
		
		
		IL_005:		//	Int8
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.SByte
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_006
					
		ldarg.0
		conv.i1		// Cast to SByte
		ret
		
		
		IL_006:		//	UInt64
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.UInt64
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_007
					
		ldarg.0
		conv.u8		// Cast to UInt64
		ret
		
		
		IL_007:		//	UInt32
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.UInt32
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_008
					
		ldarg.0
		conv.u4		// Cast to UInt32
		ret
		
		
		IL_008:		//	UInt16
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.UInt16
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_009
					
		ldarg.0
		conv.u2		// Cast to UInt16
		ret

		
		IL_009:		//	UInt16
		ldtoken		!!TTo
		call		class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		ldtoken     [mscorlib]System.Byte
		call        class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
        call        bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type, class [mscorlib]System.Type)
		brfalse.s		IL_0FF
					
		ldarg.0
		conv.u1		// Cast to Byte
		ret


		IL_0FF:		// If no matching type, throw
		newobj		instance void [mscorlib]System.ArithmeticException::.ctor()
		throw
	}
}