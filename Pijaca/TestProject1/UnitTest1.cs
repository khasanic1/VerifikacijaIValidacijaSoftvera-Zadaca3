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
            DateTime datumOtvaranja = new DateTime(2021, 1, 2);


            int x = 0;

            for (int i=0; i<10000000; i++)
            {
                Prodavač prodavač = new Prodavač("Ime", "124", System.DateTime.Now, 10);
                t.RadSaProdavačima(prodavač, "Dodavanje", 20);

                Prodavač prodavač2 = new Prodavač("Ime", "1245", System.DateTime.Now, 10);
                t.RadSaProdavačima(prodavač2, "Izmjena", 20);
                t.RadSaProdavačima(prodavač, "Brisanje", 20);
            }

            int y = 0;
        }

    }
}
