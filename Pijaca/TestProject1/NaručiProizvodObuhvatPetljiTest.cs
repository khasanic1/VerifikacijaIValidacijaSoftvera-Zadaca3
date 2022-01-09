using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pijaca;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class NaručiProizvodObuhvatPetljiTest
    {
        static Tržnica t;
        static DateTime datumOtvaranja, rok;
        static List<DateTime> datumiRokova;
        static Prodavač prodavač;
        static Proizvod janjetina;

        [TestInitialize]
        public void InicijalizacijaTržnice()
        {
            t = new Tržnica();
            datumOtvaranja = new DateTime(2021, 11, 11);
            rok = new DateTime(2021, 1, 30);
            prodavač = new Prodavač("Mujo", "šifratralala", datumOtvaranja, 25);
            janjetina = new Proizvod(Namirnica.Meso, "Janjetina", 1, new DateTime(2021, 11, 11), 23, true);
            datumiRokova = new List<DateTime>()
            {
                new DateTime(2022, 1, 22),
                new DateTime(2022, 1, 27),
                new DateTime(2022, 1, 30)
            };
        }


        [TestMethod]
        //prolazak uslova kojim se omogućava ulazak u petlju
        //jedan prolazak kroz petlju
        //dva prolaska kroz petlju
        //m prolazaka kroz petlju gdje je m<n
        // (n-1), (n), (n+1) prolazaka kroz petlju
        public void Test1()
        {

            List<Proizvod> proizvodi = new List<Proizvod>()
            {
                janjetina,
                new Proizvod(Namirnica.Voće, "Jabuka", 5, new DateTime(2022, 1, 1), 23, false),
                new Proizvod(Namirnica.Povrće, "Kupus", 7, new DateTime(2022, 1, 7), 23, true)
            };

            Štand štand = new Štand(prodavač, rok, proizvodi);


            List<int> kolicine = new List<int>()
            {
                6,
                10,
                7
            };

            t.NaručiProizvode(štand, proizvodi, kolicine, datumiRokova, false);
            Assert.AreEqual(6, štand.Proizvodi[0].OčekivanaKoličina);
            Assert.AreEqual(10, štand.Proizvodi[1].OčekivanaKoličina);
            Assert.AreEqual(7, štand.Proizvodi[2].OčekivanaKoličina);
        }
    }
}