using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Internal.UnsafeNumerics;
using NUnit.Framework;

using Ops = Internal.Numerics.MathOps;
using UOps = Internal.UnsafeNumerics.MathOps;

namespace Tests
{
    [TestFixture]
    public class Program
    {
        [Test]
        public void TestAdd()
        {
            Assert.AreEqual(Ops.DangerousAdd(100, 200), UOps.DangerousAdd(100, 200));
            Assert.AreEqual(Ops.DangerousAdd(100e3, 200), UOps.DangerousAdd(100e3, 200));
            Assert.AreEqual(Ops.DangerousAdd(100L, 200), UOps.DangerousAdd(100, 200L));
        }

        [Test]
        public void TestSubtract()
        {
            Assert.AreEqual(Ops.DangerousSubtract(100, 200), UOps.DangerousSubtract(100, 200));
            Assert.AreEqual(Ops.DangerousSubtract(100e3, 200), UOps.DangerousSubtract(100e3, 200));
            Assert.AreEqual(Ops.DangerousSubtract(100L, 200), UOps.DangerousSubtract(100, 200L));
        }

        [Test]
        public void TestMultiply()
        {
            Assert.AreEqual(Ops.DangerousMultiply(100, 200), UOps.DangerousMultiply(100, 200));
            Assert.AreEqual(Ops.DangerousMultiply(100e3, 200), UOps.DangerousMultiply(100e3, 200));
            Assert.AreEqual(Ops.DangerousMultiply(100L, 200), UOps.DangerousMultiply(100, 200L));


            Assert.AreEqual(1e200 * -1.23512e-3, UOps.DangerousMultiply(1e200, -1.23512e-3));

        }

        [Test]
        public void TestDivide()
        {
            Assert.AreEqual(Ops.DangerousDivide(100, 200), UOps.DangerousDivide(100, 200));
            Assert.AreEqual(Ops.DangerousDivide(100e3, 200), UOps.DangerousDivide(100e3, 200));
            Assert.AreEqual(Ops.DangerousDivide(100L, 200), UOps.DangerousDivide(100, 200L));
        }

        [Test]
        public void TestNegate()
        {
            Assert.AreEqual(Ops.DangerousNegate(100), UOps.DangerousNegate(100));
            Assert.AreEqual(Ops.DangerousNegate(100e3), UOps.DangerousNegate(100e3));
            Assert.AreEqual(Ops.DangerousNegate(100L), UOps.DangerousNegate(100L));
        }

        [Test]
        public void TestEquals()
        {
            Assert.AreEqual(Ops.DangerousEquals(100, 100), UOps.DangerousEquals(100, 100));
            Assert.AreEqual(Ops.DangerousEquals(100e3, 100e3 + 1e-100), UOps.DangerousEquals(100e3, 100e3 + 1e-100));
            Assert.AreEqual(Ops.DangerousEquals(100L, 100L), UOps.DangerousEquals(100L, 100L));
        }

        [Test]
        public void TestNotEquals()
        {
            Assert.AreEqual(Ops.DangerousNotEquals(100, -100), UOps.DangerousNotEquals(100, -100));
            Assert.AreEqual(Ops.DangerousNotEquals(100e3, 100e3 + 1e-10), UOps.DangerousNotEquals(100e3, 100e3 + 1e-10));
            Assert.AreEqual(Ops.DangerousNotEquals(100L, -100L), UOps.DangerousNotEquals(100L, -100L));
        }

        [Test]
        public void TestGreaterEquals()
        {
            Assert.AreEqual(Ops.DangerousGreaterEquals(100, 100), UOps.DangerousGreaterEquals(100, 100));
            Assert.AreEqual(Ops.DangerousGreaterEquals(100e3 + 1e-10, 100e3), UOps.DangerousGreaterEquals(100e3 + 1e-10, 100e3));
            Assert.AreEqual(Ops.DangerousGreaterEquals(100L, 100L), UOps.DangerousGreaterEquals(100L, 100L));
        }

        [Test]
        public void TestDangerousCast()
        {
            Assert.AreEqual(Ops.DangerousCast<double, int>(123.56), UOps.DangerousCast<double, int>(123.56));
        }

        [SuppressMessage("ReSharper", "NotAccessedField.Local")]
        private struct Test
        {
            public string S;
            public double D;

        }

        [Test]
        public void Test_UnsafeComparer()
        {
            var comp1 = UnsafeComparer.GetEqualityComparer<string>();
            Assert.IsTrue(comp1.Equals("", ""));

            var comp2 = UnsafeComparer.GetEqualityComparer<double>();
            Assert.IsTrue(comp2.Equals(0.1 + 0.2, 0.3));

            var comp3 = UnsafeComparer.GetEqualityComparer<Test>();
            Assert.IsFalse(comp3.Equals(new Test {D = 0.1d + 0.2d, S = "Str"}, new Test { D = 0.3d, S = "Str"}));
        }

        [Test]
        public void Test_UnsafeOrdering()
        {
            var comp = UnsafeComparer.GetComparer<double>();

            Assert.That(comp.Compare(0.1 + 0.2, 0.3), Is.EqualTo(0));

            var f_comp = UnsafeComparer.GetComparer<float>();

            Assert.That(f_comp.Compare(0.2f, 0.1f), Is.EqualTo(1));
        }

    }
}
