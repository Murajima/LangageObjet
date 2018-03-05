using System;
using LangageObjCours1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLOCours1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestFractionWithDenominator0 () {
            try {
                Fraction f = new Fraction(1, 0);
                Assert.Fail();
            } catch (Exception ex){
                Assert.IsInstanceOfType(ex, typeof(FractionInitException));
            }
        }

        [TestMethod]
        public void TestFractionWithDenominator0String()
        {
            try
            {
                Fraction f = new Fraction("1/0");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FractionInitException));
            }
        }

        [TestMethod]
        public void BadStringInitializer() {
            try
            {
                Fraction f = new Fraction("BKDJBFKJWBFK");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FractionInitException));
            }
        }

        [TestMethod]
        public void Simplifier()
        {
            Fraction f = new Fraction(4, 4);
            f.Simplifier();
            Assert.AreEqual(1, f.Denominator);
            Assert.AreEqual(1, f.Numerator);
        }

        [TestMethod]
        public void FractionString() {
            Fraction f = new Fraction("1/2");
            Assert.AreEqual(1, f.Numerator);
            Assert.AreEqual(2, f.Denominator);
        }

        [TestMethod]
        public void MultiplyFraction() {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);
            Fraction test = f1 * f2;
            Assert.AreEqual(8, test.Denominator);
            Assert.AreEqual(1, test.Numerator);
        }

        [TestMethod]
        public void MultiplyFractionSimplified()
        {
            Fraction f1 = new Fraction(1, 4);
            Fraction f2 = new Fraction(4, 1);
            Fraction test = f1 * f2;
            test.Simplifier();
            Assert.AreEqual(1, test.Denominator);
            Assert.AreEqual(1, test.Numerator);
        }

        [TestMethod]
        public void AddFraction()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);
            Fraction test = f1 + f2;
            Assert.AreEqual(4, test.Denominator);
            Assert.AreEqual(3, test.Numerator);
        }

        [TestMethod]
        public void SubstractFraction()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);
            Fraction test = f1 - f2;
            Assert.AreEqual(4, test.Denominator);
            Assert.AreEqual(1, test.Numerator);
        }

        [TestMethod]
        public void InverseFraction() {
            Fraction f = new Fraction(1, 2);
            f = -f;
            Assert.AreEqual(2, f.Denominator);
            Assert.AreEqual(-1, f.Numerator);
        }

        [TestMethod]
        public void DivideFraction() {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);
            Fraction test = f1 / f2;
            Assert.AreEqual(2, test.Denominator);
            Assert.AreEqual(4, test.Numerator);
        }

        [TestMethod]
        public void DivideFractionSimplified()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 4);
            Fraction test = f1 / f2;
            test.Simplifier();
            Assert.AreEqual(1, test.Denominator);
            Assert.AreEqual(2, test.Numerator);
        }


    }
}
