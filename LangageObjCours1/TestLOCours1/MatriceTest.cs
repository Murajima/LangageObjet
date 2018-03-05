using System;
using LangageObjCours1;
using LangageObjCours1.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLOCours1
{
    [TestClass]
    public class MatriceTest
    {
        [TestMethod]
        public void TestInitMatrice () {
            int[,] matrice = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matrice m = new Matrice(matrice);
            Assert.AreEqual(matrice, m.matrice);
        }

        [TestMethod]
        public void TestAddMatrice () {
            int[,] matrice = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matriceTest = new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } };

            Matrice m1 = new Matrice(matrice);
            Matrice m2 = new Matrice(matrice);

            Matrice mTest = m1 + m2;

            CollectionAssert.AreEqual(matriceTest, mTest.matrice);
        }

        [TestMethod]
        public void TestMatricesNotTHeSameSize() {
            int[,] matrice = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrice2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            try
            {
                Matrice m1 = new Matrice(matrice);
                Matrice m2 = new Matrice(matrice2);

                Matrice mTest = m1 + m2;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MatriceException));
            }
        }

        [TestMethod]
        public void TestMultiplyMatrice()
        {
            int[,] matrice = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matriceTest = new int[,] { { 30, 36, 42 }, { 66, 81, 96 }, { 102, 126, 150 } };

            Matrice m1 = new Matrice(matrice);
            Matrice m2 = new Matrice(matrice);

            Matrice mTest = m1 * m2;

            CollectionAssert.AreEqual(matriceTest, mTest.matrice);
        }

        [TestMethod]
        public void TestMultiplyMatriceNOK()
        {
            int[,] matrice = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrice2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] matriceTest = new int[,] { { 30, 36, 42 }, { 66, 81, 96 }, { 102, 126, 150 } };

            try
            {
                Matrice m1 = new Matrice(matrice);
                Matrice m2 = new Matrice(matrice2);

                Matrice mTest = m1 * m2;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(MatriceException));
            }
        }
    }
}
