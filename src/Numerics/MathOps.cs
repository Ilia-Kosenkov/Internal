using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Image")]
[assembly: InternalsVisibleTo("Tests")]
[assembly: InternalsVisibleTo("CopyBenchmarks")]
namespace Internal.Numerics
{
    internal static class MathOps
    {
        private static readonly Dictionary<(Type Type, string Op), Delegate> Cache =
            new Dictionary<(Type Type, string Op), Delegate>();

        private static readonly Dictionary<(Type From, Type To), Delegate> CastCache =
            new Dictionary<(Type From, Type To), Delegate>();

        public static T DangerousAdd<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousAdd)), out var del))
                return del is Func<T, T, T> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousAdd));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.Add(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, T>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousAdd))] = func;

            return func(left, right);
        }

        public static T DangerousSubtract<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousSubtract)), out var del))
                return del is Func<T, T, T> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousSubtract));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.Subtract(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, T>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousSubtract))] = func;

            return func(left, right);
        }

        public static T DangerousMultiply<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousMultiply)), out var del))
                return del is Func<T, T, T> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousMultiply));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.Multiply(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, T>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousMultiply))] = func;

            return func(left, right);
        }

        public static T DangerousDivide<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousDivide)), out var del))
                return del is Func<T, T, T> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousDivide));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.Divide(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, T>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousDivide))] = func;

            return func(left, right);
        }

        public static T DangerousNegate<T>(T item) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousNegate)), out var del))
                return del is Func<T, T> specificFunc
                    ? specificFunc(item)
                    : throw new InvalidOperationException(nameof(DangerousNegate));

            var itemPar = Expression.Parameter(t, nameof(item));
            var body = Expression.Negate(itemPar);

            var func = Expression.Lambda<Func<T, T>>(body, itemPar).Compile();

            Cache[(t, nameof(DangerousNegate))] = func;

            return func(item);
        }

        public static bool DangerousEquals<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousEquals)), out var del))
                return del is Func<T, T, bool> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousEquals));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            Func<T, T, bool> func;
            if (t == typeof(double))
            {
                var body = Expression.Call(
                    typeof(MathNet.Numerics.Precision).GetMethod(nameof(MathNet.Numerics.Precision.AlmostEqual),
                        new[] {typeof(double), typeof(double)}) ?? throw new InvalidOperationException(), leftPar, rightPar);
                func = Expression.Lambda<Func<T, T, bool>>(body, leftPar, rightPar).Compile();
            }
            else if (t == typeof(float))
            {
                var body = Expression.Call(
                    typeof(MathNet.Numerics.Precision).GetMethod(nameof(MathNet.Numerics.Precision.AlmostEqual),
                        new[] {typeof(float), typeof(float)}) ?? throw new InvalidOperationException(), leftPar,
                    rightPar);
                func = Expression.Lambda<Func<T, T, bool>>(body, leftPar, rightPar).Compile();
            }
            else
                func = Expression.Lambda<Func<T, T, bool>>(Expression.Equal(leftPar, rightPar), leftPar, rightPar)
                    .Compile();

            Cache[(t, nameof(DangerousEquals))] = func;

            return func(left, right);
        }

        public static bool DangerousNotEquals<T>(T left, T right) where T : unmanaged
            => !DangerousEquals(left, right);


        public static bool DangerousGreaterThan<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousGreaterThan)), out var del))
                return del is Func<T, T, bool> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousGreaterThan));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.GreaterThan(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, bool>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousGreaterThan))] = func;

            return func(left, right);
        }

        public static bool DangerousLessThan<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousLessThan)), out var del))
                return del is Func<T, T, bool> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousLessThan));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.LessThan(leftPar, rightPar);

            var func = Expression.Lambda<Func<T, T, bool>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousLessThan))] = func;

            return func(left, right);
        }

        public static bool DangerousGreaterEquals<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousGreaterEquals)), out var del))
                return del is Func<T, T, bool> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousGreaterEquals));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.OrElse(
                Expression.GreaterThan(leftPar, rightPar),
                Expression.Call(
                    typeof(MathOps).GetMethod(nameof(DangerousEquals),
                            BindingFlags.Public | BindingFlags.Static)
                        ?.MakeGenericMethod(t) ?? throw new InvalidOperationException(),
                    leftPar, rightPar));

            var func = Expression.Lambda<Func<T, T, bool>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousGreaterEquals))] = func;

            return func(left, right);
        }


        public static bool DangerousLessEquals<T>(T left, T right) where T : unmanaged
        {
            var t = typeof(T);
            if (Cache.TryGetValue((t, nameof(DangerousLessEquals)), out var del))
                return del is Func<T, T, bool> specificFunc
                    ? specificFunc(left, right)
                    : throw new InvalidOperationException(nameof(DangerousLessEquals));

            var leftPar = Expression.Parameter(t, nameof(left));
            var rightPar = Expression.Parameter(t, nameof(right));
            var body = Expression.OrElse(
                Expression.LessThan(leftPar, rightPar),
                Expression.Call(
                    typeof(MathOps).GetMethod(nameof(DangerousEquals),
                            BindingFlags.Public | BindingFlags.Static)
                        ?.MakeGenericMethod(t) ?? throw new InvalidOperationException(),
                    leftPar, rightPar));

            var func = Expression.Lambda<Func<T, T, bool>>(body, leftPar, rightPar).Compile();

            Cache[(t, nameof(DangerousLessEquals))] = func;

            return func(left, right);
        }

        public static int DangerousCompare<T>(T left, T right) where T : unmanaged
        {
            if (DangerousGreaterThan(left, right))
                return 1;
            if (DangerousEquals(left, right))
                return 0;
            if (DangerousLessThan(left, right))
                return -1;
            throw new ArithmeticException();
        }

        public static TTo DangerousCast<TFrom, TTo>(TFrom item)
            where TFrom : unmanaged
            where TTo : unmanaged
        {
            var tFrom = typeof(TFrom);
            var tTo = typeof(TTo);

            if (CastCache.TryGetValue((tFrom, tTo), out var del))
                return del is Func<TFrom, TTo> specificDel
                    ? specificDel(item)
                    : throw new InvalidOperationException(nameof(DangerousCast));

            var itemPar = Expression.Parameter(tFrom, nameof(item));
            var func = Expression.Lambda<Func<TFrom, TTo>>(Expression.Convert(itemPar, tTo), itemPar).Compile();

            CastCache[(tFrom, tTo)] = func;


            return func(item);
        }
    }
}
