using System;
using LangageObjCours1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLOCours1
{
    [TestClass]
    public class SpiraleTest
    {
        [TestMethod]
        public void testInitSpirale () {
            Spirale sp = new Spirale(5);
            Assert.AreEqual(25, sp.spirale.matrice[4, 4]);
            Assert.AreEqual(2, sp.spirale.matrice[2, 3]);
        }

        [TestMethod]
        public void testDistance()
        {
            Spirale sp = new Spirale(3);
            int normal = sp.getDistance(8);
            int diagonale = sp.getDistance(9);

            Assert.AreEqual(2, diagonale);
            Assert.AreEqual(1, normal);
        }
    }
}
