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
    }
}
