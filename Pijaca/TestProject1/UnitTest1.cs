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
            for (int i=0; i<10000000; i++)
            {
                t.Prodavači.Add(new Prodavač("Ime" + i, "124", datumOtvaranja, 15));
                
            }
            int x = 0;
            for (int i = 0; i < 15; i++)
            {
                Prodavač prodavač1 = new Prodavač("Ime5000000", "121244", datumOtvaranja, 15);
                t.RadSaProdavačimaTuning2(prodavač1, "Izmjena", 15);
                Prodavač prodavač2 = new Prodavač("Ime10000001", "124611244", datumOtvaranja, 15);
                t.RadSaProdavačimaTuning2(prodavač2, "Dodavanje", 15);
                t.RadSaProdavačimaTuning2(prodavač2, "Brisanje", 15);
            }
            int y = 0;
            Assert.IsTrue(true);
        }

    }
}
