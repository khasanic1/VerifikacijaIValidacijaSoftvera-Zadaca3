using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestTuning
    {
        [TestMethod]
        public void Test1()
        {
            Tržnica t = new Tržnica();
            DateTime datumOtvaranja = new DateTime(2021, 11, 11);

            Prodavač prodavač = new Prodavač("Ime5000000", "124", datumOtvaranja, 15);
            for (int i=0; i<10000000; i++)
            {
                t.Prodavači.Add(new Prodavač("Ime" + i, "124", datumOtvaranja, 15));
                
            }
            int x = 0;
            Prodavač prodavač2 = new Prodavač("Ime5000000", "121244", datumOtvaranja, 15);
            t.RadSaProdavačima(prodavač2, "Izmjena", 15);

            t.RadSaProdavačima(prodavač, "Brisanje", 15);
            int y = 0;

            Assert.IsTrue(true);
        }

    }
}
